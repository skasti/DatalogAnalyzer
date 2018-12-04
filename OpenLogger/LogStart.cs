using System;
using System.IO;

namespace OpenLogger.Core
{
    public class LogStart
    {
        public LogStart()
        {
        }

        public LogStart(uint microseconds, uint timestamp)
        {
            Microseconds = microseconds;
            Timestamp = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
        }

        public uint Microseconds { get; }
        public DateTime Timestamp { get; }

        public void WriteToStream(BinaryWriter writer)
        {
            var unixTime = new DateTimeOffset(Timestamp).ToUnixTimeSeconds();
            writer.Write((UInt32)Microseconds);
            writer.Write((UInt32)unixTime);
        }

        public static LogStart ReadFromStream(BinaryReader reader)
        {
            return new LogStart(reader.ReadUInt32(), reader.ReadUInt32());
        }
    }
}
