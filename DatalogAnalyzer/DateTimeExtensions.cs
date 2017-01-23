using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogAnalyzer
{
    public static class DateTimeExtensions
    {
        public static DateTime AddMicros(this DateTime dateTime, long microseconds)
        {
            return dateTime.AddMilliseconds(microseconds/1000.0);
        }
    }
}
