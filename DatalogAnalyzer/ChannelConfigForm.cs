using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DatalogAnalyzer
{
    public partial class ChannelConfigForm : Form
    {
        private const int RowSpacing = 40;
        private const int FormPadding = 30;
        private List<ChannelConfig> _config;
        public event EventHandler<ChannelConfigChangedEventArgs> OnApply;

        public ChannelConfigForm(List<ChannelConfig> channelConfigs)
        {
            InitializeComponent();
            _config = channelConfigs;

            InitializeUI();
        }

        private void InitializeUI()
        {
            for (int i = 0; i < _config.Count; i++)
            {
                var channelConfig = _config[i];

                var isTempInput = new CheckBox
                {
                    Left = chIsTempTemplate.Left,
                    Top = chIsTempTemplate.Top + i*RowSpacing,
                    Checked = channelConfig.IsTemperature,
                    Width = chIsTempTemplate.Width,
                    Height = chIsTempTemplate.Height
                };

                var nameInput = new TextBox
                {
                    Width = chNameTemplate.Width,
                    Height = chNameTemplate.Height,
                    Text = channelConfig.Name,
                    Left = chNameTemplate.Left,
                    Top = chNameTemplate.Top + i * RowSpacing
                };

                var zeroInput = new TextBox
                {
                    Width = chZeroTemplate.Width,
                    Height = chZeroTemplate.Height,
                    Text = channelConfig.ZeroPoint.ToString(CultureInfo.CurrentUICulture),
                    Left = chZeroTemplate.Left,
                    Top = chZeroTemplate.Top + i * RowSpacing
                };

                var scalingInput = new TextBox
                {
                    Width = chScalingTemplate.Width,
                    Height = chScalingTemplate.Height,
                    Text = channelConfig.Scaling.ToString(CultureInfo.CurrentUICulture),
                    Left = chScalingTemplate.Left,
                    Top = chScalingTemplate.Top + i * RowSpacing
                };

                var arm1LengthInput = new TextBox
                {
                    Width = chArm1LengthTemplate.Width,
                    Height = chArm1LengthTemplate.Height,
                    Text = channelConfig.Arm1Length.ToString(CultureInfo.CurrentUICulture),
                    Left = chArm1LengthTemplate.Left,
                    Top = chArm1LengthTemplate.Top + i * RowSpacing
                };

                var arm2LengthInput = new TextBox
                {
                    Width = chArm2LengthTemplate.Width,
                    Height = chArm2LengthTemplate.Height,
                    Text = channelConfig.Arm2Length.ToString(CultureInfo.CurrentUICulture),
                    Left = chArm2LengthTemplate.Left,
                    Top = chArm2LengthTemplate.Top + i * RowSpacing
                };

                var armAxisDistanceInput = new TextBox
                {
                    Width = chArmAxisDistanceTemplate.Width,
                    Height = chArmAxisDistanceTemplate.Height,
                    Text = channelConfig.ArmAxisDistance.ToString(CultureInfo.CurrentUICulture),
                    Left = chArmAxisDistanceTemplate.Left,
                    Top = chArmAxisDistanceTemplate.Top + i * RowSpacing
                };

                var applyButton = new Button
                {
                    Width = applyBtnTemplate.Width,
                    Height = applyBtnTemplate.Height,
                    Text = "Apply",
                    Left = applyBtnTemplate.Left,
                    Top = applyBtnTemplate.Top + i * RowSpacing
                };

                var resetButton = new Button
                {
                    Width = resetBtnTemplate.Width,
                    Height = resetBtnTemplate.Height,
                    Text = "Reset",
                    Left = resetBtnTemplate.Left,
                    Top = resetBtnTemplate.Top + i * RowSpacing
                };

                var channelIndex = i;
                applyButton.Click += (sender, args) =>
                {
                    channelConfig.Name = nameInput.Text;

                    var zero = 0.0;
                    var scaling = 0.0;
                    var arm1Length = 0.0;
                    var arm2Length = 0.0;
                    var armAxisDistance = 0.0;

                    if (double.TryParse(zeroInput.Text,
                        NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture,
                        out zero))
                    {
                        channelConfig.ZeroPoint = zero;
                    }
                    else
                    {
                        MessageBox.Show("Failed to parse Zero-point");
                    }

                    if (double.TryParse(scalingInput.Text,
                        NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture,
                        out scaling))
                    {
                        channelConfig.Scaling = scaling;
                    }
                    else
                    {
                        MessageBox.Show("Failed to parse Scaling");
                    }

                    if (double.TryParse(arm1LengthInput.Text,
                        NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture,
                        out arm1Length))
                    {
                        channelConfig.Arm1Length = arm1Length;
                    }
                    else
                    {
                        MessageBox.Show("Failed to parse Arm #1");
                    }

                    if (double.TryParse(arm2LengthInput.Text,
                        NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture,
                        out arm2Length))
                    {
                        channelConfig.Arm2Length = arm2Length;
                    }
                    else
                    {
                        MessageBox.Show("Failed to parse Arm #2");
                    }

                    if (double.TryParse(armAxisDistanceInput.Text,
                        NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture,
                        out armAxisDistance))
                    {
                        channelConfig.ArmAxisDistance = armAxisDistance;
                    }
                    else
                    {
                        MessageBox.Show("Failed to parse Arm-Axis");
                    }

                    OnApply?.Invoke(this, new ChannelConfigChangedEventArgs
                    {
                        Index = channelIndex
                    });
                };

                resetButton.Click += (sender, args) =>
                {
                    nameInput.Text = channelConfig.Name;
                    zeroInput.Text = channelConfig.ZeroPoint.ToString(CultureInfo.CurrentUICulture);
                    scalingInput.Text = channelConfig.Scaling.ToString(CultureInfo.CurrentUICulture);
                    arm1LengthInput.Text = channelConfig.Arm1Length.ToString(CultureInfo.CurrentUICulture);
                    arm2LengthInput.Text = channelConfig.Arm2Length.ToString(CultureInfo.CurrentUICulture);
                    armAxisDistanceInput.Text = channelConfig.ArmAxisDistance.ToString(CultureInfo.CurrentUICulture);
                    isTempInput.Checked = channelConfig.IsTemperature;
                };

                Controls.AddRange(new Control[]
                {
                    isTempInput, nameInput, zeroInput, scalingInput,
                    arm1LengthInput, arm2LengthInput, armAxisDistanceInput, applyButton, resetButton
                });

                Height = nameInput.Top + RowSpacing + FormPadding;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            var serialized = JsonConvert.SerializeObject(_config, Formatting.Indented);

            File.WriteAllText(saveFileDialog.FileName, serialized);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            var serialized = File.ReadAllText(openFileDialog.FileName);

            var config = JsonConvert.DeserializeObject<List<ChannelConfig>>(serialized);

            for (int i = 0; i < config.Count; i++)
            {
                if (i >= _config.Count)
                    break;

                if (_config[i].Copy(config[i]))
                    OnApply?.Invoke(this, new ChannelConfigChangedEventArgs
                    {
                        Index = i
                    });
            }
        }
    }
}
