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

        [JsonIgnore]
        public Series ChartSeries { get; set; }

        public event EventHandler<DataChannel> OnChanged;

        public DataChannel(int source, string name = null, ChartType chart = ChartType.Sensor, double zeroPoint = 0.0, double scaling = 1.0)
        {
            Source = source;
            Name = name ?? $"Channel {source}";
            Chart = chart;
            ZeroPoint = zeroPoint;
            Scaling = scaling;
        }

        public double Raw(LogEntry entry)
        {
            return entry.Values[Source];
        }

        public virtual double Value(LogEntry entry)
        {
            return (Raw(entry) - ZeroPoint) * Scaling;
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

        public void ClearChart()
        {
            ChartSeries.Points.Clear();
            ChartSeries.LegendText = Name;
            ChartSeries.Name = Name;
        }
    }
}
