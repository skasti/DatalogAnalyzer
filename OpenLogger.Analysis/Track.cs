using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;
using Newtonsoft.Json;
using OpenLogger.Analysis.JsonConverter;

namespace OpenLogger.Analysis
{
    public enum TrackType
    {
        //Start/Finish with laps
        //Laptimes are what count
        Circuit,

        //Start and finish are separate areas. 
        //Time taken from start to finish is what is measured
        TimeTrial
    }
    public class Track
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Changed { get; set; }

        public TrackType Type { get; set; }

        [JsonConverter(typeof(PolygonConverter))]
        public GMapPolygon StartLinePolygon { get; set; }

        [JsonConverter(typeof(PolygonConverter))]
        public GMapPolygon FinishLinePolygon { get; set; }

        [JsonConverter(typeof(PolygonConverter))]
        public GMapPolygon Area { get; set; }

        public PointLatLng GpsCorrection { get; set; }
    }
}
