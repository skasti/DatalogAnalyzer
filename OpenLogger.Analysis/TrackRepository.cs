using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using OpenLogger.Analysis.Extensions;
using OpenLogger.Core;

namespace OpenLogger.Analysis
{
    public abstract class TrackRepository
    {
        public List<Track> Tracks { get; }

        protected TrackRepository()
        {
            Tracks = new List<Track>();
        }

        /// <summary>
        /// Load all tracks
        /// </summary>
        public abstract void Load();

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
