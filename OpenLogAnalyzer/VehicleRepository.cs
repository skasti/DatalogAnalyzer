using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenLogger.Analysis.Vehicle;

namespace OpenLogAnalyzer
{
    public class VehicleRepository
    {
        private static Dictionary<string, Vehicle> _vehicles = new Dictionary<string, Vehicle>(); 
        public static Vehicle Get(string vehicleName)
        {
            if (string.IsNullOrWhiteSpace(vehicleName))
                return null;

            if (_vehicles.ContainsKey(vehicleName))
                return _vehicles[vehicleName];

            var files = Directory.GetFiles(Paths.BikeLibrary, $"{vehicleName}.json");

            if (files.Length == 0)
                return null;

            var file = files.FirstOrDefault();
            var json = File.ReadAllText(file);

            var vehicle = JsonConvert.DeserializeObject<Vehicle>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                
            });

            _vehicles.Add(vehicleName, vehicle);
            return vehicle;
        }

        public static IEnumerable<string> GetNames()
        {
            var files = Directory.GetFiles(Paths.BikeLibrary, $"*.json");

            return files.Select(f => Path.GetFileNameWithoutExtension(f));
        }

        public static bool Exists(string name)
        {
            if (_vehicles.ContainsKey(name))
                return true;

            var files = Directory.GetFiles(Paths.BikeLibrary, $"{name}.json");

            if (files.Length > 0)
                return true;

            return false;
        }

        public static void Save(Vehicle vehicle)
        {
            if (vehicle == null)
                return;

            var json = JsonConvert.SerializeObject(vehicle, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            File.WriteAllText(Path.Combine(Paths.BikeLibrary, $"{vehicle.Name}.json"), json);
        }
    }
}
