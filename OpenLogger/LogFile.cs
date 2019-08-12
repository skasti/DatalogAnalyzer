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
        private LogFile(string fileName, LogStart logStart, List<LogEntry> entries, LogFileMetadata metadata) : base(logStart, entries)
        {
            UpdateLocation(fileName);
            Metadata = metadata;
        }

        private void UpdateLocation(string fileName)
        {
            Location = Path.GetDirectoryName(fileName);
            Filename = Path.GetFileNameWithoutExtension(fileName);

            if (Metadata != null)
                Metadata.LogFilename = FullFilename;
        }

        public void Save(Stream logFileStream, Stream metadataStream = null)
        {
            var writer = new BinaryWriter(logFileStream);

            WriteToStream(writer);
            writer.Flush();
            writer.Close();

            if (metadataStream != null)
                SaveMetadata(metadataStream);
        }

        public void SaveMetadata(Stream metadataStream)
        {
            Metadata.Save(metadataStream);
        }

        public static LogFile Load(string fileName, Stream logStream, TimeSpan gpsTimeOffset, LogFileMetadata metadata = null)
        {
            var reader = new BinaryReader(logStream);

            var logStart = LogStart.ReadFromStream(reader);

            var entries = new List<LogEntry>();

            uint previous = logStart.Microseconds;
            ulong deltaSum = 0;
            uint smallestDelta = uint.MaxValue;
            uint largestDelta = 0;

            uint largeDeltaThreshold = 10000;
            int largeDeltas = 0;

            var valueCount = reader.ReadUInt16();

            while (logStream.Position < logStream.Length)
            {
                try
                {
                    var entry = LogEntry.ReadFromStream(valueCount, reader);

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

            if (entries.Count == 0)
            {
                Log.Error("Stream contains no entries: {0}", fileName);
                return null;
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

            var logFile = new LogFile(fileName, logStart, entries, metadata);

            if (metadata == null)
                logFile.InitMetadata(gpsTimeOffset);

            return logFile;
        }

        private void InitMetadata(TimeSpan gpsTimeOffset)
        {
            Metadata = new LogFileMetadata(this, gpsTimeOffset);
        }
    }
}
