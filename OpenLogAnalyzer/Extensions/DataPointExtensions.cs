using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DataPoint = OpenLogger.Analysis.DataPoint;
using ChartDataPoint = System.Windows.Forms.DataVisualization.Charting.DataPoint;

namespace OpenLogAnalyzer.Extensions
{
    public static class DataPointExtensions
    {
        public static ChartDataPoint ToDataPoint(this DataPoint point)
        {
            return new ChartDataPoint(point.X, point.Y);
        }

        public static void AddRange(this DataPointCollection dataPointCollection, IEnumerable<DataPoint> newPoints)
        {
            var timer = new Stopwatch();
            timer.Start();

            foreach (var point in newPoints)
            {
                dataPointCollection.AddXY(point.X, point.Y);
                if (timer.ElapsedMilliseconds > 1000)
                {
                    Application.DoEvents();
                    timer.Restart();
                }
            }

            timer.Stop();
        }

        /// <summary>
        /// Updates a DataPointCollection with new x and y values. More efficient than clearing and re-adding data.
        /// </summary>
        /// <param name="dataPointCollection">The DataPointCollection you want to update</param>
        /// <param name="data">The new data</param>
        /// <param name="perPoint">Use this if you need to do some processing with the datapoints</param>
        /// <param name="parent">The parent control that the DataPointCollection belongs to. Used to synchronise threads</param>
        public static void Update(this DataPointCollection dataPointCollection, 
            List<DataPoint> data, 
            Action<DataPoint, ChartDataPoint> perPoint = null,
            Control parent = null)
        {
            //Remove excess datapoints
            while (dataPointCollection.Count > data.Count)
                dataPointCollection.RemoveAt(dataPointCollection.Count-1);

            for (var i = 0; i < data.Count; i++)
            {
                var point = data[i];
                var index = i;

                if (parent?.InvokeRequired ?? false)
                {
                    parent.Invoke((MethodInvoker) delegate()
                    {
                        AddOrUpdateDataPoint(dataPointCollection, perPoint, index, point);
                    });
                }
                else
                    AddOrUpdateDataPoint(dataPointCollection, perPoint, index, point);
            }
        }

        private static void AddOrUpdateDataPoint(DataPointCollection dataPointCollection, Action<DataPoint, ChartDataPoint> perPoint, int index,
            DataPoint point)
        {
            if (dataPointCollection.Count <= index)
                dataPointCollection.AddXY(point.X, point.Y);
            else
            {
                dataPointCollection[index].XValue = point.X;
                dataPointCollection[index].YValues[0] = point.Y;
            }

            perPoint?.Invoke(point, dataPointCollection[index]);
        }
    }
}
