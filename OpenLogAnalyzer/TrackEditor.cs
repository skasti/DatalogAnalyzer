﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using OpenLogAnalyzer.Extensions;
using OpenLogger.Analysis;
using OpenLogger.Analysis.Extensions;
using OpenLogger.Core;

namespace OpenLogAnalyzer
{


    public partial class TrackEditor : Form
    {
        readonly GMapOverlay _activeOverlay = new GMapOverlay();
        readonly GMapOverlay _areaOverlay = new GMapOverlay();
        readonly GMapOverlay _startFinishOverlay = new GMapOverlay();
        readonly GMapOverlay _sectionsOverlay = new GMapOverlay();
        readonly GMapOverlay _segmentOverlay = new GMapOverlay();

        private GMapPolygon _activePolygon = null;
        private GMapMarker _cursorMarker = null;
        private bool _cursorSticky = false;

        private int _sectionSkip = 0;

        public Track Track { get; }
        public LogSegment Segment { get; }
        public bool Saved { get; private set; }

        public TrackEditor(Track track = null, LogSegment segment = null)
        {
            InitializeComponent();

            var values = Enum.GetNames(typeof (TrackType));
            TypeInput.Items.AddRange(values);

            Track = track ?? new Track { Id = Guid.NewGuid() };
            nameInput.Text = Track.Name;
            TypeInput.SelectedItem = Enum.GetName(typeof(TrackType), Track.Type);

            Segment = segment;

            if (Track.Area != null)
            {
                Track.Area.Stroke = new Pen(Color.CornflowerBlue, 5.0f);
                Track.Area.Fill = new SolidBrush(Color.Transparent);
                _areaOverlay.Polygons.Add(Track.Area);
            }

            if (Track.StartLinePolygon != null)
            {
                Track.StartLinePolygon.Stroke = new Pen(Color.Red, 2.0f);
                Track.StartLinePolygon.Fill = new SolidBrush(Color.FromArgb(40, Color.Red));
                _startFinishOverlay.Polygons.Add(Track.StartLinePolygon);
            }

            //if (Track.Sections != null)
            //{
            //    foreach (var section in Track.Sections)
            //    {
            //        _sectionsOverlay.Polygons.Add(section);
            //    }
            //}

            InitializeActivePolygon();
        }

        private void TrackEditor_Load(object sender, EventArgs e)
        {
            trackMap.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            trackMap.Overlays.Add(_segmentOverlay);
            trackMap.Overlays.Add(_areaOverlay);
            trackMap.Overlays.Add(_startFinishOverlay);
            trackMap.Overlays.Add(_sectionsOverlay);
            trackMap.Overlays.Add(_activeOverlay);

            if (Segment != null)
            {
                var segmentRoute = Segment.GetRoute("Log", currentTrack: Track);
                _segmentOverlay.Routes.Add(segmentRoute);
                trackMap.ZoomAndCenterRoute(segmentRoute);
            }

            if (Track.Area != null)
            {
                var areaRoute = new GMapRoute(Track.Area.Points, "Area");
                trackMap.ZoomAndCenterRoute(areaRoute);
            }
        }

        private void trackMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _cursorSticky = true;
            MoveCursor(e.X, e.Y);

            if (_activePolygon == null)
                return;

            var newPoint = new PointLatLng(_cursorMarker.Position.Lat, _cursorMarker.Position.Lng);
            _activePolygon.Points.Add(newPoint);

            //_activeOverlay.Refresh();
        }

