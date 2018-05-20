﻿using System;
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
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using OpenLogAnalyzer.Extensions;
using OpenLogAnalyzer.Transforms;
using OpenLogAnalyzer.Transforms.Editors;
using OpenLogger;
using OpenLogger.Analysis;
using OpenLogger.Analysis.Analyses;
using OpenLogger.Analysis.Extensions;
using OpenLogger.Analysis.Vehicle;
using OpenLogger.Analysis.Vehicle.Inputs;
using OpenLogger.Core;
using OpenLogger.Core.Debugging;
using OpenLogger.Core.Extensions;

namespace OpenLogAnalyzer
{
    public partial class MainForm : Form, ILogger
    {
        List<DriveInfo> _knownDrives = new List<DriveInfo>();
        private readonly TrackRepository _trackRepository = new TrackRepository();
        private Dictionary<Input, TabPage> _inputTab;
        private List<InputPage> _inputPages;
        private RenderingController _renderingController;
        private double _analysisResolution = 1.0;

        private Vehicle _currentVehicle = null;
        private SessionAnalysis _currentAnalysis = null;
        private List<SegmentAnalysis> _currentSegments = null; 
        //private readonly List<SegmentAnalysis> RenderedSegments = new List<SegmentAnalysis>(); 
        //private readonly Dictionary<SegmentAnalysis, GMapMarker> RenderedSegmentMarkers = new Dictionary<SegmentAnalysis, GMapMarker>();

        public MainForm()
        {
            InitializeComponent();
            Log.Instance = this;
            Map.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            TrackLibraryMap.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;

            _renderingController = new RenderingController();
            _renderingController.OnRoutes += RenderingControllerOnOnRoutes;
            _renderingController.OnMarkers += RenderingControllerOnOnMarkers;
        }

        private void RenderingControllerOnOnMarkers(object sender, IEnumerable<GMapMarker> gMapMarkers)
        {
            var mapOverlay = Map.Overlays.FirstOrDefault(o => o.Id == "RenderedSegments");

            if (mapOverlay == null)
            {
                mapOverlay = new GMapOverlay("RenderedSegments");
                Map.Overlays.Add(mapOverlay);
            }

            var markersToRemove = mapOverlay.Markers.Where(r => !gMapMarkers.Contains(r)).ToList();

            foreach (var marker in markersToRemove)
                mapOverlay.Markers.Remove(marker);

            foreach (var route in gMapMarkers)
            {
                if (!mapOverlay.Markers.Contains(route))
                    mapOverlay.Markers.Add(route);
            }
        }

        private void RenderingControllerOnOnRoutes(object sender, IEnumerable<GMapRoute> gMapRoutes)
        {
            var mapOverlay = Map.Overlays.FirstOrDefault(o => o.Id == "RenderedSegments");

            if (mapOverlay == null)
            {
                mapOverlay = new GMapOverlay("RenderedSegments");
                Map.Overlays.Add(mapOverlay);
            }

            var routesToRemove = mapOverlay.Routes.Where(r => !gMapRoutes.Contains(r)).ToList();

            foreach (var route in routesToRemove)
                mapOverlay.Routes.Remove(route);

            var maxDistance = 0.0;

            foreach (var route in gMapRoutes)
            {
                if (!mapOverlay.Routes.Contains(route))
                    mapOverlay.Routes.Add(route);

                if (route.Distance > maxDistance)
                    maxDistance = route.Distance;
            }

            AnalysisTrackBar.Maximum = (int) (maxDistance*1000);
            MapTrackBar.Maximum = (int)(maxDistance * 1000);
            _renderingController.MarkerDistance = MapTrackBar.Value;
            Map.ZoomAndCenterRoutes("RenderedSegments");
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
            var metadatas = libraryFiles.Select(LogFileMetadata.Load).OrderByDescending(m => m.StartTime);

            LogLibraryList.Items.Clear();

            foreach (var metadata in metadatas)
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

            var importForm = new LogImportForm(Paths.DataLoggerCard);
            importForm.OnCompleted += ImportFormOnOnCompleted;
            importForm.ShowDialog(this);
            Log.Instance = this;
        }

