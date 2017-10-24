using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using OpenLogAnalyzer.Extensions;
using OpenLogger;
using OpenLogger.Analysis;
using OpenLogger.Analysis.Extensions;
using OpenLogger.Core;
using OpenLogger.Core.Debugging;

namespace OpenLogAnalyzer
{
    public partial class MainForm : Form, ILogger
    {
        List<DriveInfo> _knownDrives = new List<DriveInfo>();
        private readonly TrackRepository _trackRepository = new TrackRepository();
        private SessionAnalysis _currentAnalysis = null;
        private readonly List<SegmentAnalysis> _renderedSegments = new List<SegmentAnalysis>(); 
        private readonly Dictionary<SegmentAnalysis, GMapMarker> _renderedSegmentMarkers = new Dictionary<SegmentAnalysis, GMapMarker>();

        public MainForm()
        {
            InitializeComponent();
            Log.Instance = this;
            Map.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            TrackLibraryMap.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTracks();
            _knownDrives = DriveInfo.GetDrives().Where(d => d.IsReady).ToList();
            UpdateFormText();
            AutoImport();
            UpdateLogLibraryList();
        }

        private void LoadTracks()
        {
            _trackRepository.Load();

            UpdateTrackLibraryList();
        }

        private void UpdateTrackLibraryList()
        {
            TrackLibraryList.Items.Clear();
            TrackLibraryList.Items.AddRange(_trackRepository.Tracks.Select(track => track.ToListViewItem()).ToArray());
        }

        private void UpdateLogLibraryList()
        {
            var libraryFiles = Directory.GetFiles(Paths.LogLibrary, "*.LOG.meta");
            LogLibraryList.Items.Clear();

            foreach (var metadata in libraryFiles.Select(LogFileMetadata.Load).OrderByDescending(m => m.StartTime))
            {
                LogLibraryList.Items.Add(metadata.ToListViewItem());
            }
        }

