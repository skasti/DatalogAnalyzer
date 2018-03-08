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
        public Input Input { get; }
        private LogSegment _segment;
        private GMapOverlay _segmentOverlay = new GMapOverlay("Segment");
        private GMapMarker _marker;

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
                if (inputSource != InputSource.Analog)
                {
                    SourceInput.Items.Add(inputSource.ToString());
                    continue;
                }

                var name = inputSource.ToString();

                for (int i = 0; i < _segment.ValueCount; i++)
                {
                    SourceInput.Items.Add($"{name} {i}");
                }
            }
        }

        private void InputConfigurator_Load(object sender, EventArgs e)
        {
            InitMap();

            SegmentPosition.Maximum = _segment.Entries.Count - 1;

            InitSourceInput();

            if (Input.Source == InputSource.Analog)
            {
                SourceInput.SelectedItem = $"{InputSource.Analog} {Input.AnalogSource}";
            }
            else
            {
                SourceInput.SelectedItem = Input.Source.ToString();
            }

            NameInput.Text = Input.Name;
            UpdateCharts();

            InitTransformChartMenu();
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
                        Input.Transforms.Add(transform);
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

            foreach (var transform in Input.Transforms)
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
                var value = Input.GetValue(entry, selectedTransform);

                TransformChart.Series[0].Points.AddXY(entry.GetTimeSpan(_segment.LogStart).TotalSeconds, value);
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
                var value = Input.GetSmoothedValue(entry);

                RawChart.Series[1].Points.AddXY(entry.GetTimeSpan(_segment.LogStart).TotalSeconds, value);
            }
        }

        private void UpdateRawChart()
        {
            RawChart.Series[0].Points.Clear();

            foreach (var entry in _segment.Entries)
            {
                var value = Input.GetRawValue(entry);

                RawChart.Series[0].Points.AddXY(entry.GetTimeSpan(_segment.LogStart).TotalSeconds, value);
            }
        }

        private void SourceInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            InputSource newSource = InputSource.Analog;
            if (Enum.TryParse(SourceInput.Text, out newSource))
            {
                Input.Source = newSource;
            }
            else
            {
                Input.Source = InputSource.Analog;
                Input.AnalogSource = int.Parse(SourceInput.Text.Split(' ').Last());
            }

            UpdateCharts();
        }

        private void SmoothingInput_ValueChanged(object sender, EventArgs e)
        {
            Input.Smoothing = (int)SmoothingInput.Value;
            UpdateSmoothedChart();
            UpdateTransformChart();
        }

        private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            SelectionLabel.Text = $"{e.NewSelectionStart} - {e.NewSelectionEnd}";
        }

        private void chart1_CursorPositionChanged(object sender, CursorEventArgs e)
        {
            CursorLabel.Text =
                $"{RawChart.ChartAreas[0].CursorX.Position:0.00} / {RawChart.ChartAreas[0].CursorY.Position:0.00}";
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

            CursorLabel.Text =
                $"{RawChart.ChartAreas[0].CursorX.Position:0.00} / {RawChart.ChartAreas[0].CursorY.Position:0.00}";

            TransformChart.ChartAreas[0].Axes[0].ScaleView.Zoom(zoomMin, zoomMax);
            TransformChart.ChartAreas[0].CursorX.Position = cursorPosition;

            TransformCursorLabel.Text =
                $"{TransformChart.ChartAreas[0].CursorX.Position:0.00} / {TransformChart.ChartAreas[0].CursorY.Position:0.00}";

            _marker.Position = entry.GetLocation();
        }

        private void TransformChart_CursorPositionChanged(object sender, CursorEventArgs e)
        {
            TransformCursorLabel.Text =
                $"{TransformChart.ChartAreas[0].CursorX.Position:0.00} / {TransformChart.ChartAreas[0].CursorY.Position:0.00}";
        }

        private void TransformChart_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            TransformSelectionLabel.Text = $"{e.NewSelectionStart} - {e.NewSelectionEnd}";
        }

        private void TransformList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTransformChart();
        }
    }
}
