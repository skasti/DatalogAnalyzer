using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogAnalyzer
{
    public class LogAnalysis
    {
        public LogAnalysis(List<DataLog> segments)
        {
            Segments = segments;
        }

        public List<DataLog> Segments { get; } 
    }
}
