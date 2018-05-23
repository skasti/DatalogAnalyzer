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
        public LineConfigForm()
        {
            InitializeComponent();

            accelerationStateConfigurator1.Configuration = AccelerationLineConfig.Instance;
            accelerationStateConfigurator2.Configuration = AccelerationLineConfig.Instance;
            accelerationStateConfigurator3.Configuration = AccelerationLineConfig.Instance;
            accelerationStateConfigurator4.Configuration = AccelerationLineConfig.Instance;
            accelerationStateConfigurator5.Configuration = AccelerationLineConfig.Instance;
            accelerationStateConfigurator6.Configuration = AccelerationLineConfig.Instance;
        }
    }
}
