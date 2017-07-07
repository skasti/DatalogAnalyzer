using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DatalogAnalyzer.DataChannels;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace DatalogAnalyzer
{
    public partial class MainForm : Form, ILogger
    {
        private LogSegment CurrentLog { get; set; }

        private List<LogSegment> _displayedSegments = new List<LogSegment>(); 

        private SessionAnalysis _analysis;
        private Track _track;

        private bool _showDelta = false;
        private bool _showSpeedAccuracy = false;
        private bool _showSpeed = true;

        private Dictionary<DataChannel, bool> ChannelEnabled { get; set; }
        private readonly List<Button> _channelToggleButtons = new List<Button>();

        private readonly Color _enabledColor = Color.ForestGreen;
        private readonly Color _disabledColor = Color.Crimson;

        private GMapOverlay _lineOverlay = null;
        private GMapOverlay _startFinishOverlay = null;
        private List<GMapRoute> _lineRoutes = new List<GMapRoute>();
        private GMapOverlay _accellerationOverlay = null;

        private GMapMarker _cursorMarker = null;
        private bool _cursorSticky = false;

        private TimeSpan _interval = TimeSpan.FromMilliseconds(100);

        private double _graphCursorX = 0.0;
        private double _graphViewPosition = 0.0;

        readonly TrackRepository _trackRepository = new TrackRepository();
        readonly ChannelManager _channelManager = new ChannelManager();

        public MainForm()
        {
            InitializeComponent();

            speedChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            speedChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            speedChart.ChartAreas[0].CursorY.IsUserEnabled = true;

            tempChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            tempChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            tempChart.ChartAreas[0].CursorY.IsUserEnabled = true;

            sensorChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            sensorChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            sensorChart.ChartAreas[0].CursorY.IsUserEnabled = true;

            Log.Instance = this;

            toggleDelta.BackColor = _showDelta ? _enabledColor : _disabledColor;
            toggleSpeed.BackColor = _showSpeed ? _enabledColor : _disabledColor;
            toggleSpeedAcc.BackColor = _showSpeedAccuracy ? _enabledColor : _disabledColor;

            _trackRepository.Load();

            _channelManager.OnLoaded += (sender, args) =>
            {
                InitializeChannelEnable();
                RefreshGraph();
            };
            _channelManager.OnAdded += (sender, channel) => AddChartSeries(channel);
            _channelManager.OnRemoved += (sender, channel) => RemoveChartSeries(channel);
            _channelManager.OnChannelChanged += (sender, channel) => RefreshGraph(channel);
        }

        private void RemoveChartSeries(DataChannel channel)
        {
            switch (channel.Chart)
            {
                case ChartType.Speed:
                    foreach (var chartSeries in channel.ChartSeries.Values)
                    {
                        speedChart.Series.Remove(chartSeries);
                    }
                    break;
                case ChartType.Temperature:
                    foreach (var chartSeries in channel.ChartSeries.Values)
                    {
                        tempChart.Series.Remove(chartSeries);
                    }
                    break;
                case ChartType.Sensor:
                    foreach (var chartSeries in channel.ChartSeries.Values)
                    {
                        sensorChart.Series.Remove(chartSeries);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddChartSeries(DataChannel channel)
        {
            foreach (var segment in _displayedSegments)
            {
                AddChartSeries(segment, channel);
            }
        }

        private void AddChartSeries(LogSegment displayedSegment, DataChannel channel)
        {
            if (!channel.ChartSeries.ContainsKey(displayedSegment))
            {
                var series = new Series
                {
                    Name = $"{channel.Name} ({displayedSegment.Name})",
                    LegendText = $"{channel.Name} ({displayedSegment.Name})",
                    ChartType = SeriesChartType.FastLine
                };

                channel.ChartSeries.Add(displayedSegment, series);
            }

            switch (channel.Chart)
            {
                case ChartType.Speed:
                    speedChart.Series.Add(channel.ChartSeries[displayedSegment]);
                    break;
                case ChartType.Temperature:
                    tempChart.Series.Add(channel.ChartSeries[displayedSegment]);
                    break;
                case ChartType.Sensor:
                    sensorChart.Series.Add(channel.ChartSeries[displayedSegment]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void LoadLog(LogSegment newSegment)
        {
            CurrentLog = newSegment;

            InitializeChannelEnable();

            FindTrack(CurrentLog);

            InitializeStartFinish();

            DisplaySegments(CurrentLog);

            if (_lineRoutes.Any())
                gMap.ZoomAndCenterRoute(_lineRoutes.FirstOrDefault());

            if (_track != null)
                AnalyzeCurrentLog();
            else
            {
                if (MessageBox.Show(this, text: "Can't find existing track matching this log. Do you want to create a new track?", caption: "Track not identified", buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var editor = new TrackEditor(segment: CurrentLog);
                    editor.ShowDialog(this);

                    if (editor.Saved)
                    {
                        _trackRepository.Tracks.Add(editor.Track);

                        FindTrack(CurrentLog);

                        if (_track != null)
                        {
                            InitializeStartFinish();
                            AnalyzeCurrentLog();
                        }
                    }
                }
            }
        }

        private void ClearMap()
        {
            _accellerationOverlay?.Clear();
            _lineOverlay?.Clear();
            _lineRoutes?.Clear();
        }

        private void DisplaySegments(params LogSegment[] segments)
        {
            _displayedSegments.Clear();
            _displayedSegments.AddRange(segments);

            InitializeChartSeries();
            ClearMap();

            foreach (var displayedSegment in _displayedSegments)
            {
                RenderTrack(displayedSegment, RandomColors.GetNext());
                RefreshGraph();
            }
        }

        private void InitializeStartFinish()
        {
            if (_track != null)
            {
                if (_startFinishOverlay == null)
                {
                    _startFinishOverlay = new GMapOverlay();
                    gMap.Overlays.Add(_startFinishOverlay);
                }

                var startFinishRoute = new GMapRoute(_track.StartFinishPolygon.Points.Take(2), "Start/Finish");
                startFinishRoute.Stroke = new Pen(Color.Red, 2.0f);
                _startFinishOverlay.Routes.Add(startFinishRoute);
            }
        }

        private void FindTrack(LogSegment segment)
        {
            int index = 0;
            _track = null;

            while (_track == null)
            {
                if (index >= segment.Entries.Count)
                    break;

                _track = _trackRepository.FindTrackAt(segment.Entries[index].Position());

                index += 200;
            }
        }

        private void RenderTrack(LogSegment segment, Color strokeColor)
        {
            var latitudes = segment.Entries.Select(e => e.Latitude);
            var minLat = latitudes.Min();
            var maxLat = latitudes.Max();

            var longitudes = segment.Entries.Select(e => e.Longitude);
            var minLon = longitudes.Min();
            var maxLon = longitudes.Max();

            Log.Info("Lat: {0} to {1}", minLat, maxLat);
            Log.Info("Lon: {0} to {1}", minLon, maxLon);

            gMap.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;

            var route = new GMapRoute("Route");
            route.Stroke = new Pen(strokeColor, 2.0f);
            _lineRoutes.Add(route);

            if (_lineOverlay == null)
            {
                _lineOverlay = new GMapOverlay();
                gMap.Overlays.Add(_lineOverlay);
            }

            if (_accellerationOverlay == null)
            {
                _accellerationOverlay = new GMapOverlay();
                gMap.Overlays.Add(_accellerationOverlay);
            }
            else
            {
                _accellerationOverlay.Clear();
            }

            var prevLat = 0.0;
            var prevLong = 0.0;

            GMapRoute currentAccellerationRoute = null;
            int accellerationCount = 0;
            var currentAccellerationPositive = true;

            foreach (var logEntry in segment.Entries)
            {
                if ((logEntry.Latitude == prevLat) && (logEntry.Longitude == prevLong))
                    continue;

                if (logEntry.FixType != 3)
                    continue;

                if (logEntry.SpeedAccuracy > 5)
                    continue;

                var latLng = logEntry.Position(_track);

                if (currentAccellerationRoute == null)
                {
                    if (logEntry.Accelleration > Settings.AccelleratingThreshold)
                    {
                        currentAccellerationRoute = new GMapRoute($"Accelleration {accellerationCount++}");
                        currentAccellerationRoute.Points.Add(latLng);
                        currentAccellerationRoute.Stroke = new Pen(Color.Green, 3.0f);
                        currentAccellerationPositive = true;
                    }
                    else if (logEntry.Accelleration < Settings.BrakingThreshold)
                    {
                        currentAccellerationRoute = new GMapRoute($"Accelleration {accellerationCount++}");
                        currentAccellerationRoute.Points.Add(latLng);
                        currentAccellerationRoute.Stroke = new Pen(Color.Red, 3.0f);
                        currentAccellerationPositive = false;
                    }
                }
                else if (((logEntry.Accelleration > -Settings.CoastingThreshold) && !currentAccellerationPositive) || ((logEntry.Accelleration < Settings.CoastingThreshold) && currentAccellerationPositive))
                {
                    _accellerationOverlay.Routes.Add(currentAccellerationRoute);
                    currentAccellerationRoute = null;
                }
                else
                {
                    currentAccellerationRoute.Points.Add(latLng);
                }

                prevLat = logEntry.Latitude;
                prevLong = logEntry.Longitude;

                route.Points.Add(latLng);
            }

            _lineOverlay.Routes.Add(route);

            toggleAccelerationButton.BackColor = _accellerationOverlay.IsVisibile ? _enabledColor : _disabledColor;
        }

        private void RefreshGraph(LogSegment segment, DataChannel channel)
        {
            if (segment == null)
                return;

            channel.ClearCharts();

            var nextEntry = TimeSpan.Zero;

            foreach (var logEntry in segment.Entries)
            {
                var timeStamp = logEntry.GetTimeSpan(segment.LogStart);

                if (timeStamp < nextEntry)
                    continue;

                nextEntry = timeStamp + _interval;

                if (ChannelEnabled[channel])
                {
                    channel.ChartSeries[segment].Points.AddXY(logEntry.GetTimeSpan(segment.LogStart).TotalSeconds, channel.Value(logEntry));
                }
            }
        }

        private void RefreshGraph(DataChannel channel = null)
        {
            foreach (var segment in _displayedSegments)
            {
                if (channel == null)
                    RefreshGraph(segment);
                else
                    RefreshGraph(segment, channel);
            }
        }

        private void RefreshGraph(LogSegment segment)
        {
            if (segment == null)
                return;

            foreach (var dataChannel in _channelManager.Channels)
            {
                dataChannel.ChartSeries[segment].Points.Clear();
            }

            segment.SpeedSeries.Points.Clear();
            segment.AccelerationSeries.Points.Clear();
            segment.SpeedAccuracySeries.Points.Clear();
            segment.DeltaSeries.Points.Clear();
            
            var nextEntry = TimeSpan.Zero;
            var nextAcceleration = TimeSpan.Zero;
            var accelerationInterval = TimeSpan.FromMilliseconds(500);

            foreach (var logEntry in segment.Entries)
            {
                var timeStamp = logEntry.GetTimeSpan(segment.LogStart);

                if (timeStamp < nextEntry)
                    continue;

                nextEntry = timeStamp + _interval;


                foreach (var channel in _channelManager.Channels)
                {
                    if (ChannelEnabled[channel])
                    {
                        channel.ChartSeries[segment].Points.AddXY(logEntry.GetTimeSpan(segment.LogStart).TotalSeconds, channel.Value(logEntry));
                    }
                }


                if (_showSpeed && (logEntry.SpeedAccuracy < 5.0))
                {
                    segment.SpeedSeries.Points.AddXY(logEntry.GetTimeSpan(segment.LogStart).TotalSeconds, logEntry.Speed);
                }

                if (_showSpeedAccuracy)
                {
                    segment.SpeedAccuracySeries.Points.AddXY(logEntry.GetTimeSpan(segment.LogStart).TotalSeconds, logEntry.SpeedAccuracy);
                }

                if (_showDelta)
                {
                    segment.DeltaSeries.Points.AddXY(logEntry.GetTimeSpan(segment.LogStart).TotalSeconds, Math.Min(logEntry.Delta/1000, 100));
                }

                if (timeStamp > nextAcceleration)
                {
                    nextAcceleration = timeStamp + accelerationInterval;

                    segment.AccelerationSeries.Points.AddXY(logEntry.GetTimeSpan(segment.LogStart).TotalSeconds, logEntry.Accelleration);
                }
            }
        }

        private void InitializeChartSeries()
        {
            speedChart.Series.Clear();
            tempChart.Series.Clear();
            sensorChart.Series.Clear();

            foreach (var segment in _displayedSegments)
            {
                if (segment.SpeedSeries == null)
                {
                    segment.SpeedSeries = new Series
                    {
                        Name = $"Speed (km/h) ({segment.Name})",
                        LegendText = $"Speed (km/h) ({segment.Name})",
                        ChartType = SeriesChartType.FastLine,
                        Color = Color.DarkOrange
                    };
                }

                if (segment.SpeedAccuracySeries == null)
                {
                    segment.SpeedAccuracySeries = new Series
                    {
                        Name = $"Speed Accuracy (m/s) ({segment.Name})",
                        LegendText = $"Speed Accuracy (m/s) ({segment.Name})",
                        ChartType = SeriesChartType.FastLine,
                        Color = Color.DarkBlue
                    };
                }

                if (segment.AccelerationSeries == null)
                {
                    segment.AccelerationSeries = new Series
                    {
                        Name = $"Acceleration (m/s2) ({segment.Name})",
                        LegendText = $"Acceleration (m/s2) ({segment.Name})",
                        ChartType = SeriesChartType.FastLine,
                        Color = Color.Crimson
                    };
                }

                if (segment.DeltaSeries == null)
                {
                    segment.DeltaSeries = new Series
                    {
                        Name = $"Delta ({segment.Name})",
                        LegendText = $"Delta ({segment.Name})",
                        ChartType = SeriesChartType.FastLine,
                        Color = Color.CornflowerBlue
                    };
                }

                speedChart.Series.Add(segment.SpeedSeries);
                speedChart.Series.Add(segment.SpeedAccuracySeries);
                speedChart.Series.Add(segment.AccelerationSeries);
                speedChart.Series.Add(segment.DeltaSeries);
                
                foreach (var channel in _channelManager.Channels)
                {
                    AddChartSeries(segment, channel);
                }
            }
        }

        public void Info(string format, params object[] parameters)
        {
            logWindow.AppendText(string.Format($"[{DateTime.Now.ToString("yyyy-mm-dd HH:MM")}][INFO] - {format}\n", parameters));
        }

        public void Error(string format, params object[] parameters)
        {
            logWindow.AppendText(string.Format($"[{DateTime.Now.ToString("yyyy-mm-dd HH:MM")}][ERROR] - {format}\n", parameters));
        }

        private bool ToggleChannel(DataChannel channel)
        {
            ChannelEnabled[channel] = !ChannelEnabled[channel];
            RefreshGraph(channel);
            return ChannelEnabled[channel];
        }

        private void InitializeChannelEnable()
        {
            ChannelEnabled = new Dictionary<DataChannel, bool>();

            for (int i = 0; i < _channelManager.Channels.Count; i++)
            {
                var dataChannel = _channelManager.Channels[i];
                ChannelEnabled.Add(dataChannel, true);

                if (_channelToggleButtons.Count <= i)
                {
                    var button = new Button
                    {
                        Size = new Size(50, ChannelToggleButtonTemplate.Height), Left = ChannelToggleButtonTemplate.Left + (i*56), Top = ChannelToggleButtonTemplate.Top, Anchor = ChannelToggleButtonTemplate.Anchor, Text = dataChannel.Name, BackColor = _enabledColor, ForeColor = Color.White,
                    };

                    button.Font = new Font(button.Font, FontStyle.Bold);

                    button.Click += (sender, args) => button.BackColor = ToggleChannel(dataChannel) ? _enabledColor : _disabledColor;

                    Controls.Add(button);
                    _channelToggleButtons.Add(button);
                }
                else
                {
                    _channelToggleButtons[i].BackColor = ChannelEnabled[dataChannel] ? _enabledColor : _disabledColor;
                }
            }
        }

        private void toggleDelta_Click(object sender, EventArgs e)
        {
            _showDelta = !_showDelta;
            toggleDelta.BackColor = _showDelta ? _enabledColor : _disabledColor;
            RefreshGraph();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var removableDrives = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable && d.IsReady);

            var dataLoggerCards = removableDrives.Where(d => d.RootDirectory.GetFiles("*.LOG").Any()).ToList();

            if (dataLoggerCards.Any())
                openFileDialog.InitialDirectory = dataLoggerCards.First().RootDirectory.ToString();

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    logWindow.Clear();
                    LoadLog(new LogSegment(openFileDialog.FileName));
                }
                catch (Exception ex)
                {
                    Log.Error("Failed to load log from \"{0}\" with error: {1}", openFileDialog.FileName, ex);
                }
            }
        }

        private void keepAfterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cursor = _graphCursorX;

            if (cursor < 0.1)
                return;

            var closestEntry = CurrentLog.GetClosestEntry(cursor);
            var lastEntry = CurrentLog.Entries.Last();

            LoadLog(CurrentLog.SubSet("AFTER", closestEntry, lastEntry));
        }

        private void keepBeforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cursor = _graphCursorX;

            if (cursor < 0.1)
                return;

            var closestEntry = CurrentLog.GetClosestEntry(cursor);
            var firstEntry = CurrentLog.Entries.First();

            LoadLog(CurrentLog.SubSet("BEFORE", firstEntry, closestEntry));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toggleSpeedAcc_Click(object sender, EventArgs e)
        {
            _showSpeedAccuracy = !_showSpeedAccuracy;
            toggleSpeedAcc.BackColor = _showSpeedAccuracy ? _enabledColor : _disabledColor;
            RefreshGraph();
        }

        private void toggleSpeed_Click(object sender, EventArgs e)
        {
            _showSpeed = !_showSpeed;
            toggleSpeed.BackColor = _showSpeed ? _enabledColor : _disabledColor;
            RefreshGraph();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var removableDrives = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable && d.IsReady);

            var dataLoggerCards = removableDrives.Where(d => d.RootDirectory.GetFiles("*.LOG").Any()).ToList();

            if (dataLoggerCards.Any())
                openFileDialog.InitialDirectory = dataLoggerCards.First().RootDirectory.ToString();

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    CurrentLog.Save(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    Log.Error("Failed to save log to \"{0}\" with error: {1}", saveFileDialog.FileName, ex);
                }
            }
        }

        private void MoveCursor(int x, int y)
        {
            if (CurrentLog == null)
                return;

            var newPosition = gMap.FromLocalToLatLng(x, y);

            if (_cursorMarker == null)
            {
                _cursorMarker = new GMarkerCross(newPosition);
                _lineOverlay.Markers.Add(_cursorMarker);
            }
            else
            {
                _cursorMarker.Position = newPosition;
            }
        }

        private void gMap_MouseDown(object sender, MouseEventArgs e)
        {
            _cursorSticky = true;
            MoveCursor(e.X, e.Y);
        }

        private void gMap_MouseLeave(object sender, EventArgs e)
        {
            _cursorSticky = false;
        }

        private void gMap_MouseUp(object sender, MouseEventArgs e)
        {
            _cursorSticky = false;
        }

        private void gMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_cursorSticky)
                return;

            MoveCursor(e.X, e.Y);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_track == null)
                FindTrack(CurrentLog);

            if (_track != null)
                AnalyzeCurrentLog();
        }

        private void AnalyzeCurrentLog()
        {
            if (CurrentLog == null)
                return;

            _analysis = new SessionAnalysis(CurrentLog, _track);

            logWindow.Clear();
            segmentsList.Items.Clear();
            LapContextMenu.Items.Clear();

            segmentsList.Columns.Clear();
            segmentsList.Columns.Add("Lap", 100);
            segmentsList.Columns.Add("Laptime", 100);
            segmentsList.Columns.Add("Avg. Speed", 100);
            segmentsList.Columns.Add("Top Speed", 100);
            segmentsList.Columns.Add("Min. Speed", 100);

            if (_analysis.Track.Sections != null)
            {
                for (int i = 1; i <= _analysis.Track.Sections.Count; i++)
                {
                    segmentsList.Columns.Add($"Section {i}", 100);
                    var contextMenuItem = new ToolStripMenuItem($"View Section {i}");
                    var sectionIndex = i - 1;
                    contextMenuItem.Click += (o, args) => ViewLapSection(sectionIndex);
                    LapContextMenu.Items.Add(contextMenuItem);
                }

                segmentsList.ContextMenuStrip = LapContextMenu;

                segmentsList.Columns.Add("SectionSum", 100);
            }

            if (_analysis.LeadIn != null)
                AddLap("Lead-in", _analysis.LeadIn);

            if (_analysis.LeadOut != null)
                AddLap("Lead-out", _analysis.LeadOut);

            var segmentIndex = 1;
            foreach (var lap in _analysis.Laps)
            {
                Log.Info("Lap {0} time: {1}", segmentIndex, lap.LapTime.ToString("hh\\:mm\\:ss\\.fff"));
                var text = $"Lap {segmentIndex++}";
                AddLap(text, lap);
            }
        }

        private void ViewLapSection(int sectionIndex)
        {
            if (!(segmentsList.SelectedItems[0].Tag is LapAnalysis))
                return;

            var lap = (LapAnalysis) segmentsList.SelectedItems[0].Tag;

            if (lap.Sections[sectionIndex].Segment != CurrentLog)
                DisplaySegments(lap.Sections[sectionIndex].Segment);
        }

        private void AddLap(string text, LogSegment lap)
        {
            var lvItem = new ListViewItem {Text = text};
            lvItem.SubItems.Add(lap.Length.ToString("hh\\:mm\\:ss\\.fff"));
            lvItem.Tag = lap;
            segmentsList.Items.Add(lvItem);
        }

        private void AddLap(string text, LapAnalysis lap)
        {
            var lvItem = new ListViewItem {Text = text};
            lvItem.SubItems.Add(lap.LapTime.ToString("hh\\:mm\\:ss\\.fff"));
            lvItem.SubItems.Add(lap.AverageSpeed.ToString("0.00"));
            lvItem.SubItems.Add(lap.TopSpeed.ToString("0.00"));
            lvItem.SubItems.Add(lap.LowestSpeed.ToString("0.00"));

            if ((lap.Sections != null) && lap.Sections.Any())
            {
                foreach (var sectionAnalysis in lap.Sections)
                {
                    lvItem.SubItems.Add(sectionAnalysis.SectionTime.ToString("hh\\:mm\\:ss\\.fff"));
                }

                lvItem.SubItems.Add(TimeSpan.FromSeconds(lap.Sections.Sum(s => s.SectionTime.TotalSeconds)).ToString("hh\\:mm\\:ss\\.fff"));
            }

            lvItem.Tag = lap;
            segmentsList.Items.Add(lvItem);
        }

        private void segmentsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (segmentsList.SelectedIndices.Count == 0)
                return;

            if (segmentsList.SelectedItems[0].Tag is LogSegment)
            {
                var segment = (LogSegment) segmentsList.SelectedItems[0].Tag;

                if (segment != CurrentLog)
                    DisplaySegments(segment);
            }
            else if (segmentsList.SelectedItems[0].Tag is LapAnalysis)
            {
                var lap = (LapAnalysis) segmentsList.SelectedItems[0].Tag;

                if (lap.Segment != CurrentLog)
                    DisplaySegments(lap.Segment);
            }
        }

        private void MoveMapMarker(double timeStamp)
        {
            if (!_displayedSegments.Any())
                return;

            _lineOverlay.Markers.Clear();

            foreach (var segment in _displayedSegments)
            {
                var closestEntry = segment.GetClosestEntry(timeStamp);
                var mapMarker = new GMarkerGoogle(closestEntry.Position(_track), GMarkerGoogleType.red_pushpin);
                _lineOverlay.Markers.Add(mapMarker);
            }
        }

        private void speedChart_MouseDown(object sender, MouseEventArgs e)
        {
            _graphCursorX = speedChart.ChartAreas[0].CursorX.Position;
            tempChart.ChartAreas[0].CursorX.Position = _graphCursorX;
            sensorChart.ChartAreas[0].CursorX.Position = _graphCursorX;

            var x = speedChart.ChartAreas[0].CursorX.Position;
            var y = speedChart.ChartAreas[0].CursorY.Position;

            Log.Info("Cursor: [{0},{1}]", x, y);

            MoveMapMarker(x);
        }

        private void tempChart_MouseDown(object sender, MouseEventArgs e)
        {
            _graphCursorX = tempChart.ChartAreas[0].CursorX.Position;
            speedChart.ChartAreas[0].CursorX.Position = _graphCursorX;
            sensorChart.ChartAreas[0].CursorX.Position = _graphCursorX;

            var x = tempChart.ChartAreas[0].CursorX.Position;
            var y = tempChart.ChartAreas[0].CursorY.Position;

            Log.Info("Cursor: [{0},{1}]", x, y);

            MoveMapMarker(x);
        }

        private void sensorChart_MouseDown(object sender, MouseEventArgs e)
        {
            _graphCursorX = sensorChart.ChartAreas[0].CursorX.Position;
            speedChart.ChartAreas[0].CursorX.Position = _graphCursorX;
            tempChart.ChartAreas[0].CursorX.Position = _graphCursorX;

            var x = sensorChart.ChartAreas[0].CursorX.Position;
            var y = sensorChart.ChartAreas[0].CursorY.Position;

            Log.Info("Cursor: [{0},{1}]", x, y);

            MoveMapMarker(x);
        }

        private void ZoomGraphs(double zoomLevel)
        {
            var viewStart = 0.0;
            var viewEnd = zoomLevel;

            if (_graphCursorX < zoomLevel)
            {
                viewStart = 0.0;
                viewEnd = zoomLevel;
            }
            else if (_graphCursorX > CurrentLog.Length.TotalSeconds - zoomLevel)
            {
                viewStart = CurrentLog.Length.TotalSeconds - zoomLevel;
                viewEnd = CurrentLog.Length.TotalSeconds;
            }
            else
            {
                viewStart = _graphCursorX - (zoomLevel/2);
                viewEnd = _graphCursorX + (zoomLevel/2);
            }

            speedChart.ChartAreas[0].AxisX.ScaleView.Zoom(viewStart, viewEnd);
            tempChart.ChartAreas[0].AxisX.ScaleView.Zoom(viewStart, viewEnd);
            sensorChart.ChartAreas[0].AxisX.ScaleView.Zoom(viewStart, viewEnd);
        }

        private void segmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomGraphs(CurrentLog.Length.TotalSeconds);

            _interval = TimeSpan.FromMilliseconds(Math.Min(CurrentLog.Length.TotalSeconds, 500.0));
            RefreshGraph();
        }

        private void secToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomGraphs(60.0);

            _interval = TimeSpan.FromMilliseconds(200);
            RefreshGraph();
        }

        private void secToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ZoomGraphs(30.0);

            _interval = TimeSpan.FromMilliseconds(100);
            RefreshGraph();
        }

        private void secToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ZoomGraphs(15.0);

            _interval = TimeSpan.FromMilliseconds(50);
            RefreshGraph();
        }

        private void secToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ZoomGraphs(5.0);

            _interval = TimeSpan.Zero;
            RefreshGraph();
        }

        private void secToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ZoomGraphs(1.0);

            _interval = TimeSpan.Zero;
            RefreshGraph();
        }

        private void speedChart_AxisViewChanged(object sender, ViewEventArgs e)
        {
            _graphViewPosition = e.NewPosition;
            tempChart.ChartAreas[0].AxisX.ScaleView.Position = _graphViewPosition;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Position = _graphViewPosition;
        }

        private void tempChart_AxisViewChanged(object sender, ViewEventArgs e)
        {
            _graphViewPosition = e.NewPosition;
            speedChart.ChartAreas[0].AxisX.ScaleView.Position = _graphViewPosition;
            sensorChart.ChartAreas[0].AxisX.ScaleView.Position = _graphViewPosition;
        }

        private void sensorChart_AxisViewChanged(object sender, ViewEventArgs e)
        {
            _graphViewPosition = e.NewPosition;
            tempChart.ChartAreas[0].AxisX.ScaleView.Position = _graphViewPosition;
            speedChart.ChartAreas[0].AxisX.ScaleView.Position = _graphViewPosition;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editor = new TrackEditor(segment: CurrentLog);
            editor.ShowDialog(this);
        }

        private void openLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var library = new TrackLibrary(_trackRepository, _displayedSegments.FirstOrDefault());
            library.ShowDialog(this);
        }

        private void segmentsList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (segmentsList.SelectedIndices.Count == 0)
                return;

            var selectedSegments = new List<LogSegment>();

            foreach (ListViewItem selectedItem in segmentsList.SelectedItems)
            {
                if (selectedItem.Tag is LogSegment)
                {
                    var segment = (LogSegment) selectedItem.Tag;
                    selectedSegments.Add(segment);
                }
                else if (selectedItem.Tag is LapAnalysis)
                {
                    var lap = (LapAnalysis) selectedItem.Tag;
                    selectedSegments.Add(lap.Segment);
                }
            }
            
            DisplaySegments(selectedSegments.ToArray());
        }

        private void toggleAccelerationButton_Click(object sender, EventArgs e)
        {
            _accellerationOverlay.IsVisibile = !_accellerationOverlay.IsVisibile;

            toggleAccelerationButton.BackColor = _accellerationOverlay.IsVisibile ? _enabledColor : _disabledColor;
        }

        private void newChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _channelManager.Show(this);
        }
    }
}