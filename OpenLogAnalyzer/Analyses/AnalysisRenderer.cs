using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using OpenLogAnalyzer.Extensions;
using OpenLogger.Analysis.Analyses;
using DataPoint = OpenLogger.Analysis.DataPoint;

namespace OpenLogAnalyzer.Analyses
{
    public partial class AnalysisRenderer : UserControl
    {
        private IDataAnalysis _analysis;
        public AnalysisRenderer(IDataAnalysis analysis)
        {
            InitializeComponent();
            _analysis = analysis;

            ToStringLabel.Text = analysis.ToString();
        }

        public void Render(List<DataPoint> data)
        {
            var series = AnalysisChart.Series.FirstOrDefault();

            if (series == null)
                return;

            series.Points.Clear();

            foreach (var point in data)
            {
                var customLabel = _analysis.CustomLabel(point);
                var dataPoint = point.ToDataPoint();

                if (!string.IsNullOrWhiteSpace(customLabel))
                {
                    //dataPoint.Label = customLabel;
                    //dataPoint.LabelAngle = -90;
                    dataPoint.ToolTip = customLabel;
                }

                series.Points.Add(dataPoint);
            }

            //series.SmartLabelStyle.Enabled = false;
            series.ChartType = _analysis.GraphType.ToSeriesChartType();
        }
    }
}
