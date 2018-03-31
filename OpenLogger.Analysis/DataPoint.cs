using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLogger.Analysis
{
    public class DataPoint
    {
        public double X;
        public double Y;

        public DataPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
