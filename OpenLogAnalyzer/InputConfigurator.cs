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
using OpenLogger.Analysis;
using OpenLogger.Analysis.Extensions;
using OpenLogger.Analysis.Vehicle.Inputs;
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
            
            var firstPos = segment.Entries.First().GetLocation();

            Map.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            _marker = new GMarkerGoogle(firstPos, GMarkerGoogleType.red_small);

            var route = segment.GetRoute("Segment");
            _segmentOverlay.Markers.Add(_marker);
            _segmentOverlay.Routes.Add(route);
            Map.Overlays.Add(_segmentOverlay);
            Map.ZoomAndCenterMarkers(_segmentOverlay.Id);

            SegmentPosition.Maximum = segment.Entries.Count-1;
        }

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
            UpdateChart();
        }

        private void UpdateChart()
        {
            chart1.Series[0].Points.Clear();

            foreach (var entry in _segment.Entries)
            {
                var value = Input.GetValue(entry);

                chart1.Series[0].Points.AddXY(entry.GetTimeSpan(_segment.LogStart).TotalSeconds, value);
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

            UpdateChart();
        }

        private void SmoothingInput_ValueChanged(object sender, EventArgs e)
        {
            Input.Smoothing = (int)SmoothingInput.Value;
            UpdateChart();
        }

        private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            SelectionLabel.Text = $"{e.NewSelectionStart} - {e.NewSelectionEnd}";
        }

        private void chart1_CursorPositionChanged(object sender, CursorEventArgs e)
        {
            CursorLabel.Text =
                $"{chart1.ChartAreas[0].CursorX.Position:0.00} / {chart1.ChartAreas[0].CursorY.Position:0.00}";
        }

        private void SegmentPosition_Scroll(object sender, EventArgs e)
        {
            var entryIndex = Math.Min(SegmentPosition.Value, _segment.Entries.Count - 1);
            var entry = _segment.Entries[entryIndex];
            var cursorPosition = entry.GetTimeSpan(_segment.LogStart).TotalSeconds;
            var zoomMin = Math.Max(cursorPosition - 10, 0.0);
            var zoomMax = Math.Min(cursorPosition + 10, _segment.Length.TotalSeconds);

            chart1.ChartAreas[0].Axes[0].ScaleView.Zoom(zoomMin, zoomMax);
            chart1.ChartAreas[0].CursorX.Position = cursorPosition;

            CursorLabel.Text =
                $"{chart1.ChartAreas[0].CursorX.Position:0.00} / {chart1.ChartAreas[0].CursorY.Position:0.00}";

            _marker.Position = entry.GetLocation();
        }
    }
}
