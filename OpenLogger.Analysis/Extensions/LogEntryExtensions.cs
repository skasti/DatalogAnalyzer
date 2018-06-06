using System.Collections.Generic;
using GMap.NET;
using GMap.NET.WindowsForms;
using OpenLogger.Core;

namespace OpenLogger.Analysis.Extensions
{
    public static class LogEntryExtensions
    {
        public static PointLatLng GetLocation(this IHavePosition entry, Track currentTrack = null)
        {
            // I find this more readable in this form, so I have disabled resharpers nagging
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (currentTrack == null)
                return new PointLatLng(entry.Latitude, entry.Longitude);

            return new PointLatLng(entry.Latitude + currentTrack.GpsCorrection.Lat, entry.Longitude + currentTrack.GpsCorrection.Lng);
        }

        private static readonly Dictionary<IHavePosition, Dictionary<LogSegment, double>> Distances = new Dictionary<IHavePosition, Dictionary<LogSegment, double>>();
        private static readonly Dictionary<LogSegment, GMapRoute> DistanceRoutes = new Dictionary<LogSegment, GMapRoute>();
        private static readonly Dictionary<LogSegment, PointLatLng> PreviousPositions = new Dictionary<LogSegment, PointLatLng>();
        private static readonly Dictionary<LogSegment, double> PreviousDistances = new Dictionary<LogSegment, double>();

        public static double GetDistance(this IHavePosition entry, LogSegment segment)
        {
            if (Distances.ContainsKey(entry) && Distances[entry].ContainsKey(segment))
                return Distances[entry][segment];

            if (!DistanceRoutes.ContainsKey(segment))
                DistanceRoutes.Add(segment, new GMapRoute("DistanceRoute"));

            var route = DistanceRoutes[segment];

            var position = entry.GetLocation();

            var prevPosition = PointLatLng.Empty;

            if (PreviousPositions.ContainsKey(segment))
                prevPosition = PreviousPositions[segment];

            var distance = 0.0;

            if (PreviousDistances.ContainsKey(segment))
                distance = PreviousDistances[segment];

            if (position != prevPosition)
            {
                route.Points.Add(position);
                distance = route.Distance*1000;
                PreviousDistances[segment] = distance;
                PreviousPositions[segment] = position;
            }

            if (!Distances.ContainsKey(entry))
                Distances.Add(entry, new Dictionary<LogSegment, double>());

            Distances[entry].Add(segment, distance);

            return distance;
        }
    }
}
