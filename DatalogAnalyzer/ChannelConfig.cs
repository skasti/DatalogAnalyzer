using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogAnalyzer
{
    public class ChannelConfig
    {
        public string Name { get; set; }
        public double ZeroPoint { get; set; }
        public double Scaling { get; set; }

        public double ArmLength { get; set; }

        public ChannelConfig(int index)
        {
            Name = $"Channel {index + 1}";
            ZeroPoint = 0.0;
            Scaling = 1.0;
            ArmLength = 0.0;
        }

        public ChannelConfig(string name, double zero, double scaling, double armLength)
        {
            Name = name;
            ZeroPoint = zero;
            Scaling = scaling;
            ArmLength = armLength;
        }

        public double Process(double rawData)
        {
            if (ArmLength > 0)
            {
                var degrees = (rawData - ZeroPoint) * Scaling;
                var radians = degrees*Math.PI/180.0;
                return (Math.Sin(radians) + 1)*ArmLength;
            }

            return (rawData - ZeroPoint)*Scaling;
        }
    }
}
