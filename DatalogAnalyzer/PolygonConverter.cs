using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using GMap.NET;
using GMap.NET.WindowsForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DatalogAnalyzer
{
    public class PolygonConverter:  JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var polygon = value as GMapPolygon;

            serializer.Serialize(writer, polygon);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var polygon = existingValue as GMapPolygon;


            var points = new List<PointLatLng>();
            var name = "";

            var jObject = JObject.Load(reader);

            name = jObject.Value<string>("Name");
            points = JsonConvert.DeserializeObject<List<PointLatLng>>(jObject.GetValue("Points").ToString());

            if (polygon == null)
                polygon = new GMapPolygon(points, name);
            else
            {
                polygon.Name = name;
                polygon.Points.AddRange(points);
            }

            return polygon;
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(GMapPolygon))
                return true;

            return false;
        }
    }
}