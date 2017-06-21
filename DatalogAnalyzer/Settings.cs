using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogAnalyzer
{
    public static class Settings
    {
        public static double AccelleratingThreshold => GetDouble("AccelleratingThreshold", 0.0);
        public static double BrakingThreshold => GetDouble("BrakingThreshold", 0.0);
        public static double CoastingThreshold => Math.Abs(GetDouble("CoastingThreshold", 0.0));

        private static double GetDouble(string settingName, double fallBack)
        {
            var setting = ConfigurationManager.AppSettings[settingName];
            double value;

            if (double.TryParse(setting, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                return value;

            return fallBack;
        }
    }
}
