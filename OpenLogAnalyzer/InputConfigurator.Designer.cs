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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameInput = new System.Windows.Forms.TextBox();
            this.SourceInput = new System.Windows.Forms.ComboBox();
            this.SourceLabel = new System.Windows.Forms.Label();
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SegmentPosition = new System.Windows.Forms.TrackBar();
            this.SmoothingInput = new System.Windows.Forms.NumericUpDown();
            this.SmoothingLabel = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CursorLabel = new System.Windows.Forms.Label();
            this.SelectionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothingInput)).BeginInit();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 33);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(51, 20);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // NameInput
            // 
            this.NameInput.Location = new System.Drawing.Point(12, 56);
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
            this.SourceLabel.Location = new System.Drawing.Point(212, 33);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(60, 20);
            this.SourceLabel.TabIndex = 3;
            this.SourceLabel.Text = "Source";
            // 
            // Map
            // 
            this.Map.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Map.Bearing = 0F;
            this.Map.CanDragMap = true;
            this.Map.EmptyTileColor = System.Drawing.Color.Navy;
            this.Map.GrayScaleMode = false;
            this.Map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Map.LevelsKeepInMemmory = 5;
            this.Map.Location = new System.Drawing.Point(923, 12);
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
            this.Map.Size = new System.Drawing.Size(508, 773);
            this.Map.TabIndex = 4;
            this.Map.Zoom = 0D;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
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
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 89);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(905, 621);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            this.chart1.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_CursorPositionChanged);
            this.chart1.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_SelectionRangeChanged);
            // 
            // SegmentPosition
            // 
            this.SegmentPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SegmentPosition.Location = new System.Drawing.Point(12, 716);
            this.SegmentPosition.Name = "SegmentPosition";
            this.SegmentPosition.Size = new System.Drawing.Size(905, 69);
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
            this.SmoothingInput.Size = new System.Drawing.Size(139, 26);
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
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(133, 30);
            this.saveToolStripMenuItem.Text = "Save";
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
            // InputConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 797);
            this.Controls.Add(this.SelectionLabel);
            this.Controls.Add(this.CursorLabel);
            this.Controls.Add(this.SmoothingLabel);
            this.Controls.Add(this.SmoothingInput);
            this.Controls.Add(this.SegmentPosition);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.SourceLabel);
            this.Controls.Add(this.SourceInput);
            this.Controls.Add(this.NameInput);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InputConfigurator";
            this.Text = "InputConfigurator";
            this.Load += new System.EventHandler(this.InputConfigurator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothingInput)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameInput;
        private System.Windows.Forms.ComboBox SourceInput;
        private System.Windows.Forms.Label SourceLabel;
        private GMap.NET.WindowsForms.GMapControl Map;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TrackBar SegmentPosition;
        private System.Windows.Forms.NumericUpDown SmoothingInput;
        private System.Windows.Forms.Label SmoothingLabel;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label CursorLabel;
        private System.Windows.Forms.Label SelectionLabel;
    }
}