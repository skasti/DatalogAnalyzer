using System.Collections.Generic;

namespace OpenLogger.Analysis.Metadata
{
    public class LapMetadata: SegmentMetadata
    {
        public List<SegmentMetadata> Sections { get; set; }
    }
}
