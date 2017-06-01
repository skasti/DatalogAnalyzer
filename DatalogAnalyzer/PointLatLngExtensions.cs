using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;

namespace DatalogAnalyzer
{
    public static class PointLatLngExtensions
    {
        public static float GetDistance(this PointLatLng a, PointLatLng b)
        {
            double earthRadius = 3958.75;
            double latDiff = ToRadians(b.Lat - a.Lat);
            double lngDiff = ToRadians(b.Lng - a.Lng);
            double d = Math.Sin(latDiff / 2) * Math.Sin(latDiff / 2) +
            Math.Cos(ToRadians(a.Lat)) * Math.Cos(ToRadians(b.Lat)) *
            Math.Sin(lngDiff / 2) * Math.Sin(lngDiff / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(d), Math.Sqrt(1 - d));
            double distance = earthRadius * c;

            float meterConversion = 1609f;

            return (float) distance*meterConversion;
        }

        private static double ToRadians(double angleDegreees)
        {
            return angleDegreees*Math.PI/180;
        }
    }
}
