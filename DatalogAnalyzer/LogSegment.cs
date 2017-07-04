using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace DatalogAnalyzer
{
    public class LogSegment
    {
        public LogStart LogStart { get; }
        public List<LogEntry> Entries { get; }
        public int ValueCount { get; }
        public TimeSpan Length => Entries?.LastOrDefault()?.GetTimeSpan(LogStart) ?? TimeSpan.Zero;
        public double Distance { get; private set; }
        public double AverageSpeed { get; private set; }
        public double TopSpeed { get; private set; }
        public double LowestSpeed { get; private set; }

        public Series SpeedSeries { get; set; }
        public Series SpeedAccuracySeries { get; set; }
        public Series AccelerationSeries { get; set; }
        public Series DeltaSeries { get; set; }
        public string Name { get; set; }

        public LogSegment(LogStart logStart, List<LogEntry> entries, string name)
        {
            LogStart = logStart;
            Entries = entries;
            ValueCount = entries.Select(e => e.Values.Count).Max();
            Name = name;

            InitializeStats();
        }

        private void InitializeStats()
        {
            var route = GetMapRoute();

            Distance = route.Distance;
            AverageSpeed = Distance/Length.TotalHours;
            TopSpeed = Entries.Max(e => e.Speed);
            LowestSpeed = Entries.Min(e => e.Speed);
        }

        public LogSegment(string fileName)
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

            LogEntry previousGpsEntry = null; 

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

                    if (previousGpsEntry == null)
                    {
                        entry.Accelleration = 0.0;

                        if (entry.SpeedAccuracy < 5)
                        {
                            previousGpsEntry = entry;
                        }
                    }
                    else if (entry.Latitude == previousGpsEntry.Latitude && entry.Longitude == previousGpsEntry.Longitude)
                    {
                        entry.Accelleration = previousGpsEntry.Accelleration;
                    }
                    else if (entry.SpeedAccuracy < 5)
                    {
                        var deltaSpeed = entry.Speed - previousGpsEntry.Speed;
                        deltaSpeed *= 0.277778;

                        var deltaTime = entry.GetTimeSpan(LogStart) - previousGpsEntry.GetTimeSpan(LogStart);
                        
                        entry.Accelleration = (deltaSpeed / deltaTime.TotalSeconds); // * 0.101971621;

                        previousGpsEntry = entry;
                    }
                    else
                    {
                        entry.Accelleration = previousGpsEntry.Accelleration;
                    }

                    entries.Add(entry);
                }
                catch (Exception ex)
                {
                    Log.Error("Failed to read LogEntry: {0}", ex);
                }
            }

            Entries = entries;
            InitializeStats();

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

        public LogSegment SubSet(string name, LogEntry start, LogEntry end = null)
        {
            var startIndex = Entries.IndexOf(start);
            var endIndex = Entries.IndexOf(end);

            var count = endIndex - startIndex + 1;

            return SubSet(name, startIndex, count);
        }

        public LogSegment SubSet(string name, int startIndex, int count = 0)
        {
            if (count == 0)
                count = Entries.Count - startIndex;

            var entries = Entries.GetRange(startIndex, count);
            var firstEntry = entries.FirstOrDefault();

            var logStart = new LogStart(firstEntry.Microseconds, (uint)firstEntry.GetTimeStamp(LogStart).Ticks);

            return new LogSegment(logStart, entries.Skip(1).ToList(), name);
        }

        public GMapRoute GetMapRoute(Track track = null)
        {
            var lineRoute = new GMapRoute("Route")
            {
                Stroke = new Pen(Color.CornflowerBlue, 2.0f)
            };

            var prevLat = 0.0;
            var prevLong = 0.0;
            foreach (var logEntry in Entries)
            {
                if ((logEntry.Latitude == prevLat) && (logEntry.Longitude == prevLong))
                    continue;

                if (logEntry.FixType != 3)
                    continue;

                if (logEntry.SpeedAccuracy > 5)
                    continue;

                prevLat = logEntry.Latitude;
                prevLong = logEntry.Longitude;

                lineRoute.Points.Add(new PointLatLng(
                    logEntry.Latitude + track?.LatLongCorrection.Lat ?? 0.0, 
                    logEntry.Longitude + track?.LatLongCorrection.Lng ?? 0.0));
            }

            return lineRoute;
        }
    }
}
