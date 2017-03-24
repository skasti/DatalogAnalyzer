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
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace DatalogAnalyzer
{
    public partial class MainForm : Form, ILogger
    {
        private DataLog CurrentLog { get; set; }
        private TimeSpan GraphStart { get; set; }
        private TimeSpan GraphStop { get; set; }

        private bool _showDelta = true;
        private List<bool> ChannelEnabled { get; set; }
        private List<Button> _channelToggleButtons = new List<Button>();

        private List<ChannelConfig> _config = new List<ChannelConfig>(); 

        private TimeSpan BaseInterval { get; set; }
        private TimeSpan Interval
        {
            get { return TimeSpan.FromMilliseconds((GraphStop - GraphStart).TotalMilliseconds/1000); }
        }

        private readonly Color _enabledColor = Color.ForestGreen;
        private readonly Color _disabledColor = Color.Crimson;

        private GMapOverlay mapOverlay = null;
        private GMapMarker mapMarker = null;

        public MainForm()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            Log.Instance = this;

            BaseInterval = TimeSpan.FromMilliseconds(20);

            chart1.AxisScrollBarClicked +=Chart1OnAxisScrollBarClicked;
            toggleDelta.BackColor = _enabledColor;
        }

        private void Chart1OnAxisScrollBarClicked(object sender, ScrollBarEventArgs scrollBarEventArgs)
        {
            GraphStart = TimeSpan.FromSeconds(chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum);
            GraphStop = TimeSpan.FromSeconds(chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum);

            RefreshGraph();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void LoadLog(DataLog newLog)
        {
            CurrentLog = newLog;

            InitializeChannelEnable();

            _config.Clear();

            for (int i = 0; i < CurrentLog.ValueCount; i++)
                _config.Add(new ChannelConfig(i));

            RenderTrack();

            GraphStart = TimeSpan.Zero;
            GraphStop = CurrentLog.Length;
            BaseInterval = Interval;
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

            gMap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;

            var route = new GMapRoute("Route");


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

                route.Points.Add(new PointLatLng(logEntry.Latitude, logEntry.Longitude));
            }

            if (mapOverlay == null)
            {
                mapOverlay = new GMapOverlay();
                gMap.Overlays.Add(mapOverlay);
            }

            mapOverlay.Clear();
            mapOverlay.Routes.Add(route);

            mapMarker = null;
        }

        private void RefreshGraph()
        {
            if (CurrentLog == null)
                return;

            chart1.Series.Clear();

            foreach (var channelConfig in _config)
            {
                chart1.Series.Add(new Series
                {
                    Name = channelConfig.Name,
                    ChartType = SeriesChartType.Line
                });
            }

            chart1.Series.Add(new Series
            {
                Name = "Speed (km/h)",
                ChartType = SeriesChartType.Line
            });

            chart1.Series.Add(new Series
            {
                Name = "Speed Accuracy (m/s)",
                ChartType = SeriesChartType.Line
            });

            chart1.Series.Add(new Series
            {
                Name = "Delta",
                ChartType = SeriesChartType.Line
            });

            TimeSpan previous = TimeSpan.Zero;
            
            foreach (var logEntry in CurrentLog.Entries)
            {
                var timeStamp = logEntry.GetTimeSpan(CurrentLog.LogStart);

                if (previous > TimeSpan.Zero)
                {
                    if ((timeStamp > GraphStart) && (timeStamp < GraphStop))
                    {
                        if (timeStamp < previous + Interval)
                            continue;
                    }
                    else if (timeStamp < previous + BaseInterval)
                        continue;
                }

                previous = logEntry.GetTimeSpan(CurrentLog.LogStart);

                for (var i = 0; i < CurrentLog.ValueCount; i++)
                {
                    if (i < logEntry.Values.Count && ChannelEnabled[i])
                    {
                        chart1.Series[i].Points.AddXY(
                            logEntry.GetTimeSpan(CurrentLog.LogStart).TotalSeconds, 
                            _config[i].Process(logEntry.Values[i]));
                    }
                }

                if (logEntry.SpeedAccuracy < 5.0)
                {
                    chart1.Series[CurrentLog.ValueCount + 0].Points.AddXY(
                        logEntry.GetTimeSpan(CurrentLog.LogStart).TotalSeconds,
                        logEntry.Speed);
                }

                chart1.Series[CurrentLog.ValueCount + 1].Points.AddXY(
                    logEntry.GetTimeSpan(CurrentLog.LogStart).TotalSeconds,
                    logEntry.SpeedAccuracy);

                if (_showDelta)
                {
                    chart1.Series.Last().Points.AddXY(logEntry.GetTimeSpan(CurrentLog.LogStart).TotalSeconds,
                        Math.Min(logEntry.Delta / 1000, 100));
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chart1.MouseWheel += Chart1OnMouseWheel;
        }

        private void Chart1OnMouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;

                if (e.Delta < 0)
                {
                    double posXStart = Math.Max(chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin), 0.0);
                    double posXFinish = Math.Min(chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin), CurrentLog.Length.TotalSeconds);

                    Log.Info($"Zoom out: {posXStart} - {posXFinish}");

                    chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                }

                if (e.Delta > 0)
                {
                    double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;

                    Log.Info($"Zoom in: {posXStart} - {posXFinish}");

                    chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                }

                GraphStart = TimeSpan.FromSeconds(chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum);
                GraphStop = TimeSpan.FromSeconds(chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum);

                RefreshGraph();
            }
            catch { }
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
            RefreshGraph();
            return ChannelEnabled[channel];
        }

        private void InitializeChannelEnable()
        {
            ChannelEnabled = new List<bool>(CurrentLog.ValueCount);

            for (int i = 0; i < CurrentLog.ValueCount; i++)
            {
                ChannelEnabled.Add(true);

                if (_channelToggleButtons.Count <= i)
                {
                    var button = new Button
                    {
                        Size = new Size(50, LoadSampleButton.Height),
                        Left = LoadSampleButton.Left + LoadSampleButton.Width + 6 + (i*56),
                        Top = LoadSampleButton.Top,
                        Anchor = LoadSampleButton.Anchor,
                        Text = $"CH {i + 1}",
                        BackColor = _enabledColor,
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

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            if (CurrentLog == null)
                return;

            var x = chart1.ChartAreas[0].CursorX.Position;
            var y = chart1.ChartAreas[0].CursorY.Position;

            Log.Info("Cursor: [{0},{1}]", x, y);

            var closestEntry = CurrentLog.GetClosestEntry(x);

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

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            var form = new ChannelConfigForm(_config);
            form.OnApply += (o, args) => RefreshGraph();
            form.ShowDialog(this);
        }

        private void splitButton_Click(object sender, EventArgs e)
        {
            var cursor = chart1.ChartAreas[0].CursorX.Position;

            if (cursor < 1)
                return;

            var closestEntry = CurrentLog.GetClosestEntry(cursor);
            var lastEntry = CurrentLog.Entries.Last();

            LoadLog(CurrentLog.SubSet(closestEntry, lastEntry));
        }
    }
}
