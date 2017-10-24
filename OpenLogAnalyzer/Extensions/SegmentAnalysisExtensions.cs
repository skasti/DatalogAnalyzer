using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenLogger.Analysis;

namespace OpenLogAnalyzer.Extensions
{
    public static class SegmentAnalysisExtensions
    {
        public static ListViewItem ToMapOverlayListViewItem(this SegmentAnalysis segment, TimeSpan bestTime)
        {
            
            var item = new ListViewItem(segment.Name);

            if (bestTime != TimeSpan.Zero)
            {
                var diff = segment.Time - bestTime;
                item.SubItems.Add($"{segment.Time.ToString("g")} ( +{diff.TotalSeconds.ToString("0.00")}s )");
            }
            else
            {
                item.SubItems.Add($"{segment.Time.ToString("g")}");
            }

            item.SubItems.Add(segment.TopSpeed.ToString("0.00"));
            item.SubItems.Add(segment.LowestSpeed.ToString("0.00"));
            item.SubItems.Add(segment.AverageSpeed.ToString("0.00"));

            item.Tag = segment;

            return item;
        }
    }
}
