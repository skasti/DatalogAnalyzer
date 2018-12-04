using System;
using System.Collections.Generic;
using OpenLogger.Core;

namespace OpenLogger.Analysis.Metadata
{
    public class SegmentMetadata
    {
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public double Distance { get; set; }
        public double LowestSpeed { get; set; }
        public double TopSpeed { get; set; }
        public double AverageSpeed { get; set; }
        public IEnumerable<GPSPosition> Line { get; set; }
        public LogStart LogStart { get; set; }
    }
}
