using System;

namespace DatalogAnalyzer
{
    public class ChannelConfigChangedEventArgs: EventArgs
    {
        public int Index { get; set; }
    }
}