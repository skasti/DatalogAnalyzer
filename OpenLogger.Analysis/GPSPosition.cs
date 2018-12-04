using System;
using OpenLogger.Core;
using OpenLogger.Core.Extensions;

namespace OpenLogger.Analysis
{
    public class GPSPosition:IHavePositionAndTime
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public uint Microseconds { get; set; }

        public GPSPosition()
        {

        }
        public GPSPosition(LogEntry entry)
        {
            Microseconds = entry.Microseconds;
            Longitude = entry.Longitude;
            Latitude = entry.Latitude;
        }
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