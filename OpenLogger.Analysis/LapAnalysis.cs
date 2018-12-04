using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLogger.Core;

namespace OpenLogger.Analysis
{
    public class LapAnalysis: SegmentAnalysis
    {

        public LapAnalysis(LogSegment segment, string name, bool generateGPSData = true) : base(segment, name, generateGPSData)
        {
        }


    }
}
