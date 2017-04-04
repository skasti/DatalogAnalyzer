﻿using System;
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

namespace DatalogAnalyzer
{
    public partial class MainForm : Form, ILogger
    {
        private DataLog CurrentLog { get; set; }

        private bool _showDelta = true;
        private bool _showSpeedAccuracy = true;
        private bool _showSpeed = true;

        private List<bool> ChannelEnabled { get; set; }
        private readonly List<Button> _channelToggleButtons = new List<Button>();

        private readonly List<ChannelConfig> _config = new List<ChannelConfig>();

        private readonly Color _enabledColor = Color.ForestGreen;
        private readonly Color _disabledColor = Color.Crimson;

        private GMapOverlay mapOverlay = null;
        private GMapMarker mapMarker = null;
        private GMapRoute mapRoute = null;

        private GMapMarker cursorMarker = null;
        private bool _cursorSticky = false;

        private PointLatLng StartFinish_A = PointLatLng.Empty;
        private PointLatLng StartFinish_B = PointLatLng.Empty;
        private PointLatLng StartFinish_C = PointLatLng.Empty;
        private PointLatLng StartFinish_D = PointLatLng.Empty;
        private GMapPolygon StartFinishLine = null;
        private GMapRoute StartFinishLineRoute = null;

        private LogAnalysis _analysis = null;

        private TimeSpan Interval = TimeSpan.FromMilliseconds(100);

        private double _graphCursorX = 0.0;

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

            LoadStartFinish();
        }

        private void LoadLog(DataLog newLog)
        {
            CurrentLog = newLog;

            InitializeChannelEnable();

            _config.Clear();

            for (int i = 0; i < CurrentLog.ValueCount; i++)
                _config.Add(new ChannelConfig(i));

            RenderTrack();
            UpdateStartFinish();
            InitializeChartSeries();

            RefreshGraph();
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

            mapRoute = new GMapRoute("Route");


            var prevLat = 0.0;
            var prevLong = 0.0;
            foreach (var logEntry in CurrentLog.Entries)
            {
                if ((logEntry.Latitude == prevLat) && (logEntry.Longitude == prevLong))
                    continue;

                if (logEntry.FixType != 3)
                    continue;

                if (logEntry.HorizontalAccuracy > 20)
                    continue;

                if (logEntry.SpeedAccuracy > 5)
                    continue;

                prevLat = logEntry.Latitude;
                prevLong = logEntry.Longitude;

                mapRoute.Points.Add(new PointLatLng(logEntry.Latitude, logEntry.Longitude));
            }

            if (mapOverlay == null)
            {
                mapOverlay = new GMapOverlay();
                gMap.Overlays.Add(mapOverlay);
            }

            mapOverlay.Clear();
            mapOverlay.Routes.Add(mapRoute);

            gMap.ZoomAndCenterRoute(mapRoute);

            mapMarker = null;
        }

        private void RefreshGraph(int startChannel = 0, int endChannel = int.MaxValue)
        {
            if (CurrentLog == null)
                return;

            var refreshSpeedChart = startChannel == 0 && endChannel == CurrentLog.ValueCount - 1;

            endChannel = Math.Min(endChannel, CurrentLog.ValueCount - 1);

            for (int i = startChannel; i <= endChannel; i++)
            {
                _config[i].ChartSeries.Points.Clear();
            }

            if (refreshSpeedChart)
            {
                speedChart.Series[0].Points.Clear();
                speedChart.Series[1].Points.Clear();
                speedChart.Series[2].Points.Clear();
            }

            var nextEntry = TimeSpan.Zero;

            foreach (var logEntry in CurrentLog.Entries)
            {
                var timeStamp = logEntry.GetTimeSpan(CurrentLog.LogStart);

                if (timeStamp < nextEntry)
                    continue;

                nextEntry = timeStamp + Interval;


                for (var i = startChannel; i <= endChannel; i++)
                {
                    if (i < logEntry.Values.Count && ChannelEnabled[i])
                    {
                        _config[i].ChartSeries.Points.AddXY(
                            logEntry.GetTimeSpan(CurrentLog.LogStart).TotalSeconds, 
                            _config[i].Process(logEntry.Values[i]));
                    }
                }

                if (refreshSpeedChart)
                {
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
                    ChartType = SeriesChartType.Line
                };

                if (channelConfig.IsTemperature)
                    tempChart.Series.Add(channelConfig.ChartSeries);
                else
                    sensorChart.Series.Add(channelConfig.ChartSeries);
            }

            speedChart.Series.Add(new Series
            {
                Name = "Speed (km/h)",
                ChartType = SeriesChartType.Line
            });

            speedChart.Series.Add(new Series
            {
                Name = "Speed Accuracy (m/s)",
                ChartType = SeriesChartType.Line
            });

            speedChart.Series.Add(new Series
            {
                Name = "Delta",
                ChartType = SeriesChartType.Line
            });
        }

