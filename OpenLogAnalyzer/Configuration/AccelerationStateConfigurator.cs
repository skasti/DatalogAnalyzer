using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenLogAnalyzer.Helpers;
using OpenLogger.Analysis;
using OpenLogger.Analysis.Config;
using OpenLogger.Analysis.Extensions;

namespace OpenLogAnalyzer.Configuration
{
    public partial class AccelerationStateConfigurator : UserControl
    {
        private AccelerationLineConfig _configuration;

        public AccelerationLineConfig Configuration
        {
            get => _configuration;
            set
            {
                _configuration = value;
                ResetInput();
            }
        }

        private AccelerationState _accelerationState;

        public AccelerationState AccelerationState
        {
            get => _accelerationState;
            set
            {
                _accelerationState = value;
                UpdateTitle();
            }
        }

        private void UpdateTitle()
        {
            if (groupBox == null)
                return;

            groupBox.Text = EnumHelper<AccelerationState>.GetDisplayValue(_accelerationState);
        }

        public double Threshold { get; set; }
        public float LineWidth { get; set; }
        public float LineOpacity { get; set; }
        public Color LineColor { get; set; }

        public AccelerationStateConfigurator()
        {
            InitializeComponent();
            UpdateTitle();
        }

        public void ResetInput()
        {
            if (_configuration == null)
                return;

            Threshold = _configuration.Threshold[AccelerationState];
            LineWidth = _configuration.LineWidth[AccelerationState];
            LineOpacity = _configuration.LineOpacity[AccelerationState];
            LineColor = _configuration.LineColor[AccelerationState];

            thresholdInput.Text = Threshold.ToString("N");
            lineWidthInput.Text = LineWidth.ToString("N");
            lineOpacityInput.Text = LineOpacity.ToString("N");
            colorPickerButton.BackColor = LineColor.WithOpacity(LineOpacity);
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            if (ColorPicker.ShowDialog(this) != DialogResult.OK)
                return;

            LineColor = ColorPicker.Color;
            colorPickerButton.BackColor = LineColor.WithOpacity(LineOpacity);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

        public bool ApplyToConfig()
        {
            if (!ValidateInputs()) return false;

            Configuration.Threshold[AccelerationState] = Threshold;
            Configuration.LineWidth[AccelerationState] = LineWidth;
            Configuration.LineOpacity[AccelerationState] = LineOpacity;
            Configuration.LineColor[AccelerationState] = LineColor;

            return true;
        }

        public bool ValidateInputs()
        {
            double threshold;
            if (!double.TryParse(thresholdInput.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.CurrentCulture, out threshold))
            {
                MessageBox.Show($"{EnumHelper<AccelerationState>.GetDisplayValue(AccelerationState)}: Threshold must be a valid decimal number", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            float lineWidth;
            if (!float.TryParse(lineWidthInput.Text, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out lineWidth))
            {
                MessageBox.Show($"{EnumHelper<AccelerationState>.GetDisplayValue(AccelerationState)}: Line width must be a valid decimal number", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            float lineOpacity;
            if (!float.TryParse(lineOpacityInput.Text, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out lineOpacity))
            {
                MessageBox.Show($"{EnumHelper<AccelerationState>.GetDisplayValue(AccelerationState)}: Line opacity must be a valid decimal number", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            Threshold = threshold;
            LineWidth = lineWidth;
            LineOpacity = lineOpacity;
            return true;
        }
    }
}
