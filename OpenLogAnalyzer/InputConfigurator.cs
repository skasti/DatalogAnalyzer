using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using OpenLogAnalyzer.Analyses;
using OpenLogAnalyzer.Extensions;
using OpenLogAnalyzer.Transforms;
using OpenLogger.Analysis;
using OpenLogger.Analysis.Analyses;
using OpenLogger.Analysis.Extensions;
using OpenLogger.Analysis.Vehicle.Inputs;
using OpenLogger.Analysis.Vehicle.Inputs.Transforms;
using OpenLogger.Core;
using DataPoint = OpenLogger.Analysis.DataPoint;

namespace OpenLogAnalyzer
{
    public partial class InputConfigurator : Form
    {
        public bool Saved { get; set; }
        public Input Input { get; }
        private Input _editingInput;
        private SegmentAnalysis _segment;
        private GMapOverlay _segmentOverlay = new GMapOverlay("Segment");
        private GMapMarker _marker;
        private List<DataPoint> _rawData;
        private List<DataPoint> _smoothedData;
        private List<DataPoint> _transformedData;
        private bool _loaded = false;
        public event EventHandler<Input> OnSave; 

        private Dictionary<IDataAnalysis, AnalysisRenderer> _analysisRenderers = new Dictionary<IDataAnalysis, AnalysisRenderer>();
        private List<ListViewItem> _analysisListItems = new List<ListViewItem>();

        public InputConfigurator()
        {
            InitializeComponent();
        }

        public InputConfigurator(LogSegment segment, Input input = null)
        {
            InitializeComponent();
            _segment = new SegmentAnalysis(segment,"NewInputAnalysis");
            Input = input ?? new Input
            {
                Name = "Unnamed"
            };

            _editingInput = Input.Copy();
        }

        private double TransformedCursorY => TransformChart.ChartAreas[0].CursorY.Position;

        private double TransformedCursorX => TransformChart.ChartAreas[0].CursorX.Position;

        private double TransformedSelectionMax => TransformChart.ChartAreas[0].CursorY.SelectionStart > TransformChart.ChartAreas[0].CursorY.SelectionEnd ? 
            TransformChart.ChartAreas[0].CursorY.SelectionStart : TransformChart.ChartAreas[0].CursorY.SelectionEnd;

        private double TransformedSelectionMin => TransformChart.ChartAreas[0].CursorY.SelectionStart > TransformChart.ChartAreas[0].CursorY.SelectionEnd ? 
            TransformChart.ChartAreas[0].CursorY.SelectionEnd : TransformChart.ChartAreas[0].CursorY.SelectionStart;

        private void InitSourceInput()
        {
            foreach (var inputSource in Enum.GetValues(typeof(InputSource)).Cast<InputSource>())
            {
                if (inputSource == InputSource.Analog)
                {
                    var name = inputSource.ToString();

                    for (int i = 0; i < _segment.Segment.ValueCount - 6; i++)
                    {
                        SourceInput.Items.Add($"{name} {i+1}");
                    }
                }
                else if (inputSource == InputSource.Temperature)
                {
                    var name = inputSource.ToString();

                    for (int i = 0; i < 6; i++)
                    {
                        SourceInput.Items.Add($"{name} {i+1}");
                    }
                }
                else
                {
                    SourceInput.Items.Add(inputSource.ToString());
                }
            }
        }

        private void InputConfigurator_Load(object sender, EventArgs e)
        {
            InitMap();

            SegmentPosition.Maximum = _segment.Segment.Entries.Count - 1;

            InitSourceInput();
            InitXAxisInput();

            if (_editingInput.Source == InputSource.Analog)
            {
                SourceInput.SelectedItem = $"{InputSource.Analog} {_editingInput.AnalogSource + 1}";
            }
            else if (_editingInput.Source == InputSource.Temperature)
            {
                SourceInput.SelectedItem = $"{InputSource.Temperature} {_editingInput.AnalogSource + 1}";
            }
            else
            {
                SourceInput.SelectedItem = _editingInput.Source.ToString();
            }

            xAxisInput.SelectedItem = _editingInput.XAxisType.ToString();

            NameInput.Text = _editingInput.Name;
            SmoothingInput.Value = _editingInput.Smoothing;

            autoRangeInput.Checked = _editingInput.AutoGraphRange;
            rangeMinInput.Value = (decimal)_editingInput.GraphMin;
            rangeMaxInput.Value = (decimal)_editingInput.GraphMax;

            UpdateTransformsList();
            UpdateAnalysesList();

            InitTransformsListMenu();
            InitAnalysesListMenu();
        }

