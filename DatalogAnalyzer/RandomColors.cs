using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogAnalyzer
{
    public class RandomColors
    {
        static Color lastColor = Color.Empty;

        static KnownColor[] colorValues = (KnownColor[])Enum.GetValues(typeof(KnownColor));

        static Random rnd = new Random();
        const int MaxColor = 256;
        static RandomColors()
        {
            lastColor = Color.FromArgb(rnd.Next(MaxColor), rnd.Next(MaxColor), rnd.Next(MaxColor));
        }

        public static Color[] Generate(int n)
        {
            var colors = new Color[n];
            if (n <= colorValues.Length)
            {
                // known color suggestion from TAW
                // http://stackoverflow.com/questions/37234131/how-to-generate-randomly-colors-that-is-easily-recognizable-from-each-other#comment61999963_37234131
                var step = (colorValues.Length - 1) / n;
                var colorIndex = step;
                step = step == 0 ? 1 : step; // hacky
                for (int i = 0; i < n; i++)
                {
                    colors[i] = Color.FromKnownColor(colorValues[colorIndex]);
                    colorIndex += step;
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    colors[i] = GetNext();
                }
            }

            return colors;
        }

        /// <summary>
        /// Gets a new random color based of the last one.
        /// Use color parameter to get a color similar to a base.
        /// </summary>
        /// <param name="color">Base color on this one</param>
        /// <returns></returns>
        public static Color GetNext(Color? color = null)
        {
            if (color != null)
                lastColor = color.Value;

            // use the previous value as a mix color as demonstrated by David Crow
            // http://stackoverflow.com/a/43235/578411
            Color nextColor = Color.FromArgb(
                (rnd.Next(MaxColor) + lastColor.R + lastColor.R) / 3,
                (rnd.Next(MaxColor) + lastColor.G + lastColor.G) / 3,
                (rnd.Next(MaxColor) + lastColor.B + lastColor.B) / 3
                );
            lastColor = nextColor;
            return nextColor;
        }
    }
}
