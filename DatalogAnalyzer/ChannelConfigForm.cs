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

namespace DatalogAnalyzer
{
    public partial class ChannelConfigForm : Form
    {
        private const int RowSpacing = 48;
        private const int FormPadding = 20;
        private List<ChannelConfig> _config;
        public event EventHandler OnApply;

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

                var armLengthInput = new TextBox
                {
                    Width = chArmLengthTemplate.Width,
                    Height = chArmLengthTemplate.Height,
                    Text = channelConfig.ArmLength.ToString(CultureInfo.CurrentUICulture),
                    Left = chArmLengthTemplate.Left,
                    Top = chArmLengthTemplate.Top + i * RowSpacing
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

                applyButton.Click += (sender, args) =>
                {
                    channelConfig.Name = nameInput.Text;

                    var zero = 0.0;
                    var scaling = 0.0;
                    var armLength = 0.0;

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

                    if (double.TryParse(armLengthInput.Text,
                        NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture,
                        out armLength))
                    {
                        channelConfig.ArmLength = armLength;
                    }
                    else
                    {
                        MessageBox.Show("Failed to parse ArmLength");
                    }

                    OnApply?.Invoke(this, new EventArgs());
                };

                resetButton.Click += (sender, args) =>
                {
                    nameInput.Text = channelConfig.Name;
                    zeroInput.Text = channelConfig.ZeroPoint.ToString(CultureInfo.CurrentUICulture);
                    scalingInput.Text = channelConfig.Scaling.ToString(CultureInfo.CurrentUICulture);
                };

                Controls.AddRange(new Control[]{nameInput, zeroInput, scalingInput, armLengthInput, applyButton, resetButton});
                Height = nameInput.Top + RowSpacing + FormPadding;
            }
        }
    }
}
