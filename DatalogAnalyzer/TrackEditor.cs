using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;

namespace DatalogAnalyzer
{
    public partial class TrackEditor : Form
    {
        readonly GMapOverlay _mapOverlay = new GMapOverlay();

        private GMapPolygon _activePolygon = null;
        private GMapMarker _cursorMarker = null;
        private bool _cursorSticky = false;

        private EventHandler OnPolygonCreated;
        private EventHandler OnMapCursorMoved;

        public Track Track { get; private set; }

        public TrackEditor(Track track = null)
        {
            InitializeComponent();
            Track = track ?? new Track();
        }

        private void TrackEditor_Load(object sender, EventArgs e)
        {
            trackMap.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            trackMap.Overlays.Add(_mapOverlay);

            if (Track.Area != null)
            {
                var areaRoute = new GMapRoute(Track.Area.Points, "Area");
                trackMap.ZoomAndCenterRoute(areaRoute);
            }
        }

        private void trackMap_MouseDown(object sender, MouseEventArgs e)
        {
            _cursorSticky = true;
            MoveCursor(e.X, e.Y);
            OnMapCursorMoved?.Invoke(sender, new EventArgs());
        }

        private void MoveCursor(int x, int y)
        {
            var newPosition = trackMap.FromLocalToLatLng(x, y);

            if (_cursorMarker == null)
            {
                _cursorMarker = new GMarkerCross(newPosition);
                _mapOverlay.Markers.Add(_cursorMarker);
            }
            else
            {
                _cursorMarker.Position = newPosition;
            }
        }

        private void trackMap_MouseLeave(object sender, EventArgs e)
        {
            _cursorSticky = false;
        }

        private void trackMap_MouseUp(object sender, MouseEventArgs e)
        {
            _cursorSticky = false;
        }

        private void trackMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_cursorSticky)
                return;

            MoveCursor(e.X, e.Y);
        }

        private void showHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Track.StartFinishPolygon == null)
                return;

            if (_activePolygon == Track.StartFinishPolygon)
            {
                _activePolygon = null;
                _mapOverlay.Polygons.Clear();
                return;
            }

            _mapOverlay.Polygons.Clear();
            _activePolygon = Track.StartFinishPolygon;
            _mapOverlay.Polygons.Add(_activePolygon);
        }

        private void defineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _activePolygon = new GMapPolygon(new List<PointLatLng>(), "Start/Finish");
            _mapOverlay.Polygons.Clear();
            _mapOverlay.Polygons.Add(_activePolygon);

            OnMapCursorMoved = null;
            OnMapCursorMoved += StartFinish_OnMapCursorMoved;
        }

        private void StartFinish_OnMapCursorMoved(object sender, EventArgs eventArgs)
        {
            var newPoint = new PointLatLng(_cursorMarker.Position.Lat, _cursorMarker.Position.Lng);
            _activePolygon.Points.Add(newPoint);
            _mapOverlay.Polygons.Clear();
            _mapOverlay.Polygons.Add(_activePolygon);

            if (_activePolygon.Points.Count >= 4)
            {
                Track.StartFinishPolygon = _activePolygon;
                _mapOverlay.Polygons.Clear();
                _mapOverlay.Polygons.Add(_activePolygon);

                OnMapCursorMoved = null;
            }
        }

        private void showHideToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Track.Area == null)
                return;

            if (_activePolygon == Track.Area)
            {
                _activePolygon = null;
                _mapOverlay.Polygons.Clear();
                return;
            }

            _mapOverlay.Polygons.Clear();
            _activePolygon = Track.Area;
            _mapOverlay.Polygons.Add(_activePolygon);
        }

        private void defineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _activePolygon = new GMapPolygon(new List<PointLatLng>(), "Area");
            _mapOverlay.Polygons.Clear();
            _mapOverlay.Polygons.Add(_activePolygon);

            OnMapCursorMoved = null;
            OnMapCursorMoved += Area_OnMapCursorMoved;
        }

        private void Area_OnMapCursorMoved(object sender, EventArgs e)
        {
            var newPoint = new PointLatLng(_cursorMarker.Position.Lat, _cursorMarker.Position.Lng);
            _activePolygon.Points.Add(newPoint);
            _mapOverlay.Polygons.Clear();
            _mapOverlay.Polygons.Add(_activePolygon);

            if (_activePolygon.Points.Count >= 4)
            {
                Track.Area = _activePolygon;
                _mapOverlay.Polygons.Clear();
                _mapOverlay.Polygons.Add(_activePolygon);

                OnMapCursorMoved = null;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileName = $"Tracks\\{Track.Id}.track";

            if (!Directory.Exists("Tracks"))
                Directory.CreateDirectory("Tracks");

            File.WriteAllText(fileName, JsonConvert.SerializeObject(Track, Formatting.Indented));
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
