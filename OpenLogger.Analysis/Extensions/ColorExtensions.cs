using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLogger.Analysis.Extensions
{
    static class ColorExtensions
    {
        public static Color WithAlpha(this Color color, int alpha)
        {
            return Color.FromArgb(alpha, color);
        }
    }
}
