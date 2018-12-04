using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;
using OpenLogger.Analysis.Metadata;

namespace OpenLogger.Analysis.Extensions
{
    public static class MetadataExtensions
    {
        public static T PopulateSegmentMetadata<T>(this T metadata, SegmentAnalysis analysis) where T: SegmentMetadata
        {
            metadata.LogStart = analysis.Segment.LogStart;
            metadata.Name = analysis.Name;
            metadata.Distance = analysis.Distance;
            metadata.Line = analysis.GPSData.Select(p => new GPSPosition
            {
                Latitude = p.Latitude,
                Longitude = p.Longitude,
                Microseconds = p.Microseconds
            });
            metadata.LowestSpeed = analysis.LowestSpeed;
            metadata.TopSpeed = analysis.TopSpeed;
            metadata.AverageSpeed = analysis.AverageSpeed;
            metadata.Time = analysis.Time;

            return metadata;
        }
        public static SegmentMetadata GetSegmentMetadata(this SegmentAnalysis analysis)
        {
            return new SegmentMetadata().PopulateSegmentMetadata(analysis);
        }

        public static LapMetadata GetLapMetadata(this LapAnalysis analysis)
        {
            var metadata = new LapMetadata().PopulateSegmentMetadata(analysis);
            return metadata;
        }

        public static SessionMetadata GetSessionMetadata(this SessionAnalysis analysis)
        {
            var metadata = new SessionMetadata().PopulateSegmentMetadata(analysis.Full);
            metadata.Laps = analysis.Laps?.Select(l => l.GetLapMetadata());
            metadata.LeadIn = analysis.LeadIn?.GetSegmentMetadata();
            metadata.LeadOut = analysis.LeadOut?.GetSegmentMetadata();
            metadata.CombinedLaps = analysis.CombinedLaps?.GetSegmentMetadata();
            metadata.Name = analysis.LogFile.Filename;

            return metadata;
        }

        public static SegmentAccelerationPaths GetAccelerationPaths(this SegmentAnalysis analysis, string configPath, DateTime generated)
        {
            return new SegmentAccelerationPaths
            {
                AccelerationPaths = analysis.AccelerationRoutes.Select(r => r.ToGPSPath()),
                ConfigPath = configPath,
                Generated = generated
            };
        }

        public static GPSPath ToGPSPath(this GMapRoute route)
        {
            return new GPSPath
            {
                Color = route.Stroke.Color,
                LineWidth = route.Stroke.Width,
                Opacity = route.Stroke.Color.A / 255.0f,
                Points = route.Points
                    .Select(p => new GPSPosition {Latitude = p.Lat, Longitude = p.Lng, Microseconds = 0})
            };
        }
    }
}
