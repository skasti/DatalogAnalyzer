using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogAnalyzer
{
    public class LogStart
    {
        public LogStart(string logLine)
        {
            var components = logLine.Split('|');
            Microseconds = uint.Parse(components[0]);
            Timestamp = new DateTime(ticks: long.Parse(components[1]));
        }
        public LogStart(uint microseconds, uint timestamp)
        {
            Microseconds = microseconds;
            Timestamp = new DateTime(ticks: timestamp);
        }

        public uint Microseconds { get; }
        public DateTime Timestamp { get; }

        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write((UInt32)Microseconds);
            writer.Write((UInt32)Timestamp.Ticks);
        }
    }
}
