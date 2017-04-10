using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;

namespace DatalogAnalyzer
{
    public class ChannelConfig
    {
        public string Name { get; set; }
        public double ZeroPoint { get; set; }
        public double Scaling { get; set; }

        public bool IsTemperature { get; set; }

        public double Arm1Length { get; set; }
        public double Arm2Length { get; set; }
        public double ArmAxisDistance { get; set; }

        [JsonIgnore]
        public Series ChartSeries { get; set; }

        public ChannelConfig(int index)
        {
            Name = $"Channel {index + 1}";
            ZeroPoint = 0.0;
            Scaling = 1.0;
            Arm1Length = 0.0;
            Arm2Length = 0.0;
            ArmAxisDistance = 0.0;

            if (index < 6)
                IsTemperature = true;
        }

        [JsonConstructor]
        public ChannelConfig(string name, double zero, double scaling, bool isTemperature, double arm1Length,
            double arm2Length, double armAxisDistance)
        {
            Name = name;
            ZeroPoint = zero;
            Scaling = scaling;
            IsTemperature = isTemperature;
            Arm1Length = arm1Length;
            Arm2Length = arm2Length;
            ArmAxisDistance = armAxisDistance;
        }

        public double Process(double rawData)
        {
            if (Arm1Length > 0)
            {
                var degrees = (rawData - ZeroPoint)*Scaling;
                var radians = degrees*Math.PI/180.0;

                var arm1Sin = Math.Sin(radians);
                var arm1X = Math.Cos(radians)*Arm1Length;

                if (Arm2Length == 0.0)
                    return (Math.Sin(radians) + 1)*Arm1Length;

                var arm2Cos = (arm1X - ArmAxisDistance)/Arm2Length;
                var arm2Sin = Math.Sqrt(1 - Math.Pow(arm2Cos, 2));

                return arm2Sin * Arm2Length + arm1Sin * Arm1Length;
            }

            return (rawData - ZeroPoint)*Scaling;
        }

        public bool Copy(ChannelConfig from)
        {
            var changed = false;

            if (IsTemperature != from.IsTemperature)
            {
                IsTemperature = from.IsTemperature;
                changed = true;
            }

            if (Name != from.Name)
            {
                Name = from.Name;
                changed = true;
            }

            if (ZeroPoint != from.ZeroPoint)
            {
                ZeroPoint = from.ZeroPoint;
                changed = true;
            }

            if (Scaling != from.Scaling)
            {
                Scaling = from.Scaling;
                changed = true;
            }

            if (Arm1Length != from.Arm1Length)
            {
                Arm1Length = from.Arm1Length;
                changed = true;
            }

            if (Arm2Length != from.Arm2Length)
            {
                Arm2Length = from.Arm2Length;
                changed = true;
            }

            if (ArmAxisDistance != from.ArmAxisDistance)
            {
                ArmAxisDistance = from.ArmAxisDistance;
                changed = true;
            }

            return changed;
        }
    }
}