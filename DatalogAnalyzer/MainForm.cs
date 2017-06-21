using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

namespace DatalogAnalyzer
{
    public partial class MainForm : Form, ILogger
    {
        private LogSegment CurrentSegment { get; set; }
        private SessionAnalysis _analysis;
        private Track _track;

        private bool _showDelta = false;
        private bool _showSpeedAccuracy = false;
        private bool _showSpeed = true;

        private List<bool> ChannelEnabled { get; set; }
        private readonly List<Button> _channelToggleButtons = new List<Button>();

        private readonly List<ChannelConfig> _config = new List<ChannelConfig>();

        private readonly Color _enabledColor = Color.ForestGreen;
        private readonly Color _disabledColor = Color.Crimson;

        private GMapOverlay _lineOverlay = null;
        private GMapOverlay _startFinishOverlay = null;
        private GMapMarker _mapMarker = null;
        private GMapRoute _lineRoute = null;
        private GMapOverlay _accellerationOverlay = null;

        private GMapMarker _cursorMarker = null;
        private bool _cursorSticky = false;

        private TimeSpan _interval = TimeSpan.FromMilliseconds(100);

        private double _graphCursorX = 0.0;
        private double _graphViewPosition = 0.0;

        readonly TrackRepository _trackRepository = new TrackRepository();

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
        }

