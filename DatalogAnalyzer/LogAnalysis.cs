using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;

namespace DatalogAnalyzer
{
    public class LogAnalysis
    {
        public Track Track { get; }
        public List<DataLog> Laps { get; }
        public DataLog LeadIn { get; private set; }
        public DataLog LeadOut { get; private set; }
        public DataLog Log { get; }

        public LogAnalysis(DataLog log, Track track)
        {
            Track = track;
            Log = log;
            Laps = GetLaps();
        }

        private List<DataLog> GetLaps()
        {
            LogEntry latestInside = null;
            LogEntry previousEntry = null;

            List<DataLog> laps = new List<DataLog>();

            foreach (var entry in Log.Entries)
            {
                var latLong = new PointLatLng(entry.Latitude, entry.Longitude);
                if (Track.StartFinishPolygon.IsInside(latLong))
                    latestInside = entry;
                else if (latestInside != null)
                {
                    if (previousEntry == null)
                        LeadIn = Log.SubSet(Log.Entries.First(), entry);
                    else
                        laps.Add(Log.SubSet(previousEntry, entry));

                    previousEntry = entry;
                    latestInside = null;
                }
            }

            LeadOut = Log.SubSet(previousEntry, Log.Entries.Last());

            return laps;
        }
    }
}
