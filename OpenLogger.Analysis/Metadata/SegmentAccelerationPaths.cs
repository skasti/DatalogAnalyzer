using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLogger.Analysis.Config;

namespace OpenLogger.Analysis.Metadata
{
    public class SegmentAccelerationPaths
    {
        public string ConfigPath { get; set; }
        public DateTime Generated { get; set; }
        public IEnumerable<GPSPath> AccelerationPaths { get; set; }
    }
}
