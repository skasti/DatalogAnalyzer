using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OpenLogger.Analysis.Vehicle;
using OpenLogger.Analysis.Vehicle.Inputs;

namespace OpenLogAnalyzer
{
    public partial class VehicleSelector : Form
    {
        public event EventHandler<string> OnSelected; 
        public VehicleSelector()
        {
            InitializeComponent();
        }

        private void VehicleSelector_Load(object sender, EventArgs e)
        {
            var names = VehicleRepository.GetNames();
            vehicleList.Items.AddRange(names.Select(n => new ListViewItem(n)).ToArray());
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (vehicleList.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select a vehicle", "Selection required", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            OnSelected?.Invoke(this, vehicleList.SelectedItems[0].Text);
            Close();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var newVehicle = new Vehicle()
            {
                Inputs = new List<Input>
                {
                    new Input
                    {
                        Name = "Speed",
                        Source = InputSource.Speed
                    },

                    new Input
                    {
                        Name = "Altitude",
                        Source = InputSource.Altitude
                    },

                    new Input
                    {
                        Name = "TPS",
                        Source = InputSource.Analog,
                        AnalogSource = 0,
                        Smoothing = 10
                    },

                    new Input
                    {
                        Name = "Fork Position",
                        Source = InputSource.Analog,
                        AnalogSource = 1,
                        Smoothing = 10
                    }
                }
            };

            var editor = new VehicleEditor(newVehicle);
            editor.ShowDialog(this);

            while (VehicleRepository.Exists(newVehicle.Name))
            {
                MessageBox.Show("Vehicle name must be unique. Consider using license plate or frame number.",
                    "Vehicle not unique!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                editor.ShowDialog(this);
            }

            VehicleRepository.Save(newVehicle);

            OnSelected?.Invoke(this, newVehicle.Name);
            Close();
        }
    }
}