        public void Info(string format, params object[] parameters)
        {
            logWindow.AppendText(string.Format($"[{DateTime.Now.ToString("yyyy-mm-dd HH:MM")}][INFO] - {format}\n", parameters));
        }

        public void Error(string format, params object[] parameters)
        {
            logWindow.AppendText(string.Format($"[{DateTime.Now.ToString("yyyy-mm-dd HH:MM")}][ERROR] - {format}\n", parameters));
        }

        private bool ToggleChannel(int channel)
        {
            ChannelEnabled[channel] = !ChannelEnabled[channel];
            RefreshGraph(channel, channel);
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
                        Text = _config[i].Name,
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
                    _channelToggleButtons[i].BackColor = _enabledColor;
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
            form.OnApply += (o, args) => RefreshGraph();
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

            if (cursorMarker == null)
            {
                cursorMarker = new GMarkerCross(newPosition);
                mapOverlay.Markers.Add(cursorMarker);
            }
            else
            {
                cursorMarker.Position = newPosition;
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

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cursorMarker == null)
                return;

            StartFinish_A = cursorMarker.Position;
            UpdateStartFinish();
        }

        private void UpdateStartFinish()
        {
            if (StartFinish_A == PointLatLng.Empty ||
                StartFinish_B == PointLatLng.Empty ||
                StartFinish_C == PointLatLng.Empty ||
                StartFinish_D == PointLatLng.Empty)
                return;

            if (StartFinishLine == null)
            {
                StartFinishLine = new GMapPolygon(new List<PointLatLng>
                    {
                        StartFinish_A,
                        StartFinish_B,
                        StartFinish_C,
                        StartFinish_D
                    },
                    "Start/Finish");

                StartFinishLineRoute = new GMapRoute(new List<PointLatLng>
                    {
                        StartFinish_A,
                        StartFinish_B
                    },
                    "Start/Finish");
                
                if (mapOverlay != null)
                    mapOverlay.Routes.Add(StartFinishLineRoute);

            }
            else
            {
                StartFinishLineRoute.Points[0] = StartFinish_A;
                StartFinishLineRoute.Points[1] = StartFinish_B;

                StartFinishLine.Points[0] = StartFinish_A;
                StartFinishLine.Points[1] = StartFinish_B;
                StartFinishLine.Points[2] = StartFinish_C;
                StartFinishLine.Points[3] = StartFinish_D;

                if (mapOverlay != null && !mapOverlay.Routes.Contains(StartFinishLineRoute))
                    mapOverlay.Routes.Add(StartFinishLineRoute);
            }
        }