        private void MoveCursor(int x, int y)
        {
            var newPosition = trackMap.FromLocalToLatLng(x, y);

            if (_cursorMarker == null)
            {
                _cursorMarker = new GMarkerCross(newPosition);
                _activeOverlay.Markers.Add(_cursorMarker);
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
            if (e.Button != MouseButtons.Left)
                return;

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
            _startFinishOverlay.IsVisibile = !_startFinishOverlay.IsVisibile;
        }

        private void defineStartFinish_Click(object sender, EventArgs e)
        {
            if (!ValidateActivePolygon())
                return;

            if (Track.StartLinePolygon == null)
            {
                Track.StartLinePolygon = new GMapPolygon(_activePolygon.Points, "Start/Finish");
                Track.StartLinePolygon.Stroke = new Pen(Color.Red, 2.0f);
                Track.StartLinePolygon.Fill = new SolidBrush(Color.FromArgb(40, Color.Red));
                _startFinishOverlay.Polygons.Add(Track.StartLinePolygon);
            }
            else
            {
                Track.StartLinePolygon.Points.Clear();
                Track.StartLinePolygon.Points.AddRange(_activePolygon.Points);
            }

            Track.Changed = DateTime.Now;
            //_startFinishOverlay.Refresh();
            InitializeActivePolygon();
        }

        private void InitializeActivePolygon(List<PointLatLng> initialPoints = null)
        {
            InitializeActivePolygon(Color.CornflowerBlue, Color.CornflowerBlue, initialPoints);
        }

        private void InitializeActivePolygon(Color pointColor, Color fillColor, List<PointLatLng> initialPoints = null)
        {
            _activePolygon = new GMapPolygon(initialPoints ?? new List<PointLatLng>(), "");
            _activePolygon.Stroke = new Pen(pointColor, 2.0f);
            _activePolygon.Fill = new SolidBrush(Color.FromArgb(20, fillColor));
            _activeOverlay.Polygons.Clear();
            _activeOverlay.Polygons.Add(_activePolygon);
        }

        private void showHideToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _areaOverlay.IsVisibile = !_areaOverlay.IsVisibile;
        }

