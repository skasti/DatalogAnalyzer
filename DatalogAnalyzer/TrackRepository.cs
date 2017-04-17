using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using Newtonsoft.Json;

namespace DatalogAnalyzer
{
    public class TrackRepository
    {
        public List<Track> Tracks { get; }

        public TrackRepository()
        {
            Tracks = new List<Track>();
        }

        /// <summary>
        /// Load all tracks
        /// </summary>
        public void Load()
        {
            if (!Directory.Exists("Tracks"))
            {
                Directory.CreateDirectory("Tracks");
                return;
            }

            var removableDrives = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable && d.IsReady);

            var dataLoggerCards = removableDrives.Where(d => d.RootDirectory.GetFiles("*.LOG").Any()).ToList();

            if (dataLoggerCards.Any())
            {
                var cardRoot = dataLoggerCards.First().RootDirectory.ToString();

                if (Directory.Exists($"{cardRoot}\\Tracks"))
                {
                    var cardTracks = Directory.GetFiles($"{cardRoot}\\Tracks", "*.track");

                    foreach (var trackFile in cardTracks)
                    {
                        var data = File.ReadAllText(trackFile);
                        var track = JsonConvert.DeserializeObject<Track>(data);
                        Tracks.Add(track);
                    }
                }
            }

            var trackFiles = Directory.GetFiles("Tracks", "*.track");

            if (trackFiles.Length <= 0)
                return;

            foreach (var trackFile in trackFiles)
            {
                var data = File.ReadAllText(trackFile);
                var track = JsonConvert.DeserializeObject<Track>(data);

                
                var existing = Tracks.FirstOrDefault(t => t.Id == track.Id);

                if (existing != null)
                {
                    if (existing.ChangedDate < track.ChangedDate)
                    {
                        Tracks.Remove(existing);
                        Tracks.Add(track);
                    }
                }
                else
                    Tracks.Add(track);
            }
        }

        /// <summary>
        /// Tries to find a track at the position provided. Returns null if not found
        /// </summary>
        public Track FindTrackAt(PointLatLng position)
        {
            return Tracks.FirstOrDefault(t => t.Area.IsInside(position));
        }
    }
}
