using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace OpenLogger.Analysis.Analyses
{
    public class YDistributionAnalysis: IDataAnalysis
    {
        public string Name { get; set; }
        public double MinimumY { get; set; } = -200;
        public double MaximumY { get; set; } = 200;
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

        private double Clamp(double d)
        {
            return Math.Min(MaximumY, Math.Max(MinimumY, d));
        }
    }
}
