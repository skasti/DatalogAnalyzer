using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OpenLogAnalyzer.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<T> DeserializeJson<T>(this HttpContent content)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                TypeNameHandling = TypeNameHandling.Auto
            };

            var json = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json, settings);
        }
    }
}
