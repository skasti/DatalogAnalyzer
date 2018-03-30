using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLogger.Analysis.Vehicle.Inputs.Transforms
{
    public class AngleBasedForkPositionTransform: InputTransform
    {
        /// <summary>
        /// Distance from center of fork leg to center of sensor
        /// </summary>
        public double SensorForkDistance { get; set; } = 50.0;

        /// <summary>
        /// Length of secondary arm in millimeters
        /// </summary>
        public double Arm2Length { get; set; } = 100.0;

        /// <summary>
        /// Length of primary arm in millimeters
        /// </summary>
        public double Arm1Length { get; set; } = 100.0;

        /// <summary>
        /// Distance from center of upper fork-leg mount to tip of dust-seal in millimeters
        /// </summary>
        public double UpperForkLegOffset { get; set; } = 30.0;

        /// <summary>
        /// Distance from bottom-out to sensor-center in millimeters
        /// </summary>
        public double BottomOutToSensorOffset { get; set; } = 10.0;

        public double Transform(double input)
        {
            var arm1Pos = GetArm1Position(input);
            var arm2Pos = GetArm2Position(arm1Pos);

            return arm2Pos.Item2 - UpperForkLegOffset + BottomOutToSensorOffset;
        }

        public InputTransform Copy()
        {
            return new AngleBasedForkPositionTransform
            {
                Arm1Length = Arm1Length,
                Arm2Length = Arm2Length,
                SensorForkDistance = SensorForkDistance,
                BottomOutToSensorOffset = BottomOutToSensorOffset,
                UpperForkLegOffset = UpperForkLegOffset
            };
        }

        public Tuple<double, double> GetArm1Position(double degrees)
        {
            var radians = degrees * Math.PI / 180.0;

            var arm1Sin = Math.Sin(radians);
            var arm1X = Math.Cos(radians) * Arm1Length;
            var arm1Y = arm1Sin * Arm1Length;

            return new Tuple<double, double>(arm1X,arm1Y);
        }

        public Tuple<double, double> GetArm2Position(Tuple<double, double> arm1Pos)
        {
            var arm2Cos = (arm1Pos.Item1 - SensorForkDistance) / Arm2Length;
            var arm2Sin = Math.Sqrt(1 - Math.Pow(arm2Cos, 2));

            var arm2X = arm1Pos.Item1 - arm2Cos*Arm2Length;
            var arm2Y = arm1Pos.Item2 + arm2Sin*Arm2Length;

            if (double.IsNaN(arm2Y))
                arm2Y = arm1Pos.Item2;

            if (double.IsNaN(arm2X))
                arm2X = arm1Pos.Item1;

            return new Tuple<double, double>(arm2X, arm2Y);
        }

        public override string ToString()
        {
            return $"Fork position [{Arm1Length}/{Arm2Length}]";
        }
    }
}