        private void LoadLog(LogSegment newSegment)
        {
            CurrentSegment = newSegment;

            _config.Clear();

            for (int i = 0; i < CurrentSegment.ValueCount; i++)
                _config.Add(new ChannelConfig(i));

            InitializeChannelEnable();

            RenderTrack();
            InitializeChartSeries();
            RefreshGraph();

            FindTrack();

            InitializeStartFinish();
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

        private void FindTrack()
        {
            int index = 0;
            _track = null;

            while (_track == null)
            {
                if (index >= CurrentSegment.Entries.Count)
                    break;

                _track = _trackRepository.FindTrackAt(CurrentSegment.Entries[index].Position);

                index += 200;
            }
        }

        private void RenderTrack()
        {
            var latitudes = CurrentSegment.Entries.Select(e => e.Latitude);
            var minLat = latitudes.Min();
            var maxLat = latitudes.Max();

            var longitudes = CurrentSegment.Entries.Select(e => e.Longitude);
            var minLon = longitudes.Min();
            var maxLon = longitudes.Max();

            Log.Info("Lat: {0} to {1}", minLat, maxLat);
            Log.Info("Lon: {0} to {1}", minLon, maxLon);

            gMap.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;

            _lineRoute = new GMapRoute("Route");
            _lineRoute.Stroke = new Pen(Color.CornflowerBlue, 2.0f);

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

            foreach (var logEntry in CurrentSegment.Entries)
            {
                if ((logEntry.Latitude == prevLat) && (logEntry.Longitude == prevLong))
                    continue;

                if (logEntry.FixType != 3)
                    continue;

                if (logEntry.SpeedAccuracy > 5)
                    continue;

                if (currentAccellerationRoute == null)
                {
                    if (logEntry.Accelleration > Settings.AccelleratingThreshold)
                    {
                        currentAccellerationRoute = new GMapRoute($"Accelleration {accellerationCount++}");
                        currentAccellerationRoute.Points.Add(new PointLatLng(logEntry.Latitude, logEntry.Longitude));
                        currentAccellerationRoute.Stroke = new Pen(Color.Green, 3.0f);
                        currentAccellerationPositive = true;
                    }
                    else if (logEntry.Accelleration < Settings.BrakingThreshold)
                    {
                        currentAccellerationRoute = new GMapRoute($"Accelleration {accellerationCount++}");
                        currentAccellerationRoute.Points.Add(new PointLatLng(logEntry.Latitude, logEntry.Longitude));
                        currentAccellerationRoute.Stroke = new Pen(Color.Red, 3.0f);
                        currentAccellerationPositive = false;
                    }
                }
                else if (((logEntry.Accelleration > -Settings.CoastingThreshold) && !currentAccellerationPositive) 
                    || ((logEntry.Accelleration < Settings.CoastingThreshold) && currentAccellerationPositive))
                {
                    _accellerationOverlay.Routes.Add(currentAccellerationRoute);
                    currentAccellerationRoute = null;
                }
                else
                {
                    currentAccellerationRoute.Points.Add(new PointLatLng(logEntry.Latitude, logEntry.Longitude));
                }

                prevLat = logEntry.Latitude;
                prevLong = logEntry.Longitude;
                
                _lineRoute.Points.Add(new PointLatLng(logEntry.Latitude, logEntry.Longitude));
            }

            var directions = new GDirections();
            directions.Route = _lineRoute.Points;

            _lineOverlay.Clear();
            _lineOverlay.Routes.Add(_lineRoute);

            gMap.ZoomAndCenterRoute(_lineRoute);

            _mapMarker = null;
        }

        private void RefreshGraph(int channel = -1)
        {
            if (CurrentSegment == null)
                return;

            if (channel < -1 || channel >= CurrentSegment.ValueCount)
                throw new ArgumentOutOfRangeException("channel", "channel out of range");

            var singleChannel = channel >= 0;

            if (singleChannel)
            {
                _config[channel].ChartSeries.Points.Clear();
                _config[channel].ChartSeries.LegendText = _config[channel].Name;
                _config[channel].ChartSeries.Name = _config[channel].Name;
            }
            else
            {
                for (int i = 0; i < CurrentSegment.ValueCount; i++)
                {
                    _config[i].ChartSeries.Points.Clear();
                    _config[i].ChartSeries.LegendText = _config[i].Name;
                    _config[i].ChartSeries.Name = _config[i].Name;
                }

                speedChart.Series[0].Points.Clear();
                speedChart.Series[1].Points.Clear();
                speedChart.Series[2].Points.Clear();
                speedChart.Series[3].Points.Clear();
            }

            var nextEntry = TimeSpan.Zero;
            var nextAcceleration = TimeSpan.Zero;
            var accelerationInterval = TimeSpan.FromMilliseconds(500);
            LogEntry previousAcceleration = null;

            foreach (var logEntry in CurrentSegment.Entries)
            {
                var timeStamp = logEntry.GetTimeSpan(CurrentSegment.LogStart);

                if (timeStamp < nextEntry)
                    continue;

                nextEntry = timeStamp + _interval;

                if (singleChannel)
                {
                    if (channel < logEntry.Values.Count && ChannelEnabled[channel])
                    {
                        _config[channel].ChartSeries.Points.AddXY(
                            logEntry.GetTimeSpan(CurrentSegment.LogStart).TotalSeconds,
                            _config[channel].Process(logEntry.Values[channel]));
                    }
                }
                else
                {
                    for (var i = 0; i < CurrentSegment.ValueCount; i++)
                    {
                        if (i < logEntry.Values.Count && ChannelEnabled[i])
                        {
                            _config[i].ChartSeries.Points.AddXY(
                                logEntry.GetTimeSpan(CurrentSegment.LogStart).TotalSeconds,
                                _config[i].Process(logEntry.Values[i]));
                        }
                    }


                    if (_showSpeed && (logEntry.SpeedAccuracy < 5.0))
                    {
                        speedChart.Series[0].Points.AddXY(
                            logEntry.GetTimeSpan(CurrentSegment.LogStart).TotalSeconds,
                            logEntry.Speed);
                    }

                    if (_showSpeedAccuracy)
                    {
                        speedChart.Series[1].Points.AddXY(
                            logEntry.GetTimeSpan(CurrentSegment.LogStart).TotalSeconds,
                            logEntry.SpeedAccuracy);
                    }

                    if (_showDelta)
                    {
                        speedChart.Series[2].Points.AddXY(logEntry.GetTimeSpan(CurrentSegment.LogStart).TotalSeconds,
                            Math.Min(logEntry.Delta/1000, 100));
                    }

                    if (timeStamp > nextAcceleration)
                    {
                        nextAcceleration = timeStamp + accelerationInterval;

                        var deltaSpeed = logEntry.Speed - (previousAcceleration?.Speed ?? logEntry.Speed);
                        deltaSpeed /= 3.6;

                        var deltaTime = logEntry.GetTimeSpan(CurrentSegment.LogStart) -
                                        (previousAcceleration?.GetTimeSpan(CurrentSegment.LogStart) ?? TimeSpan.Zero);

                        var acceleration = (deltaSpeed / deltaTime.TotalSeconds); // * 0.101971621;
                        speedChart.Series[3].Points.AddXY(logEntry.GetTimeSpan(CurrentSegment.LogStart).TotalSeconds,
                            logEntry.Accelleration);

                        previousAcceleration = logEntry;
                    }
                }
            }
        }

        private void InitializeChartSeries()
        {
            speedChart.Series.Clear();
            tempChart.Series.Clear();
            sensorChart.Series.Clear();

            foreach (var channelConfig in _config)
            {
                channelConfig.ChartSeries = new Series
                {
                    Name = channelConfig.Name,
                    LegendText = channelConfig.Name,
                    ChartType = SeriesChartType.FastLine
                };

                if (channelConfig.IsTemperature)
                    tempChart.Series.Add(channelConfig.ChartSeries);
                else
                    sensorChart.Series.Add(channelConfig.ChartSeries);
            }

            speedChart.Series.Add(new Series
            {
                Color = Color.DarkOrange,
                Name = "Speed (km/h)",
                ChartType = SeriesChartType.Spline
            });

            speedChart.Series.Add(new Series
            {
                Color = Color.DarkBlue,
                Name = "Speed Accuracy (m/s)",
                ChartType = SeriesChartType.FastLine
            });

            speedChart.Series.Add(new Series
            {
                Color = Color.CornflowerBlue,
                Name = "Delta",
                ChartType = SeriesChartType.FastLine
            });

            speedChart.Series.Add(new Series
            {
                Color = Color.Red,
                Name = "Acceleration",
                ChartType = SeriesChartType.Spline
            });
        }

        public void Info(string format, params object[] parameters)
        {
            logWindow.AppendText(string.Format($"[{DateTime.Now.ToString("yyyy-mm-dd HH:MM")}][INFO] - {format}\n",
                parameters));
        }

        public void Error(string format, params object[] parameters)
        {
            logWindow.AppendText(string.Format($"[{DateTime.Now.ToString("yyyy-mm-dd HH:MM")}][ERROR] - {format}\n",
                parameters));
        }

        private bool ToggleChannel(int channel)
        {
            ChannelEnabled[channel] = !ChannelEnabled[channel];
            RefreshGraph(channel);
            return ChannelEnabled[channel];
        }

        private void InitializeChannelEnable()
        {
            ChannelEnabled = new List<bool>(CurrentSegment.ValueCount);

            for (int i = 0; i < CurrentSegment.ValueCount; i++)
            {
                ChannelEnabled.Add(false);

                if (_channelToggleButtons.Count <= i)
                {
                    var button = new Button
                    {
                        Size = new Size(50, ChannelToggleButtonTemplate.Height),
                        Left = ChannelToggleButtonTemplate.Left + (i*56),
                        Top = ChannelToggleButtonTemplate.Top,
                        Anchor = ChannelToggleButtonTemplate.Anchor,
                        Text = $"Ch {i + 1}",
                        BackColor = _disabledColor,
                        ForeColor = Color.White,
                    };

                    button.Font = new Font(button.Font, FontStyle.Bold);

                    var channel = i;
                    button.Click +=
                        (sender, args) => button.BackColor = ToggleChannel(channel) ? _enabledColor : _disabledColor;

                    Controls.Add(button);
                    _channelToggleButtons.Add(button);
                }
                else
                {
                    _channelToggleButtons[i].BackColor = ChannelEnabled[i] ? _enabledColor : _disabledColor;
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

            var closestEntry = CurrentSegment.GetClosestEntry(cursor);
            var lastEntry = CurrentSegment.Entries.Last();

            LoadLog(CurrentSegment.SubSet(closestEntry, lastEntry));
        }

        private void keepBeforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cursor = _graphCursorX;

            if (cursor < 0.1)
                return;

            var closestEntry = CurrentSegment.GetClosestEntry(cursor);
            var firstEntry = CurrentSegment.Entries.First();

            LoadLog(CurrentSegment.SubSet(firstEntry, closestEntry));
        }

        private void channelConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ChannelConfigForm(_config);
            form.OnApply += (o, args) => RefreshGraph(args.Index);
            form.ShowDialog(this);
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
                    CurrentSegment.Save(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    Log.Error("Failed to save log to \"{0}\" with error: {1}", saveFileDialog.FileName, ex);
                }
            }
        }

