using System;
using System.Collections.Generic;
using System.ComponentModel;
using OpenLogger.Analysis.Vehicle.Inputs;

namespace OpenLogger.Analysis.Analyses
{
    public class YDeltaXAnalysis: IDataAnalysis
    {
        public string Name { get; set; }
        public bool ClampValue { get; set; }
        public double ClampMinimum { get; set; } = double.MinValue;
        public double ClampMaximum { get; set; } = double.MaxValue;
        public GraphType GraphType { get; } = GraphType.FastLine;

        public List<DataPoint> Analyze(List<DataPoint> input)
        {
            var postAnalysis = new List<DataPoint>();

            for (int i = 1; i < input.Count; i++)
            {
                var deltaY = input[i].Y - input[i - 1].Y;
                var deltaX = input[i].X - input[i - 1].X;

                var value = deltaY*(1.0/deltaX);

                postAnalysis.Add(new DataPoint(input[i].X, ClampValue ? Clamp(value) : value));
            }

            return postAnalysis;
        }

        private double Clamp(double value)
        {
            return Math.Min(ClampMaximum, Math.Max(ClampMinimum, value));
        }

        public string GetDetails()
        {
            return ClampValue ? $"clamped between {ClampMinimum} and {ClampMaximum}" : "";
        }

        public string CustomLabel(DataPoint point)
        {
            return null;
        }

        public IDataAnalysis Copy()
        {
            return new YDeltaXAnalysis
            {
                Name = Name,
                ClampValue = ClampValue,
                ClampMinimum = ClampMinimum,
                ClampMaximum = ClampMaximum
            };
        }

        public override string ToString()
        {
            return $"{Name} ({GetDetails()})";
        }
    }
}
