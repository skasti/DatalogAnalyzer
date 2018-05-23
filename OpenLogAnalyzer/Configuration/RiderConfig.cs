using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenLogAnalyzer
{
    public class RiderConfig
    {
        public string RiderName { get; set; }
        public string RiderNumber { get; set; }
        public string BikeName { get; set; }

        private static RiderConfig _instance;

        public static RiderConfig Instance
        {
            get
            {
                if (_instance == null)
                    Load();

                return _instance;
            }

            set { _instance = value; }
        }

        public static RiderConfig Load()
        {
            if (!File.Exists(Paths.RiderConfigFile))
                InitializeConfig();

            var json = File.ReadAllText(Paths.RiderConfigFile);
            Instance = JsonConvert.DeserializeObject<RiderConfig>(json);

            return Instance;
        }

        private static void InitializeConfig()
        {
            var config = new RiderConfig
            {
                RiderName = Environment.UserName,
                RiderNumber = "-"
            };

            config.Save();
        }

        public void Save(string filename = null)
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filename ?? Paths.RiderConfigFile, json);
        }
    }
}
