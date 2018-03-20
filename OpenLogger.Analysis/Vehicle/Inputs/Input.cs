﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenLogger.Analysis.Vehicle.Inputs.Transforms;
using OpenLogger.Core;

namespace OpenLogger.Analysis.Vehicle.Inputs
{
    public class Input
    {
        public string Name { get; set; }
        public InputSource Source { get; set; }
        public InputGraphType GraphType { get; set; }
        public int AnalogSource { get; set; }
        public List<InputTransform> Transforms { get; set; } = new List<InputTransform>();

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

        public double GetValue(LogEntry entry, InputTransform LastTransform = null)
        {
            var smoothed = GetSmoothedValue(entry);
            return Transform(smoothed, LastTransform);
        }

        public double GetSmoothedValue(LogEntry entry)
        {
            var rawValue = GetRawValue(entry);
            var smoothed = Smooth(rawValue);
            return smoothed;
        }

        public double GetRawValue(LogEntry entry)
        {
            double rawValue = 0.0;
            switch (Source)
            {
                case InputSource.Speed:
                    rawValue = entry.Speed;
                    break;
                case InputSource.Altitude:
                    rawValue = entry.Altitude;
                    break;
                case InputSource.HorizontalAccuracy:
                    rawValue = entry.HorizontalAccuracy;
                    break;
                case InputSource.VerticalAccuracy:
                    rawValue = entry.VerticalAccuracy;
                    break;
                case InputSource.FixType:
                    rawValue = entry.FixType;
                    break;
                case InputSource.Temperature:
                {
                    if ((AnalogSource < 6) && (AnalogSource >= 0))
                        rawValue = entry.Values[AnalogSource];

                    break;
                }
                case InputSource.Analog:
                {
                    if ((AnalogSource < entry.Values.Count - 6) && (AnalogSource >= 0))
                        rawValue = entry.Values[AnalogSource + 6];

                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException();
            }
            return rawValue;
        }

        private double Transform(double input, InputTransform lastTransform)
        {
            var current = input;
            foreach (var transform in Transforms)
            {
                current = transform.Transform(current);

                if (transform == lastTransform)
                    break;
            }

            return current;
        }

        private double Smooth(double value)
        {
            if (Smoothing <= 1)
                return value;

            _ringBuffer[_bufferPosition++] = value;
            _bufferPosition = _bufferPosition >= _smoothing ? 0 : _bufferPosition;

            return _ringBuffer.Average();
        }

        public Input Copy()
        {
            var copy = new Input
            {
                AnalogSource = AnalogSource,
                Smoothing = Smoothing,
                Name = Name,
                Source = Source,
                GraphType = GraphType
            };

            foreach (var transform in Transforms)
            {
                copy.Transforms.Add(transform.Copy());
            }

            return copy;
        }

        public void SaveTo(Input input)
        {
            input.AnalogSource = AnalogSource;
            input.Source = Source;
            input.GraphType = GraphType;
            input.Name = Name;
            input.Smoothing = Smoothing;
            input.Transforms = Transforms;
        }
    }
}
