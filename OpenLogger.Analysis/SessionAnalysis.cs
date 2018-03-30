using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLogger.Analysis.Extensions;
using OpenLogger.Analysis.JsonConverter;
using OpenLogger.Core;

namespace OpenLogger.Analysis
{
    public class SessionAnalysis
    {
        [JsonConverter(typeof(LogFileConverter))]
        public LogFile LogFile { get; set; }
        public Track Track { get; set; }
        public SegmentAnalysis Full { get; private set; }
        public SegmentAnalysis LeadIn { get; private set; }
        public SegmentAnalysis LeadOut { get; private set; }
        public List<LapAnalysis> Laps { get; private set; }
        public string VehicleName => LogFile.Metadata.Bike;

        public SessionAnalysis(LogFile logFile, Track track)
        {
            LogFile = logFile;
            Track = track;
            Laps = GetLaps();
            Full = new SegmentAnalysis(LogFile, "Full");

            LogFile.Metadata.UpdateAnalysisData(this);
        }

        private List<LapAnalysis> GetLaps()
        {
            if (Track == null)
                return new List<LapAnalysis>();

            LogEntry latestInside = null;
            LogEntry previousEntry = null;

            List<LapAnalysis> laps = new List<LapAnalysis>();

            foreach (var entry in LogFile.Entries.Where(e => e.HorizontalAccuracy < 3))
            {
                var latLong = entry.GetLocation(Track);
                if (Track.StartLinePolygon.IsInside(latLong))
                    latestInside = entry;
                else if (latestInside != null)
                {
                    if (previousEntry == null)
                    {
                        LeadIn = new SegmentAnalysis(LogFile.SubSet(LogFile.Entries.First(), entry), "Lead in");
                        previousEntry = entry;
                        latestInside = null;
                    }
                    else
                    {
                        var lapSegment = LogFile.SubSet(previousEntry, entry);

                        laps.Add(new LapAnalysis(lapSegment, $"Lap {laps.Count + 1}"));
                        previousEntry = entry;
                        latestInside = null;
                    }
                }
            }

            if (previousEntry != null)
                LeadOut = new SegmentAnalysis(LogFile.SubSet(previousEntry, LogFile.Entries.Last()), "Lead out");

            return laps.ToList();
        }
    }
}
