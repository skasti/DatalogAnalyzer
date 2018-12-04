using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLogger.Analysis.Config;
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
        public SegmentAnalysis CombinedLaps { get; private set; }
        public List<LapAnalysis> Laps { get; private set; }
        public string VehicleName => LogFile.Metadata.Bike;

        public SessionAnalysis(LogFile logFile, Track track, bool performAnalysis = true, bool calculateRoutes = true, bool calculateAccelerationRoutes = true)
        {
            LogFile = logFile;
            Track = track;

            if (performAnalysis)
            {
                AnalyzeBaseData();
                AnalyzeLaps();
                LogFile.Metadata.UpdateAnalysisData(this);
            }

            if (calculateRoutes)
                CalculateRoutes(calculateAccelerationRoutes);
        }

        public void AnalyzeBaseData()
        {
            Full = new SegmentAnalysis(LogFile, "Full");
        }

        public void AnalyzeLaps(bool generateGPSData = true)
        {
            Laps = GetLaps(generateGPSData);
        }

        private List<LapAnalysis> GetLaps(bool generateGPSData = true)
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
                        LeadIn = new SegmentAnalysis(LogFile.SubSet(LogFile.Entries.First(), entry), "Lead in", generateGPSData);
                        previousEntry = latestInside;
                        latestInside = null;
                    }
                    else
                    {
                        var lapSegment = LogFile.SubSet(previousEntry, entry);
                        var lapAnalysis = new LapAnalysis(lapSegment, $"Lap {laps.Count + 1}", generateGPSData);
                        laps.Add(lapAnalysis);
                        previousEntry = latestInside;
                        latestInside = null;
                    }
                }
            }

            if (previousEntry != null)
            {
                LeadOut = new SegmentAnalysis(LogFile.SubSet(previousEntry, LogFile.Entries.Last()), "Lead out", generateGPSData);
            }

            if (laps.Any())
                CombinedLaps = new SegmentAnalysis(LogFile.SubSet(laps.First().Segment.Entries.First(), laps.Last().Segment.Entries.Last()), "Combined laps", generateGPSData);

            return laps.ToList();
        }

        public void CalculateRoutes(bool calculateAccelerationRoutes = true)
        {
            Full?.CalculateRoutes(Track, calculateAccelerationRoutes);
            LeadIn?.CalculateRoutes(Track, calculateAccelerationRoutes);

            if (Laps != null)
            {
                foreach (var lap in Laps)
                    lap.CalculateRoutes(Track, calculateAccelerationRoutes);
            }

            CombinedLaps?.CalculateRoutes(Track, calculateAccelerationRoutes);

            LeadOut?.CalculateRoutes(Track, calculateAccelerationRoutes);
        }
    }
}
