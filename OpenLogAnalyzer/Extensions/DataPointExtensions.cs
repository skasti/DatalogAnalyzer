using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using DataPoint = OpenLogger.Analysis.DataPoint;

namespace OpenLogAnalyzer.Extensions
{
    public static class DataPointExtensions
    {
        public static System.Windows.Forms.DataVisualization.Charting.DataPoint ToDataPoint(this DataPoint point)
        {
            return new System.Windows.Forms.DataVisualization.Charting.DataPoint(point.X, point.Y);
        }

        public static void AddRange(this DataPointCollection dataPointCollection, IEnumerable<DataPoint> newPoints)
        {
            foreach (var point in newPoints)
                dataPointCollection.AddXY(point.X, point.Y);
        }
    }
}
