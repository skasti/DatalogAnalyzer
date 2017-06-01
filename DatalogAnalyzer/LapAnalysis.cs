using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;

namespace DatalogAnalyzer
{
    public class LapAnalysis
    {
        public Track Track { get; }
        public LogSegment Segment { get; }
        public List<LapSectionAnalysis> Sections { get; }
        public TimeSpan LapTime => Segment.Length;
        public double Distance => Segment.Distance;
        public double AverageSpeed => Segment.AverageSpeed;
        public double TopSpeed => Segment.TopSpeed;
        public double LowestSpeed => Segment.LowestSpeed;

        public LapAnalysis(Track track, LogSegment segment)
        {
            Track = track;
            Segment = segment;


            Sections = GetSections();
        }

        private List<LapSectionAnalysis> GetSections()
        {
            if (Track.Sections == null)
                return new List<LapSectionAnalysis>();

            var firstInside = Segment.Entries.First();
            var sectionIndex = -1;
            var sections = new List<LapSectionAnalysis>();

            foreach (var entry in Segment.Entries)
            {
                var latLong = new PointLatLng(entry.Latitude, entry.Longitude);
                int entrySection = GetSectionIndex(latLong);

                if ((entrySection == sectionIndex) && (sectionIndex == -1))
                    continue;

                if (entrySection != sectionIndex)
                {
                    if (sectionIndex == -1)
                    {
                        firstInside = entry;
                    }
                    else
                    {
                        var sectionSegment = Segment.SubSet(firstInside, entry);
                        var sectionAnalysis = new LapSectionAnalysis(Track, Track.Sections[sectionIndex], sectionSegment);

                        sections.Add(sectionAnalysis);
                        firstInside = entry;
                    }
                }

                sectionIndex = entrySection;
            }

            return sections;
        }

        private int GetSectionIndex(PointLatLng latLong)
        {
            for (int i = 0; i < Track.Sections.Count; i++)
            {
                if (Track.Sections[i].IsInside(latLong))
                    return i;
            }

            return -1;
        }
    }
}
