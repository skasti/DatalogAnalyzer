using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OpenLogAnalyzer
{
    public static class Paths
    {
        public const string AppDataFolder = "OpenLog Analyzer";
        public const string LogLibraryFolder = "Logs";
        public const string TrackLibraryFolder = "Tracks";
        public const string BikeLibraryFolder = "Bikes";
        public static string DataRoot
        {
            get
            {
                var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData,
                    Environment.SpecialFolderOption.Create);

                return EnsureDirectory(Path.Combine(appData, AppDataFolder));
            }
        }

        public static string LogLibrary => EnsureDirectory(Path.Combine(DataRoot, LogLibraryFolder));
        public static string TrackLibrary => EnsureDirectory(Path.Combine(DataRoot, TrackLibraryFolder));
        public static string BikeLibrary => EnsureDirectory(Path.Combine(DataRoot, BikeLibraryFolder));

        public static string RiderConfigFile => Path.Combine(DataRoot, "RiderConfig.json");

        public static string DataLoggerCard
        {
            get
            {
                var removableDrives = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable && d.IsReady);

                var dataLoggerCards = removableDrives.Where(d => d.RootDirectory.GetFiles("*.LOG").Any()).ToList();

                if (dataLoggerCards.Any())
                    return dataLoggerCards.First().RootDirectory.ToString();

                return null;
            }
        }

        private static string EnsureDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}
