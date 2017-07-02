using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatalogAnalyzer.Icons;

namespace DatalogAnalyzer.DataChannels
{
    public partial class DataChannelEditor : Form
    {
        private readonly DataChannel _channel;
        public event EventHandler OnSave;

        private int _iconIndex = 0;

        public DataChannelEditor()
        {
            InitializeComponent();
            InitChartDropdown();
        }

        public DataChannelEditor(DataChannel channel)
        {
            _channel = channel;

            InitializeComponent();
            IconProvider.PopulateImageList(channelIcons);
            InitChartDropdown();
            InitIconDropdown();

            LoadFromChannel();
        }

        private void InitIconDropdown()
        {
            foreach (var icon in IconProvider.Icons)
            {
                var iconMenuItem = new ToolStripMenuItem(icon.Title);
                iconMenuItem.Click += (sender, args) => SelectIcon(icon.Index);
                iconContextMenu.Items.Add(iconMenuItem);
            }
        }

        private void SelectIcon(int index)
        {
            if ((index < 0) || (index >= channelIcons.Images.Count))
                return;

            _iconIndex = index;
            iconPicture.Image = channelIcons.Images[index];
        }

        private bool Callback()
        {
            throw new NotImplementedException();
        }

        private void LoadFromChannel()
        {
            if (_channel == null)
                return;

            sourceInput.Value = _channel.Source;
            nameInput.Text = _channel.Name;
            chartInput.SelectedItem = _channel.Chart;
            zeroPointInput.Text = _channel.ZeroPoint.ToString(CultureInfo.CurrentUICulture);
            scalingInput.Text = _channel.Scaling.ToString(CultureInfo.CurrentUICulture);

            SelectIcon(_channel.IconIndex);
        }

        private void InitChartDropdown()
        {
            foreach (var chartType in Enum.GetValues(typeof(ChartType)))
            {
                chartInput.Items.Add(chartType);
            }
        }

        public virtual void Apply()
        {
            _channel.Name = nameInput.Text;
            _channel.Source = (int)sourceInput.Value;
            _channel.IconIndex = _iconIndex;

            double zero;
            double scaling;

            if (double.TryParse(zeroPointInput.Text,
                NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture,
                out zero))
            {
                _channel.ZeroPoint = zero;
            }
            else
            {
                MessageBox.Show("Failed to parse Zero-point");
            }

            if (double.TryParse(scalingInput.Text,
                NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture,
                out scaling))
            {
                _channel.Scaling = scaling;
            }
            else
            {
                MessageBox.Show("Failed to parse Scaling");
            }
        }

        public virtual void Reset()
        {
            LoadFromChannel();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Apply();
            OnSave?.Invoke(this, new EventArgs());
            Close();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
