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
        private DataLog CurrentLog { get; set; }
        private LogAnalysis _analysis;
        private Track _track;

        private bool _showDelta = true;
        private bool _showSpeedAccuracy = true;
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

            toggleDelta.BackColor = _enabledColor;
            toggleSpeed.BackColor = _enabledColor;
            toggleSpeedAcc.BackColor = _enabledColor;

            _trackRepository.Load();
        }

        private void LoadLog(DataLog newLog)
        {
            CurrentLog = newLog;

            _config.Clear();

            for (int i = 0; i < CurrentLog.ValueCount; i++)
                _config.Add(new ChannelConfig(i));

            InitializeChannelEnable();

            RenderTrack();
            InitializeChartSeries();
            RefreshGraph();

            _track = _trackRepository.FindTrackAt(CurrentLog.Entries[CurrentLog.Entries.Count/2].Position);

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

        private void RenderTrack()
        {
            var latitudes = CurrentLog.Entries.Select(e => e.Latitude);
            var minLat = latitudes.Min();
            var maxLat = latitudes.Max();

            var longitudes = CurrentLog.Entries.Select(e => e.Longitude);
            var minLon = longitudes.Min();
            var maxLon = longitudes.Max();

            Log.Info("Lat: {0} to {1}", minLat, maxLat);
            Log.Info("Lon: {0} to {1}", minLon, maxLon);

            gMap.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;

            _lineRoute = new GMapRoute("Route");
            _lineRoute.Stroke = new Pen(Color.CornflowerBlue, 2.0f);

            var prevLat = 0.0;
            var prevLong = 0.0;
            foreach (var logEntry in CurrentLog.Entries)
            {
                if ((logEntry.Latitude == prevLat) && (logEntry.Longitude == prevLong))
                    continue;

                if (logEntry.FixType != 3)
                    continue;

                if (logEntry.SpeedAccuracy > 5)
                    continue;

                prevLat = logEntry.Latitude;
                prevLong = logEntry.Longitude;

                _lineRoute.Points.Add(new PointLatLng(logEntry.Latitude, logEntry.Longitude));
            }

            if (_lineOverlay == null)
            {
                _lineOverlay = new GMapOverlay();
                gMap.Overlays.Add(_lineOverlay);
            }

            _lineOverlay.Clear();
            _lineOverlay.Routes.Add(_lineRoute);

            gMap.ZoomAndCenterRoute(_lineRoute);

            _mapMarker = null;
        }

        private void RefreshGraph(int channel = -1)
        {
            if (CurrentLog == null)
                return;

            if (channel < -1 || channel >= CurrentLog.ValueCount)
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
                for (int i = 0; i < CurrentLog.ValueCount; i++)
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
            var accelerationInterval = TimeSpan.FromMilliseconds(100);
            LogEntry previousAcceleration = null;

            foreach (var logEntry in CurrentLog.Entries)
            {
                var timeStamp = logEntry.GetTimeSpan(CurrentLog.LogStart);

                if (timeStamp < nextEntry)
                    continue;

                nextEntry = timeStamp + _interval;

                if (singleChannel)
                {
                    if (channel < logEntry.Values.Count && ChannelEnabled[channel])
                    {
                        _config[channel].ChartSeries.Points.AddXY(
                            logEntry.GetTimeSpan(CurrentLog.LogStart).TotalSeconds,
                            _config[channel].Process(logEntry.Values[channel]));
                    }
                }
                else
                {
                    for (var i = 0; i < CurrentLog.ValueCount; i++)
                    {
                        if (i < logEntry.Values.Count && ChannelEnabled[i])
                        {
                            _config[i].ChartSeries.Points.AddXY(
                                logEntry.GetTimeSpan(CurrentLog.LogStart).TotalSeconds,
                                _config[i].Process(logEntry.Values[i]));
                        }
                    }


                    if (_showSpeed && (logEntry.SpeedAccuracy < 5.0))
                    {
                        speedChart.Series[0].Points.AddXY(
                            logEntry.GetTimeSpan(CurrentLog.LogStart).TotalSeconds,
                            logEntry.Speed);
                    }

                    if (_showSpeedAccuracy)
                    {
                        speedChart.Series[1].Points.AddXY(
                            logEntry.GetTimeSpan(CurrentLog.LogStart).TotalSeconds,
                            logEntry.SpeedAccuracy);
                    }

                    if (_showDelta)
                    {
                        speedChart.Series[2].Points.AddXY(logEntry.GetTimeSpan(CurrentLog.LogStart).TotalSeconds,
                            Math.Min(logEntry.Delta/1000, 100));
                    }

                    if (timeStamp > nextAcceleration)
                    {
                        nextAcceleration = timeStamp + accelerationInterval;

                        var deltaSpeed = logEntry.Speed - (previousAcceleration?.Speed ?? logEntry.Speed);
                        deltaSpeed /= 3.6;

                        var deltaTime = logEntry.GetTimeSpan(CurrentLog.LogStart) -
                                        (previousAcceleration?.GetTimeSpan(CurrentLog.LogStart) ?? TimeSpan.Zero);

                        var acceleration = (deltaSpeed/deltaTime.TotalSeconds); // * 0.101971621;
                        speedChart.Series[3].Points.AddXY(logEntry.GetTimeSpan(CurrentLog.LogStart).TotalSeconds,
                            acceleration);

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
            ChannelEnabled = new List<bool>(CurrentLog.ValueCount);

            for (int i = 0; i < CurrentLog.ValueCount; i++)
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
                    LoadLog(new DataLog(openFileDialog.FileName));
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

            LoadLog(CurrentLog.SubSet(closestEntry, lastEntry));
        }

        private void keepBeforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cursor = _graphCursorX;

            if (cursor < 0.1)
                return;

            var closestEntry = CurrentLog.GetClosestEntry(cursor);
            var firstEntry = CurrentLog.Entries.First();

            LoadLog(CurrentLog.SubSet(firstEntry, closestEntry));
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
            _analysis = new LogAnalysis(CurrentLog, _track);

            logWindow.Clear();
            segmentsList.Items.Clear();
            var segmentIndex = 1;
            foreach (var segment in _analysis.Laps)
            {
                Log.Info("Segment {0} time: {1}", segmentIndex, segment.Length.ToString("hh\\:mm\\:ss\\.fff"));

                var lvItem = new ListViewItem();
                lvItem.Text = $"Segment {segmentIndex++}";
                lvItem.SubItems.Add(segment.Length.ToString("hh\\:mm\\:ss\\.fff"));

                segmentsList.Items.Add(lvItem);
            }
        }

        private void segmentsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (segmentsList.SelectedIndices.Count == 0)
                return;

            var selectedSegment = _analysis.Laps[segmentsList.SelectedIndices[0]];

            if (selectedSegment != CurrentLog)
            {
                LoadLog(selectedSegment);
            }
        }

        private void MoveMapMarker(double timeStamp)
        {
            if (CurrentLog == null)
                return;

            var closestEntry = CurrentLog.GetClosestEntry(timeStamp);

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