        private void InitXAxisInput()
        {
            foreach (var axisType in Enum.GetValues(typeof (InputXAxis)).Cast<InputXAxis>())
            {
                xAxisInput.Items.Add(axisType.ToString());
            }
        }

        private void InitTransformsListMenu()
        {
            foreach (var editorType in TransformEditors.EditorTypes)
            {
                var name = TransformEditors.GetEditorName(editorType);
                var button = new ToolStripMenuItem(name);
                button.Click += (sender, args) =>
                {
                    var editor = editorType.GetConstructor(new Type[0])?.Invoke(new object[0]) as IEditInputTransforms;
                    editor.Create(
                        TransformedSelectionMin, 
                        TransformedSelectionMax, 
                        TransformedCursorX, 
                        TransformedCursorY);

                    editor.Saved += (o, transform) =>
                    {
                        _editingInput.Transforms.Add(transform);
                        UpdateTransformsList();
                        UpdateTransformChart();
                    };

                    editor.ShowDialog(this);
                };


                AddTransformMenu.DropDownItems.Add(button);
            }
        }

        private void InitAnalysesListMenu()
        {
            foreach (var editorType in AnalysisEditors.EditorTypes)
            {
                var name = AnalysisEditors.GetEditorName(editorType);
                var description = AnalysisEditors.GetEditorDescription(editorType);

                var button = new ToolStripMenuItem(name);

                if (!string.IsNullOrWhiteSpace(description))
                    button.ToolTipText = description;

                button.Click += (sender, args) =>
                {
                    var editor = editorType.GetConstructor(new Type[0])?.Invoke(new object[0]) as IEditDataAnalysis;
                    editor.Create();

                    editor.Saved += (o, analysis) =>
                    {
                        _editingInput.Analyses.Add(analysis);

                        UpdateAnalysesList();
                        UpdateAnalysesRenders();
                    };

                    editor.ShowDialog(this);
                };


                AddAnalysisMenu.DropDownItems.Add(button);
            }
        }

        private void UpdateTransformsList()
        {
            TransformList.Items.Clear();

            foreach (var transform in _editingInput.Transforms)
            {
                var item = new ListViewItem(transform.ToString());
                item.Tag = transform;

                TransformList.Items.Add(item);
            }
        }

        private void InitMap()
        {
            var firstPos = _segment.Segment.Entries.First().GetLocation();

            Map.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            _marker = new GMarkerGoogle(firstPos, GMarkerGoogleType.red_small);

            var route = _segment.Route;
            _segmentOverlay.Markers.Add(_marker);
            _segmentOverlay.Routes.Add(route);
            Map.Overlays.Add(_segmentOverlay);
            Map.ZoomAndCenterMarkers(_segmentOverlay.Id);
        }

        private void UpdateCharts()
        {
            if (!_loaded)
                return;

            UpdatePreChart();
            UpdateTransformChart();
        }

        private void UpdateTransformChart()
        {
            var selectedTransform = TransformList.SelectedItems.Count >= 1 ? TransformList.SelectedItems[0].Tag as IInputTransform : null;

            _transformedData = _editingInput.Transform(_smoothedData, selectedTransform);

            TransformChart.Series[0].Points.Update(_transformedData);
        }

        private void UpdatePreChart()
        {
            UpdateRawChart();
            UpdateSmoothedChart();
            var chartArea = RawChart.ChartAreas.FirstOrDefault();
            
            chartArea.AxisY.Maximum = double.NaN;
            chartArea.AxisY.Minimum = double.NaN;
            chartArea.RecalculateAxesScale();
        }

        private void UpdateSmoothedChart()
        {
            _smoothedData = _editingInput.Smooth(_rawData);

            RawChart.Series[1].Points.Update(_smoothedData);
        }

        private void UpdateRawChart()
        {
            _rawData = _editingInput.ExtractRaw(_segment.Segment);

            RawChart.Series[0].Points.Update(_rawData);
        }

        private void SourceInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loaded)
                return;

            InputSource newSource = InputSource.Analog;
            if (Enum.TryParse(SourceInput.Text, out newSource))
            {
                _editingInput.Source = newSource;
            }
            else
            {
                if (SourceInput.Text.StartsWith("Analog"))
                    _editingInput.Source = InputSource.Analog;
                else
                    _editingInput.Source = InputSource.Temperature;

                _editingInput.AnalogSource = int.Parse(SourceInput.Text.Split(' ').Last()) - 1;
            }

