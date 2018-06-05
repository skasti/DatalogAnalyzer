using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using GMap.NET.WindowsForms;
using OpenLogAnalyzer.Configuration;
using OpenLogAnalyzer.Extensions;
using OpenLogAnalyzer.Transforms.Editors;
using OpenLogger.Analysis;
using OpenLogger.Analysis.Config;
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
        private readonly RenderingController _renderingController;

        private Vehicle _currentVehicle = null;
        private SessionAnalysis _currentAnalysis = null;
        private List<SegmentAnalysis> _currentSegments = null;

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

            if (!_renderingController.RenderMarkers)
            {
                mapOverlay.Markers.Clear();
                return;
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

            MapTrackBar.Maximum = _renderingController.RenderedSegments.Max(s => s.Segment.Entries.Count);
            _renderingController.MarkerIndex = MapTrackBar.Value;
            Map.ZoomAndCenterRoutes("RenderedSegments");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadConfig();
            LoadTracks();
            _knownDrives = DriveInfo.GetDrives().Where(d => d.IsReady).ToList();
            UpdateFormText();
            AutoImport();
            UpdateLogLibraryList();
        }

        private void LoadConfig()
        {
            if (!File.Exists(Paths.LineConfigFile))
                CreateLineConfig();
            else
                AccelerationLineConfig.Instance = AccelerationLineConfig.Load(Paths.LineConfigFile);

        }

        private void CreateLineConfig()
        {
            AccelerationLineConfig.Instance = new AccelerationLineConfig
            {
                LineColor = new Dictionary<AccelerationState, Color>
                {
                    {AccelerationState.HardAcceleration, Color.Lime},
                    {AccelerationState.MediumAcceleration, Color.LimeGreen},
                    {AccelerationState.LightAcceleration, Color.Green},
                    {AccelerationState.HardBraking, Color.Red},
                    {AccelerationState.MediumBraking, Color.OrangeRed},
                    {AccelerationState.LightBraking, Color.Orange},
                    {AccelerationState.Coasting, Color.DodgerBlue}
                },
                LineWidth = new Dictionary<AccelerationState, float>
                {
                    {AccelerationState.HardAcceleration, 5.0f},
                    {AccelerationState.MediumAcceleration, 5.0f},
                    {AccelerationState.LightAcceleration, 5.0f},
                    {AccelerationState.HardBraking, 5.0f},
                    {AccelerationState.MediumBraking, 5.0f},
                    {AccelerationState.LightBraking, 5.0f},
                    {AccelerationState.Coasting, 5.0f}
                },
                LineOpacity = new Dictionary<AccelerationState, float>
                {
                    {AccelerationState.HardAcceleration, 0.9f},
                    {AccelerationState.MediumAcceleration, 0.7f},
                    {AccelerationState.LightAcceleration, 0.5f},
                    {AccelerationState.HardBraking, 0.9f},
                    {AccelerationState.MediumBraking, 0.7f},
                    {AccelerationState.LightBraking, 0.5f},
                    {AccelerationState.Coasting, 0.5f}
                },
                Threshold = new Dictionary<AccelerationState, double>
                {
                    {AccelerationState.HardAcceleration, 5.0},
                    {AccelerationState.MediumAcceleration, 2.5},
                    {AccelerationState.LightAcceleration, 0.5},
                    {AccelerationState.HardBraking, -8.0},
                    {AccelerationState.MediumBraking, -4.0},
                    {AccelerationState.LightBraking, -2.5}
                },
                Smoothing = 10
            };

            AccelerationLineConfig.Instance.Save(Paths.LineConfigFile);
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
            Text = $"OpenLog Analyzer - {RiderConfig.Instance.RiderName} (#{RiderConfig.Instance.RiderNumber})";
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
                logFile.LogStartCorrection(new LogStart(logFile.LogStart.Microseconds,
                    (uint) selectedMetadata.StartTime.ToUnixTimestamp(), TimeSpan.Zero));
            }

            var trackMatches = _trackRepository.FindTracks(logFile);

            var track = trackMatches.FirstOrDefault();

            if (track == null)
            {
                if (
                    MessageBox.Show("No track found for log. Create new track at this position?",
                        "Track not identified",
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

            LoadLapList(_currentAnalysis);
            CreateInputCharts();

            AccelerationLineConfig.OnInstance += (sender, config) => analysis.CalculateRoutes();
        }

        private void CreateInputCharts()
        {
            AnalysisInputTabs.TabPages.Clear();
            AnalysisInputTabs.TabPages.Add(AnalysisOverviewTab);

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

        private void LoadLapList(SessionAnalysis analysis)
        {
            MapOverlayLapList.Items.Clear();
            MapOverlayLapList.Items.Add(analysis.Full.ToMapOverlayListViewItem(TimeSpan.Zero));

            if (analysis.CombinedLaps != null)
                MapOverlayLapList.Items.Add(analysis.CombinedLaps.ToMapOverlayListViewItem(TimeSpan.Zero));

            if (analysis.LeadIn != null)
                MapOverlayLapList.Items.Add(analysis.LeadIn.ToMapOverlayListViewItem(TimeSpan.Zero));

            MapOverlayLapList.Items.AddRange(analysis.Laps
                .Select(l => l.ToMapOverlayListViewItem(analysis.LogFile.Metadata.Best)).ToArray());

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
                var startFinishRoute =
                    new GMapRoute(selectedTrack.StartLinePolygon.Points.Take(2), "Start/Finish")
                    {
                        Stroke =
                        {
                            Color = Color.Red,
                            Width = 1.0f
                        }
                    };
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
            //AnalysisTrackBar.Value = MapTrackBar.Value;
            _renderingController.MarkerIndex = MapTrackBar.Value;

            var markerIndex = _renderingController.MarkerIndex;
            // Gets the closest entry to the index.
            var markedEntries = _renderingController.RenderedSegments.ToDictionary(segment =>
                markerIndex < segment.Segment.Entries.Count
                    ? segment.Segment.Entries[markerIndex]
                    : segment.Segment.Entries.Last());
            var minDistance = markedEntries.Keys.Min(entry => entry.GetDistance(markedEntries[entry].Segment));
            var maxDistance = markedEntries.Keys.Max(entry => entry.GetDistance(markedEntries[entry].Segment));
            var midPoint = (minDistance + maxDistance) / 2;
            var firstEntry = markedEntries.First();
            var time = firstEntry.Key.GetTimeSpan(firstEntry.Value.Segment.LogStart).TotalSeconds;

            foreach (var inputPage in _inputPages)
            {
                inputPage.SetCursor(midPoint, time);
            }

            AnalysisOverviewChart.ChartAreas.First().CursorX.SelectionStart = minDistance;
            AnalysisOverviewChart.ChartAreas.First().CursorX.SelectionEnd = maxDistance;
            AnalysisOverviewChart.ChartAreas.First().CursorX.Position = midPoint;
        }

        private void MapOverlayLapList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MapOverlayLapList.SelectedItems.Count == 0)
                return;

            var selectedItem = MapOverlayLapList.SelectedItems[0].Tag as SegmentAnalysis;
            _renderingController.RenderSegments(selectedItem);
            AnalyzeSegment(selectedItem);
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

        private void NewInputButton_Click(object sender, EventArgs e)
        {
            if (MapOverlayLapList.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select a segment to use for raw data for new input", "Must select segment",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            var primaryYMax = 200.0;

            foreach (var segment in _currentSegments)
            {
                foreach (var input in _currentVehicle.Inputs)
                {
                    var data = input.Extract(segment.Segment, xAxisOverride: InputXAxis.Distance);
                    var series = AnalysisOverviewChart.Series.FindByName($"{input.Name} ({segment.Name})");

                    if (series == null)
                    {
                        series = new Series($"{input.Name} ({segment.Name})")
                        {
                            ChartType = input.GetSeriesChartType(),
                            BorderWidth = 2,
                            Legend = "Legend",
                            ChartArea = "Overview"
                        };

                        series.SetCustomProperty("CHECK", "☑");
                        series.SetCustomProperty("COLOR", ColorTranslator.ToHtml(series.Color));

                        AnalysisOverviewChart.Series.Add(series);
                    }

                    var dataMax = data.Max(d => d.Y);

                    if (dataMax > primaryYMax * 2)
                        series.YAxisType = AxisType.Secondary;
                    else if (dataMax > primaryYMax)
                        primaryYMax = dataMax;

                    series.Points.Update(data);
                }
            }

            foreach (var series in AnalysisOverviewChart.Series
                .Where(s => !_currentSegments.Any(segment => s.Name.Contains(segment.Name))).ToList())
            {
                AnalysisOverviewChart.Series.Remove(series);
            }
        }

        private void AnalyzeSegment(SegmentAnalysis segment = null, Input singleInput = null)
        {
            AnalyzeSegments(new[] {segment}, singleInput);
        }

        private void MapShowMarkers_CheckedChanged(object sender, EventArgs e)
        {
            _renderingController.RenderMarkers = MapShowMarkers.Checked;
        }

        private void compareMapLaps_Click(object sender, EventArgs e)
        {
            if (MapOverlayLapList.SelectedItems.Count == 0)
                return;

            var segments = MapOverlayLapList.SelectedItems.Cast<ListViewItem>().Select(i => i.Tag as SegmentAnalysis)
                .ToArray();
            _renderingController.RenderSegments(segments);
            AnalyzeSegments(segments);

            var markerIndex = _renderingController.MarkerIndex;
            // Gets the closest entry to the index.
            var markedEntries = segments.ToDictionary(segment =>
                markerIndex < segment.Segment.Entries.Count
                    ? segment.Segment.Entries[markerIndex]
                    : segment.Segment.Entries.Last());
            var minDistance = markedEntries.Keys.Min(entry => entry.GetDistance(markedEntries[entry].Segment));
            var maxDistance = markedEntries.Keys.Max(entry => entry.GetDistance(markedEntries[entry].Segment));
            var midPoint = (minDistance + maxDistance) / 2;
            var firstEntry = markedEntries.First();
            var time = firstEntry.Key.GetTimeSpan(firstEntry.Value.Segment.LogStart).TotalSeconds;

            foreach (var inputPage in _inputPages)
            {
                inputPage.SetCursor(midPoint, time);
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
                    "Couldn't find any LOG-files in the selected folder. Make sure you select the folder containing your LOG-files",
                    "Logs not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            var importForm = new LogImportForm(FolderSelector.SelectedPath);
            importForm.OnCompleted += ImportFormOnOnCompleted;
            importForm.ShowDialog(this);
            Log.Instance = this;
        }

        private void lineConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new LineConfigForm();
            form.ShowDialog(this);
        }

        private void preferencesMenuItem_Click(object sender, EventArgs e)
        {
            var configForm = new RiderConfigForm();
            configForm.ShowDialog(this);
            UpdateFormText();
        }

        private void AnalysisOverviewChart_MouseDown(object sender, MouseEventArgs e)
        {
            var clickedObject = AnalysisOverviewChart.HitTest(e.X, e.Y)?.Object;

            if (!(clickedObject is LegendItem legendItem) || e.Button != MouseButtons.Left)
                return;

            var series = AnalysisOverviewChart.Series[legendItem.SeriesName];

            if (series.GetCustomProperty("CHECK").Equals("☑"))
            {
                series.SetCustomProperty("CHECK", "☐");
                series.Color = Color.FromArgb(0, series.Color);
            }
            else
            {
                series.SetCustomProperty("CHECK", "☑");
                series.Color = ColorTranslator.FromHtml(
                    series.GetCustomProperty("COLOR"));
            }
        }
    }
}
