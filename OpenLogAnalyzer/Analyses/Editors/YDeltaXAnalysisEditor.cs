using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenLogger.Analysis.Analyses;

namespace OpenLogAnalyzer.Analyses.Editors
{
    [DisplayName("ΔY over ΔX")]
    [Description("Used to derive velocity from position, or acceleration from velocity")]
    public partial class YDeltaXAnalysisEditor : Form, IEditDataAnalysis<YDeltaXAnalysis>
    {
        private YDeltaXAnalysis _analysis;

        public event EventHandler<IDataAnalysis> Saved;
        public YDeltaXAnalysisEditor()
        {
            InitializeComponent();
        }

        public void Create()
        {
            _analysis = new YDeltaXAnalysis
            {
                Name = "Unnamed"
            };
        }

        public void LoadAnalysis(IDataAnalysis analysis)
        {
            _analysis = analysis as YDeltaXAnalysis;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var clampValue = clampValueInput.Checked;

            if (clampValue)
            {
                double clampMin, clampMax;

                if (!double.TryParse(clampMinInput.Text, out clampMin))
                {
                    MessageBox.Show(this, $"Invalid clamp minimum: '{clampMinInput.Text}'", "Invalid number format",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(clampMaxInput.Text, out clampMax))
                {
                    MessageBox.Show(this, $"Invalid clamp maximum: '{clampMaxInput.Text}'", "Invalid number format",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (clampMin >= clampMax)
                {
                    MessageBox.Show(this, $"Clamp minimum must be smaller than clamp maximum: {clampMin:N} >= {clampMax:N}", "Invalid clamping",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _analysis.ClampMaximum = clampMax;
                _analysis.ClampMinimum = clampMin;
            }
            _analysis.ClampValue = clampValue;
            _analysis.Name = nameInput.Text;

            Saved?.Invoke(this, _analysis);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void YDeltaXAnalysisEditor_Load(object sender, EventArgs e)
        {
            if (_analysis == null)
            {
                MessageBox.Show(this, "You must load or create an analysis before showing this dialog",
                    "Invalid Implementation!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Close();
                return;
            }

            nameInput.Text = _analysis.Name;
            clampValueInput.Checked = _analysis.ClampValue;

            if (_analysis.ClampMinimum > double.MinValue)
                clampMinInput.Text = $"{_analysis.ClampMinimum:N}";

            if (_analysis.ClampMaximum < double.MaxValue)
                clampMaxInput.Text = $"{_analysis.ClampMaximum:N}";
        }

        private void clampValueInput_CheckedChanged(object sender, EventArgs e)
        {
            if (clampValueInput.Checked)
            {
                clampMinInput.Enabled = true;
                clampMaxInput.Enabled = true;
            }
            else
            {
                clampMinInput.Enabled = false;
                clampMaxInput.Enabled = false;
            }
        }
    }
}
