namespace OpenLogAnalyzer
{
    partial class InputConfigurator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("This is a transform item");
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameInput = new System.Windows.Forms.TextBox();
            this.SourceInput = new System.Windows.Forms.ComboBox();
            this.SourceLabel = new System.Windows.Forms.Label();
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.RawChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SegmentPosition = new System.Windows.Forms.TrackBar();
            this.SmoothingInput = new System.Windows.Forms.NumericUpDown();
            this.SmoothingLabel = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CursorLabel = new System.Windows.Forms.Label();
            this.SelectionLabel = new System.Windows.Forms.Label();
            this.TransformChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TransformChartMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CreateTransformMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TransformList = new System.Windows.Forms.ListView();
            this.TransformSelectionLabel = new System.Windows.Forms.Label();
            this.TransformCursorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RawChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothingInput)).BeginInit();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransformChart)).BeginInit();
            this.TransformChartMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 32);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(51, 20);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // NameInput
            // 
            this.NameInput.Location = new System.Drawing.Point(12, 55);
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(188, 26);
            this.NameInput.TabIndex = 1;
            // 
            // SourceInput
            // 
            this.SourceInput.DropDownWidth = 188;
            this.SourceInput.FormattingEnabled = true;
            this.SourceInput.Location = new System.Drawing.Point(212, 54);
            this.SourceInput.Name = "SourceInput";
            this.SourceInput.Size = new System.Drawing.Size(188, 28);
            this.SourceInput.TabIndex = 2;
            this.SourceInput.SelectedIndexChanged += new System.EventHandler(this.SourceInput_SelectedIndexChanged);
            // 
            // SourceLabel
            // 
            this.SourceLabel.AutoSize = true;
            this.SourceLabel.Location = new System.Drawing.Point(212, 32);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(60, 20);
            this.SourceLabel.TabIndex = 3;
            this.SourceLabel.Text = "Source";
            // 
            // Map
            // 
            this.Map.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Map.Bearing = 0F;
            this.Map.CanDragMap = true;
            this.Map.EmptyTileColor = System.Drawing.Color.Navy;
            this.Map.GrayScaleMode = false;
            this.Map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Map.LevelsKeepInMemmory = 5;
            this.Map.Location = new System.Drawing.Point(922, 12);
            this.Map.MarkersEnabled = true;
            this.Map.MaxZoom = 20;
            this.Map.MinZoom = 12;
            this.Map.MouseWheelZoomEnabled = true;
            this.Map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.Map.Name = "Map";
            this.Map.NegativeMode = false;
            this.Map.PolygonsEnabled = true;
            this.Map.RetryLoadTile = 0;
            this.Map.RoutesEnabled = true;
            this.Map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.Map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.Map.ShowTileGridLines = false;
            this.Map.Size = new System.Drawing.Size(508, 560);
            this.Map.TabIndex = 4;
            this.Map.Zoom = 0D;
            // 
            // RawChart
            // 
            this.RawChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisY.ScaleView.Zoomable = false;
            chartArea1.AxisY2.ScaleView.Zoomable = false;
            chartArea1.CursorX.Interval = 0.01D;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorY.Interval = 0.01D;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.CursorY.LineColor = System.Drawing.Color.RoyalBlue;
            chartArea1.CursorY.SelectionColor = System.Drawing.Color.LightGreen;
            chartArea1.Name = "ChartArea1";
            this.RawChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.RawChart.Legends.Add(legend1);
            this.RawChart.Location = new System.Drawing.Point(12, 89);
            this.RawChart.Name = "RawChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.RawChart.Series.Add(series1);
            this.RawChart.Series.Add(series2);
            this.RawChart.Size = new System.Drawing.Size(904, 408);
            this.RawChart.TabIndex = 5;
            this.RawChart.Text = "chart1";
            this.RawChart.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_CursorPositionChanged);
            this.RawChart.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_SelectionRangeChanged);
            // 
            // SegmentPosition
            // 
            this.SegmentPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SegmentPosition.Location = new System.Drawing.Point(12, 503);
            this.SegmentPosition.Name = "SegmentPosition";
            this.SegmentPosition.Size = new System.Drawing.Size(904, 69);
            this.SegmentPosition.TabIndex = 6;
            this.SegmentPosition.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.SegmentPosition.Scroll += new System.EventHandler(this.SegmentPosition_Scroll);
            // 
            // SmoothingInput
            // 
            this.SmoothingInput.Location = new System.Drawing.Point(412, 57);
            this.SmoothingInput.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.SmoothingInput.Name = "SmoothingInput";
            this.SmoothingInput.Size = new System.Drawing.Size(140, 26);
            this.SmoothingInput.TabIndex = 7;
            this.SmoothingInput.ValueChanged += new System.EventHandler(this.SmoothingInput_ValueChanged);
            // 
            // SmoothingLabel
            // 
            this.SmoothingLabel.AutoSize = true;
            this.SmoothingLabel.Location = new System.Drawing.Point(412, 34);
            this.SmoothingLabel.Name = "SmoothingLabel";
            this.SmoothingLabel.Size = new System.Drawing.Size(86, 20);
            this.SmoothingLabel.TabIndex = 8;
            this.SmoothingLabel.Text = "Smoothing";
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1443, 33);
            this.Menu.TabIndex = 10;
            this.Menu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(50, 29);
            this.FileMenu.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // CursorLabel
            // 
            this.CursorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CursorLabel.Location = new System.Drawing.Point(717, 66);
            this.CursorLabel.Name = "CursorLabel";
            this.CursorLabel.Size = new System.Drawing.Size(200, 20);
            this.CursorLabel.TabIndex = 14;
            this.CursorLabel.Text = "1024.00 / 1024.00";
            this.CursorLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SelectionLabel
            // 
            this.SelectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectionLabel.Location = new System.Drawing.Point(717, 46);
            this.SelectionLabel.Name = "SelectionLabel";
            this.SelectionLabel.Size = new System.Drawing.Size(200, 20);
            this.SelectionLabel.TabIndex = 15;
            this.SelectionLabel.Text = "1024.00 / 1024.00";
            this.SelectionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TransformChart
            // 
            this.TransformChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisY.ScaleView.Zoomable = false;
            chartArea2.AxisY2.ScaleView.Zoomable = false;
            chartArea2.CursorX.Interval = 0.01D;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorY.Interval = 0.01D;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.CursorY.LineColor = System.Drawing.Color.RoyalBlue;
            chartArea2.CursorY.SelectionColor = System.Drawing.Color.LightGreen;
            chartArea2.Name = "ChartArea1";
            this.TransformChart.ChartAreas.Add(chartArea2);
            this.TransformChart.ContextMenuStrip = this.TransformChartMenu;
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.TransformChart.Legends.Add(legend2);
            this.TransformChart.Location = new System.Drawing.Point(12, 598);
            this.TransformChart.Name = "TransformChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.TransformChart.Series.Add(series3);
            this.TransformChart.Size = new System.Drawing.Size(904, 448);
            this.TransformChart.TabIndex = 16;
            this.TransformChart.Text = "chart1";
            this.TransformChart.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.TransformChart_CursorPositionChanged);
            this.TransformChart.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.TransformChart_SelectionRangeChanged);
            // 
            // TransformChartMenu
            // 
            this.TransformChartMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TransformChartMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateTransformMenu});
            this.TransformChartMenu.Name = "TransformChartMenu";
            this.TransformChartMenu.Size = new System.Drawing.Size(135, 34);
            // 
            // CreateTransformMenu
            // 
            this.CreateTransformMenu.Name = "CreateTransformMenu";
            this.CreateTransformMenu.Size = new System.Drawing.Size(134, 30);
            this.CreateTransformMenu.Text = "Create";
            // 
            // TransformList
            // 
            this.TransformList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransformList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.TransformList.Location = new System.Drawing.Point(922, 598);
            this.TransformList.Name = "TransformList";
            this.TransformList.Size = new System.Drawing.Size(508, 449);
            this.TransformList.TabIndex = 17;
            this.TransformList.UseCompatibleStateImageBehavior = false;
            this.TransformList.View = System.Windows.Forms.View.List;
            this.TransformList.SelectedIndexChanged += new System.EventHandler(this.TransformList_SelectedIndexChanged);
            // 
            // TransformSelectionLabel
            // 
            this.TransformSelectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransformSelectionLabel.Location = new System.Drawing.Point(717, 575);
            this.TransformSelectionLabel.Name = "TransformSelectionLabel";
            this.TransformSelectionLabel.Size = new System.Drawing.Size(200, 20);
            this.TransformSelectionLabel.TabIndex = 19;
            this.TransformSelectionLabel.Text = "1024.00 / 1024.00";
            this.TransformSelectionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TransformCursorLabel
            // 
            this.TransformCursorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransformCursorLabel.Location = new System.Drawing.Point(8, 575);
            this.TransformCursorLabel.Name = "TransformCursorLabel";
            this.TransformCursorLabel.Size = new System.Drawing.Size(200, 20);
            this.TransformCursorLabel.TabIndex = 18;
            this.TransformCursorLabel.Text = "1024.00 / 1024.00";
            // 
            // InputConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 1058);
            this.Controls.Add(this.TransformSelectionLabel);
            this.Controls.Add(this.TransformCursorLabel);
            this.Controls.Add(this.TransformList);
            this.Controls.Add(this.TransformChart);
            this.Controls.Add(this.SelectionLabel);
            this.Controls.Add(this.CursorLabel);
            this.Controls.Add(this.SmoothingLabel);
            this.Controls.Add(this.SmoothingInput);
            this.Controls.Add(this.SegmentPosition);
            this.Controls.Add(this.RawChart);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.SourceLabel);
            this.Controls.Add(this.SourceInput);
            this.Controls.Add(this.NameInput);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InputConfigurator";
            this.Text = "InputConfigurator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputConfigurator_FormClosing);
            this.Load += new System.EventHandler(this.InputConfigurator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RawChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothingInput)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransformChart)).EndInit();
            this.TransformChartMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameInput;
        private System.Windows.Forms.ComboBox SourceInput;
        private System.Windows.Forms.Label SourceLabel;
        private GMap.NET.WindowsForms.GMapControl Map;
        private System.Windows.Forms.DataVisualization.Charting.Chart RawChart;
        private System.Windows.Forms.TrackBar SegmentPosition;
        private System.Windows.Forms.NumericUpDown SmoothingInput;
        private System.Windows.Forms.Label SmoothingLabel;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label CursorLabel;
        private System.Windows.Forms.Label SelectionLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart TransformChart;
        private System.Windows.Forms.ListView TransformList;
        private System.Windows.Forms.Label TransformSelectionLabel;
        private System.Windows.Forms.Label TransformCursorLabel;
        private System.Windows.Forms.ContextMenuStrip TransformChartMenu;
        private System.Windows.Forms.ToolStripMenuItem CreateTransformMenu;
    }
}