        private void ImportFormOnOnCompleted(object sender, List<string> list)
        {
            UpdateLogLibraryList();
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

            if (logFile.LogStart.Timestamp != selectedMetadata.StartTime)
            {
                logFile.LogStartCorrection(new LogStart(logFile.LogStart.Microseconds, (uint)selectedMetadata.StartTime.ToUnixTimestamp(), TimeSpan.Zero));
            }

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
            _currentVehicle = VehicleRepository.Get(analysis.VehicleName);

            if (_currentVehicle == null)
            {
                var selector = new VehicleSelector();

                selector.OnSelected += (sender, s) =>
                {
                    analysis.LogFile.Metadata.Bike = s;
                    analysis.LogFile.SaveMetadata();

                    _currentVehicle = VehicleRepository.Get(analysis.VehicleName);
                };

                selector.ShowDialog(this);
            }

            _renderingController.RenderSegments(analysis.Full);

            LoadMapOverlayLaps(_currentAnalysis);
            LoadAnalysisLaps(_currentAnalysis);
            CreateInputCharts();
        }

        private void LoadAnalysisLaps(SessionAnalysis analysis)
        {
            AnalysisLapList.Items.Clear();
            AnalysisLapList.Items.Add(analysis.Full.ToMapOverlayListViewItem(TimeSpan.Zero));

            if (analysis.LeadIn != null)
                AnalysisLapList.Items.Add(analysis.LeadIn.ToMapOverlayListViewItem(TimeSpan.Zero));

            AnalysisLapList.Items.AddRange(
                analysis.Laps.Select(l => l.ToMapOverlayListViewItem(analysis.LogFile.Metadata.Best)).ToArray());

            if (analysis.LeadOut != null)
                AnalysisLapList.Items.Add(analysis.LeadOut.ToMapOverlayListViewItem(TimeSpan.Zero));
        }

        private void CreateInputCharts()
        {
            AnalysisInputTabs.TabPages.Clear();
            _inputTab = new Dictionary<Input, TabPage>();
            _inputPages = new List<InputPage>();

            foreach (var input in _currentVehicle.Inputs)
            {
                AddInputTab(input);
            }
        }

        private void AddInputTab(Input input)
        {
            var tabPage = new TabPage(input.Name);
            var inputPage = new InputPage(input);
            AnalysisInputTabs.TabPages.Add(tabPage);
            
            tabPage.Controls.Add(inputPage);
            inputPage.Location = new Point(0, 0);
            inputPage.Dock = DockStyle.Fill;

            _inputTab.Add(input, tabPage);
            _inputPages.Add(inputPage);
        }

        private void LoadMapOverlayLaps(SessionAnalysis analysis)
        {
            MapOverlayLapList.Items.Clear();
            MapOverlayLapList.Items.Add(analysis.Full.ToMapOverlayListViewItem(TimeSpan.Zero));

            if (analysis.LeadIn != null)
                MapOverlayLapList.Items.Add(analysis.LeadIn.ToMapOverlayListViewItem(TimeSpan.Zero));

            MapOverlayLapList.Items.AddRange(analysis.Laps.Select(l => l.ToMapOverlayListViewItem(analysis.LogFile.Metadata.Best)).ToArray());

            if (analysis.LeadOut != null)
                MapOverlayLapList.Items.Add(analysis.LeadOut.ToMapOverlayListViewItem(TimeSpan.Zero));
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

        private void MapTrackbar_Scroll(object sender, EventArgs e)
        {
            AnalysisTrackBar.Value = MapTrackBar.Value;
            _renderingController.MarkerDistance = MapTrackBar.Value;
        }

        private void MapOverlayLapList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MapOverlayLapList.SelectedItems.Count == 0)
                return;

            var selectedItem = MapOverlayLapList.SelectedItems[0].Tag as SegmentAnalysis;
            _renderingController.RenderSegments(selectedItem);
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
            NewInputButton.Visible = MapOverlayLapList.SelectedItems.Count > 0;
        }