        private void MoveCursor(int x, int y)
        {
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
            _analysis = new SessionAnalysis(CurrentSegment, _track);

            logWindow.Clear();
            segmentsList.Items.Clear();
            LapContextMenu.Items.Clear();
            
            segmentsList.Columns.Clear();
            segmentsList.Columns.Add("Lap", 100);
            segmentsList.Columns.Add("Laptime", 100);
            segmentsList.Columns.Add("Avg. Speed", 100);
            segmentsList.Columns.Add("Top Speed", 100);
            segmentsList.Columns.Add("Min. Speed", 100);

            for (int i = 1; i <= _analysis.Track.Sections.Count; i++)
            {
                segmentsList.Columns.Add($"Section {i}", 100);
                var contextMenuItem = new ToolStripMenuItem($"View Section {i}");
                var sectionIndex = i-1;
                contextMenuItem.Click += (o, args) => ViewLapSection(sectionIndex);
                LapContextMenu.Items.Add(contextMenuItem);
            }

            segmentsList.Columns.Add("SectionSum", 100);

            AddLap("Lead-in", _analysis.LeadIn);
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
            
            var lap = (LapAnalysis)segmentsList.SelectedItems[0].Tag;

            if (lap.Sections[sectionIndex].Segment != CurrentSegment)
                LoadLog(lap.Sections[sectionIndex].Segment);
        }

