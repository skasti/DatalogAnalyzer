using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;
using OpenLogger.Core;

namespace OpenLogger.Analysis.Extensions
{
    public static class LogSegmentExtensions
    {
        public static GMapRoute GetRoute(this LogSegment segment, string name, Pen stroke = null)
        {
            var route = new GMapRoute(name);
            route.Stroke = stroke ?? route.Stroke;

            PointLatLng prevPos = PointLatLng.Empty;
           
            foreach (var entry in segment.Entries.Where(e => e.HorizontalAccuracy < 10))
            {
                var entryPos = entry.GetLocation();

                if (entryPos == prevPos)
                    continue;

                route.Points.Add(entryPos);
                prevPos = entryPos;
            }

            return route;
        }
    }
}
