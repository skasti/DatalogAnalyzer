using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;

namespace DatalogAnalyzer
{
    public class SessionAnalysis
    {
        public Track Track { get; }
        public List<LapAnalysis> Laps { get; }
        public LogSegment LeadIn { get; private set; }
        public LogSegment LeadOut { get; private set; }
        public LogSegment Segment { get; }

        public TimeSpan SessionTime => Segment.Length;
        public double Distance => Segment.Distance;
        public double AverageSpeed => Segment.AverageSpeed;
        public double TopSpeed => Segment.TopSpeed;
        public double LowestSpeed => Segment.LowestSpeed;

        public SessionAnalysis(LogSegment segment, Track track)
        {
            Track = track;
            Segment = segment;
            Laps = GetLaps();
        }

        private List<LapAnalysis> GetLaps()
        {
            LogEntry latestInside = null;
            LogEntry previousEntry = null;

            List<LogSegment> laps = new List<LogSegment>();

            foreach (var entry in Segment.Entries)
            {
                var latLong = new PointLatLng(entry.Latitude, entry.Longitude);
                if (Track.StartFinishPolygon.IsInside(latLong))
                    latestInside = entry;
                else if (latestInside != null)
                {
                    if (previousEntry == null)
                        LeadIn = Segment.SubSet("Lead in", Segment.Entries.First(), entry);
                    else
                        laps.Add(Segment.SubSet($"Lap {laps.Count + 1}", previousEntry, entry));

                    previousEntry = entry;
                    latestInside = null;
                }
            }

            if (previousEntry != null)
                LeadOut = Segment.SubSet("Lead out", previousEntry, Segment.Entries.Last());

            return laps.Select(lapSegment => new LapAnalysis(Track, lapSegment)).ToList();
        }
    }
}
