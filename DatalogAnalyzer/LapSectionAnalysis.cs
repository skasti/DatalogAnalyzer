using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;

namespace DatalogAnalyzer
{
    public class LapSectionAnalysis
    {
        public LapSectionAnalysis(Track track, GMapPolygon section, LogSegment segment)
        {
            Track = track;
            Section = section;
            Segment = segment;
        }

        public Track Track { get; }
        public GMapPolygon Section { get; }
        public LogSegment Segment { get; }
        public TimeSpan SectionTime => Segment.Length;
        public double Distance => Segment.Distance;
        public double AverageSpeed => Segment.AverageSpeed;
        public double TopSpeed => Segment.TopSpeed;
        public double LowestSpeed => Segment.LowestSpeed;
    }
}
