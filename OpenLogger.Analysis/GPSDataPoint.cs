using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLogger.Core;

namespace OpenLogger.Analysis
{
    public class GPSDataPoint: GPSPosition
    {
        public GPSDataPoint(LogEntry entry)
        :base(entry)
        {
            Speed = entry.Speed;
            SpeedAccuracy = entry.SpeedAccuracy;
            Altitude = entry.Altitude;
            HorizontalAccuracy = entry.HorizontalAccuracy;
            VerticalAccuracy = entry.VerticalAccuracy;
            FixType = entry.FixType;
            Entries = new List<LogEntry>();
        }
        public double Speed { get; set; }
        public double SpeedAccuracy { get; set; }
        public double Acceleration { get; set; }
        public double Altitude { get; set; }
        public double HorizontalAccuracy { get; set; }
        public double VerticalAccuracy { get; set; }
        public byte FixType { get; set; }
        public List<LogEntry> Entries { get; set; }
    }
}
