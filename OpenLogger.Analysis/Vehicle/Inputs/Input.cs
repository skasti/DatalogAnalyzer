using System;
using System.Collections.Generic;
using System.Linq;
using OpenLogger.Analysis.Analyses;
using OpenLogger.Analysis.Extensions;
using OpenLogger.Analysis.Vehicle.Inputs.Transforms;
using OpenLogger.Core;

namespace OpenLogger.Analysis.Vehicle.Inputs
{
    public class Input
    {
        public string Name { get; set; }
        public InputSource Source { get; set; }
        public GraphType GraphType { get; set; }
        public InputXAxis XAxisType { get; set; } = InputXAxis.Distance;
        public double GraphMin { get; set; }
        public double GraphMax { get; set; }
        public bool AutoGraphRange { get; set; }
        public int AnalogSource { get; set; }
        public List<IInputTransform> Transforms { get; set; } = new List<IInputTransform>();
        public List<IDataAnalysis> Analyses { get; set; } = new List<IDataAnalysis>();

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
                ResetSmoothing();
            }
        }

        private int _bufferPosition = 0;
        private double[] _ringBuffer;

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

        private double Transform(double input, IInputTransform lastTransform)
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

        public List<DataPoint> Smooth(IEnumerable<DataPoint> rawData)
        {
            ResetSmoothing();

            return rawData.Select(r => new DataPoint(r.X, Smooth(r.Y))).ToList();
        }

        public List<DataPoint> Transform(IEnumerable<DataPoint> rawData, IInputTransform lastTransform)
        {
            return rawData.Select(r => new DataPoint(r.X, Transform(r.Y, lastTransform))).ToList();
        }

        private void ResetSmoothing()
        {
            _ringBuffer = new double[_smoothing];

            for (int i = 0; i < _smoothing; i++)
                _ringBuffer[i] = 0.0;

            _bufferPosition = 0;
        }

        public List<DataPoint> Extract(LogSegment segment, IInputTransform lastTransform = null)
        {
            var data = ExtractRaw(segment);
            var smooth = Smooth(data);
            return Transform(smooth, lastTransform);
        }

        public List<DataPoint> ExtractRaw(LogSegment segment)
        {
            return segment.Entries.Select(entry => new DataPoint(GetXValue(entry, segment),GetRawValue(entry))).ToList();
        }

        private double GetXValue(LogEntry entry, LogSegment segment)
        {
            switch (XAxisType)
            {
                case InputXAxis.Time:
                    return entry.GetTimeSpan(segment.LogStart).TotalSeconds;
                case InputXAxis.Distance:
                    return entry.GetDistance(segment);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Input Copy()
        {
            var copy = new Input
            {
                AnalogSource = AnalogSource,
                Smoothing = Smoothing,
                Name = Name,
                Source = Source,
                GraphType = GraphType,
                GraphMin = GraphMin,
                GraphMax = GraphMax,
                AutoGraphRange = AutoGraphRange,
                XAxisType = XAxisType
            };

            foreach (var transform in Transforms)
            {
                copy.Transforms.Add(transform.Copy());
            }

            foreach (var analysis in Analyses)
            {
                copy.Analyses.Add(analysis.Copy());
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
            input.Analyses = Analyses;
            input.AutoGraphRange = AutoGraphRange;
            input.GraphMin = GraphMin;
            input.GraphMax = GraphMax;
            input.XAxisType = XAxisType;
        }
    }
}
