using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;

namespace DatalogAnalyzer
{
    public static class OverlayExtensions
    {
        public static void Refresh(this GMapOverlay overlay)
        {
            overlay.IsVisibile = false;
            overlay.IsVisibile = true;
        }
    }
}
