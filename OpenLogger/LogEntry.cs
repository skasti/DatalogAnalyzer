using System;
using System.Collections.Generic;
using System.IO;
using OpenLogger.Core.Extensions;

namespace OpenLogger.Core
{
    public interface IHaveTime
    {
        uint Microseconds { get; }
        TimeSpan GetTimeSpan(LogStart logStart);
        DateTime GetTimeStamp(LogStart logStart);
    }

    public interface IHavePosition
    {
        double Longitude { get; }
        double Latitude { get; }
    }
    public interface IHavePositionAndTime : IHavePosition, IHaveTime
    { }
    public class LogEntry: IHavePositionAndTime
    {
        public LogEntry(uint microseconds, List<double> values, double speed, double speedAccuracy, double longitude, double latitude, double altitude, double horizontalAccuracy, double verticalAccuracy, byte fixType)
        {
            Microseconds = microseconds;
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

        public LogEntry()
        {
            
        }

        public static LogEntry ReadFromStream(int valueCount, BinaryReader reader)
        {
            var entry = new LogEntry
            {
                Microseconds = reader.ReadUInt32(),
                Speed = reader.ReadUInt16() * 0.0036, //unit is mm/s, we want km/h
                SpeedAccuracy = reader.ReadUInt16() * 0.01, //unit is mm/s, we want m/s
                Longitude = reader.ReadInt32() * 0.0000001, //Scaling is 1e-7
                Latitude = reader.ReadInt32() * 0.0000001, //Scaling is 1e-7
                Altitude = reader.ReadInt32(),
                HorizontalAccuracy = reader.ReadUInt32() * 0.001,
                VerticalAccuracy = reader.ReadUInt32() * 0.001,
                FixType = reader.ReadByte(),

                Values = new List<double>(valueCount)

            };

            for (var i = 0; i < valueCount; i++)
            {
                entry.Values.Add(reader.ReadUInt16());
            }

            return entry;
        }

        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write((UInt32)Microseconds);
            writer.Write((UInt16)(Speed / 0.0036));
            writer.Write((UInt16)(SpeedAccuracy / 0.01));
            writer.Write((Int32)(Longitude / 0.0000001));
            writer.Write((Int32)(Latitude / 0.0000001));
            writer.Write((Int32)Altitude);

            writer.Write((UInt32)(HorizontalAccuracy / 0.001));
            writer.Write((UInt32)(VerticalAccuracy / 0.001));

            writer.Write((byte)(FixType));

            foreach (var value in Values)
            {
                writer.Write((UInt16)value);
            }
        }

        public uint Microseconds { get; private set; }
        public double Speed { get; private set; }
        public double SpeedAccuracy { get; private set; }
        public double Longitude { get; private set; }
        public double Latitude { get; private set; }
        public double Altitude { get; private set; }
        public double HorizontalAccuracy { get; private set; }
        public double VerticalAccuracy { get; private set; }
        public byte FixType { get; private set; }
        public List<double> Values { get; private set; }

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
