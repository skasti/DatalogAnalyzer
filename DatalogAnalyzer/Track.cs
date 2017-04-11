using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;
using Newtonsoft.Json;

namespace DatalogAnalyzer
{
    public class Track
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof(PolygonConverter))]
        public GMapPolygon Area { get; set; }

        [JsonConverter(typeof(PolygonConverter))]
        public GMapPolygon StartFinishPolygon { get; set; }

        [JsonProperty(ItemConverterType = typeof(PolygonConverter))]
        public List<GMapPolygon> Sections { get; set; }

        public Track()
        {
            Id = Guid.NewGuid();
        }
    }
}
