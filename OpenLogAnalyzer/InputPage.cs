using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenLogAnalyzer.Analyses;
using OpenLogAnalyzer.Extensions;
using OpenLogger.Analysis;
using OpenLogger.Analysis.Analyses;
using OpenLogger.Analysis.Vehicle.Inputs;

namespace OpenLogAnalyzer
{
    public partial class InputPage : UserControl
    {
        public Input Input { get; }

        public double XSelectionStart
        {
            get
            {
                var sel = RawChart.ChartAreas.First().AxisX.ScaleView.ViewMinimum;
                return sel;
            }
        }

        public double XSelectionEnd
        {
            get
            {
                var sel = RawChart.ChartAreas.First().AxisX.ScaleView.ViewMaximum;
                return sel;
            }
        }

        private int _zoomOperations = 0;

        private readonly List<SegmentAnalysis> _currentSegments = new List<SegmentAnalysis>();

        private readonly Dictionary<IDataAnalysis, TabPage> _analysisTabs = new Dictionary<IDataAnalysis, TabPage>();
        private readonly List<AnalysisRenderer> _analysisRenderers = new List<AnalysisRenderer>();

        private readonly Dictionary<SegmentAnalysis, List<DataPoint>> _segmentData = new Dictionary<SegmentAnalysis, List<DataPoint>>(); 

        public InputPage(Input input)
        {
            InitializeComponent();
            Input = input;

            foreach (var analysis in Input.Analyses)
            {
                GetAnalysisTab(analysis);
            }
        }

        public void Render(SegmentAnalysis segment)
        {
            Render(new[] { segment });
        }

        public void Render(IEnumerable<SegmentAnalysis> segments)
        {
            _currentSegments.Clear();
            _currentSegments.AddRange(segments);

            PruneSeries();
            PruneAnalysisRenderers();

            UpdateSegmentData();

            foreach (var segment in segments)
            {
                RenderSegmentRawSeries(segment);

                var data = _segmentData[segment];

                foreach (var analysis in Input.Analyses)
                {
                    data = analysis.Analyze(data);
                    var renderer = GetRenderer(analysis, segment);
                    renderer.Render(data);
                }
            }

            var chartArea = RawChart.ChartAreas.First();

            if (Input.AutoGraphRange)
            {
                chartArea.AxisY.Minimum = double.NaN;
                chartArea.AxisY.Maximum = double.NaN;
                chartArea.RecalculateAxesScale();
            }
            else
            {
                if (Input.GraphMin >= Input.GraphMax)
                {
                    chartArea.AxisY.Minimum = 0;
                    chartArea.AxisY.Maximum = 1000;

                    MessageBox.Show($"Input '{Input.Name}' has invalid values for graph range", "Invalid Graph Range",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    chartArea.AxisY.Minimum = Input.GraphMin;
                    chartArea.AxisY.Maximum = Input.GraphMax;
                }
            }
        }

        private void UpdateSegmentData()
        {
            var removedSegments = _segmentData.Keys.Where(k => !_currentSegments.Contains(k)).ToList();

            foreach (var segment in removedSegments)
                _segmentData.Remove(segment);

            Parallel.ForEach(_currentSegments, analysis =>
            {
                var data = Input.Extract(analysis.Segment);

                if (!_segmentData.ContainsKey(analysis))
                    _segmentData.Add(analysis, data);
                else
                    _segmentData[analysis] = data;
            });
        }

        private void PruneAnalysisRenderers()
        {
            var deleteRenderers =
                _analysisRenderers.Where(renderer => !_currentSegments.Contains(renderer.Segment)).ToList();

            foreach (var renderer in deleteRenderers)
            {
                var page = GetAnalysisTab(renderer.Analysis);
                page.Controls.Remove(renderer);
                _analysisRenderers.Remove(renderer);
            }
        }

        private void PruneSeries()
        {
            var deleteSeries =
                RawChart.Series.Where(series => _currentSegments.All(segment => segment.Name != series.Name)).ToList();

            foreach (var series in deleteSeries)
            {
                RawChart.Series.Remove(series);
            }
        }

        private AnalysisRenderer GetRenderer(IDataAnalysis analysis, SegmentAnalysis segment)
        {
            var renderer = _analysisRenderers.FirstOrDefault(r => r.Segment == segment && r.Analysis == analysis);

            if (renderer != null)
            {
                ScaleRenderer(analysis, segment, renderer);
                return renderer;
            }

            renderer = new AnalysisRenderer(analysis, segment);
            ScaleRenderer(analysis, segment, renderer);
            _analysisRenderers.Add(renderer);

            return renderer;
        }

        private void ScaleRenderer(IDataAnalysis analysis, SegmentAnalysis segment, AnalysisRenderer renderer)
        {
            var index = _currentSegments.IndexOf(segment);
            var page = GetAnalysisTab(analysis);

            page.Controls.Add(renderer);

            if (_currentSegments.Count > 1)
            {
                var height = renderer.MinimumSize.Height;

                if (page.Height >= renderer.MinimumSize.Height*_currentSegments.Count)
                {
                    height = page.Height/_currentSegments.Count;
                }

                renderer.Location = new Point(0, index*height);
                renderer.Size = new Size(page.Width, height);
                renderer.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            }
            else
            {
                renderer.Location = new Point(0, 0);
                renderer.Size = new Size(page.Width, page.Height);
                renderer.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            }
        }

        private TabPage GetAnalysisTab(IDataAnalysis analysis)
        {
            if (_analysisTabs.ContainsKey(analysis))
                return _analysisTabs[analysis];

            var tabPage = new TabPage(analysis.Name);
            inputTabs.TabPages.Add(tabPage);

            tabPage.AutoScroll = true;

            _analysisTabs.Add(analysis, tabPage);

            return tabPage;
        }

        private void RenderSegmentRawSeries(SegmentAnalysis segment)
        {
            var data = _segmentData[segment];
            var series = RawChart.Series.FindByName(segment.Name);

            if (series == null)
            {
                series = Input.CreateSeries(segment);
                RawChart.Series.Add(series);
                series.Points.AddRange(data);
            }
            else
            {
                series.Points.Update(data);
            }
        }

        public void SetCursor(double distance, double time)
        {
            switch (Input.XAxisType)
            {
                case InputXAxis.Time:
                    RawChart.ChartAreas[0].CursorX.Position = time;
                    break;
                case InputXAxis.Distance:
                    RawChart.ChartAreas[0].CursorX.Position = distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            RawChart.UpdateCursor();
        }

        private void ToggleZoomEnableButton_Click(object sender, EventArgs e)
        {
            var chartArea = RawChart.ChartAreas.First();

            chartArea.AxisX.ScaleView.Zoomable = ToggleZoomEnableButton.Checked;
            chartArea.AxisY.ScaleView.Zoomable = ToggleZoomEnableButton.Checked;

            if (!ToggleZoomEnableButton.Checked)
                ResetZoom();
        }

        private void ResetZoomButton_Click(object sender, EventArgs e)
        {
            ResetZoom();
        }

        private void ResetZoom()
        {
            var chartArea = RawChart.ChartAreas.First();

            chartArea.AxisX.ScaleView.ZoomReset(_zoomOperations);
            chartArea.AxisY.ScaleView.ZoomReset(_zoomOperations);

            _zoomOperations = 0;
        }
    }
}
