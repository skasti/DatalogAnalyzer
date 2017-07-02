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
using DatalogAnalyzer.DataChannels.Suspension;
using DatalogAnalyzer.Icons;
using Newtonsoft.Json;
using static System.String;

namespace DatalogAnalyzer.DataChannels
{
    public partial class ChannelManagementForm : Form
    {
        private ChannelManager _manager;

        public ChannelManagementForm()
        {
            InitializeComponent();
        }

        public ChannelManagementForm(ChannelManager manager)
        {
            InitializeComponent();

            IconProvider.PopulateImageList(channelIcons);

            _manager = manager;
            InitChannels();

            _manager.OnLoaded += (sender, args) => InitChannels();

            var dataLoggerCards = _manager.GetDataLoggerCards();

            if (!dataLoggerCards.Any())
                return;

            openFileDialog.InitialDirectory = dataLoggerCards.First().RootDirectory.ToString();
            saveFileDialog.InitialDirectory = dataLoggerCards.First().RootDirectory.ToString();
        }

        

        private void dataChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var channel = new DataChannel(_manager.Channels.Count);
            _manager.Add(channel);
            AppendChannel(channel);
        }

        void InitChannels()
        {
            channelListView.Items.Clear();

            foreach (var dataChannel in _manager.Channels)
            {
                AppendChannel(dataChannel);
            }
        }
        void AppendChannel(DataChannel channel)
        {
            var listItem = new ListViewItem(channel.Name);
            listItem.Tag = channel;
            listItem.ImageIndex = channel.IconIndex;

            channelListView.Items.Add(listItem);
        }

        private void suspensionChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var channel = new SuspensionChannel(_manager.Channels.Count);
            _manager.Add(channel);
            AppendChannel(channel);
        }

        private void channelListView_DoubleClick(object sender, EventArgs e)
        {
            var selectedChannel = channelListView.SelectedItems[0].Tag as DataChannel;

            if (selectedChannel == null)
                return;

            var editor = selectedChannel.CreateEditor();
            editor.OnSave += (o, args) =>
            {
                channelListView.SelectedItems[0].Text = selectedChannel.Name;
                channelListView.SelectedItems[0].ImageIndex = selectedChannel.IconIndex;
            };

            editor.Show(this);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                _manager.SaveChannels(saveFileDialog.FileName);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                _manager.LoadChannels(openFileDialog.FileName);
        }

        private void editChannelMenuItem_Click(object sender, EventArgs e)
        {
            var selectedChannel = channelListView.SelectedItems[0].Tag as DataChannel;

            if (selectedChannel == null)
                return;

            var editor = selectedChannel.CreateEditor();
            editor.OnSave += (o, args) =>
            {
                channelListView.SelectedItems[0].Text = selectedChannel.Name;
                channelListView.SelectedItems[0].ImageIndex = selectedChannel.IconIndex;
            };

            editor.Show(this);
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            var selectedChannel = channelListView.SelectedItems[0].Tag as DataChannel;

            if (selectedChannel == null)
                return;

            if (MessageBox.Show(
                $"Are you sure you want to delete \"{selectedChannel.Name}\"?", "Are you sure?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _manager.Remove(selectedChannel);
            channelListView.Items.Remove(channelListView.SelectedItems[0]);
        }
    }
}
