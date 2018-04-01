using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace OpenLogger.Analysis.Analyses
{
    public class YDistributionAnalysis: IDataAnalysis
    {
        public string Name { get; set; }
        public GraphType GraphType { get; } = GraphType.Column;
        public double MinimumY { get; set; } = -205;
        public double MaximumY { get; set; } = 205;
        public double Interval { get; set; } = 10;
        public bool ClampInput { get; set; } = true;

        public List<DataPoint> Analyze(List<DataPoint> input)
        {
            var result = new List<DataPoint>();

            for (double x = MinimumY; x < MaximumY; x += Interval)
            {
                var count = input.Count(d =>
                {
                    var y = ClampInput ? Clamp(d.Y) : d.Y;

                    return y >= x && y < x + Interval;
                });

                result.Add(new DataPoint(x, count));
            }

            return result;
        }

        public string GetDetails()
        {
            return $"{MinimumY} to {MaximumY} @ {Interval} intervals (clamping: {ClampInput})";
        }

        public string CustomLabel(DataPoint point)
        {
            return $"[{point.X} to {point.X + Interval}]";
        }

        public IDataAnalysis Copy()
        {
            return new YDistributionAnalysis
            {
                Name = Name,
                ClampInput = ClampInput,
                MinimumY = MinimumY,
                MaximumY = MaximumY,
                Interval = Interval
            };
        }

        private double Clamp(double d)
        {
            return Math.Min(MaximumY, Math.Max(MinimumY, d));
        }

        public override string ToString()
        {
            return $"{Name} {GetDetails()}";
        }
    }
}
