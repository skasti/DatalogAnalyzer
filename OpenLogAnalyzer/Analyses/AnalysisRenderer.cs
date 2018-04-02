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
using OpenLogger.Analysis;
using OpenLogger.Analysis.Analyses;
using OpenLogger.Core;
using DataPoint = OpenLogger.Analysis.DataPoint;

namespace OpenLogAnalyzer.Analyses
{
    public partial class AnalysisRenderer : UserControl
    {
        public IDataAnalysis Analysis { get; }
        public SegmentAnalysis Segment { get; }
        
        public AnalysisRenderer(IDataAnalysis analysis, SegmentAnalysis segment = null)
        {
            InitializeComponent();
            Analysis = analysis;
            Segment = segment;

            ToStringLabel.Text = analysis.ToString();

            if (Segment != null)
            {
                ToStringLabel.Text = $"{analysis.Name} ({Segment.Name})";
                var series = AnalysisChart.Series.FirstOrDefault();

                if (series == null)
                    return;

                series.Color = Segment.SegmentColor;
            }
        }

        public void Render(List<DataPoint> data)
        {
            var series = AnalysisChart.Series.FirstOrDefault();

            if (series == null)
                return;

            series.Points.Clear();

            foreach (var point in data)
            {
                var customLabel = Analysis.CustomLabel(point);
                var dataPoint = point.ToDataPoint();

                if (!string.IsNullOrWhiteSpace(customLabel))
                {
                    dataPoint.ToolTip = customLabel;
                }

                series.Points.Add(dataPoint);
            }

            series.ChartType = Analysis.GraphType.ToSeriesChartType();
        }
    }
}
