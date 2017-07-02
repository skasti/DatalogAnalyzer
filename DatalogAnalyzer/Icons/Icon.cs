using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogAnalyzer.Icons
{
    public class Icon
    {
        public Image Image { get; }
        public int Index { get; }
        public string Title { get; }

        public Icon(string fileName)
        {
            Image = Image.FromFile(fileName);

            var imageFileName = Path.GetFileNameWithoutExtension(fileName)?.Split(' ') ?? new[] {"0", "NA"};
            Index = int.Parse(imageFileName[0]);
            Title = imageFileName[1];
        }
    }
}
