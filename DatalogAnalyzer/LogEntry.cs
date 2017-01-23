using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogAnalyzer
{
    public class LogEntry
    {
        public LogEntry(uint microseconds, uint delta, List<double> values)
        {
            Microseconds = microseconds;
            Delta = delta;
            Values = values;
        }

        public uint Microseconds { get; }
        public uint Delta { get; }
        public List<double> Values { get; }

        public DateTime GetTimeStamp(LogStart logStart)
        {
            return logStart.AdjustedTimestamp.AddMicros(Microseconds);
        }

        public TimeSpan GetTimeSpan(LogStart logStart)
        {
            return GetTimeStamp(logStart) - logStart.AdjustedTimestamp;
        }
    }
}
