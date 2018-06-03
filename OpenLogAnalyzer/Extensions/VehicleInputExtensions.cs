using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using OpenLogger.Analysis;
using OpenLogger.Analysis.Vehicle.Inputs;

namespace OpenLogAnalyzer.Extensions
{
    public static class VehicleInputExtensions
    {
        public static Series CreateSeries(this Input input, SegmentAnalysis analysis)
        {
            var series = new Series(analysis.Name)
            {
                LegendText = analysis.Name,
                ChartType = input.GetSeriesChartType(),
                Color = analysis.SegmentColor,
                BorderWidth = 2
            };

            return series;
        }

        public static SeriesChartType GetSeriesChartType(this Input input)
        {
            switch (input.GraphType)
            {
                case GraphType.FastLine:
                    return SeriesChartType.FastLine;
                case GraphType.Spline:
                    return SeriesChartType.Spline;
                case GraphType.Bar:
                    return SeriesChartType.Bar;
                default:
                    return SeriesChartType.FastLine;
            }
        }
    }
}
