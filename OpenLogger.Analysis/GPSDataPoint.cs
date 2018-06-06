using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLogger.Core;
using OpenLogger.Core.Extensions;

namespace OpenLogger.Analysis
{
    public class GPSDataPoint: IHavePositionAndTime
    {
        public GPSDataPoint(LogEntry entry)
        {
            Microseconds = entry.Microseconds;
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

        public uint Microseconds { get; set; }
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

        public DateTime GetTimeStamp(LogStart logStart)
        {
            return logStart.Timestamp.AddMicros(Microseconds - logStart.Microseconds);
        }

        public TimeSpan GetTimeSpan(LogStart logStart)
        {
            return GetTimeStamp(logStart) - logStart.Timestamp;
        }
    }
}
