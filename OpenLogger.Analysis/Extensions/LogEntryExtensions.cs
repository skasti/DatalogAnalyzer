using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;
using OpenLogger.Core;

namespace OpenLogger.Analysis.Extensions
{
    public static class LogEntryExtensions
    {
        public static PointLatLng GetLocation(this LogEntry entry, Track currentTrack = null)
        {
            if (currentTrack == null)
                return new PointLatLng(entry.Latitude, entry.Longitude);

            return new PointLatLng(entry.Latitude + currentTrack.GpsCorrection.Lat, entry.Longitude + currentTrack.GpsCorrection.Lng);
        }

        static Dictionary<LogEntry, Dictionary<LogSegment, double>> _distances = new Dictionary<LogEntry, Dictionary<LogSegment, double>>(); 
        static Dictionary<LogSegment, GMapRoute> _distanceRoutes = new Dictionary<LogSegment, GMapRoute>();
        static Dictionary<LogSegment, PointLatLng> _previousPositions = new Dictionary<LogSegment, PointLatLng>();
        static Dictionary<LogSegment, double> _previousDistances = new Dictionary<LogSegment, double>();

        public static double GetDistance(this LogEntry entry, LogSegment segment)
        {
            if (_distances.ContainsKey(entry) && _distances[entry].ContainsKey(segment))
                return _distances[entry][segment];

            if (!_distanceRoutes.ContainsKey(segment))
                _distanceRoutes.Add(segment, new GMapRoute("DistanceRoute"));

            var route = _distanceRoutes[segment];

            var position = entry.GetLocation();

            var prevPosition = PointLatLng.Empty;

            if (_previousPositions.ContainsKey(segment))
                prevPosition = _previousPositions[segment];

            var distance = 0.0;

            if (_previousDistances.ContainsKey(segment))
                distance = _previousDistances[segment];

            if (position != prevPosition)
            {
                route.Points.Add(position);
                distance = route.Distance*1000;
                _previousDistances[segment] = distance;
                _previousPositions[segment] = position;
            }

            if (!_distances.ContainsKey(entry))
                _distances.Add(entry, new Dictionary<LogSegment, double>());

            _distances[entry].Add(segment, distance);

            return distance;
        }
    }
}
