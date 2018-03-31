using System;
using System.Collections.Generic;
using System.ComponentModel;
using OpenLogger.Analysis.Vehicle.Inputs;

namespace OpenLogger.Analysis.Analyses
{
    [DisplayName("Y delta X analysis")]
    [Description("Change in Y over X")]
    public class YDeltaXAnalysis: IDataAnalysis
    {
        public Input Input { get; set; }

        public List<DataPoint> Analyze(List<DataPoint> input)
        {
            var postAnalysis = new List<DataPoint>();

            for (int i = 1; i < input.Count; i++)
            {
                var deltaY = input[i].Y - input[i - 1].Y;
                var deltaX = input[i].X - input[i - 1].X;

                postAnalysis.Add(new DataPoint(input[i].X, Math.Max(-500, Math.Min(500, Math.Round(deltaY * (1.0 / deltaX))))));
            }

            return postAnalysis;
        }
    }
}
