using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogAnalyzer
{
    public class DataLog
    {
        public LogStart LogStart { get; }
        public IEnumerable<LogEntry> Entries { get; }

        public TimeSpan Length => Entries?.LastOrDefault()?.GetTimeSpan(LogStart) ?? TimeSpan.Zero;

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

                    if (delta < smallestDelta)
                        smallestDelta = delta;

                    if (delta > largestDelta)
                        largestDelta = delta;

                    if (delta > largeDeltaThreshold)
                        largeDeltas++;

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

            Log.Info("DataLog - Loaded {0} samples ({7} seconds)\navg delta: {1} micros\nsmallest delta: {2}\nlargest delta: {3}\ndeltas over {4} micros: {5} ({6}%)", 
                        Entries.Count(), 
                        deltaSum / (ulong)Entries.Count(), 
                        smallestDelta, 
                        largestDelta, 
                        largeDeltaThreshold, 
                        largeDeltas, 
                        ((double)largeDeltas / entries.Count) * 100.0, 
                        entries.Last().GetTimeSpan(LogStart).TotalSeconds);
        }

        public int ValueCount { get; }

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
    }
}