        private void AutoImport()
        {
            if (Paths.DataLoggerCard == null)
                return;

            if (
                MessageBox.Show("OpenLogger card detected. Import new logs?", "Card detected", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Import();
        }

        private void Import()
        {
            if (Paths.DataLoggerCard == null)
            {
                MessageBox.Show(
                    "OpenLogger card not detected. Make sure you can see it in file explorer, and that it contains .LOG-files",
                    "Card not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            var importForm = new LogImportForm();
            importForm.ShowDialog(this);
            Log.Instance = this;
        }

        private void UpdateFormText()
        {
            Text = $"OpenLog Analyzer - {AnalyzerConfig.Instance.RiderName} (#{AnalyzerConfig.Instance.RiderNumber})";
        }

        private void preferencesMenuItem_Click(object sender, EventArgs e)
        {
            var configForm = new ConfigForm();
            configForm.ShowDialog(this);
            UpdateFormText();
        }

        public void Info(string format, params object[] parameters)
        {
            //MessageBox.Show(String.Format(format, parameters), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Error(string format, params object[] parameters)
        {
            MessageBox.Show(String.Format(format, parameters), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ImportFromCardButton_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void ImportTimer_Tick(object sender, EventArgs e)
        {
            var drives = DriveInfo.GetDrives().Where(d => d.IsReady).ToList();

            if (drives.Count != _knownDrives.Count)
            {
                _knownDrives = drives.ToList();
                AutoImport();
            }
        }

        private void LogLibraryList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (LogLibraryList.SelectedItems.Count == 0)
                return;

            var selectedItem = LogLibraryList.SelectedItems[0];
            var selectedMetadata = selectedItem.Tag as LogFileMetadata;

            if (selectedMetadata == null)
                return;

            var logFile = LogFile.Load(selectedMetadata.LogFilename, TimeSpan.Zero);

            var trackMatches = _trackRepository.FindTracks(logFile);

            var track = trackMatches.FirstOrDefault();

            if (track == null)
            {
                if (
                    MessageBox.Show("No track found for log. Create new track at this position?", "Track not identified",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var editor = new TrackEditor(segment: logFile);
                    editor.ShowDialog(this);

                    if (editor.Saved)
                    {
                        AddTrack(editor.Track);
                        track = editor.Track;
                    }
                }
            }

            var analysis = new SessionAnalysis(logFile, track);

            analysis.LogFile.SaveMetadata();
            analysis.LogFile.Metadata.UpdateListViewItem(selectedItem);

            SetCurrentAnalysis(analysis);

            MainTabs.SelectTab(MapTab);
        }

        private void SetCurrentAnalysis(SessionAnalysis analysis)
        {
            _currentAnalysis = analysis;

            RenderSegments(analysis.Full);

            LoadMapOverlayLaps(_currentAnalysis);

            CreateInputCharts(_currentAnalysis);
        }

        private void CreateInputCharts(SessionAnalysis currentAnalysis)
        {
            //AnalysisTab.Controls.Clear();

            var chart = new Chart();

            var chartArea = new ChartArea("ChartArea1");

            chart.ChartAreas.Add(chartArea);
            chart.Legends.Add("Legend1");

            for (int i = 0; i < currentAnalysis.LogFile.ValueCount; i++)
            {
                var series = new Series
                {
                    Name = $"Channel {i + 1}",
                    LegendText = $"Channel {i + 1}",
                    ChartType = SeriesChartType.FastLine,
                    XValueType = ChartValueType.Time
                };

                chart.Series.Add(series);
                //chart1.Series.Add(series);
            }

            
            for (int i = 6; i < 8; i++)
            {
                foreach (var entry in currentAnalysis.Full.Segment.Entries.Take(200 * 60))
                {
                    var time = entry.GetTimeStamp(currentAnalysis.LogFile.LogStart)
                        .AddHours(-currentAnalysis.LogFile.LogStart.Timestamp.Hour)
                        .AddMinutes(-currentAnalysis.LogFile.LogStart.Timestamp.Minute)
                        .AddSeconds(-currentAnalysis.LogFile.LogStart.Timestamp.Second)
                        .ToOADate();

                    chart.Series[i].Points.AddXY(time, entry.Values[i]);
                }
            }

            //chart.Series.Add(chart1.Series[0]);
            
            AnalysisTab.Controls.Add(chart);
            chart.Left = 0;
            chart.Top = 0;
            chart.Width = AnalysisTab.Width;
            chart.Height = 200;

            //chart.BeginInit();
        }

        private void LoadMapOverlayLaps(SessionAnalysis analysis)
        {
            MapOverlayLapList.Items.Clear();
            MapOverlayLapList.Items.Add(analysis.Full.ToMapOverlayListViewItem(TimeSpan.Zero));

            if (analysis.LeadIn != null)
                MapOverlayLapList.Items.Add(analysis.LeadIn.ToMapOverlayListViewItem(TimeSpan.Zero));

            MapOverlayLapList.Items.AddRange(
                analysis.Laps.Select(l => l.ToMapOverlayListViewItem(analysis.LogFile.Metadata.Best)).ToArray());

            if (analysis.LeadOut != null)
                MapOverlayLapList.Items.Add(analysis.LeadOut.ToMapOverlayListViewItem(TimeSpan.Zero));
        }

        private void RenderSegments(params SegmentAnalysis[] segments)
        {
            var mapOverlay = Map.Overlays.FirstOrDefault(o => o.Id == "RenderedSegments");

            if (mapOverlay == null)
            {
                mapOverlay = new GMapOverlay("RenderedSegments");
                Map.Overlays.Add(mapOverlay);
            }

            mapOverlay.Clear();
            _renderedSegments.Clear();
            foreach (var segment in segments)
            {
                mapOverlay.Routes.Add(segment.Route);
                _renderedSegments.Add(segment);
            }

            InitializeSegmentMarkers();

            Map.ZoomAndCenterRoute(mapOverlay.Routes.FirstOrDefault());

            AnalysisTrackbar.Maximum = _renderedSegments.Max(s => s.Segment.Entries.Count);
        }

        private void InitializeSegmentMarkers()
        {
            var mapOverlay = Map.Overlays.FirstOrDefault(o => o.Id == "RenderedSegments");

            if (mapOverlay == null)
            {
                mapOverlay = new GMapOverlay("RenderedSegments");
                Map.Overlays.Add(mapOverlay);
            }

            var markerEntry = AnalysisTrackbar.Value;

            _renderedSegmentMarkers.Clear();
            mapOverlay.Markers.Clear();
            
            foreach (var segment in _renderedSegments)
            {
                var entry = segment.Segment.Entries.Count > markerEntry
                    ? segment.Segment.Entries[markerEntry]
                    : segment.Segment.Entries.Last();

                var marker = new GMarkerGoogle(entry.GetLocation(_currentAnalysis.Track), GMarkerGoogleType.blue_small);
                _renderedSegmentMarkers.Add(segment, marker);
                mapOverlay.Markers.Add(marker);
            }
        }

        private void UpdateSegmentMarkers()
        {
            var mapOverlay = Map.Overlays.FirstOrDefault(o => o.Id == "RenderedSegments");

            if (mapOverlay == null)
            {
                mapOverlay = new GMapOverlay("RenderedSegments");
                Map.Overlays.Add(mapOverlay);
            }

            var markerEntry = AnalysisTrackbar.Value;
            
            foreach (var segment in _renderedSegments)
            {
                var entry = segment.Segment.Entries.Count > markerEntry
                    ? segment.Segment.Entries[markerEntry]
                    : segment.Segment.Entries.Last();

                var marker = _renderedSegmentMarkers[segment];
                marker.Position = entry.GetLocation(_currentAnalysis.Track);
            }
        }

        private void TrackLibraryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TrackLibraryList.SelectedIndices.Count == 0)
                return;

            var selectedTrack = _trackRepository.Tracks[TrackLibraryList.SelectedIndices[0]];

            if (selectedTrack.Area != null)
            {
                var areaRoute = new GMapRoute(selectedTrack.Area.Points, "Area");
                TrackLibraryMap.ZoomAndCenterRoute(areaRoute);
            }

            if (selectedTrack.StartLinePolygon != null)
            {
                var startFinishRoute = new GMapRoute(selectedTrack.StartLinePolygon.Points.Take(2), "Start/Finish");
                startFinishRoute.Stroke.Color = Color.Red;
                startFinishRoute.Stroke.Width = 1.0f;
                var overlay = TrackLibraryMap.Overlays.FirstOrDefault();

                if (overlay == null)
                {
                    overlay = new GMapOverlay("TrackLibrary");
                    TrackLibraryMap.Overlays.Add(overlay);
                }

                overlay.Routes.Clear();
                overlay.Routes.Add(startFinishRoute);
            }
        }

        private void AnalysisTrackbar_Scroll(object sender, EventArgs e)
        {
            UpdateSegmentMarkers();
        }

        private void MapOverlayLapList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MapOverlayLapList.SelectedItems.Count == 0)
                return;

            var selectedItem = MapOverlayLapList.SelectedItems[0].Tag as SegmentAnalysis;
            RenderSegments(selectedItem);
        }

        private void NewTrackButton_Click(object sender, EventArgs e)
        {
            var segment = _currentAnalysis?.Full?.Segment;

            var editor = new TrackEditor(segment: segment);
            editor.ShowDialog(this);

            if (editor.Saved)
            {
                AddTrack(editor.Track);
                MainTabs.SelectTab(TrackLibraryTab);
            }
        }

        private void AddTrack(Track track)
        {
            _trackRepository.Add(track);
            UpdateTrackLibraryList();
        }

        private void MapOverlayLapList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MapOverlayLapList.SelectedItems.Count > 0)
                NewInputButton.Visible = true;
        }

        private void NewInputButton_Click(object sender, EventArgs e)
        {
            var segment = MapOverlayLapList.SelectedItems[0].Tag as SegmentAnalysis;

            if (segment == null)
                return;

            var editor = new InputConfigurator(segment.Segment);
            editor.ShowDialog(this);
        }

        private void TrackLibraryList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (TrackLibraryList.SelectedIndices.Count == 0)
                return;

            var segment = _currentAnalysis?.Full?.Segment;
            var selectedTrack = _trackRepository.Tracks[TrackLibraryList.SelectedIndices[0]];

            var editor = new TrackEditor(track: selectedTrack, segment: segment);
            editor.ShowDialog(this);

            if (editor.Saved)
            {
                UpdateTrackLibraryList();
            }
        }
    }
}
