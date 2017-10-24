using System;
using System.IO;

namespace OpenLogger.Core
{
    public class LogStart
    {
        public LogStart(string logLine)
        {
            var components = logLine.Split('|');
            Microseconds = uint.Parse(components[0]);
            Timestamp = new DateTime(ticks: long.Parse(components[1]));
        }
        public LogStart(uint microseconds, uint timestamp, TimeSpan gpsTimeOffset)
        {
            Microseconds = microseconds;
            Timestamp = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime.Add(gpsTimeOffset);
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
