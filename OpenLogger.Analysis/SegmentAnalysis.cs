using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GMap.NET.WindowsForms;
using OpenLogger.Analysis.Config;
using OpenLogger.Analysis.Extensions;
using OpenLogger.Analysis.Metadata;
using OpenLogger.Core;

namespace OpenLogger.Analysis
{
    public class SegmentAnalysis
    {
        public Color SegmentColor { get; } = RandomColors.GetNext();
        public string Name { get; set; }
        public LogSegment Segment { get; }
        public List<GPSDataPoint> GPSData { get; set; }
        public GMapRoute Route { get; private set; }
        public List<GMapRoute> AccelerationRoutes { get; private set; }
        public double Distance => Route.Distance;
        public TimeSpan Time => Segment.Length;

        public double AverageSpeed => Distance / Time.TotalHours;
        public double TopSpeed { get; private set; }
        public double LowestSpeed { get; private set; }

        public event EventHandler<SegmentAnalysis> OnRoutes;

        public SegmentAnalysis(LogSegment segment, string name, bool generateGPSData = true)
        {
            Name = name;
            Segment = segment;

            var viableSpeedEntries = segment.Entries.Where(e => e.SpeedAccuracy < 5).ToList();

            if (viableSpeedEntries.Any())
            {
                TopSpeed = viableSpeedEntries.Max(e => e.Speed);
                LowestSpeed = viableSpeedEntries.Min(e => e.Speed);
            }
            else
            {
                TopSpeed = 0;
                LowestSpeed = 0;
            }

            if (generateGPSData)
                GenerateGPSData();
        }

        public void GenerateGPSData()
        {
            double prevLat = 0, prevLong = 0, prevSpeed = -1, prevAcceleration = -1000;
            uint prevMicroseconds = 0;
            GPSDataPoint gpsData = null;
            GPSData = new List<GPSDataPoint>();

            foreach (var entry in Segment.Entries)
            {
                // ReSharper disable CompareOfFloatsByEqualityOperator
                if ((gpsData != null) && (entry.Latitude == prevLat) && (entry.Longitude == prevLong)) // ReSharper restore CompareOfFloatsByEqualityOperator
                {
                    gpsData.Entries.Add(entry);
                    continue;
                }

                gpsData = new GPSDataPoint(entry);

                if (entry.SpeedAccuracy < 5)
                {
                    if (prevSpeed > 0)
                    {
                        var speedDelta = ((entry.Speed - prevSpeed) / 3.6); // Change in speed in m/s
                        var timeDelta = TimeSpan.FromMilliseconds((entry.Microseconds - prevMicroseconds) / 1000.0)
                            .TotalSeconds; // Time since last measurement in seconds
                        var acceleration = speedDelta / timeDelta; // Acceleration as m/s^2

                        gpsData.Acceleration = acceleration;
                        prevAcceleration = acceleration;
                    }
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    else if (prevAcceleration != -1000)
                    {
                        gpsData.Acceleration = prevAcceleration;
                    }
                    else
                    {
                        gpsData.Acceleration = 0;
                    }
                }
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                else if (prevAcceleration != -1000)
                {
                    gpsData.Acceleration = prevAcceleration;
                }
                else
                {
                    gpsData.Acceleration = 0;
                }

                prevSpeed = gpsData.Speed;
                prevLat = entry.Latitude;
                prevLong = entry.Longitude;
                prevMicroseconds = entry.Microseconds;

                GPSData.Add(gpsData);
            }
        }

        public void CalculateRoutes(Track currentTrack, bool calculateAccelerationRoutes = true)
        {
            Route = GPSData.GetRoute(Name, new Pen(Color.White, 2.0f), currentTrack);

            if (calculateAccelerationRoutes)
                CalculateAccelerationRoutes(currentTrack);

            OnRoutes?.Invoke(this, this);
        }

        public void CalculateAccelerationRoutes(Track currentTrack)
        {
            AccelerationRoutes = new List<GMapRoute>();

            GMapRoute currentRoute = null;
            var prevAccelerationState = AccelerationState.Coasting;

            var smoothingBuffer = new[] {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0};
            var smoothingIndex = 0;

            var lineConfig = AccelerationLineConfig.Instance;

            foreach (var gpsPoint in GPSData)
            {
                smoothingBuffer[smoothingIndex++] = gpsPoint.Acceleration;

                if (smoothingIndex >= smoothingBuffer.Length)
                    smoothingIndex = 0;

                var acceleration = smoothingBuffer.Average();

                var accelerationState = lineConfig.GetState(acceleration);

                if (currentRoute == null || accelerationState != prevAccelerationState)
                {
                    currentRoute?.Points.Add(gpsPoint.GetLocation(currentTrack));

                    // ReSharper disable once UseObjectOrCollectionInitializer
                    currentRoute = new GMapRoute($"Acceleration {AccelerationRoutes.Count}");
                    currentRoute.Stroke = lineConfig.GetPen(accelerationState);
                    currentRoute.Points.Add(gpsPoint.GetLocation(currentTrack));

                    prevAccelerationState = accelerationState;

                    AccelerationRoutes.Add(currentRoute);
                }
                else
                {
                    currentRoute.Points.Add(gpsPoint.GetLocation(currentTrack));
                }
            }

            OnRoutes?.Invoke(this, this);
        }
    }
}
