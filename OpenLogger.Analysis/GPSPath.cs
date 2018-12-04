using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLogger.Analysis
{
    public class GPSPath
    {
        public  IEnumerable<GPSPosition> Points { get; set; }
        public Color Color { get; set; }
        public float LineWidth { get; set; }
        public float Opacity { get; set; }
    }
}
