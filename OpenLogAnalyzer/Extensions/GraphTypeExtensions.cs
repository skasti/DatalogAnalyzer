using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using OpenLogger.Analysis;

namespace OpenLogAnalyzer.Extensions
{
    public static class GraphTypeExtensions
    {
        public static SeriesChartType ToSeriesChartType(this GraphType graphType)
        {
            switch (graphType)
            {
                case GraphType.FastLine:
                    return SeriesChartType.FastLine;
                case GraphType.Spline:
                    return SeriesChartType.Spline;
                case GraphType.Bar:
                    return SeriesChartType.Bar;
                case GraphType.Column:
                    return SeriesChartType.Column;
                default:
                    throw new ArgumentOutOfRangeException(nameof(graphType), graphType, null);
            }
        }
    }
}
