using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLogger.Core;

namespace OpenLogger.Analysis
{
    public class GPSDataPoint
    {
        public GPSDataPoint(LogEntry entry)
        {
            Speed = entry.Speed;
            SpeedAccuracy = entry.SpeedAccuracy;
            Longitude = entry.Longitude;
            Latitude = entry.Latitude;
            Altitude = entry.Altitude;
            HorizontalAccuracy = entry.HorizontalAccuracy;
            VerticalAccuracy = entry.VerticalAccuracy;
            FixType = entry.FixType;
            Entries = new List<LogEntry>();
        }

        public double Speed { get; set; }
        public double SpeedAccuracy { get; set; }
        public double Acceleration { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Altitude { get; set; }
        public double HorizontalAccuracy { get; set; }
        public double VerticalAccuracy { get; set; }
        public byte FixType { get; set; }
        public List<LogEntry> Entries { get; set; }
    }
}
