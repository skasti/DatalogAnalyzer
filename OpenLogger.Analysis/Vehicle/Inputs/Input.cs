using System;
using System.Linq;
using OpenLogger.Core;

namespace OpenLogger.Analysis.Vehicle.Inputs
{
    public class Input
    {
        public string Name { get; set; }
        public InputSource Source { get; set; }
        public InputGraphType GraphType { get; set; }
        public int AnalogSource { get; set; }

        private int _smoothing = 0;

        public int Smoothing
        {
            get
            {
                return _smoothing;
            }
            set
            {
                _smoothing = value;
                _ringBuffer = new double[_smoothing];

                for (int i = 0; i < _smoothing; i++)
                    _ringBuffer[i] = 0.0;

                _bufferPosition = 0;
            }
        }

        private int _bufferPosition = 0;
        private double[] _ringBuffer;

        public double GetValue(LogEntry entry)
        {
            switch (Source)
            {
                case InputSource.Speed:
                    return Smooth(entry.Speed);
                case InputSource.Altitude:
                    return Smooth(entry.Altitude);
                case InputSource.HorizontalAccuracy:
                    return Smooth(entry.HorizontalAccuracy);
                case InputSource.VerticalAccuracy:
                    return Smooth(entry.VerticalAccuracy);
                case InputSource.FixType:
                    return Smooth(entry.FixType);
                case InputSource.Temperature:
                {
                    if ((AnalogSource >= 6) || (AnalogSource < 0))
                        return 0.0;

                    return Smooth(entry.Values[AnalogSource]);
                }
                case InputSource.Analog:
                {
                    if ((AnalogSource >= entry.Values.Count - 6) || (AnalogSource < 0))
                        return 0.0;

                    return Smooth(entry.Values[AnalogSource + 6]);
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private double Smooth(double value)
        {
            if (Smoothing <= 1)
                return value;

            _ringBuffer[_bufferPosition++] = value;
            _bufferPosition = _bufferPosition >= _smoothing ? 0 : _bufferPosition;

            return _ringBuffer.Average();
        }
    }
}
