using System;
using System.Drawing;
using System.Linq;
using GMap.NET.WindowsForms;
using OpenLogger.Analysis.Extensions;
using OpenLogger.Core;

namespace OpenLogger.Analysis
{
    public class SegmentAnalysis
    {
        public Color SegmentColor { get; } = RandomColors.GetNext();
        public string Name { get; set; }
        public LogSegment Segment { get; set; }

        public GMapRoute Route { get; }
        public double Distance => Route.Distance;
        public TimeSpan Time => Segment.Length;

        public double AverageSpeed => Distance / Time.TotalHours;
        public double TopSpeed { get; private set; }
        public double LowestSpeed { get; private set; }

        public SegmentAnalysis(LogSegment segment, string name)
        {
            Name = name;
            Segment = segment;
            Route = segment.GetRoute(name, new Pen(SegmentColor));
            var viableSpeedEntries = segment.Entries.Where(e => e.SpeedAccuracy < 5);

            if (viableSpeedEntries.Any())
            {
                TopSpeed = segment.Entries.Where(e => e.SpeedAccuracy < 5).Max(e => e.Speed);
                LowestSpeed = segment.Entries.Where(e => e.SpeedAccuracy < 5).Min(e => e.Speed);
            }
            else
            {
                TopSpeed = 0;
                LowestSpeed = 0;
            }
        }
    }
}
