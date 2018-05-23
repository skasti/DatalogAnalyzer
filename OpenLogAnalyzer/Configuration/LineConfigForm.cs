using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenLogger.Analysis.Config;

namespace OpenLogAnalyzer.Configuration
{
    public partial class LineConfigForm : Form
    {
        private AccelerationLineConfig Config { get; set; }

        public LineConfigForm()
        {
            InitializeComponent();

            Config = AccelerationLineConfig.Instance.Copy();

            accelerationStateConfigurator1.Configuration = Config;
            accelerationStateConfigurator2.Configuration = Config;
            accelerationStateConfigurator3.Configuration = Config;
            accelerationStateConfigurator4.Configuration = Config;
            accelerationStateConfigurator5.Configuration = Config;
            accelerationStateConfigurator6.Configuration = Config;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            accelerationStateConfigurator1.ResetInput();
            accelerationStateConfigurator2.ResetInput();
            accelerationStateConfigurator3.ResetInput();
            accelerationStateConfigurator4.ResetInput();
            accelerationStateConfigurator5.ResetInput();
            accelerationStateConfigurator6.ResetInput();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (!accelerationStateConfigurator1.ValidateInputs()) return;
            if (!accelerationStateConfigurator2.ValidateInputs()) return;
            if (!accelerationStateConfigurator3.ValidateInputs()) return;
            if (!accelerationStateConfigurator4.ValidateInputs()) return;
            if (!accelerationStateConfigurator5.ValidateInputs()) return;
            if (!accelerationStateConfigurator6.ValidateInputs()) return;

            accelerationStateConfigurator1.ApplyToConfig();
            accelerationStateConfigurator2.ApplyToConfig();
            accelerationStateConfigurator3.ApplyToConfig();
            accelerationStateConfigurator4.ApplyToConfig();
            accelerationStateConfigurator5.ApplyToConfig();
            accelerationStateConfigurator6.ApplyToConfig();

            AccelerationLineConfig.Instance = Config;
        }
    }
}
