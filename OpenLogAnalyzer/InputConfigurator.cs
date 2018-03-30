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
using OpenLogAnalyzer.Transforms;
using OpenLogger.Analysis;
using OpenLogger.Analysis.Extensions;
using OpenLogger.Analysis.Vehicle.Inputs;
using OpenLogger.Analysis.Vehicle.Inputs.Transforms;
using OpenLogger.Core;

namespace OpenLogAnalyzer
{
    public partial class InputConfigurator : Form
    {
        public bool Saved { get; set; }
        public Input Input { get; }
        private Input _editingInput;
        private LogSegment _segment;
        private GMapOverlay _segmentOverlay = new GMapOverlay("Segment");
        private GMapMarker _marker;
        public event EventHandler<Input> OnSave; 

        public InputConfigurator()
        {
            InitializeComponent();
        }

        public InputConfigurator(LogSegment segment, Input input = null)
        {
            InitializeComponent();
            _segment = segment;
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

                    for (int i = 0; i < _segment.ValueCount - 6; i++)
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

            SegmentPosition.Maximum = _segment.Entries.Count - 1;

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
            UpdateCharts();

            autoRangeInput.Checked = _editingInput.AutoGraphRange;
            rangeMinInput.Value = (decimal)_editingInput.GraphMin;
            rangeMaxInput.Value = (decimal)_editingInput.GraphMax;

            InitTransformChartMenu();
        }

        private void InitXAxisInput()
        {
            foreach (var axisType in Enum.GetValues(typeof (InputXAxis)).Cast<InputXAxis>())
            {
                xAxisInput.Items.Add(axisType.ToString());
            }
        }

        private void InitTransformChartMenu()
        {
            foreach (var editorType in TransformEditors.EditorTypes)
            {
                var name = TransformEditors.GetEditorName(editorType);
                var button = new ToolStripMenuItem(name);
                button.Click += (sender, args) =>
                {
                    var editor = editorType.GetConstructor(new Type[0])?.Invoke(new object[0]) as IEditInputTransforms;
                    editor.CreateTransform(
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


                CreateTransformMenu.DropDownItems.Add(button);
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
            var firstPos = _segment.Entries.First().GetLocation();

            Map.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            _marker = new GMarkerGoogle(firstPos, GMarkerGoogleType.red_small);

            var route = _segment.GetRoute("Segment");
            _segmentOverlay.Markers.Add(_marker);
            _segmentOverlay.Routes.Add(route);
            Map.Overlays.Add(_segmentOverlay);
            Map.ZoomAndCenterMarkers(_segmentOverlay.Id);
        }

        private void UpdateCharts()
        {
            UpdatePreChart();
            UpdateTransformChart();
        }

        private void UpdateTransformChart()
        {
            TransformChart.Series[0].Points.Clear();
            var selectedTransform = TransformList.SelectedItems.Count >= 1 ? TransformList.SelectedItems[0].Tag as InputTransform : null;

            foreach (var entry in _segment.Entries)
            {
                var value = _editingInput.GetValue(entry, selectedTransform);

                switch (_editingInput.XAxisType)
                {
                    case InputXAxis.Time:
                        TransformChart.Series[0].Points.AddXY(entry.GetTimeSpan(_segment.LogStart).TotalSeconds, value);
                        break;
                    case InputXAxis.Distance:
                        TransformChart.Series[0].Points.AddXY(entry.GetDistance(_segment), value);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void UpdatePreChart()
        {
            UpdateRawChart();
            UpdateSmoothedChart();
        }

        private void UpdateSmoothedChart()
        {
            RawChart.Series[1].Points.Clear();

            foreach (var entry in _segment.Entries)
            {
                var value = _editingInput.GetSmoothedValue(entry);

                switch (_editingInput.XAxisType)
                {
                    case InputXAxis.Time:
                        RawChart.Series[1].Points.AddXY(entry.GetTimeSpan(_segment.LogStart).TotalSeconds, value);
                        break;
                    case InputXAxis.Distance:
                        RawChart.Series[1].Points.AddXY(entry.GetDistance(_segment), value);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void UpdateRawChart()
        {
            RawChart.Series[0].Points.Clear();

            foreach (var entry in _segment.Entries)
            {
                var value = _editingInput.GetRawValue(entry);
                switch (_editingInput.XAxisType)
                {
                    case InputXAxis.Time:
                        RawChart.Series[0].Points.AddXY(entry.GetTimeSpan(_segment.LogStart).TotalSeconds, value);
                        break;
                    case InputXAxis.Distance:
                        RawChart.Series[0].Points.AddXY(entry.GetDistance(_segment), value);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void SourceInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            InputSource newSource = InputSource.Analog;
            if (Enum.TryParse(SourceInput.Text, out newSource))
            {
                _editingInput.Source = newSource;
            }
            else
            {
                _editingInput.Source = InputSource.Analog;
                _editingInput.AnalogSource = int.Parse(SourceInput.Text.Split(' ').Last()) - 1;
            }

            UpdateCharts();
        }

        private void SmoothingInput_ValueChanged(object sender, EventArgs e)
        {
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
            var entryIndex = Math.Min(SegmentPosition.Value, _segment.Entries.Count - 1);
            var entry = _segment.Entries[entryIndex];
            var cursorPosition = entry.GetTimeSpan(_segment.LogStart).TotalSeconds;
            var zoomMin = Math.Max(cursorPosition - 10, 0.0);
            var zoomMax = Math.Min(cursorPosition + 10, _segment.Length.TotalSeconds);

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
            UpdateTransformChart();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
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
    }
}
