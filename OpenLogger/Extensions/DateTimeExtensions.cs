using System;

namespace OpenLogger.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime AddMicros(this DateTime dateTime, long microseconds)
        {
            return dateTime.AddMilliseconds(microseconds/1000.0);
        }

        public static long ToUnixTimestamp(this DateTime dateTime)
        {
            return new DateTimeOffset(dateTime).ToUnixTimeSeconds();
        }
    }
}
