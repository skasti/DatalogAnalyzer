using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLogAnalyzer
{
    public partial class RiderConfigForm : Form
    {
        public RiderConfigForm()
        {
            InitializeComponent();
            var config = RiderConfig.Instance;
            StartNumberInput.Text = config.RiderNumber;
            NameInput.Text = config.RiderName;
            BikeNameInput.Text = config.BikeName;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var config = RiderConfig.Instance;
            config.RiderNumber = StartNumberInput.Text;
            config.RiderName = NameInput.Text;
            config.BikeName = BikeNameInput.Text;
            config.Save();
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
