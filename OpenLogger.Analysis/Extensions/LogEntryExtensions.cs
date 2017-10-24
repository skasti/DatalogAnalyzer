using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
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
    }
}