        private void defineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!ValidateActivePolygon())
                return;

            if (Track.Area == null)
            {
                Track.Area = new GMapPolygon(_activePolygon.Points, "Area");
                Track.Area.Stroke = new Pen(Color.CornflowerBlue, 5.0f);
                Track.Area.Fill = new SolidBrush(Color.Transparent);
                _areaOverlay.Polygons.Add(Track.Area);
            }
            else
            {
                Track.Area.Points.Clear();
                Track.Area.Points.AddRange(_activePolygon.Points);
            }

            Track.Changed = DateTime.Now;
            //_areaOverlay.Refresh();
            InitializeActivePolygon();
        }

        private bool ValidateActivePolygon(int minCount = 4)
        {
            if (_activePolygon.Points.Count >= minCount) return true;

            MessageBox.Show(
                $"Need at least {minCount} points to make a polygon of this type", "Not enough points",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Track.Name != nameInput.Text)
            {
                Track.Name = nameInput.Text;
                Track.Changed = DateTime.Now;
            }

            var type = (TrackType)Enum.Parse(typeof (TrackType), TypeInput.SelectedItem as string);

            if (Track.Type != type)
            {
                Track.Type = type;
                Track.Changed = DateTime.Now;
            }

            Track.Save();
            Saved = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void polygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeActivePolygon();
        }

        private void newSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sectionSkip = 0;
            NewSection();
        }

        private void NewSection()
        {
            //if (Track.Sections == null)
            //    Track.Sections = new List<GMapPolygon>();

            //var lastSection = GetLastSection();


            //var initialPoints = new List<PointLatLng>();
            //var numPoints = lastSection.Points.Count;

            //var firstPointIndex = _sectionSkip;
            //var secondPointIndex = _sectionSkip + 1;

            //if (firstPointIndex < 0)
            //    firstPointIndex = numPoints - firstPointIndex;

            //if (secondPointIndex >= numPoints)
            //    secondPointIndex -= numPoints;

            //initialPoints.Add(lastSection.Points[firstPointIndex]);
            //initialPoints.Add(lastSection.Points[secondPointIndex]);

            //StartSection(initialPoints);
        }

        //private GMapPolygon GetLastSection()
        //{
        //    GMapPolygon lastSection = null;

        //    if (Track.Sections.Count == 0)
        //    {
        //        if (Track.StartFinishPolygon == null)
        //        {
        //            MessageBox.Show("Start/Finish must be defined before you can start adding sections",
        //                "Start/Finish undefined!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return lastSection;
        //        }

        //        lastSection = Track.StartFinishPolygon;
        //    }
        //    else
        //        lastSection = Track.Sections.Last();
        //    return lastSection;
        //}

        //private void StartSection(List<PointLatLng> initialPoints)
        //{
        //    InitializeActivePolygon(Color.Fuchsia, Color.CornflowerBlue, initialPoints);
        //    newSectionToolStripMenuItem.Visible = false;
        //    finishSectionToolStripMenuItem.Visible = true;
        //    abortSectionToolStripMenuItem.Visible = true;
        //    sectionStartToolStripMenuItem.Visible = true;
        //    defineToolStripMenuItem.Enabled = false;
        //    defineToolStripMenuItem1.Enabled = false;
        //}

        private void finishSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!ValidateActivePolygon())
            //    return;

            //var section = new GMapPolygon(_activePolygon.Points, $"Section {Track.Sections.Count + 1}");
            //section.Stroke = new Pen(RandomColors.GetNext(), 3.0f);
            //section.Fill = new SolidBrush(Color.FromArgb(70, section.Stroke.Color));

            //Track.Sections.Add(section);
            //Track.ChangedDate = DateTime.Now;
            //_sectionsOverlay.Polygons.Add(section);

            //InitializeActivePolygon();

            //newSectionToolStripMenuItem.Visible = true;
            //finishSectionToolStripMenuItem.Visible = false;
            //abortSectionToolStripMenuItem.Visible = false;
            //sectionStartToolStripMenuItem.Visible = false;

            //defineToolStripMenuItem.Enabled = true;
            //defineToolStripMenuItem1.Enabled = true;
        }

        private void abortSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //InitializeActivePolygon();

            //newSectionToolStripMenuItem.Visible = true;
            //finishSectionToolStripMenuItem.Visible = false;
            //abortSectionToolStripMenuItem.Visible = false;
            //sectionStartToolStripMenuItem.Visible = false;
            //defineToolStripMenuItem.Enabled = true;
            //defineToolStripMenuItem1.Enabled = true;

        }

        private void backwardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //_sectionSkip--;

            //if (_sectionSkip < 0)
            //{
            //    var lastSection = GetLastSection();
            //    _sectionSkip = lastSection.Points.Count + _sectionSkip;
            //}

            //NewSection();
        }

        private void forwardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //_sectionSkip++;
            //var lastSection = GetLastSection();

            //if (_sectionSkip >= lastSection.Points.Count)
            //{
            //    _sectionSkip -= lastSection.Points.Count;
            //}

            //NewSection();
        }

        private void defineToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!ValidateActivePolygon(2))
                return;

            var latCorrection = _activePolygon.Points[1].Lat - _activePolygon.Points[0].Lat;
            var lngCorrection = _activePolygon.Points[1].Lng - _activePolygon.Points[0].Lng;

            Track.GpsCorrection = new PointLatLng(Track.GpsCorrection.Lat + latCorrection, Track.GpsCorrection.Lng + lngCorrection);

            Track.Changed = DateTime.Now;

            var segmentRoute = Segment.GetRoute("Log", currentTrack: Track);
            _segmentOverlay.Clear();
            _segmentOverlay.Routes.Add(segmentRoute);

            InitializeActivePolygon();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Track.GpsCorrection = PointLatLng.Empty;
            Track.Changed = DateTime.Now;

            var segmentRoute = Segment.GetRoute("Log");
            _segmentOverlay.Clear();
            _segmentOverlay.Routes.Add(segmentRoute);
        }
    }
}
