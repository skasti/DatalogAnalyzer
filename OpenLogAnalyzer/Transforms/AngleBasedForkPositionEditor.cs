using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenLogger.Analysis.Vehicle.Inputs.Transforms;

namespace OpenLogAnalyzer.Transforms
{
    [DisplayName("Fork Position")]
    public partial class AngleBasedForkPositionEditor : Form, IEditInputTransforms
    {
        private AngleBasedForkPositionTransform _transform;
        private AngleBasedForkPositionTransform _editingTransform;

        Image _backgroundImage = Image.FromFile("Images/background.png");
        Image _forkLeg = Image.FromFile("Images/upper fork.png");
        Image _sensorAnchor = Image.FromFile("Images/Sensor Anchor.png");
        Image _sensorPoint = Image.FromFile("Images/Sensor Point.png");

        Image _visualization = Image.FromFile("Images/background.png");

        int _iconHalfsize = 8;

        public AngleBasedForkPositionEditor()
        {
            InitializeComponent();
        }

        public event EventHandler<InputTransform> Saved;
        public void LoadTransform(InputTransform transform)
        {
            _transform = transform as AngleBasedForkPositionTransform;
            _editingTransform = _transform.Copy() as AngleBasedForkPositionTransform;
        }

        public void CreateTransform(double selectionMin, double selectionMax, double cursorX, double cursorY)
        {
            _transform = new AngleBasedForkPositionTransform();
            _editingTransform = new AngleBasedForkPositionTransform
            {
                Arm1Length = _transform.Arm1Length,
                Arm2Length = _transform.Arm2Length,
                SensorForkDistance = _transform.SensorForkDistance,
                BottomOutToSensorOffset = _transform.BottomOutToSensorOffset,
                UpperForkLegOffset = _transform.UpperForkLegOffset
            };
        }

        private void AngleBasedForkPositionEditor_Load(object sender, EventArgs e)
        {
            if (_transform == null)
            {
                MessageBox.Show(this, "You must load or create a transform before showing this dialog",
                    "Invalid Implementation!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Close();
                return;
            }

            arm1LengthInput.Text = $"{_transform.Arm1Length}";
            arm2LengthInput.Text = $"{_transform.Arm2Length}";
            legToSensorInput.Text = $"{_transform.SensorForkDistance}";
            bottomOutToSensorInput.Text = $"{_transform.BottomOutToSensorOffset}";
            upperLegOffsetInput.Text = $"{_transform.UpperForkLegOffset}";

            UpdateVisualization();
        }

        private void UpdateVisualization()
        {
            var sensorPosition = new Point(125 + (int)_editingTransform.SensorForkDistance, 264-(int)_editingTransform.BottomOutToSensorOffset);
            var arm1Pos = _editingTransform.GetArm1Position(visualizationPositionInput.Value);
            var arm2Pos = _editingTransform.GetArm2Position(arm1Pos);
            var linePen = new Pen(Color.Black, 4);

            var canvas = Graphics.FromImage(_visualization);
            canvas.Clear(Color.CornflowerBlue);

            canvas.DrawImageUnscaled(_backgroundImage, 0,0);
            canvas.DrawImageUnscaled(_forkLeg, 100, sensorPosition.Y - (int)arm2Pos.Item2 - 300 + (int)_editingTransform.UpperForkLegOffset);

            canvas.DrawLine(linePen, 
                sensorPosition.X - (int)arm1Pos.Item1, sensorPosition.Y - (int)arm1Pos.Item2,
                sensorPosition.X, sensorPosition.Y);

            canvas.DrawLine(linePen,
                sensorPosition.X - (int)arm1Pos.Item1, sensorPosition.Y - (int)arm1Pos.Item2,
                sensorPosition.X - (int)arm2Pos.Item1, sensorPosition.Y - (int)arm2Pos.Item2);

            canvas.DrawImage(_sensorAnchor, sensorPosition.X - _iconHalfsize, sensorPosition.Y - _iconHalfsize, 16, 16);
            canvas.DrawImage(_sensorPoint, sensorPosition.X - (int)arm1Pos.Item1 - _iconHalfsize, sensorPosition.Y - (int)arm1Pos.Item2 - _iconHalfsize, 16, 16);
            canvas.DrawImage(_sensorAnchor, sensorPosition.X - (int)arm2Pos.Item1 - _iconHalfsize, sensorPosition.Y - (int)arm2Pos.Item2 - _iconHalfsize, 16, 16);
            

            visualizationBox.Image = _visualization;

            forkPositionLabel.Text = $"{_editingTransform.Transform(visualizationPositionInput.Value):N} mm";
        }

        private void visualizationPositionInput_Scroll(object sender, EventArgs e)
        {
            UpdateVisualization();
        }

        private void arm1LengthInput_TextChanged(object sender, EventArgs e)
        {
            double newValue;
            if (double.TryParse(arm1LengthInput.Text, out newValue))
            {
                if (newValue <= 0)
                    return;

                _editingTransform.Arm1Length = newValue;
                UpdateVisualization();
            }
        }

        private void arm2LengthInput_TextChanged(object sender, EventArgs e)
        {
            double newValue;
            if (double.TryParse(arm2LengthInput.Text, out newValue))
            {
                if (newValue <= 0)
                    return;

                _editingTransform.Arm2Length = newValue;
                UpdateVisualization();
            }
        }

        private void legToSensorInput_TextChanged(object sender, EventArgs e)
        {
            double newValue;
            if (double.TryParse(legToSensorInput.Text, out newValue))
            {
                _editingTransform.SensorForkDistance = newValue;
                UpdateVisualization();
            }
        }

        private void bottomOutToSensorInput_TextChanged(object sender, EventArgs e)
        {
            double newValue;
            if (double.TryParse(bottomOutToSensorInput.Text, out newValue))
            {
                _editingTransform.BottomOutToSensorOffset = newValue;
                UpdateVisualization();
            }
        }

        private void upperLegOffsetInput_TextChanged(object sender, EventArgs e)
        {
            double newValue;
            if (double.TryParse(upperLegOffsetInput.Text, out newValue))
            {
                _editingTransform.UpperForkLegOffset = newValue;
                UpdateVisualization();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            double arm1Length, arm2Length;

            if (!double.TryParse(arm1LengthInput.Text, out arm1Length))
            {
                MessageBox.Show(this, $"Invalid Arm1 Length: '{arm1LengthInput.Text}'", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(arm2LengthInput.Text, out arm2Length))
            {
                MessageBox.Show(this, $"Invalid Arm2 Length: '{arm2LengthInput.Text}'", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double forkToSensor, bottomOutToSensor, upperLegOffset;

            if (!double.TryParse(legToSensorInput.Text, out forkToSensor))
            {
                MessageBox.Show(this, $"Invalid Leg to sensor: '{legToSensorInput.Text}'", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(bottomOutToSensorInput.Text, out bottomOutToSensor))
            {
                MessageBox.Show(this, $"Invalid bottom-out to sensor: '{bottomOutToSensorInput.Text}'", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(upperLegOffsetInput.Text, out upperLegOffset))
            {
                MessageBox.Show(this, $"Invalid upper leg offset: '{upperLegOffsetInput.Text}'", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _transform.Arm1Length = arm1Length;
            _transform.Arm2Length = arm2Length;
            _transform.SensorForkDistance = forkToSensor;
            _transform.BottomOutToSensorOffset = bottomOutToSensor;
            _transform.UpperForkLegOffset = upperLegOffset;

            Saved?.Invoke(this, _transform);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
