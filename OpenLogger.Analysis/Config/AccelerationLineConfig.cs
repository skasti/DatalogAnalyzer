using System;
using System.Collections.Generic;
using System.Drawing;
using OpenLogger.Analysis.Extensions;

namespace OpenLogger.Analysis.Config
{
    public class AccelerationLineConfig
    {
        private static AccelerationLineConfig _instance;

        public static AccelerationLineConfig Instance
        {
            get => _instance;
            set
            {
                _instance = value;
                OnInstance?.Invoke(null, _instance);
            }
        }

        public static event EventHandler<AccelerationLineConfig> OnInstance; 

        public Dictionary<AccelerationState, double> Threshold { get; set; }
        public Dictionary<AccelerationState, float> LineWidth { get; set; }
        public Dictionary<AccelerationState, float> LineOpacity { get; set; }
        public Dictionary<AccelerationState, Color> LineColor { get; set; }
        public int Smoothing { get; set; }

        public AccelerationState GetState(double acceleration)
        {
            if (acceleration > Threshold[AccelerationState.HardAcceleration])
                return AccelerationState.HardAcceleration;

            if (acceleration > Threshold[AccelerationState.MediumAcceleration])
                return AccelerationState.MediumAcceleration;

            if (acceleration > Threshold[AccelerationState.LightAcceleration])
                return AccelerationState.LightAcceleration;

            if (acceleration < Threshold[AccelerationState.HardBraking])
                return AccelerationState.HardBraking;

            if (acceleration < Threshold[AccelerationState.MediumBraking])
                return AccelerationState.MediumBraking;

            if (acceleration < Threshold[AccelerationState.LightBraking])
                return AccelerationState.LightBraking;

            return AccelerationState.Coasting;
        }

        public Pen GetPen(AccelerationState state)
        {
            return new Pen(LineColor[state].WithOpacity((int)(255*LineOpacity[state])), LineWidth[state]);
        }

        public AccelerationLineConfig Copy()
        {
            return new AccelerationLineConfig
            {
                LineColor = new Dictionary<AccelerationState, Color>(LineColor),
                LineOpacity = new Dictionary<AccelerationState, float>(LineOpacity),
                LineWidth = new Dictionary<AccelerationState, float>(LineWidth),
                Smoothing = Smoothing,
                Threshold = new Dictionary<AccelerationState, double>(Threshold)
            };
        }
    }
}