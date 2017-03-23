using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogAnalyzer
{
    public class LogEntry
    {
        public LogEntry(uint microseconds, uint delta, List<double> values, double speed, double speedAccuracy, double longitude, double latitude, double altitude, double horizontalAccuracy, double verticalAccuracy, byte fixType)
        {
            Microseconds = microseconds;
            Delta = delta;
            Values = values;
            Speed = speed;
            SpeedAccuracy = speedAccuracy;
            Longitude = longitude;
            Latitude = latitude;
            Altitude = altitude;
            HorizontalAccuracy = horizontalAccuracy;
            VerticalAccuracy = verticalAccuracy;
            FixType = fixType;
        }

        public LogEntry(int valueCount, uint microseconds, uint delta, BinaryReader reader)
        {
            Microseconds = microseconds;
            Delta = delta;

            Speed = reader.ReadUInt16() * 0.0036; //unit is mm/s, we want km/h
            SpeedAccuracy = reader.ReadUInt16() * 0.01; //unit is mm/s, we want m/s
            Longitude = reader.ReadInt32() * 0.0000001; //Scaling is 1e-7
            Latitude = reader.ReadInt32() * 0.0000001; //Scaling is 1e-7
            Altitude = reader.ReadInt32();
            HorizontalAccuracy = reader.ReadUInt32() * 0.001;
            VerticalAccuracy = reader.ReadUInt32() * 0.001;
            FixType = reader.ReadByte();

            Values = new List<double>(valueCount + 1);

            for (var i = 0; i < valueCount; i++)
            {
                Values.Add(reader.ReadUInt16());
            }
        }

        public uint Microseconds { get; }
        public uint Delta { get; }

        public double Speed { get; }
        public double SpeedAccuracy { get; }
        public double Longitude { get; }
        public double Latitude { get; }
        public double Altitude { get; }
        public double HorizontalAccuracy { get; }
        public double VerticalAccuracy { get; }
        public byte FixType { get; }
      
        public List<double> Values { get; }

        public DateTime GetTimeStamp(LogStart logStart)
        {
            return logStart.Timestamp.AddMicros(Microseconds);
        }

        public TimeSpan GetTimeSpan(LogStart logStart)
        {
            return GetTimeStamp(logStart) - logStart.Timestamp;
        }
    }
}
