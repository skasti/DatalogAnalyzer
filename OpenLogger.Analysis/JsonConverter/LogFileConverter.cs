using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;
using Newtonsoft.Json;
using OpenLogger.Core;

namespace OpenLogger.Analysis.JsonConverter
{
    public class LogFileConverter: Newtonsoft.Json.JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var logFile = value as LogFile;

            serializer.Serialize(writer, logFile.FullFilename);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var logFile = existingValue as LogFile;

            //var readLogFileName = reader.ReadAsString();

            //if ((logFile == null) || (logFile.FullFilename != readLogFileName))
            //    return LogFile.Load(readLogFileName, TimeSpan.Zero);
            
            return logFile;
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(LogFile))
                return true;

            return false;
        }
    }
}
