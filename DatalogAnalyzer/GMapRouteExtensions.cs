using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace DatalogAnalyzer
{
    public static class GMapRouteExtensions
    {
        public static double GetDistance(this GMapRoute route)
        {
            var distance = 0.0;
            PointLatLng prevPoint = route.Points.First();

            for (int i = 1; i < route.Points.Count; i++)
            {
                var point = route.Points[i];

                distance += prevPoint.GetDistance(point);
                prevPoint = point;
            }

            return distance * 0.001;
        }
    }
}
