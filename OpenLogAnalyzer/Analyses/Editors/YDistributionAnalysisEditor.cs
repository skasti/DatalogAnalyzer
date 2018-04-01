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
    [DisplayName("Y-distribution")]
    [Description("Used to make velocity-histograms etc.")]
    public partial class YDistributionAnalysisEditor : Form, IEditDataAnalysis<YDistributionAnalysis>
    {
        private YDistributionAnalysis _analysis;
        public event EventHandler<IDataAnalysis> Saved;
        public YDistributionAnalysisEditor()
        {
            InitializeComponent();
        }
        
        public void Create()
        {
            _analysis = new YDistributionAnalysis
            {
                Name = "Unnamed Distribution"
            };
        }

        public void LoadAnalysis(IDataAnalysis analysis)
        {
            _analysis = analysis as YDistributionAnalysis;
        }

        private void YDistributionAnalysisEditor_Load(object sender, EventArgs e)
        {
            if (_analysis == null)
            {
                MessageBox.Show(this, "You must load or create an analysis before showing this dialog",
                    "Invalid Implementation!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Close();
                return;
            }

            nameInput.Text = _analysis.Name;
            clampInputInput.Checked = _analysis.ClampInput;

            yMinInput.Text = $"{_analysis.MinimumY:N}";
            yMaxInput.Text = $"{_analysis.MaximumY:N}";
            intervalInput.Text = $"{_analysis.Interval:N}";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            double yMin, yMax, interval;

            if (!double.TryParse(yMinInput.Text, out yMin))
            {
                MessageBox.Show(this, $"Invalid Y minimum: '{yMinInput.Text}'", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(yMaxInput.Text, out yMax))
            {
                MessageBox.Show(this, $"Invalid Y maximum: '{yMaxInput.Text}'", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(intervalInput.Text, out interval))
            {
                MessageBox.Show(this, $"Invalid interval: '{intervalInput.Text}'", "Invalid number format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (yMin >= yMax)
            {
                MessageBox.Show(this, $"Y minimum must be smaller than Y maximum: {yMin:N} >= {yMax:N}", "Invalid entries",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _analysis.MaximumY = yMax;
            _analysis.MinimumY = yMin;
            _analysis.Interval = interval;
            _analysis.ClampInput = clampInputInput.Checked;
            _analysis.Name = nameInput.Text;

            Saved?.Invoke(this, _analysis);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
