using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace OpenLogger.Core
{
    public class LogFileMetadata
    {
        public string LogFilename { get; set; }
        public string Rider { get; set; }
        public string Bike { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Length { get; set; }
        public TimeSpan Best { get; set; }
        public TimeSpan Average { get; set; }
        public int Laps { get; set; }
        public string Track { get; set; }

        public LogFileMetadata()
        {
        }

        public LogFileMetadata(LogFile logFile)
        {
            LogFilename = logFile.FullFilename;
            StartTime = logFile.LogStart.Timestamp;
            Length = logFile.Entries.LastOrDefault()?.GetTimeSpan(logFile.LogStart) ?? TimeSpan.Zero;
        }

        public static LogFileMetadata Load(string filename)
        {
            var metaJson = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<LogFileMetadata>(metaJson);
        }
    }
}
