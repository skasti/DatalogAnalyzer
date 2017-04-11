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
            var trackFiles = Directory.GetFiles("Tracks", "*.track");

            if (trackFiles.Length <= 0)
                return;

            foreach (var trackFile in trackFiles)
            {
                var data = File.ReadAllText(trackFile);
                var track = JsonConvert.DeserializeObject<Track>(data);
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
