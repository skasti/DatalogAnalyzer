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
        private List<double> ChannelScale { get; set; }
        private List<double> ChannelZero { get; set; } 

        private TimeSpan BaseInterval { get; set; }
        private TimeSpan Interval
        {
            get { return TimeSpan.FromMilliseconds((GraphStop - GraphStart).TotalMilliseconds/1000); }
        }

        private readonly Color _enabledColor = Color.ForestGreen;
        private readonly Color _disabledColor = Color.Crimson;

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
                    CurrentLog = new DataLog(openFileDialog.FileName);

                    InitializeChannelEnable();

                    ChannelScale = new List<double>(CurrentLog.ValueCount);
                    for (int i = 0; i < CurrentLog.ValueCount; i++)
                        ChannelScale.Add(1.0);

                    ChannelScale[CurrentLog.ValueCount - 2] = 0.01;
                    ChannelScale[CurrentLog.ValueCount - 1] = 0.036;

                    ChannelZero = new List<double>(CurrentLog.ValueCount);
                    for (int i = 0; i < CurrentLog.ValueCount; i++)
                        ChannelZero.Add(0.0);

                    GraphStart = TimeSpan.Zero;
                    GraphStop = CurrentLog.Length;
                    BaseInterval = Interval;
                    RefreshGraph();
                }
                catch (Exception ex)
                {
                    Log.Error("Failed to load log from \"{0}\" with error: {1}", openFileDialog.FileName, ex);
                }
            }
        }

        private void RefreshGraph()
        {
            if (CurrentLog == null)
                return;

            chart1.Series.Clear();

            while (chart1.Series.Count < CurrentLog.ValueCount)
            {
                chart1.Series.Add(new Series
                {
                    Name = $"Channel {chart1.Series.Count + 1}",
                    ChartType = SeriesChartType.Line
                });
            }

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
                        chart1.Series[i].Points.AddXY(logEntry.GetTimeSpan(CurrentLog.LogStart).TotalSeconds,
                            logEntry.Values[i] * ChannelScale[i] - ChannelZero[i]);
                    }
                }

                if (_showDelta)
                {
                    chart1.Series.Last().Points.AddXY(logEntry.GetTimeSpan(CurrentLog.LogStart).TotalSeconds,
                        logEntry.Delta);
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
    }
}
