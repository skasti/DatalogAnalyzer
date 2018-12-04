using System.Collections.Generic;

namespace OpenLogger.Analysis.Metadata
{
    public class SessionMetadata: SegmentMetadata
    {
        public SegmentMetadata LeadIn { get; set; }
        public SegmentMetadata LeadOut { get; set; }
        public IEnumerable<LapMetadata> Laps { get; set; }
        public SegmentMetadata CombinedLaps { get; set; }
    }
}
