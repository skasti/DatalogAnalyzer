using System;
using System.ComponentModel;
using System.Windows.Forms;
using OpenLogger.Analysis.Vehicle.Inputs.Transforms;

namespace OpenLogAnalyzer.Transforms
{
    [DisplayName("Linear Map")]
    public partial class LinearMapEditor : Form, IEditInputTransforms
    {
        private LinearMapTransform _transform;

        public event EventHandler<IInputTransform> Saved;

        public LinearMapEditor()
        {
            InitializeComponent();
        }

        public void LoadTransform(IInputTransform transform)
        {
            _transform = transform as LinearMapTransform;
        }

        public void CreateTransform(double selectionMin, double selectionMax, double cursorX, double cursorY)
        {
            _transform = new LinearMapTransform
            {
                SourceMin = selectionMin,
                SourceMax = selectionMax,
                TargetMin = 0,
                TargetMax = 100
            };
        }

        private void LinearMapEditor_Load(object sender, EventArgs e)
        {
            if (_transform == null)
            {
                MessageBox.Show(this, "You must load or create a transform before showing this dialog",
                    "Invalid Implementation!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Close();
                return;
            }

            FromMinInput.Text = $"{_transform.SourceMin}";
            FromMaxInput.Text = $"{_transform.SourceMax}";
            ToMinInput.Text = $"{_transform.TargetMin}";
            ToMaxInput.Text = $"{_transform.TargetMax}";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            double sourceMin, sourceMax;

            if (!double.TryParse(FromMinInput.Text, out sourceMin))
            {
                MessageBox.Show(this, $"Invalid source minimum: '{FromMinInput.Text}'", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(FromMaxInput.Text, out sourceMax))
            {
                MessageBox.Show(this, $"Invalid source maximum: '{FromMaxInput.Text}'", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double targetMin, targetMax;

            if (!double.TryParse(ToMinInput.Text, out targetMin))
            {
                MessageBox.Show(this, $"Invalid target minimum: '{ToMinInput.Text}'", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(ToMaxInput.Text, out targetMax))
            {
                MessageBox.Show(this, $"Invalid target maximum: '{ToMaxInput.Text}'", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _transform.SourceMin = sourceMin;
            _transform.SourceMax = sourceMax;
            _transform.TargetMin = targetMin;
            _transform.TargetMax = targetMax;

            Saved?.Invoke(this, _transform);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
