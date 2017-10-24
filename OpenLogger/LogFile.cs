using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using OpenLogger.Core.Debugging;

namespace OpenLogger.Core
{
    public class LogFile: LogSegment
    {
        public string Location { get; set; }
        public string Filename { get; set; }
        public string FullFilename => Path.Combine(Location, Filename) + ".LOG";
        public LogFileMetadata Metadata { get; set; }
        private LogFile(string fileName, LogStart logStart, List<LogEntry> entries, LogFileMetadata metadata = null) : base(logStart, entries)
        {
            UpdateLocation(fileName);
            Metadata = metadata ?? new LogFileMetadata(this);
        }

        private void UpdateLocation(string fileName)
        {
            Location = Path.GetDirectoryName(fileName);
            Filename = Path.GetFileNameWithoutExtension(fileName);

            if (Metadata != null)
                Metadata.LogFilename = FullFilename;
        }

        public void Save(string fileName = null)
        {
            fileName = fileName ?? FullFilename;
            UpdateLocation(fileName);

            var stream = File.Create(fileName);
            var writer = new BinaryWriter(stream);

            WriteToStream(writer);
            writer.Flush();
            writer.Close();

            File.SetCreationTime(fileName, LogStart.Timestamp);

            SaveMetadata();
        }

        public void SaveMetadata()
        {
            var fileName = FullFilename + ".meta";
            var json = JsonConvert.SerializeObject(Metadata, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public static LogFile Load(string fileName, TimeSpan gpsTimeOffset)
        {
            var stream = File.OpenRead(fileName);
            var reader = new BinaryReader(stream);

            var logStart = new LogStart(reader.ReadUInt32(), reader.ReadUInt32(), gpsTimeOffset);

            var entries = new List<LogEntry>();

            uint previous = logStart.Microseconds;
            ulong deltaSum = 0;
            uint smallestDelta = uint.MaxValue;
            uint largestDelta = 0;

            uint largeDeltaThreshold = 10000;
            int largeDeltas = 0;

            var valueCount = reader.ReadUInt16();

            while (stream.Position < stream.Length)
            {
                try
                {
                    var entry = new LogEntry(valueCount, reader);

                    var delta = entry.Microseconds - previous;
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

                    previous = entry.Microseconds;

                    entries.Add(entry);
                }
                catch (Exception ex)
                {
                    Log.Error("Failed to read LogEntry: {0}", ex);
                }
            }
            
            Log.Info(
                "LogFile - Loaded {0} samples ({7} seconds)\navg delta: {1} micros\nsmallest delta: {2}\nlargest delta: {3}\ndeltas over {4} micros: {5} ({6}%)",
                entries.Count(),
                deltaSum / (ulong)entries.Count(),
                smallestDelta,
                largestDelta,
                largeDeltaThreshold,
                largeDeltas,
                ((double)largeDeltas / entries.Count) * 100.0,
                entries.Last().GetTimeSpan(logStart).TotalSeconds);

            LogFileMetadata metadata = null;

            if (File.Exists(fileName + ".meta"))
                metadata = LogFileMetadata.Load(fileName + ".meta");

            return new LogFile(fileName, logStart, entries, metadata);
        }
    }
}
