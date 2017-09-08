using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;

namespace DatalogAnalyzer.DataChannels
{
    public class DataChannel
    {
        public string Name { get; set; }
        public ChartType Chart { get; set; }
        public int Source { get; set; }
        public double ZeroPoint { get; set; }
        public double Scaling { get; set; }
        public int IconIndex { get; set; } = 0;

        public int Smoothing
        {
            get => Buffer.Length;
            set => Buffer = new double[Math.Max(value, 1)];
        }

        private double[] Buffer = new double[10];
        private int bufferIndex = 0;

        [JsonIgnore]
        public Dictionary<LogSegment, Series> ChartSeries { get; set; } = new Dictionary<LogSegment, Series>();

        public event EventHandler<DataChannel> OnChanged;

        public DataChannel(int source, string name = null, ChartType chart = ChartType.Sensor, double zeroPoint = 0.0, double scaling = 1.0, int smoothing = 10)
        {
            Source = source;
            Name = name ?? $"Channel {source}";
            Chart = chart;
            ZeroPoint = zeroPoint;
            Scaling = scaling;
            Smoothing = smoothing;
        }

        public double Raw(LogEntry entry)
        {
            return entry.Values[Source];
        }

        public virtual double Value(LogEntry entry)
        {
            Buffer[bufferIndex++] = (Raw(entry) - ZeroPoint) * Scaling;

            if (bufferIndex >= Buffer.Length)
                bufferIndex = 0;

            return Buffer.Average();
        }

        public virtual DataChannelEditor CreateEditor()
        {
            var editor = new DataChannelEditor(this);
            editor.OnSave += InvokeOnChanged;
            return editor;
        }

        protected void InvokeOnChanged(object sender, EventArgs e)
        {
            OnChanged?.Invoke(sender, this);
        }

        public void ClearCharts()
        {
            foreach (var chartSeries in ChartSeries)
            {
                chartSeries.Value.Points.Clear();
                chartSeries.Value.LegendText = Name;
                chartSeries.Value.Name = Name;
            }
        }
    }
}
