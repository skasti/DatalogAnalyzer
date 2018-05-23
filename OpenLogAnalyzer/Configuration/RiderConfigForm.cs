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

        private void saveToCardButton_Click(object sender, EventArgs e)
        {
            if (Paths.DataLoggerCard == null)
            {
                MessageBox.Show(
                    "OpenLogger card not detected. Make sure you can see it in file explorer, and that it contains .LOG-files",
                    "Card not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            var config = RiderConfig.Instance;
            config.RiderNumber = StartNumberInput.Text;
            config.RiderName = NameInput.Text;
            config.BikeName = BikeNameInput.Text;
            config.Save(Paths.CardRiderConfig);
        }

        private void selectBikeButton_Click(object sender, EventArgs e)
        {
            var form = new VehicleSelector();
            form.OnSelected += (o, vehicleName) => BikeNameInput.Text = vehicleName;
            form.ShowDialog(this);
        }
    }
}
