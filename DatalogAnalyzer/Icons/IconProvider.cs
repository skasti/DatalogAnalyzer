using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatalogAnalyzer.Icons
{
    public static class IconProvider
    {
        public static List<Icon> Icons = new List<Icon>();

        private static void LoadIcons()
        {
            var iconFiles = Directory.GetFiles("Icons", "*.png");
            foreach (var iconFile in iconFiles)
            {
                var icon = new Icon(iconFile);
                Icons.Add(icon);
            }
        }

        public static void PopulateImageList(ImageList imageList)
        {
            if (!Icons.Any())
                LoadIcons();

            imageList.Images.Clear();
            imageList.Images.AddRange(Icons.OrderBy(i => i.Index).Select(i => i.Image).ToArray());
        }
    }
}