        private void pointBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cursorMarker == null)
                return;

            StartFinish_B = cursorMarker.Position;
            UpdateStartFinish();
        }

        private void pointCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cursorMarker == null)
                return;

            StartFinish_C = cursorMarker.Position;
            UpdateStartFinish();
        }

        private void pointDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cursorMarker == null)
                return;

            StartFinish_D = cursorMarker.Position;
            UpdateStartFinish();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogEntry latestInside = null;
            LogEntry previousEntry = CurrentLog.Entries.First();
            _analysis = new LogAnalysis(new List<DataLog>());
            foreach (var entry in CurrentLog.Entries)
            {
                var latLong = new PointLatLng(entry.Latitude, entry.Longitude);
                if (StartFinishLine.IsInside(latLong))
                    latestInside = entry;
                else if (latestInside != null)
                {
                    _analysis.Segments.Add(CurrentLog.SubSet(previousEntry, entry));
                    previousEntry = entry;
                    latestInside = null;
                }
            }

            _analysis.Segments.Add(CurrentLog.SubSet(previousEntry, CurrentLog.Entries.Last()));

            logWindow.Clear();
            segmentsList.Items.Clear();
            var segmentIndex = 1;
            foreach (var segment in _analysis.Segments)
            {
                Log.Info("Segment {0} time: {1}", segmentIndex, segment.Length.ToString("hh\\:mm\\:ss\\.fff"));

                var lvItem = new ListViewItem();
                lvItem.Text = $"Segment {segmentIndex++}";
                lvItem.SubItems.Add(segment.Length.ToString("hh\\:mm\\:ss\\.fff"));

                segmentsList.Items.Add(lvItem);
            }
        }

        private void segmentAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadLog(_analysis.Segments[0]);
        }

        private void segmentBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadLog(_analysis.Segments[1]);
        }

        private void segmentCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadLog(_analysis.Segments[2]);
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveStartFinish();
        }

        private void SaveStartFinish()
        {
            var stream = File.Create("StartFinish.points");
            var writer = new BinaryWriter(stream);

            writer.Write(StartFinish_A.Lat);
            writer.Write(StartFinish_A.Lng);

            writer.Write(StartFinish_B.Lat);
            writer.Write(StartFinish_B.Lng);

            writer.Write(StartFinish_C.Lat);
            writer.Write(StartFinish_C.Lng);

            writer.Write(StartFinish_D.Lat);
            writer.Write(StartFinish_D.Lng);

            writer.Flush();
            stream.Close();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadStartFinish();
        }

        private void LoadStartFinish()
        {
            if (!File.Exists("StartFinish.points"))
            {
                Log.Info("Start/Finish not found!");
                return;
            }

            var stream = File.OpenRead("StartFinish.points");
            var reader = new BinaryReader(stream);

            StartFinish_A = new PointLatLng(reader.ReadDouble(), reader.ReadDouble());
            StartFinish_B = new PointLatLng(reader.ReadDouble(), reader.ReadDouble());
            StartFinish_C = new PointLatLng(reader.ReadDouble(), reader.ReadDouble());
            StartFinish_D = new PointLatLng(reader.ReadDouble(), reader.ReadDouble());

            stream.Close();

            UpdateStartFinish();
        }

        private void segmentsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (segmentsList.SelectedIndices.Count == 0)
                return;

            var selectedSegment = _analysis.Segments[segmentsList.SelectedIndices[0]];

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

            if (mapMarker == null)
            {
                mapMarker = new GMarkerGoogle(new PointLatLng(closestEntry.Latitude, closestEntry.Longitude),
                    GMarkerGoogleType.red_pushpin);
                mapOverlay.Markers.Add(mapMarker);
            }
            else
            {
                mapMarker.Position = new PointLatLng(closestEntry.Latitude, closestEntry.Longitude);
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

        private void ZoomGraphs(double viewStart, double viewEnd)
        {
            speedChart.ChartAreas[0].AxisX.ScaleView.Zoom(viewStart, viewEnd);
            tempChart.ChartAreas[0].AxisX.ScaleView.Zoom(viewStart, viewEnd);
            sensorChart.ChartAreas[0].AxisX.ScaleView.Zoom(viewStart, viewEnd);
        }

        private void segmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomGraphs(0.0, CurrentLog.Length.TotalSeconds);

            Interval = TimeSpan.FromMilliseconds(Math.Min(CurrentLog.Length.TotalSeconds, 500.0));
            RefreshGraph();
        }

        private void secToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomGraphs(0.0, 60.0);

            Interval = TimeSpan.FromMilliseconds(200);
            RefreshGraph();
        }

        private void secToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ZoomGraphs(0.0, 30.0);

            Interval = TimeSpan.FromMilliseconds(100);
            RefreshGraph();
        }

        private void secToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ZoomGraphs(0.0, 15.0);

            Interval = TimeSpan.FromMilliseconds(50);
            RefreshGraph();
        }

        private void secToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ZoomGraphs(0.0, 5.0);

            Interval = TimeSpan.Zero;
            RefreshGraph();
        }

        private void secToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ZoomGraphs(0.0, 1.0);
        }

        private void speedChart_AxisViewChanged(object sender, ViewEventArgs e)
        {
            ZoomGraphs(e.ChartArea.AxisX.ScaleView.ViewMinimum, e.ChartArea.AxisX.ScaleView.ViewMaximum);
        }

        private void tempChart_AxisViewChanged(object sender, ViewEventArgs e)
        {
            ZoomGraphs(e.ChartArea.AxisX.ScaleView.ViewMinimum, e.ChartArea.AxisX.ScaleView.ViewMaximum);
        }

        private void sensorChart_AxisViewChanged(object sender, ViewEventArgs e)
        {
            ZoomGraphs(e.ChartArea.AxisX.ScaleView.ViewMinimum, e.ChartArea.AxisX.ScaleView.ViewMaximum);
        }
    }
}
