using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DatalogAnalyzer.DataChannels
{
    public class ChannelManager
    {
        public List<DataChannel> Channels = new List<DataChannel>(); 

        private JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            NullValueHandling = NullValueHandling.Ignore
        };

        public event EventHandler OnLoaded;
        public event EventHandler OnSaved;
        public event EventHandler<DataChannel> OnChannelChanged;
        public event EventHandler<DataChannel> OnRemoved;
        public event EventHandler<DataChannel> OnAdded;

        public ChannelManager()
        {
            var dataLoggerCards = GetDataLoggerCards();

            if (!dataLoggerCards.Any())
                return;

            var channelFiles = Directory.GetFiles(dataLoggerCards.First().RootDirectory.ToString(), "*.channels");
            var channelFile = channelFiles.FirstOrDefault();

            LoadChannels(channelFile);
        }

        public void Show(IWin32Window owner = null)
        {
            var form = new ChannelManagementForm(this);
            form.Show(owner);
        }

        public void LoadChannels(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return;

            var serialized = File.ReadAllText(fileName);

            Channels = JsonConvert.DeserializeObject<List<DataChannel>>(serialized, _serializerSettings);

            foreach (var channel in Channels)
            {
                channel.OnChanged += InvokeOnChannelChanged;
            }
            
            OnLoaded?.Invoke(this, new EventArgs());
        }

        private void InvokeOnChannelChanged(object sender, DataChannel channel)
        {
            OnChannelChanged?.Invoke(sender,channel);
        }

        public void SaveChannels(string fileName)
        {
            if (fileName == null)
                return;

            var json = JsonConvert.SerializeObject(Channels, Formatting.Indented, _serializerSettings);
            File.WriteAllText(fileName, json);

            OnSaved?.Invoke(this, new EventArgs());
        }

        public List<DriveInfo> GetDataLoggerCards()
        {
            var removableDrives = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable && d.IsReady);

            var dataLoggerCards = removableDrives.Where(d => d.RootDirectory.GetFiles("*.LOG").Any()).ToList();
            return dataLoggerCards;
        }

        public void Add(DataChannel channel)
        {
            Channels.Add(channel);

            OnAdded?.Invoke(this, channel);
        }

        public void Remove(DataChannel channel)
        {
            Channels.Add(channel);

            OnRemoved?.Invoke(this, channel);
        }
    }
}