            UpdateCharts();
        }

        private void SmoothingInput_ValueChanged(object sender, EventArgs e)
        {
            if (!_loaded)
                return;

            _editingInput.Smoothing = (int) SmoothingInput.Value;
            UpdateSmoothedChart();
            UpdateTransformChart();
        }

        private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            SelectionLabel.Text = $"{e.NewSelectionStart} - {e.NewSelectionEnd}";
        }

        private void chart1_CursorPositionChanged(object sender, CursorEventArgs e)
        {
            CursorLabel.Text = $"{RawChart.ChartAreas[0].CursorX.Position:0.00} / {RawChart.ChartAreas[0].CursorY.Position:0.00}";
        }

        private void SegmentPosition_Scroll(object sender, EventArgs e)
        {
            var entryIndex = Math.Min(SegmentPosition.Value, _segment.Segment.Entries.Count - 1);
            var entry = _segment.Segment.Entries[entryIndex];
            var cursorPosition = entry.GetTimeSpan(_segment.Segment.LogStart).TotalSeconds;
            var zoomMin = Math.Max(cursorPosition - 10, 0.0);
            var zoomMax = Math.Min(cursorPosition + 10, _segment.Segment.Length.TotalSeconds);

            RawChart.ChartAreas[0].Axes[0].ScaleView.Zoom(zoomMin, zoomMax);
            RawChart.ChartAreas[0].CursorX.Position = cursorPosition;

            CursorLabel.Text = $"{RawChart.ChartAreas[0].CursorX.Position:0.00} / {RawChart.ChartAreas[0].CursorY.Position:0.00}";

            TransformChart.ChartAreas[0].Axes[0].ScaleView.Zoom(zoomMin, zoomMax);
            TransformChart.ChartAreas[0].CursorX.Position = cursorPosition;

            TransformCursorLabel.Text = $"{TransformChart.ChartAreas[0].CursorX.Position:0.00} / {TransformChart.ChartAreas[0].CursorY.Position:0.00}";

            _marker.Position = entry.GetLocation();
        }

        private void TransformChart_CursorPositionChanged(object sender, CursorEventArgs e)
        {
            TransformCursorLabel.Text = $"{TransformChart.ChartAreas[0].CursorX.Position:0.00} / {TransformChart.ChartAreas[0].CursorY.Position:0.00}";
        }

        private void TransformChart_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            TransformSelectionLabel.Text = $"{e.NewSelectionStart} - {e.NewSelectionEnd}";
        }

        private void TransformList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loaded)
                return;

            UpdateTransformChart();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            _editingInput.Name = NameInput.Text;
            _editingInput.SaveTo(Input);
            Saved = true;
            OnSave?.Invoke(this, Input);
        }

        private void InputConfigurator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saved && MessageBox.Show("Do you want to save your changes?", "Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Save();
            }
        }

        private void autoRangeInput_CheckedChanged(object sender, EventArgs e)
        {
            if (!_loaded)
                return;

            _editingInput.AutoGraphRange = autoRangeInput.Checked;

            var chartArea = TransformChart.ChartAreas.FirstOrDefault();

            if (!_editingInput.AutoGraphRange)
            {
                chartArea.AxisY.Maximum = (double) rangeMaxInput.Value;
                chartArea.AxisY.Minimum = (double) rangeMinInput.Value;
            }
            else
            {
                chartArea.AxisY.Maximum = double.NaN;
                chartArea.AxisY.Minimum = double.NaN;
                chartArea.RecalculateAxesScale();
            }
        }

        private void rangeMaxInput_ValueChanged(object sender, EventArgs e)
        {
            if (!_loaded)
                return;

            if (rangeMaxInput.Value <= rangeMinInput.Value)
            {
                rangeMaxInput.Value = rangeMinInput.Value + 1;
                MessageBox.Show("Max must be larger than Min", "Invalid value", MessageBoxButtons.OK);
                return;
            }

            if (autoRangeInput.Checked)
                return;

            var chartArea = TransformChart.ChartAreas.FirstOrDefault();
            _editingInput.GraphMax = (double) rangeMaxInput.Value;
            chartArea.AxisY.Maximum = (double) rangeMaxInput.Value;
            _editingInput.AutoGraphRange = false;
            autoRangeInput.Checked = false;
        }

        private void rangeMinInput_ValueChanged(object sender, EventArgs e)
        {
            if (!_loaded)
                return;

            if (rangeMinInput.Value >= rangeMaxInput.Value)
            {
                rangeMinInput.Value = rangeMaxInput.Value - 1;
                MessageBox.Show("Min must be smaller than Max", "Invalid value", MessageBoxButtons.OK);
                return;
            }

            if (autoRangeInput.Checked)
                return;

            var chartArea = TransformChart.ChartAreas.FirstOrDefault();
            _editingInput.GraphMin = (double) rangeMinInput.Value;
            chartArea.AxisY.Minimum = (double) rangeMinInput.Value;
            _editingInput.AutoGraphRange = false;
            autoRangeInput.Checked = false;
        }

        private void xAxisInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            InputXAxis newAxis = InputXAxis.Distance;
            if (Enum.TryParse(xAxisInput.Text, out newAxis))
            {
                _editingInput.XAxisType = newAxis;
                UpdateCharts();
            }
        }

        private void InputConfigurator_Shown(object sender, EventArgs e)
        {
            _loaded = true;
            UpdateCharts();
            UpdateAnalysesRenders();
        }

        private void AnalysesListMenu_Opening(object sender, CancelEventArgs e)
        {
            var selectedAnalysis = AnalysesList.SelectedItems.Count >= 1 ? AnalysesList.SelectedItems[0].Tag as IDataAnalysis : null;

            if (selectedAnalysis != null)
            {
                var index = _editingInput.Analyses.IndexOf(selectedAnalysis);

                MoveAnalysisDownButton.Enabled = (index < _editingInput.Analyses.Count - 1);
                MoveAnalysisUpButton.Enabled = (index > 0);
                EditAnalysisButton.Enabled = true;
                DeleteAnalysisButton.Enabled = true;
            }
            else
            {
                MoveAnalysisDownButton.Enabled = false;
                MoveAnalysisUpButton.Enabled = false;
                EditAnalysisButton.Enabled = false;
                DeleteAnalysisButton.Enabled = false;
            }
        }

        private void TransformListMenu_Opening(object sender, CancelEventArgs e)
        {
            var selectedTransform = TransformList.SelectedItems.Count >= 1 ? TransformList.SelectedItems[0].Tag as IInputTransform : null;

            if (selectedTransform != null)
            {
                var index = _editingInput.Transforms.IndexOf(selectedTransform);

                MoveTransformDownButton.Enabled = (index < _editingInput.Transforms.Count - 1);
                MoveTransformUpButton.Enabled = (index > 0);
                EditTransformButton.Enabled = true;
                DeleteTransformButton.Enabled = true;
            }
            else
            {
                MoveTransformDownButton.Enabled = false;
                MoveTransformUpButton.Enabled = false;
                EditTransformButton.Enabled = false;
                DeleteTransformButton.Enabled = false;
            }
        }

        private void EditTransformButton_Click(object sender, EventArgs e)
        {
            var selectedTransform = TransformList.SelectedItems.Count >= 1 ? TransformList.SelectedItems[0].Tag as IInputTransform : null;

            if (selectedTransform == null)
                return;
            
            var editor = TransformEditors.GetTransformEditor(selectedTransform);

            if (editor == null)
            {
                MessageBox.Show("Couldn't find editor for this transform type", "No editor", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            editor.LoadTransform(selectedTransform);
            editor.Saved += (o, transform) =>
            {
                UpdateTransformsList();
                UpdateTransformChart();
            };
            editor.ShowDialog(this);
        }

        private void DeleteTransformButton_Click(object sender, EventArgs e)
        {
            var selectedTransform = TransformList.SelectedItems.Count >= 1 ? TransformList.SelectedItems[0].Tag as IInputTransform : null;

            if (selectedTransform == null)
                return;

            if (MessageBox.Show(
                    "Are you sure you want to delete this transform?", "Delete transform",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }

            _editingInput.Transforms.Remove(selectedTransform);

            UpdateTransformsList();
            UpdateTransformChart();
        }
        private void MoveTransformUpButton_Click(object sender, EventArgs e)
        {
            var selectedTransform = TransformList.SelectedItems.Count >= 1 ? TransformList.SelectedItems[0].Tag as IInputTransform : null;

            if (selectedTransform == null)
                return;

            var currentIndex = _editingInput.Transforms.IndexOf(selectedTransform);

            if (currentIndex == 0)
                return;

            _editingInput.Transforms.Remove(selectedTransform);
            _editingInput.Transforms.Insert(currentIndex-1, selectedTransform);

            UpdateTransformsList();
            UpdateTransformChart();
        }

        private void MoveTransformDownButton_Click(object sender, EventArgs e)
        {
            var selectedTransform = TransformList.SelectedItems.Count >= 1 ? TransformList.SelectedItems[0].Tag as IInputTransform : null;

            if (selectedTransform == null)
                return;

            var currentIndex = _editingInput.Transforms.IndexOf(selectedTransform);

            if (currentIndex >= _editingInput.Transforms.Count - 1)
                return;

            _editingInput.Transforms.Remove(selectedTransform);
            _editingInput.Transforms.Insert(currentIndex + 1, selectedTransform);

            UpdateTransformsList();
            UpdateTransformChart();
        }

        private void UpdateAnalysesRenders()
        {
            var currentData = _transformedData;

            foreach (var analysis in _editingInput.Analyses)
            {
                var index = _editingInput.Analyses.IndexOf(analysis);

                currentData = analysis.Analyze(currentData);

                if (!_analysisRenderers.ContainsKey(analysis))
                {
                    var renderer = new AnalysisRenderer(analysis);
                    AnalysisRenderPanel.Controls.Add(renderer);
                    renderer.Location = new Point(0, index * renderer.MinimumSize.Height);
                    renderer.Size = new Size(AnalysisRenderPanel.Width, renderer.MinimumSize.Height);
                    renderer.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

                    _analysisRenderers.Add(analysis, renderer);
                }

                _analysisRenderers[analysis].Render(currentData);
                _analysisRenderers[analysis].Location = new Point(0, index * _analysisRenderers[analysis].MinimumSize.Height);
            }
        }

        private void UpdateAnalysesList()
        {
            foreach (var analysis in _editingInput.Analyses)
            {
                var item = _analysisListItems.FirstOrDefault(li => li.Tag == analysis);

                if (item == null)
                {
                    item = new ListViewItem(analysis.Name);
                    item.SubItems.Add(analysis.GetDetails());
                    item.Tag = analysis;

                    _analysisListItems.Add(item);
                    AnalysesList.Items.Add(item);
                }
                else
                {
                    item.Text = analysis.Name;
                    item.SubItems[1].Text = analysis.GetDetails();
                }
            }

            var deleteItems = _analysisListItems.Where(li => !_editingInput.Analyses.Contains(li.Tag as IDataAnalysis)).ToList();

            foreach (var item in deleteItems)
            {
                _analysisListItems.Remove(item);
                AnalysesList.Items.Remove(item);
            }
        }

        private void EditAnalysisButton_Click(object sender, EventArgs e)
        {
            var selectedAnalysis = AnalysesList.SelectedItems.Count >= 1 ? AnalysesList.SelectedItems[0].Tag as IDataAnalysis : null;

            if (selectedAnalysis == null)
                return;

            var editor = AnalysisEditors.GetAnalysisEditor(selectedAnalysis);

            if (editor == null)
            {
                MessageBox.Show("Couldn't find editor for this analysis type", "No editor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            editor.LoadAnalysis(selectedAnalysis);
            editor.Saved += (o, analysis) =>
            {
                UpdateAnalysesList();
                UpdateAnalysesRenders();
            };

            editor.ShowDialog(this);
        }

        private void DeleteAnalysisButton_Click(object sender, EventArgs e)
        {
            var selectedAnalysis = AnalysesList.SelectedItems.Count >= 1 ? AnalysesList.SelectedItems[0].Tag as IDataAnalysis : null;

            if (selectedAnalysis == null)
                return;

            if (MessageBox.Show(
                    "Are you sure you want to delete this analysis?", "Delete Analysis",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }

            _editingInput.Analyses.Remove(selectedAnalysis);

            UpdateAnalysesList();
            UpdateAnalysesRenders();
        }

        private void MoveAnalysisUpButton_Click(object sender, EventArgs e)
        {
            var selectedAnalysis = AnalysesList.SelectedItems.Count >= 1 ? AnalysesList.SelectedItems[0].Tag as IDataAnalysis : null;

            if (selectedAnalysis == null)
                return;

            var currentIndex = _editingInput.Analyses.IndexOf(selectedAnalysis);

            if (currentIndex >= _editingInput.Analyses.Count - 1)
                return;

            _editingInput.Analyses.Remove(selectedAnalysis);
            _editingInput.Analyses.Insert(currentIndex + 1, selectedAnalysis);

            UpdateAnalysesList();
            UpdateAnalysesRenders();
        }

        private void MoveAnalysisDownButton_Click(object sender, EventArgs e)
        {
            var selectedAnalysis = AnalysesList.SelectedItems.Count >= 1 ? AnalysesList.SelectedItems[0].Tag as IDataAnalysis : null;

            if (selectedAnalysis == null)
                return;

            var currentIndex = _editingInput.Analyses.IndexOf(selectedAnalysis);

            if (currentIndex >= _editingInput.Analyses.Count - 1)
                return;

            _editingInput.Analyses.Remove(selectedAnalysis);
            _editingInput.Analyses.Insert(currentIndex + 1, selectedAnalysis);

            UpdateAnalysesList();
            UpdateAnalysesRenders();
        }
    }
}
