using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLogger.Analysis;

namespace OpenLogAnalyzer.Extensions
{
    public static class DataPointExtensions
    {
        public static System.Windows.Forms.DataVisualization.Charting.DataPoint ToDataPoint(this DataPoint point)
        {
            return new System.Windows.Forms.DataVisualization.Charting.DataPoint(point.X, point.Y);
        }
    }
}
