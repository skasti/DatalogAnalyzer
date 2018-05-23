using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLogger.Analysis.Extensions
{
    public static class ColorExtensions
    {
        public static Color WithOpacity(this Color color, int opacity)
        {
            return Color.FromArgb(opacity, color);
        }

        public static Color WithOpacity(this Color color, float opacity)
        {
            return Color.FromArgb((int)(opacity*255), color);
        }
    }
}
