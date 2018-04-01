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
            this.TransformListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddTransformMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTransformButton = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTransformButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveTransformUpButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveTransformDownButton = new System.Windows.Forms.ToolStripMenuItem();
            this.TransformList = new System.Windows.Forms.ListView();
            this.TransformSelectionLabel = new System.Windows.Forms.Label();
            this.TransformCursorLabel = new System.Windows.Forms.Label();
            this.rangeMinInput = new System.Windows.Forms.NumericUpDown();
            this.rangeMaxInput = new System.Windows.Forms.NumericUpDown();
            this.autoRangeInput = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xAxisInput = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputFeaturesTabs = new System.Windows.Forms.TabControl();
            this.inputPage = new System.Windows.Forms.TabPage();
            this.transformsPage = new System.Windows.Forms.TabPage();
            this.analysesPage = new System.Windows.Forms.TabPage();
            this.AnalysisRenderPanel = new System.Windows.Forms.Panel();
            this.AnalysesList = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DetailsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AnalysesListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddAnalysisMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditAnalysisButton = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteAnalysisButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveAnalysisUpButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveAnalysisDownButton = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.RawChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothingInput)).BeginInit();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransformChart)).BeginInit();
            this.TransformListMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rangeMinInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeMaxInput)).BeginInit();
            this.inputFeaturesTabs.SuspendLayout();
            this.inputPage.SuspendLayout();
            this.transformsPage.SuspendLayout();
            this.analysesPage.SuspendLayout();
            this.AnalysesListMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(11, 7);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(51, 20);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // NameInput
            // 
            this.NameInput.Location = new System.Drawing.Point(11, 30);
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(188, 26);
            this.NameInput.TabIndex = 1;
            // 
            // SourceInput
            // 
            this.SourceInput.DropDownWidth = 188;
            this.SourceInput.FormattingEnabled = true;
            this.SourceInput.Location = new System.Drawing.Point(211, 29);
            this.SourceInput.Name = "SourceInput";
            this.SourceInput.Size = new System.Drawing.Size(188, 28);
            this.SourceInput.TabIndex = 2;
            this.SourceInput.SelectedIndexChanged += new System.EventHandler(this.SourceInput_SelectedIndexChanged);
            // 
            // SourceLabel
            // 
            this.SourceLabel.AutoSize = true;
            this.SourceLabel.Location = new System.Drawing.Point(211, 7);
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
            this.Map.Location = new System.Drawing.Point(1276, 12);
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
            this.Map.Size = new System.Drawing.Size(508, 639);
            this.Map.TabIndex = 4;
            this.Map.Zoom = 0D;
            // 
            // RawChart
            // 
            this.RawChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
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
            this.RawChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.RawChart.Legends.Add(legend1);
            this.RawChart.Location = new System.Drawing.Point(3, 63);
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
            this.RawChart.Size = new System.Drawing.Size(1247, 438);
            this.RawChart.TabIndex = 5;
            this.RawChart.Text = "chart1";
            this.RawChart.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_CursorPositionChanged);
            this.RawChart.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_SelectionRangeChanged);
            // 
            // SegmentPosition
            // 
            this.SegmentPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SegmentPosition.Location = new System.Drawing.Point(16, 582);
            this.SegmentPosition.Name = "SegmentPosition";
            this.SegmentPosition.Size = new System.Drawing.Size(1258, 69);
            this.SegmentPosition.TabIndex = 6;
            this.SegmentPosition.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.SegmentPosition.Scroll += new System.EventHandler(this.SegmentPosition_Scroll);
            // 
            // SmoothingInput
            // 
            this.SmoothingInput.Location = new System.Drawing.Point(411, 30);
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
            this.SmoothingLabel.Location = new System.Drawing.Point(411, 6);
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
            this.Menu.Size = new System.Drawing.Size(1797, 33);
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
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // CursorLabel
            // 
            this.CursorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CursorLabel.Location = new System.Drawing.Point(1044, 27);
            this.CursorLabel.Name = "CursorLabel";
            this.CursorLabel.Size = new System.Drawing.Size(200, 20);
            this.CursorLabel.TabIndex = 14;
            this.CursorLabel.Text = "1024.00 / 1024.00";
            this.CursorLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SelectionLabel
            // 
            this.SelectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectionLabel.Location = new System.Drawing.Point(1044, 7);
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
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.TransformChart.Legends.Add(legend2);
            this.TransformChart.Location = new System.Drawing.Point(6, 50);
            this.TransformChart.Name = "TransformChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.TransformChart.Series.Add(series3);
            this.TransformChart.Size = new System.Drawing.Size(916, 415);
            this.TransformChart.TabIndex = 16;
            this.TransformChart.Text = "chart1";
            this.TransformChart.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.TransformChart_CursorPositionChanged);
            this.TransformChart.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.TransformChart_SelectionRangeChanged);
            // 
            // TransformListMenu
            // 
            this.TransformListMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TransformListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTransformMenu,
            this.EditTransformButton,
            this.DeleteTransformButton,
            this.MoveTransformUpButton,
            this.MoveTransformDownButton});
            this.TransformListMenu.Name = "TransformChartMenu";
            this.TransformListMenu.Size = new System.Drawing.Size(180, 154);
            this.TransformListMenu.Opening += new System.ComponentModel.CancelEventHandler(this.TransformListMenu_Opening);
            // 
            // AddTransformMenu
            // 
            this.AddTransformMenu.Name = "AddTransformMenu";
            this.AddTransformMenu.Size = new System.Drawing.Size(179, 30);
            this.AddTransformMenu.Text = "Add";
            // 
            // EditTransformButton
            // 
            this.EditTransformButton.Name = "EditTransformButton";
            this.EditTransformButton.Size = new System.Drawing.Size(179, 30);
            this.EditTransformButton.Text = "Edit";
            this.EditTransformButton.Click += new System.EventHandler(this.EditTransformButton_Click);
            // 
            // DeleteTransformButton
            // 
            this.DeleteTransformButton.Name = "DeleteTransformButton";
            this.DeleteTransformButton.Size = new System.Drawing.Size(179, 30);
            this.DeleteTransformButton.Text = "Delete";
            this.DeleteTransformButton.Click += new System.EventHandler(this.DeleteTransformButton_Click);
            // 
            // MoveTransformUpButton
            // 
            this.MoveTransformUpButton.Name = "MoveTransformUpButton";
            this.MoveTransformUpButton.Size = new System.Drawing.Size(179, 30);
            this.MoveTransformUpButton.Text = "Move up";
            this.MoveTransformUpButton.Click += new System.EventHandler(this.MoveTransformUpButton_Click);
            // 
            // MoveTransformDownButton
            // 
            this.MoveTransformDownButton.Name = "MoveTransformDownButton";
            this.MoveTransformDownButton.Size = new System.Drawing.Size(179, 30);
            this.MoveTransformDownButton.Text = "Move down";
            this.MoveTransformDownButton.Click += new System.EventHandler(this.MoveTransformDownButton_Click);
            // 
            // TransformList
            // 
            this.TransformList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransformList.ContextMenuStrip = this.TransformListMenu;
            this.TransformList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.TransformList.Location = new System.Drawing.Point(928, 7);
            this.TransformList.Name = "TransformList";
            this.TransformList.Size = new System.Drawing.Size(316, 489);
            this.TransformList.TabIndex = 17;
            this.TransformList.UseCompatibleStateImageBehavior = false;
            this.TransformList.View = System.Windows.Forms.View.List;
            this.TransformList.SelectedIndexChanged += new System.EventHandler(this.TransformList_SelectedIndexChanged);
            // 
            // TransformSelectionLabel
            // 
            this.TransformSelectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransformSelectionLabel.Location = new System.Drawing.Point(722, 7);
            this.TransformSelectionLabel.Name = "TransformSelectionLabel";
            this.TransformSelectionLabel.Size = new System.Drawing.Size(200, 20);
            this.TransformSelectionLabel.TabIndex = 19;
            this.TransformSelectionLabel.Text = "1024.00 / 1024.00";
            this.TransformSelectionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TransformCursorLabel
            // 
            this.TransformCursorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransformCursorLabel.Location = new System.Drawing.Point(722, 27);
            this.TransformCursorLabel.Name = "TransformCursorLabel";
            this.TransformCursorLabel.Size = new System.Drawing.Size(200, 20);
            this.TransformCursorLabel.TabIndex = 18;
            this.TransformCursorLabel.Text = "1024.00 / 1024.00";
            this.TransformCursorLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rangeMinInput
            // 
            this.rangeMinInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rangeMinInput.Location = new System.Drawing.Point(79, 473);
            this.rangeMinInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.rangeMinInput.Size = new System.Drawing.Size(180, 26);
            this.rangeMinInput.TabIndex = 20;
            this.rangeMinInput.ValueChanged += new System.EventHandler(this.rangeMinInput_ValueChanged);
            // 
            // rangeMaxInput
            // 
            this.rangeMaxInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rangeMaxInput.Location = new System.Drawing.Point(301, 473);
            this.rangeMaxInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.rangeMaxInput.Size = new System.Drawing.Size(180, 26);
            this.rangeMaxInput.TabIndex = 21;
            this.rangeMaxInput.ValueChanged += new System.EventHandler(this.rangeMaxInput_ValueChanged);
            // 
            // autoRangeInput
            // 
            this.autoRangeInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autoRangeInput.AutoSize = true;
            this.autoRangeInput.Location = new System.Drawing.Point(490, 474);
            this.autoRangeInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.autoRangeInput.Name = "autoRangeInput";
            this.autoRangeInput.Size = new System.Drawing.Size(159, 24);
            this.autoRangeInput.TabIndex = 22;
            this.autoRangeInput.Text = "Automatic Range";
            this.autoRangeInput.UseVisualStyleBackColor = true;
            this.autoRangeInput.CheckedChanged += new System.EventHandler(this.autoRangeInput_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 476);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Range:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 476);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "to";
            // 
            // xAxisInput
            // 
            this.xAxisInput.FormattingEnabled = true;
            this.xAxisInput.Location = new System.Drawing.Point(557, 29);
            this.xAxisInput.Name = "xAxisInput";
            this.xAxisInput.Size = new System.Drawing.Size(142, 28);
            this.xAxisInput.TabIndex = 25;
            this.xAxisInput.SelectedIndexChanged += new System.EventHandler(this.xAxisInput_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(553, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "X-axis";
            // 
            // inputFeaturesTabs
            // 
            this.inputFeaturesTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFeaturesTabs.Controls.Add(this.inputPage);
            this.inputFeaturesTabs.Controls.Add(this.transformsPage);
            this.inputFeaturesTabs.Controls.Add(this.analysesPage);
            this.inputFeaturesTabs.Location = new System.Drawing.Point(12, 36);
            this.inputFeaturesTabs.Name = "inputFeaturesTabs";
            this.inputFeaturesTabs.SelectedIndex = 0;
            this.inputFeaturesTabs.Size = new System.Drawing.Size(1258, 540);
            this.inputFeaturesTabs.TabIndex = 27;
            // 
            // inputPage
            // 
            this.inputPage.Controls.Add(this.xAxisInput);
            this.inputPage.Controls.Add(this.NameLabel);
            this.inputPage.Controls.Add(this.label3);
            this.inputPage.Controls.Add(this.NameInput);
            this.inputPage.Controls.Add(this.SourceInput);
            this.inputPage.Controls.Add(this.SourceLabel);
            this.inputPage.Controls.Add(this.SmoothingInput);
            this.inputPage.Controls.Add(this.SmoothingLabel);
            this.inputPage.Controls.Add(this.SelectionLabel);
            this.inputPage.Controls.Add(this.CursorLabel);
            this.inputPage.Controls.Add(this.RawChart);
            this.inputPage.Location = new System.Drawing.Point(4, 29);
            this.inputPage.Name = "inputPage";
            this.inputPage.Padding = new System.Windows.Forms.Padding(3);
            this.inputPage.Size = new System.Drawing.Size(1250, 507);
            this.inputPage.TabIndex = 0;
            this.inputPage.Text = "Input";
            this.inputPage.UseVisualStyleBackColor = true;
            // 
            // transformsPage
            // 
            this.transformsPage.Controls.Add(this.TransformChart);
            this.transformsPage.Controls.Add(this.TransformList);
            this.transformsPage.Controls.Add(this.label2);
            this.transformsPage.Controls.Add(this.TransformSelectionLabel);
            this.transformsPage.Controls.Add(this.TransformCursorLabel);
            this.transformsPage.Controls.Add(this.label1);
            this.transformsPage.Controls.Add(this.rangeMaxInput);
            this.transformsPage.Controls.Add(this.autoRangeInput);
            this.transformsPage.Controls.Add(this.rangeMinInput);
            this.transformsPage.Location = new System.Drawing.Point(4, 29);
            this.transformsPage.Name = "transformsPage";
            this.transformsPage.Padding = new System.Windows.Forms.Padding(3);
            this.transformsPage.Size = new System.Drawing.Size(1250, 507);
            this.transformsPage.TabIndex = 1;
            this.transformsPage.Text = "Transformations";
            this.transformsPage.UseVisualStyleBackColor = true;
            // 
            // analysesPage
            // 
            this.analysesPage.Controls.Add(this.AnalysisRenderPanel);
            this.analysesPage.Controls.Add(this.AnalysesList);
            this.analysesPage.Location = new System.Drawing.Point(4, 29);
            this.analysesPage.Name = "analysesPage";
            this.analysesPage.Padding = new System.Windows.Forms.Padding(3);
            this.analysesPage.Size = new System.Drawing.Size(1250, 507);
            this.analysesPage.TabIndex = 2;
            this.analysesPage.Text = "Analyses";
            this.analysesPage.UseVisualStyleBackColor = true;
            // 
            // AnalysisRenderPanel
            // 
            this.AnalysisRenderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnalysisRenderPanel.AutoScroll = true;
            this.AnalysisRenderPanel.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.AnalysisRenderPanel.Location = new System.Drawing.Point(6, 6);
            this.AnalysisRenderPanel.Name = "AnalysisRenderPanel";
            this.AnalysisRenderPanel.Size = new System.Drawing.Size(827, 495);
            this.AnalysisRenderPanel.TabIndex = 1;
            // 
            // AnalysesList
            // 
            this.AnalysesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnalysesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.DetailsColumn});
            this.AnalysesList.ContextMenuStrip = this.AnalysesListMenu;
            this.AnalysesList.Location = new System.Drawing.Point(839, 6);
            this.AnalysesList.Name = "AnalysesList";
            this.AnalysesList.Size = new System.Drawing.Size(405, 495);
            this.AnalysesList.TabIndex = 0;
            this.AnalysesList.UseCompatibleStateImageBehavior = false;
            this.AnalysesList.View = System.Windows.Forms.View.Details;
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 100;
            // 
            // DetailsColumn
            // 
            this.DetailsColumn.Text = "Details";
            this.DetailsColumn.Width = 300;
            // 
            // AnalysesListMenu
            // 
            this.AnalysesListMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.AnalysesListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddAnalysisMenu,
            this.EditAnalysisButton,
            this.DeleteAnalysisButton,
            this.MoveAnalysisUpButton,
            this.MoveAnalysisDownButton});
            this.AnalysesListMenu.Name = "AnalysesListMenu";
            this.AnalysesListMenu.Size = new System.Drawing.Size(180, 154);
            this.AnalysesListMenu.Opening += new System.ComponentModel.CancelEventHandler(this.AnalysesListMenu_Opening);
            // 
            // AddAnalysisMenu
            // 
            this.AddAnalysisMenu.Name = "AddAnalysisMenu";
            this.AddAnalysisMenu.Size = new System.Drawing.Size(179, 30);
            this.AddAnalysisMenu.Text = "Add";
            // 
            // EditAnalysisButton
            // 
            this.EditAnalysisButton.Name = "EditAnalysisButton";
            this.EditAnalysisButton.Size = new System.Drawing.Size(179, 30);
            this.EditAnalysisButton.Text = "Edit";
            this.EditAnalysisButton.Click += new System.EventHandler(this.EditAnalysisButton_Click);
            // 
            // DeleteAnalysisButton
            // 
            this.DeleteAnalysisButton.Name = "DeleteAnalysisButton";
            this.DeleteAnalysisButton.Size = new System.Drawing.Size(179, 30);
            this.DeleteAnalysisButton.Text = "Delete";
            this.DeleteAnalysisButton.Click += new System.EventHandler(this.DeleteAnalysisButton_Click);
            // 
            // MoveAnalysisUpButton
            // 
            this.MoveAnalysisUpButton.Name = "MoveAnalysisUpButton";
            this.MoveAnalysisUpButton.Size = new System.Drawing.Size(179, 30);
            this.MoveAnalysisUpButton.Text = "Move up";
            this.MoveAnalysisUpButton.Click += new System.EventHandler(this.MoveAnalysisUpButton_Click);
            // 
            // MoveAnalysisDownButton
            // 
            this.MoveAnalysisDownButton.Name = "MoveAnalysisDownButton";
            this.MoveAnalysisDownButton.Size = new System.Drawing.Size(179, 30);
            this.MoveAnalysisDownButton.Text = "Move down";
            this.MoveAnalysisDownButton.Click += new System.EventHandler(this.MoveAnalysisDownButton_Click);
            // 
            // InputConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1797, 666);
            this.Controls.Add(this.inputFeaturesTabs);
            this.Controls.Add(this.SegmentPosition);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.Menu);
            this.MinimumSize = new System.Drawing.Size(1423, 652);
            this.Name = "InputConfigurator";
            this.Text = "InputConfigurator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputConfigurator_FormClosing);
            this.Load += new System.EventHandler(this.InputConfigurator_Load);
            this.Shown += new System.EventHandler(this.InputConfigurator_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.RawChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothingInput)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransformChart)).EndInit();
            this.TransformListMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rangeMinInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeMaxInput)).EndInit();
            this.inputFeaturesTabs.ResumeLayout(false);
            this.inputPage.ResumeLayout(false);
            this.inputPage.PerformLayout();
            this.transformsPage.ResumeLayout(false);
            this.transformsPage.PerformLayout();
            this.analysesPage.ResumeLayout(false);
            this.AnalysesListMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip TransformListMenu;
        private System.Windows.Forms.ToolStripMenuItem AddTransformMenu;
        private System.Windows.Forms.NumericUpDown rangeMinInput;
        private System.Windows.Forms.NumericUpDown rangeMaxInput;
        private System.Windows.Forms.CheckBox autoRangeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox xAxisInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl inputFeaturesTabs;
        private System.Windows.Forms.TabPage inputPage;
        private System.Windows.Forms.TabPage transformsPage;
        private System.Windows.Forms.TabPage analysesPage;
        private System.Windows.Forms.ListView AnalysesList;
        private System.Windows.Forms.ContextMenuStrip AnalysesListMenu;
        private System.Windows.Forms.ToolStripMenuItem AddAnalysisMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteAnalysisButton;
        private System.Windows.Forms.ToolStripMenuItem MoveAnalysisUpButton;
        private System.Windows.Forms.ToolStripMenuItem MoveAnalysisDownButton;
        private System.Windows.Forms.ToolStripMenuItem EditAnalysisButton;
        private System.Windows.Forms.ToolStripMenuItem EditTransformButton;
        private System.Windows.Forms.ToolStripMenuItem DeleteTransformButton;
        private System.Windows.Forms.ToolStripMenuItem MoveTransformUpButton;
        private System.Windows.Forms.ToolStripMenuItem MoveTransformDownButton;
        private System.Windows.Forms.Panel AnalysisRenderPanel;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader DetailsColumn;
    }
}