        private void AddLap(string text, LogSegment lap)
        {
            var lvItem = new ListViewItem { Text = text };
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

            foreach (var sectionAnalysis in lap.Sections)
            {
                lvItem.SubItems.Add(sectionAnalysis.SectionTime.ToString("hh\\:mm\\:ss\\.fff"));
            }

            lvItem.SubItems.Add(TimeSpan.FromSeconds(lap.Sections.Sum(s => s.SectionTime.TotalSeconds)).ToString("hh\\:mm\\:ss\\.fff"));

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

                if (segment != CurrentSegment)
                    LoadLog(segment);
            }
            else if (segmentsList.SelectedItems[0].Tag is LapAnalysis)
            {
                var lap = (LapAnalysis)segmentsList.SelectedItems[0].Tag;

                if (lap.Segment != CurrentSegment)
                    LoadLog(lap.Segment);
            }
        }

        private void MoveMapMarker(double timeStamp)
        {
            if (CurrentSegment == null)
                return;

            var closestEntry = CurrentSegment.GetClosestEntry(timeStamp);

            if (_mapMarker == null)
            {
                _mapMarker = new GMarkerGoogle(new PointLatLng(closestEntry.Latitude, closestEntry.Longitude),
                    GMarkerGoogleType.red_pushpin);
                _lineOverlay.Markers.Add(_mapMarker);
            }
            else
            {
                _mapMarker.Position = new PointLatLng(closestEntry.Latitude, closestEntry.Longitude);
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
            else if (_graphCursorX > CurrentSegment.Length.TotalSeconds - zoomLevel)
            {
                viewStart = CurrentSegment.Length.TotalSeconds - zoomLevel;
                viewEnd = CurrentSegment.Length.TotalSeconds;
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
            ZoomGraphs(CurrentSegment.Length.TotalSeconds);

            _interval = TimeSpan.FromMilliseconds(Math.Min(CurrentSegment.Length.TotalSeconds, 500.0));
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
            var editor = new TrackEditor();
            editor.ShowDialog(this);
        }

        private void openLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var library = new TrackLibrary(_trackRepository);
            library.ShowDialog(this);
        }
    }
}