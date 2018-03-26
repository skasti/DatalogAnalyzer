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
            this.rangeMinInput = new System.Windows.Forms.NumericUpDown();
            this.rangeMaxInput = new System.Windows.Forms.NumericUpDown();
            this.autoRangeInput = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RawChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothingInput)).BeginInit();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransformChart)).BeginInit();
            this.TransformChartMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rangeMinInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeMaxInput)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(8, 21);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // NameInput
            // 
            this.NameInput.Location = new System.Drawing.Point(8, 36);
            this.NameInput.Margin = new System.Windows.Forms.Padding(2);
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(127, 20);
            this.NameInput.TabIndex = 1;
            // 
            // SourceInput
            // 
            this.SourceInput.DropDownWidth = 188;
            this.SourceInput.FormattingEnabled = true;
            this.SourceInput.Location = new System.Drawing.Point(141, 35);
            this.SourceInput.Margin = new System.Windows.Forms.Padding(2);
            this.SourceInput.Name = "SourceInput";
            this.SourceInput.Size = new System.Drawing.Size(127, 21);
            this.SourceInput.TabIndex = 2;
            this.SourceInput.SelectedIndexChanged += new System.EventHandler(this.SourceInput_SelectedIndexChanged);
            // 
            // SourceLabel
            // 
            this.SourceLabel.AutoSize = true;
            this.SourceLabel.Location = new System.Drawing.Point(141, 21);
            this.SourceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(41, 13);
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
            this.Map.Location = new System.Drawing.Point(615, 8);
            this.Map.Margin = new System.Windows.Forms.Padding(2);
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
            this.Map.Size = new System.Drawing.Size(339, 364);
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
            this.RawChart.Location = new System.Drawing.Point(8, 58);
            this.RawChart.Margin = new System.Windows.Forms.Padding(2);
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
            this.RawChart.Size = new System.Drawing.Size(603, 265);
            this.RawChart.TabIndex = 5;
            this.RawChart.Text = "chart1";
            this.RawChart.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_CursorPositionChanged);
            this.RawChart.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_SelectionRangeChanged);
            // 
            // SegmentPosition
            // 
            this.SegmentPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SegmentPosition.Location = new System.Drawing.Point(8, 327);
            this.SegmentPosition.Margin = new System.Windows.Forms.Padding(2);
            this.SegmentPosition.Name = "SegmentPosition";
            this.SegmentPosition.Size = new System.Drawing.Size(603, 45);
            this.SegmentPosition.TabIndex = 6;
            this.SegmentPosition.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.SegmentPosition.Scroll += new System.EventHandler(this.SegmentPosition_Scroll);
            // 
            // SmoothingInput
            // 
            this.SmoothingInput.Location = new System.Drawing.Point(275, 35);
            this.SmoothingInput.Margin = new System.Windows.Forms.Padding(2);
            this.SmoothingInput.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.SmoothingInput.Name = "SmoothingInput";
            this.SmoothingInput.Size = new System.Drawing.Size(93, 20);
            this.SmoothingInput.TabIndex = 7;
            this.SmoothingInput.ValueChanged += new System.EventHandler(this.SmoothingInput_ValueChanged);
            // 
            // SmoothingLabel
            // 
            this.SmoothingLabel.AutoSize = true;
            this.SmoothingLabel.Location = new System.Drawing.Point(275, 20);
            this.SmoothingLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SmoothingLabel.Name = "SmoothingLabel";
            this.SmoothingLabel.Size = new System.Drawing.Size(57, 13);
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
            this.Menu.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.Menu.Size = new System.Drawing.Size(962, 24);
            this.Menu.TabIndex = 10;
            this.Menu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 22);
            this.FileMenu.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // CursorLabel
            // 
            this.CursorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CursorLabel.Location = new System.Drawing.Point(478, 43);
            this.CursorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CursorLabel.Name = "CursorLabel";
            this.CursorLabel.Size = new System.Drawing.Size(133, 13);
            this.CursorLabel.TabIndex = 14;
            this.CursorLabel.Text = "1024.00 / 1024.00";
            this.CursorLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SelectionLabel
            // 
            this.SelectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectionLabel.Location = new System.Drawing.Point(478, 30);
            this.SelectionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SelectionLabel.Name = "SelectionLabel";
            this.SelectionLabel.Size = new System.Drawing.Size(133, 13);
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
            this.TransformChart.Location = new System.Drawing.Point(8, 389);
            this.TransformChart.Margin = new System.Windows.Forms.Padding(2);
            this.TransformChart.Name = "TransformChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.TransformChart.Series.Add(series3);
            this.TransformChart.Size = new System.Drawing.Size(603, 296);
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
            this.TransformChartMenu.Size = new System.Drawing.Size(109, 26);
            // 
            // CreateTransformMenu
            // 
            this.CreateTransformMenu.Name = "CreateTransformMenu";
            this.CreateTransformMenu.Size = new System.Drawing.Size(108, 22);
            this.CreateTransformMenu.Text = "Create";
            // 
            // TransformList
            // 
            this.TransformList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransformList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.TransformList.Location = new System.Drawing.Point(615, 389);
            this.TransformList.Margin = new System.Windows.Forms.Padding(2);
            this.TransformList.Name = "TransformList";
            this.TransformList.Size = new System.Drawing.Size(340, 321);
            this.TransformList.TabIndex = 17;
            this.TransformList.UseCompatibleStateImageBehavior = false;
            this.TransformList.View = System.Windows.Forms.View.List;
            this.TransformList.SelectedIndexChanged += new System.EventHandler(this.TransformList_SelectedIndexChanged);
            // 
            // TransformSelectionLabel
            // 
            this.TransformSelectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransformSelectionLabel.Location = new System.Drawing.Point(478, 374);
            this.TransformSelectionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TransformSelectionLabel.Name = "TransformSelectionLabel";
            this.TransformSelectionLabel.Size = new System.Drawing.Size(133, 13);
            this.TransformSelectionLabel.TabIndex = 19;
            this.TransformSelectionLabel.Text = "1024.00 / 1024.00";
            this.TransformSelectionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TransformCursorLabel
            // 
            this.TransformCursorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransformCursorLabel.Location = new System.Drawing.Point(5, 374);
            this.TransformCursorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TransformCursorLabel.Name = "TransformCursorLabel";
            this.TransformCursorLabel.Size = new System.Drawing.Size(133, 13);
            this.TransformCursorLabel.TabIndex = 18;
            this.TransformCursorLabel.Text = "1024.00 / 1024.00";
            // 
            // rangeMinInput
            // 
            this.rangeMinInput.Location = new System.Drawing.Point(60, 690);
            this.rangeMinInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rangeMinInput.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.rangeMinInput.Name = "rangeMinInput";
            this.rangeMinInput.Size = new System.Drawing.Size(120, 20);
            this.rangeMinInput.TabIndex = 20;
            this.rangeMinInput.ValueChanged += new System.EventHandler(this.rangeMinInput_ValueChanged);
            // 
            // rangeMaxInput
            // 
            this.rangeMaxInput.Location = new System.Drawing.Point(208, 690);
            this.rangeMaxInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rangeMaxInput.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.rangeMaxInput.Name = "rangeMaxInput";
            this.rangeMaxInput.Size = new System.Drawing.Size(120, 20);
            this.rangeMaxInput.TabIndex = 21;
            this.rangeMaxInput.ValueChanged += new System.EventHandler(this.rangeMaxInput_ValueChanged);
            // 
            // autoRangeInput
            // 
            this.autoRangeInput.AutoSize = true;
            this.autoRangeInput.Location = new System.Drawing.Point(334, 691);
            this.autoRangeInput.Name = "autoRangeInput";
            this.autoRangeInput.Size = new System.Drawing.Size(108, 17);
            this.autoRangeInput.TabIndex = 22;
            this.autoRangeInput.Text = "Automatic Range";
            this.autoRangeInput.UseVisualStyleBackColor = true;
            this.autoRangeInput.CheckedChanged += new System.EventHandler(this.autoRangeInput_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 692);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Range:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 692);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "to";
            // 
            // InputConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 722);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoRangeInput);
            this.Controls.Add(this.rangeMaxInput);
            this.Controls.Add(this.rangeMinInput);
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
            this.Margin = new System.Windows.Forms.Padding(2);
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
            ((System.ComponentModel.ISupportInitialize)(this.rangeMinInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeMaxInput)).EndInit();
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
        private System.Windows.Forms.NumericUpDown rangeMinInput;
        private System.Windows.Forms.NumericUpDown rangeMaxInput;
        private System.Windows.Forms.CheckBox autoRangeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}