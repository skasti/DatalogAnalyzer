using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using OpenLogger.Analysis;
using OpenLogger.Analysis.Extensions;

namespace OpenLogAnalyzer
{
    public class RenderingController
    {
        public Track Track { get; set; }
        public List<SegmentAnalysis> RenderedSegments { get; } = new List<SegmentAnalysis>();

        public Dictionary<SegmentAnalysis, GMapMarker> RenderedSegmentMarkers { get; } =
            new Dictionary<SegmentAnalysis, GMapMarker>();

        public Dictionary<SegmentAnalysis, GMapRoute> Routes { get; } = new Dictionary<SegmentAnalysis, GMapRoute>();
        public Dictionary<SegmentAnalysis, List<GMapRoute>> AccelerationRoutes { get; } = new Dictionary<SegmentAnalysis, List<GMapRoute>>();
        public IEnumerable<GMapMarker> Markers => RenderedSegmentMarkers.Values;
        public event EventHandler<IEnumerable<GMapRoute>> OnRoutes;
        public event EventHandler<IEnumerable<GMapMarker>> OnMarkers;

        private int _markerIndex = 0;

        public int MarkerIndex
        {
            get { return _markerIndex; }
            set
            {
                _markerIndex = value;
                _markerDistance = -1;
                UpdateMarkerPositionsByIndex();
            }
        }

        private void UpdateMarkerPositionsByIndex()
        {
            foreach (var segment in RenderedSegments)
            {
                if (!RenderedSegmentMarkers.ContainsKey(segment))
                    continue;

                if (segment.Segment.Entries.Count > _markerIndex)
                    RenderedSegmentMarkers[segment].Position = segment.Segment.Entries[_markerIndex].GetLocation(Track);
                else
                    RenderedSegmentMarkers[segment].Position = segment.Segment.Entries.Last().GetLocation(Track);
            }

            OnMarkers?.Invoke(this, Markers);
        }

        private int _markerDistance = 0;

        public int MarkerDistance
        {
            get { return _markerDistance; }
            set
            {
                _markerDistance = value;
                _markerIndex = -1;
                UpdateMarkerPositionsByDistance();
            }
        }

        private void UpdateMarkerPositionsByDistance()
        {
            foreach (var segment in RenderedSegments)
            {
                if (!RenderedSegmentMarkers.ContainsKey(segment))
                    continue;

                if (segment.Route.Distance > _markerDistance)
                    RenderedSegmentMarkers[segment].Position = segment.Segment.Entries.Last().GetLocation(Track);
                else
                {
                    var route = new GMapRoute("DistanceRoute");
                    var prevPos = new PointLatLng(0,0);

                    for (int i = 1; i < segment.Segment.Entries.Count; i++)
                    {
                        var entry = segment.Segment.Entries[i];
                        var location = entry.GetLocation();

                        if (location == prevPos)
                            continue;

                        prevPos = location;
                        route.Points.Add(location);
                        var distance = route.Distance * 1000;

                        if (distance >= _markerDistance)
                        {
                            RenderedSegmentMarkers[segment].Position = segment.Segment.Entries[i].GetLocation(Track);
                            break;
                        }
                    }
                }
            }

            OnMarkers?.Invoke(this, Markers);
        }

        private bool _renderMarkers = false;

        public bool RenderMarkers
        {
            get { return _renderMarkers; }
            set
            {
                if (value != _renderMarkers)
                {
                    _renderMarkers = value;
                    UpdateMarkers();
                }
            }
        }

        private void UpdateMarkers()
        {
            if (!_renderMarkers)
            {
                RenderedSegmentMarkers.Clear();
                OnMarkers?.Invoke(this, Markers);
            }

            var markersToRemove = RenderedSegmentMarkers.Keys.Where(k => !RenderedSegments.Contains(k)).ToList();

            foreach (var markerKey in markersToRemove)
                RenderedSegmentMarkers.Remove(markerKey);

            foreach (var segment in RenderedSegments)
            {
                if (!RenderedSegmentMarkers.ContainsKey(segment))
                    RenderedSegmentMarkers.Add(segment,
                        new GMarkerGoogle(segment.Segment.Entries.First().GetLocation(Track),
                            GMarkerGoogleType.blue_small));
            }

            if (_markerIndex >= 0)
                UpdateMarkerPositionsByIndex();

            if (_markerDistance >= 0)
                UpdateMarkerPositionsByDistance();
        }

        public void RenderSegments(params SegmentAnalysis[] segments)
        {
            RenderedSegments.Clear();
            Routes.Clear();
            AccelerationRoutes.Clear();

            var routes = new List<GMapRoute>();

            foreach (var segment in segments)
            {
                Routes.Add(segment, segment.Route);
                AccelerationRoutes.Add(segment, segment.AccelerationRoutes);
                RenderedSegments.Add(segment);

                routes.Add(segment.Route);
                routes.AddRange(segment.AccelerationRoutes);
            }

            OnRoutes?.Invoke(this, routes);

            //OnRoutes?.Invoke(this, Routes.Values);

            RenderMarkers = false;
        }
    }
}
