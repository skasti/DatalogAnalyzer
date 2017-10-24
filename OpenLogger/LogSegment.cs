using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenLogger.Core.Debugging;

namespace OpenLogger.Core
{
    public class LogSegment
    {
        public LogStart LogStart { get; }
        public List<LogEntry> Entries { get; }
        public int ValueCount { get; }
        public TimeSpan Length => Entries?.LastOrDefault()?.GetTimeSpan(LogStart) ?? TimeSpan.Zero;

        public LogSegment(LogStart logStart, List<LogEntry> entries)
        {
            LogStart = logStart;
            Entries = entries;
            ValueCount = entries.Select(e => e.Values.Count).Max();
        }

        public void WriteToStream(BinaryWriter writer)
        {
            try
            {
                LogStart.WriteToStream(writer);

                writer.Write((UInt16)ValueCount);

                foreach (var logEntry in Entries)
                {
                    logEntry.WriteToStream(writer);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Failed to write to stream: {0}", ex);
            }
        }

        public LogEntry GetClosestEntry(double timeSpan, int skip = 0)
        {
            int index;
            return GetClosestEntry(timeSpan,out index, skip);
        }

        public LogEntry GetClosestEntry(double timeSpan, out int index, int skip = 0)
        {
            for (var i = skip; i < Entries.Count; i++)
            {
                index = i;
                var entry = Entries[i];

                var entrySeconds = entry.GetTimeSpan(LogStart).TotalSeconds;

                if (entrySeconds < timeSpan)
                    continue;

                if (i == 0)
                    return entry;

                var previousEntry = Entries[i - 1];
                var previousEntrySeconds = previousEntry.GetTimeSpan(LogStart).TotalSeconds;

                if (timeSpan - previousEntrySeconds < entrySeconds - timeSpan)
                    return previousEntry;

                return entry;
            }
            index = Entries.Count - 1;
            return Entries.LastOrDefault();
        }

        public LogSegment SubSet(LogEntry start, LogEntry end = null)
        {
            var startIndex = Entries.IndexOf(start);
            var endIndex = Entries.IndexOf(end);

            var count = endIndex - startIndex + 1;

            return SubSet(startIndex, count);
        }

        public LogSegment SubSet(int startIndex, int count = 0)
        {
            if (count == 0)
                count = Entries.Count - startIndex;

            var entries = Entries.GetRange(startIndex, count);
            var firstEntry = entries.FirstOrDefault();

            var logStart = new LogStart(firstEntry.Microseconds, (uint)firstEntry.GetTimeStamp(LogStart).Ticks, TimeSpan.Zero);

            return new LogSegment(logStart, entries.Skip(1).ToList());
        }
    }
}
