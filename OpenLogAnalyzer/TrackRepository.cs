using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GMap.NET;
using Newtonsoft.Json;
using OpenLogAnalyzer.Extensions;
using OpenLogger.Analysis;
using OpenLogger.Analysis.Extensions;
using OpenLogger.Core;

namespace OpenLogAnalyzer
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
            var trackFiles = Directory.GetFiles(Paths.TrackLibrary, "*.track");

            if (trackFiles.Length <= 0)
                return;

            foreach (var trackFile in trackFiles)
            {
                var data = File.ReadAllText(trackFile);
                var track = JsonConvert.DeserializeObject<Track>(data);

                if (track.Id == Guid.Empty)
                {
                    track.Id = Guid.NewGuid();
                    track.Save();
                }

                var existing = Tracks.FirstOrDefault(t => t.Id == track.Id);

                if (existing != null)
                {
                    if (existing.Changed < track.Changed)
                    {
                        Tracks.Remove(existing);
                        Tracks.Add(track);
                    }
                }
                else
                    Tracks.Add(track);
            }
        }

        public void Add(Track track)
        {
            Tracks.Add(track);
        }

        /// <summary>
        /// Tries to find a track at the position provided. Returns null if not found
        /// </summary>
        public IEnumerable<Track> FindTracksAt(PointLatLng position)
        {
            return Tracks.Where(t => t.Area.IsInside(position));
        }

        public IEnumerable<Track> FindTracks(LogFile logFile)
        {
            var tracks = new List<Track>();

            for (int i = 0; i < logFile.Entries.Count; i += 1000)
            {
                var matches = FindTracksAt(logFile.Entries[i].GetLocation());

                tracks.AddRange(matches.Where(m => !tracks.Contains(m)));
            }

            return tracks;
        }
    }
}
