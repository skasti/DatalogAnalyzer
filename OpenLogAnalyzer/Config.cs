using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenLogAnalyzer
{
    public class AnalyzerConfig
    {
        public string RiderName { get; set; }
        public string RiderNumber { get; set; }
        public string BikeName { get; set; }

        private static AnalyzerConfig _instance;

        public static AnalyzerConfig Instance
        {
            get
            {
                if (_instance == null)
                    Load();

                return _instance;
            }

            set { _instance = value; }
        }

        public static AnalyzerConfig Load()
        {
            if (!File.Exists(Paths.ConfigFile))
                InitializeConfig();

            var json = File.ReadAllText(Paths.ConfigFile);
            Instance = JsonConvert.DeserializeObject<AnalyzerConfig>(json);

            return Instance;
        }

        private static void InitializeConfig()
        {
            var config = new AnalyzerConfig
            {
                RiderName = Environment.UserName,
                RiderNumber = "-"
            };

            config.Save();
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(Paths.ConfigFile, json);
        }
    }
}
