using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenLogger.Analysis.Vehicle;

namespace OpenLogAnalyzer
{
    public partial class VehicleEditor : Form
    {
        public event EventHandler<Vehicle> OnSave;
        private Vehicle _vehicle;

        public VehicleEditor(Vehicle vehicle)
        {
            InitializeComponent();
            _vehicle = vehicle;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameInput.Text))
            {
                MessageBox.Show("Name can't be empty/whitespace. Plase enter a proper name", "Invalid name",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _vehicle.Name = nameInput.Text;
            OnSave?.Invoke(this, _vehicle);
            Close();
        }

        private void VehicleEditor_Load(object sender, EventArgs e)
        {
            nameInput.Text = _vehicle.Name;
        }
    }
}
