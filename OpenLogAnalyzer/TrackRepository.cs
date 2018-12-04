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
    public class TrackRepository: OpenLogger.Analysis.TrackRepository
    {

        public TrackRepository()
        {

        }

        /// <summary>
        /// Load all tracks
        /// </summary>
        public override void Load()
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
    }
}