        private void NewInputButton_Click(object sender, EventArgs e)
        {
            if (MapOverlayLapList.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select a segment to use for raw data for new input", "Must select segment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

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

        private void AnalysisLapList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (AnalysisLapList.SelectedItems.Count == 0)
                return;

            var selectedItem = AnalysisLapList.SelectedItems[0].Tag as SegmentAnalysis;
            AnalyzeSegment(selectedItem);
        }

        private void AnalyzeSegments(SegmentAnalysis[] segments = null, Input singleInput = null)
        {
            if (segments != null)
            {
                _currentSegments = new List<SegmentAnalysis>(segments.Length);
                _currentSegments.AddRange(segments);
            }

            foreach (var inputPage in _inputPages)
            {
                if (singleInput != null && inputPage.Input != singleInput)
                    continue;

                inputPage.Render(_currentSegments);
            }
        }

        private void AnalyzeSegment(SegmentAnalysis segment = null, Input singleInput = null)
        {
            AnalyzeSegments(new[] {segment}, singleInput);
        }

        private void AnalysisShowMarkers_CheckedChanged(object sender, EventArgs e)
        {
            MapShowMarkers.Checked = AnalysisShowMarkers.Checked;
            _renderingController.RenderMarkers = MapShowMarkers.Checked;
        }

        private void MapShowMarkers_CheckedChanged(object sender, EventArgs e)
        {
            AnalysisShowMarkers.Checked = MapShowMarkers.Checked;
            _renderingController.RenderMarkers = MapShowMarkers.Checked;
        }

        private void CompareAnalysis_Click(object sender, EventArgs e)
        {
            if (AnalysisLapList.SelectedItems.Count == 0)
                return;

            var segments = AnalysisLapList.SelectedItems.Cast<ListViewItem>().Select(i => i.Tag as SegmentAnalysis).ToArray();
            AnalyzeSegments(segments);
        }

        private void AnalysisTrackBar_Scroll_1(object sender, EventArgs e)
        {
            MapTrackBar.Value = AnalysisTrackBar.Value;
            _renderingController.MarkerDistance = MapTrackBar.Value;

            var maxTime = _currentSegments.Max(s => s.Time).TotalSeconds;
            var timeMultiplier = maxTime / AnalysisTrackBar.Maximum;
            var time = AnalysisTrackBar.Value*timeMultiplier;

            foreach (var inputPage in _inputPages)
            {
                inputPage.SetCursor(AnalysisTrackBar.Value, time);
            }
        }

        private void compareMapLaps_Click(object sender, EventArgs e)
        {
            if (MapOverlayLapList.SelectedItems.Count == 0)
                return;

            var segments = AnalysisLapList.SelectedItems.Cast<ListViewItem>().Select(i => i.Tag as SegmentAnalysis).ToArray();
            _renderingController.RenderSegments(segments);
            AnalyzeSegments(segments);

            var maxTime = _currentSegments.Max(s => s.Time).TotalSeconds;
            var timeMultiplier = maxTime / AnalysisTrackBar.Maximum;
            var time = AnalysisTrackBar.Value * timeMultiplier;

            foreach (var inputPage in _inputPages)
            {
                inputPage.SetCursor(AnalysisTrackBar.Value, time);
            }
        }

        private void forkSensorEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editor = new AngleBasedForkPositionEditor();
            editor.Create(0, 0, 0, 0);
            editor.ShowDialog(this);
        }

        private void editInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedInput = _inputTab.FirstOrDefault(kv => kv.Value == AnalysisInputTabs.SelectedTab).Key;

            if (selectedInput == null)
                return;

            if (_currentSegments == null || _currentSegments.Count == 0)
                return;

            var inputPage = _inputPages.First(ip => ip.Input == selectedInput);
            var selectionStart = inputPage.XSelectionStart;
            var selectionEnd = inputPage.XSelectionEnd;

            var segment = _currentSegments.First().Segment;


            var startEntry = segment.GetClosestEntry(selectionStart);
            var endEntry = segment.GetClosestEntry(selectionEnd);

            segment = segment.SubSet(startEntry, endEntry);

            var editor = new InputConfigurator(segment, selectedInput);
            editor.OnSave += (o, input) =>
            {
                VehicleRepository.Save(_currentVehicle);

                AnalyzeSegments(singleInput: selectedInput);

                _inputTab[selectedInput].Text = selectedInput.Name;
            };

            editor.ShowDialog(this);
        }

        private void AnalysisInputTabs_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                InputTabContextMenu.Show(AnalysisInputTabs, e.Location);
            }
        }

        private void ManualImportButton_Click(object sender, EventArgs e)
        {
            if (FolderSelector.ShowDialog(this) != DialogResult.OK)
                return;

            if (!Directory.GetFiles(FolderSelector.SelectedPath, "*.LOG").Any())
            {
                MessageBox.Show(
                    "Coulld not find any LOG-files in the selected folder. Make sure you select the folder containing your LOG-files",
                    "Logs not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            var importForm = new LogImportForm(FolderSelector.SelectedPath);
            importForm.OnCompleted += ImportFormOnOnCompleted;
            importForm.ShowDialog(this);
            Log.Instance = this;
        }
    }
}
