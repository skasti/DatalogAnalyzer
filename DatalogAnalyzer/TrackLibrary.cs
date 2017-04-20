using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms;

namespace DatalogAnalyzer
{
    public partial class TrackLibrary : Form
    {
        private readonly TrackRepository _repository;
        private readonly Dictionary<Track, ListViewItem> _trackItems = new Dictionary<Track, ListViewItem>();
        private Track _selectedTrack;
        private GMapOverlay _mapOverlay = new GMapOverlay();

        public TrackLibrary(TrackRepository repository)
        {
            _repository = repository;
            InitializeComponent();

            InitializeTrackList();

            trackMap.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            trackMap.Overlays.Add(_mapOverlay);
        }

        private void InitializeTrackList()
        {
            foreach (var track in _repository.Tracks)
            {
                CreateListItem(track);
            }
        }

        private void CreateListItem(Track track)
        {
            var item = new ListViewItem {Text = track.Name};
            item.SubItems.Add(track.ChangedDate.ToShortDateString());

            trackList.Items.Add(item);
            _trackItems.Add(track, item);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editor = new TrackEditor();
            editor.ShowDialog(this);

            if (editor.Saved)
            {
                _repository.Tracks.Add(editor.Track);
                CreateListItem(editor.Track);
            }
        }

        private void trackList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_selectedTrack == null)
                return;

            var editor = new TrackEditor(_selectedTrack);
            editor.ShowDialog(this);

            UpdateListItem(_selectedTrack);
        }

        private void UpdateListItem(Track track)
        {
            var item = _trackItems[track];
            item.Text = track.Name;
            item.SubItems[1].Text = track.ChangedDate.ToShortDateString();
        }

        private void trackList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trackList.SelectedIndices.Count == 0)
            {
                _selectedTrack = null;
                return;
            }

            _selectedTrack = _repository.Tracks[trackList.SelectedIndices[0]];

            if (_selectedTrack.Area != null)
            {
                var areaRoute = new GMapRoute(_selectedTrack.Area.Points, "Area");
                trackMap.ZoomAndCenterRoute(areaRoute);
            }

            if (_selectedTrack.StartFinishPolygon != null)
            {
                var startFinishRoute = new GMapRoute(_selectedTrack.StartFinishPolygon.Points.Take(2), "Start/Finish");
                startFinishRoute.Stroke.Color = Color.Red;
                startFinishRoute.Stroke.Width = 1.0f;
                _mapOverlay.Routes.Clear();
                _mapOverlay.Routes.Add(startFinishRoute);
            }
        }
    }
}
