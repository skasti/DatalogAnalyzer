using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;
using OpenLogger.Core;

namespace OpenLogger.Analysis.Extensions
{
    public static class GPSDataPointExtensions
    {
        public static GMapRoute GetRoute(this List<GPSDataPoint> gpsData, string name, Pen stroke = null, Track currentTrack = null)
        {
            var route = new GMapRoute(name);
            route.Stroke = stroke ?? route.Stroke;

            PointLatLng prevPos = PointLatLng.Empty;

            foreach (var entry in gpsData.Where(e => e.HorizontalAccuracy < 10))
            {
                var entryPos = entry.GetLocation(currentTrack);

                if (entryPos == prevPos)
                    continue;

                route.Points.Add(entryPos);
                prevPos = entryPos;
            }

            return route;
        }

        public static PointLatLng GetLocation(this GPSDataPoint gpsData, Track currentTrack = null)
        {
            if (currentTrack == null)
                return new PointLatLng(gpsData.Latitude, gpsData.Longitude);

            return new PointLatLng(gpsData.Latitude + currentTrack.GpsCorrection.Lat, gpsData.Longitude + currentTrack.GpsCorrection.Lng);
        }
    }
}
