using System.Collections.Generic;
using System.Drawing;
using OpenLogger.Analysis.Extensions;

namespace OpenLogger.Analysis.Config
{
    public class AccelerationLineConfig
    {
        public static AccelerationLineConfig Instance { get; set; }
        public Dictionary<AccelerationState, double> Thresholds { get; set; }
        public Dictionary<AccelerationState, float> LineWidth { get; set; }
        public Dictionary<AccelerationState, float> LineOpacities { get; set; }
        public Dictionary<AccelerationState, Color> LineColors { get; set; }
        public int Smoothing { get; set; }

        public AccelerationState GetState(double acceleration)
        {
            if (acceleration > Thresholds[AccelerationState.HardAcceleration])
                return AccelerationState.HardAcceleration;

            if (acceleration > Thresholds[AccelerationState.MediumAcceleration])
                return AccelerationState.MediumAcceleration;

            if (acceleration > Thresholds[AccelerationState.LightAcceleration])
                return AccelerationState.LightAcceleration;

            if (acceleration < Thresholds[AccelerationState.HardBraking])
                return AccelerationState.HardBraking;

            if (acceleration < Thresholds[AccelerationState.MediumBraking])
                return AccelerationState.MediumBraking;

            if (acceleration < Thresholds[AccelerationState.LightBraking])
                return AccelerationState.LightBraking;

            return AccelerationState.Coasting;
        }

        public Pen GetPen(AccelerationState state)
        {
            return new Pen(LineColors[state].WithOpacity((int)(255*LineOpacities[state])), LineWidth[state]);
        }
    }
}