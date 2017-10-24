using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OpenLogger.Analysis;

namespace OpenLogAnalyzer.Extensions
{
    public static class TrackExtensions
    {
        private static readonly Dictionary<Track, ListViewItem> TrackItems = new Dictionary<Track, ListViewItem>(); 
        public static ListViewItem ToListViewItem(this Track track)
        {
            if (TrackItems.ContainsKey(track))
                return track.UpdateListViewItem();

            var item = new ListViewItem { Text = track.Name };
            item.SubItems.Add(track.Changed.ToShortDateString());

            return item;
        }

        public static ListViewItem UpdateListViewItem(this Track track)
        {
            if (!TrackItems.ContainsKey(track))
                return track.ToListViewItem();
            
            var item = TrackItems[track];
            item.Text = track.Name;
            item.SubItems[1].Text = track.Changed.ToShortDateString();

            return item;
        }

        public static void Save(this Track track)
        {
            var fileName = Path.Combine(Paths.TrackLibrary, track.Name) + ".track";
            File.WriteAllText(fileName, JsonConvert.SerializeObject(track, Formatting.Indented));
        }
    }
}
