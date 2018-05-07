using System;
using System.IO;

namespace OpenLogger.Core
{
    public class LogStart
    {
        public LogStart(uint microseconds, uint timestamp, TimeSpan gpsTimeOffset)
        {
            Microseconds = microseconds;
            Timestamp = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime.Add(gpsTimeOffset);
        }

        public uint Microseconds { get; }
        public DateTime Timestamp { get; }

        public void WriteToStream(BinaryWriter writer)
        {
            var unixTime = new DateTimeOffset(Timestamp).ToUnixTimeSeconds();
            writer.Write((UInt32)Microseconds);
            writer.Write((UInt32)unixTime);
        }
    }
}
