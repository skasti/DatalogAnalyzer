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
    public partial class LinearMapEditor : Form
    {
        public LinearMapTransform Transform { get; private set; }

        public event EventArgs Save;

        public LinearMapEditor(LinearMapTransform transform)
        {
            InitializeComponent();

            Transform = transform;
        }

        private void LinearMapEditor_Load(object sender, EventArgs e)
        {
            FromMinInput.Text = $"{Transform.SourceMin}";
            FromMaxInput.Text = $"{Transform.SourceMax}";
            ToMinInput.Text = $"{Transform.TargetMin}";
            ToMaxInput.Text = $"{Transform.TargetMax}";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
