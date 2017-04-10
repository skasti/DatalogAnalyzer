using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogAnalyzer
{
    public class DataLog
    {
        public LogStart LogStart { get; }
        public List<LogEntry> Entries { get; }
        public int ValueCount { get; }
        public TimeSpan Length => Entries?.LastOrDefault()?.GetTimeSpan(LogStart) ?? TimeSpan.Zero;

        public DataLog(LogStart logStart, List<LogEntry> entries)
        {
            LogStart = logStart;
            Entries = entries;
            ValueCount = entries.Select(e => e.Values.Count).Max();
        }

        public DataLog(string fileName)
        {
            var stream = File.OpenRead(fileName);
            var reader = new BinaryReader(stream);

            LogStart = new LogStart(reader.ReadUInt32(), reader.ReadUInt32());

            var entries = new List<LogEntry>();

            uint previous = LogStart.Microseconds;
            ulong deltaSum = 0;
            uint smallestDelta = uint.MaxValue;
            uint largestDelta = 0;

            uint largeDeltaThreshold = 6000;
            int largeDeltas = 0;

            ValueCount = reader.ReadUInt16();
            
            while (stream.Position < stream.Length)
            {
                try
                {
                    var micros = reader.ReadUInt32();

                    var delta = micros - previous;
                    deltaSum += delta;

                    if (entries.Count > 1)
                    {
                        if (delta < smallestDelta)
                            smallestDelta = delta;

                        if (delta > largestDelta)
                            largestDelta = delta;

                        if (delta > largeDeltaThreshold)
                            largeDeltas++;
                    }

                    previous = micros;

                    var entry = new LogEntry(ValueCount, micros, delta, reader);

                    entries.Add(entry);
                }
                catch (Exception ex)
                {
                    Log.Error("Failed to read LogEntry: {0}", ex);
                }
            }

            Entries = entries;

            Log.Info(
                "DataLog - Loaded {0} samples ({7} seconds)\navg delta: {1} micros\nsmallest delta: {2}\nlargest delta: {3}\ndeltas over {4} micros: {5} ({6}%)",
                Entries.Count(),
                deltaSum/(ulong) Entries.Count(),
                smallestDelta,
                largestDelta,
                largeDeltaThreshold,
                largeDeltas,
                ((double) largeDeltas/entries.Count)*100.0,
                entries.Last().GetTimeSpan(LogStart).TotalSeconds);
        }

        public void Save(string fileName)
        {
            var stream = File.Create(fileName);
            var writer = new BinaryWriter(stream);

            WriteToStream(writer);
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

        public LogEntry GetClosestEntry(double timeSpan)
        {
            var sortedEntries = Entries.ToList();
            sortedEntries.Sort((a, b) =>
            {
                var aD = Math.Abs(timeSpan - a.GetTimeSpan(LogStart).TotalSeconds);
                var bD = Math.Abs(timeSpan - b.GetTimeSpan(LogStart).TotalSeconds);

                return aD.CompareTo(bD);
            });

            return sortedEntries.First();
        }

        public DataLog SubSet(LogEntry start, LogEntry end = null)
        {
            var startIndex = Entries.IndexOf(start);
            var endIndex = Entries.IndexOf(end);

            var count = endIndex - startIndex + 1;

            return SubSet(startIndex, count);
        }

        public DataLog SubSet(int startIndex, int count = 0)
        {
            if (count == 0)
                count = Entries.Count - startIndex;

            var entries = Entries.GetRange(startIndex, count);
            var firstEntry = entries.FirstOrDefault();

            var logStart = new LogStart(firstEntry.Microseconds, (uint)firstEntry.GetTimeStamp(LogStart).Ticks);

            return new DataLog(logStart, entries.Skip(1).ToList());
        }
    }
}
