namespace OpenLogAnalyzer
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.LegendCellColumn legendCellColumn1 = new System.Windows.Forms.DataVisualization.Charting.LegendCellColumn();
            System.Windows.Forms.DataVisualization.Charting.LegendCellColumn legendCellColumn2 = new System.Windows.Forms.DataVisualization.Charting.LegendCellColumn();
            System.Windows.Forms.DataVisualization.Charting.LegendCellColumn legendCellColumn3 = new System.Windows.Forms.DataVisualization.Charting.LegendCellColumn();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 100D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 150D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 125D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 300D);
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFromCardButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualImportButton = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTrackButton = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forkSensorEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineCOnfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogLibraryList = new System.Windows.Forms.ListView();
            this.DateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LengthHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TrackHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Laps = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BestHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AverageHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RiderHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BikeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImportTimer = new System.Windows.Forms.Timer(this.components);
            this.MainTabs = new System.Windows.Forms.TabControl();
            this.LogLibraryTab = new System.Windows.Forms.TabPage();
            this.MapTab = new System.Windows.Forms.TabPage();
            this.MapAnalysisSplitter = new System.Windows.Forms.SplitContainer();
            this.MapLapsSplitter = new System.Windows.Forms.SplitContainer();
            this.MapOverlayLapList = new System.Windows.Forms.ListView();
            this.OverlayLapHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OverlayTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OverlayTopSpeedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OverlayMinSpeedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OverlayAvgSpeedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MapLapListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.compareMapLaps = new System.Windows.Forms.ToolStripMenuItem();
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.AnalysisInputTabs = new System.Windows.Forms.TabControl();
            this.AnalysisOverviewTab = new System.Windows.Forms.TabPage();
            this.AnalysisOverviewChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TrackBarPanel = new System.Windows.Forms.Panel();
            this.MapTrackBar = new System.Windows.Forms.TrackBar();
            this.MapShowMarkers = new System.Windows.Forms.CheckBox();
            this.TrackLibraryTab = new System.Windows.Forms.TabPage();
            this.TrackLibraryMap = new GMap.NET.WindowsForms.GMapControl();
            this.TrackLibraryList = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.changedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExperimentTab = new System.Windows.Forms.TabPage();
            this.ExperimentalChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.InputTabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderSelector = new System.Windows.Forms.FolderBrowserDialog();
            this.MainMenu.SuspendLayout();
            this.MainTabs.SuspendLayout();
            this.LogLibraryTab.SuspendLayout();
            this.MapTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapAnalysisSplitter)).BeginInit();
            this.MapAnalysisSplitter.Panel1.SuspendLayout();
            this.MapAnalysisSplitter.Panel2.SuspendLayout();
            this.MapAnalysisSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapLapsSplitter)).BeginInit();
            this.MapLapsSplitter.Panel1.SuspendLayout();
            this.MapLapsSplitter.Panel2.SuspendLayout();
            this.MapLapsSplitter.SuspendLayout();
            this.MapLapListMenu.SuspendLayout();
            this.AnalysisInputTabs.SuspendLayout();
            this.AnalysisOverviewTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnalysisOverviewChart)).BeginInit();
            this.TrackBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapTrackBar)).BeginInit();
            this.TrackLibraryTab.SuspendLayout();
            this.ExperimentTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExperimentalChart)).BeginInit();
            this.InputTabContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1574, 33);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportFromCardButton,
            this.ManualImportButton,
            this.NewTrackButton});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // ImportFromCardButton
            // 
            this.ImportFromCardButton.Name = "ImportFromCardButton";
            this.ImportFromCardButton.Size = new System.Drawing.Size(247, 30);
            this.ImportFromCardButton.Text = "Import from card";
            this.ImportFromCardButton.Click += new System.EventHandler(this.ImportFromCardButton_Click);
            // 
            // ManualImportButton
            // 
            this.ManualImportButton.Name = "ManualImportButton";
            this.ManualImportButton.Size = new System.Drawing.Size(247, 30);
            this.ManualImportButton.Text = "Import from folder";
            this.ManualImportButton.Click += new System.EventHandler(this.ManualImportButton_Click);
            // 
            // NewTrackButton
            // 
            this.NewTrackButton.Name = "NewTrackButton";
            this.NewTrackButton.Size = new System.Drawing.Size(247, 30);
            this.NewTrackButton.Text = "New track";
            this.NewTrackButton.Click += new System.EventHandler(this.NewTrackButton_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forkSensorEditorToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.testToolStripMenuItem.Text = "Tools";
            // 
            // forkSensorEditorToolStripMenuItem
            // 
            this.forkSensorEditorToolStripMenuItem.Name = "forkSensorEditorToolStripMenuItem";
            this.forkSensorEditorToolStripMenuItem.Size = new System.Drawing.Size(272, 30);
            this.forkSensorEditorToolStripMenuItem.Text = "Fork Sensor Calibrator";
            this.forkSensorEditorToolStripMenuItem.Click += new System.EventHandler(this.forkSensorEditorToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesMenuItem,
            this.lineCOnfigToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // preferencesMenuItem
            // 
            this.preferencesMenuItem.Name = "preferencesMenuItem";
            this.preferencesMenuItem.Size = new System.Drawing.Size(228, 30);
            this.preferencesMenuItem.Text = "Rider and Bike";
            this.preferencesMenuItem.Click += new System.EventHandler(this.preferencesMenuItem_Click);
            // 
            // lineCOnfigToolStripMenuItem
            // 
            this.lineCOnfigToolStripMenuItem.Name = "lineCOnfigToolStripMenuItem";
            this.lineCOnfigToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.lineCOnfigToolStripMenuItem.Text = "Acceleration Line";
            this.lineCOnfigToolStripMenuItem.Click += new System.EventHandler(this.lineConfigToolStripMenuItem_Click);
            // 
            // LogLibraryList
            // 
            this.LogLibraryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DateHeader,
            this.TimeHeader,
            this.LengthHeader,
            this.TrackHeader,
            this.Laps,
            this.BestHeader,
            this.AverageHeader,
            this.RiderHeader,
            this.BikeHeader});
            this.LogLibraryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogLibraryList.FullRowSelect = true;
            this.LogLibraryList.Location = new System.Drawing.Point(3, 3);
            this.LogLibraryList.Name = "LogLibraryList";
            this.LogLibraryList.Size = new System.Drawing.Size(1560, 955);
            this.LogLibraryList.TabIndex = 1;
            this.LogLibraryList.UseCompatibleStateImageBehavior = false;
            this.LogLibraryList.View = System.Windows.Forms.View.Details;
            this.LogLibraryList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LogLibraryList_MouseDoubleClick);
            // 
            // DateHeader
            // 
            this.DateHeader.Text = "Date";
            this.DateHeader.Width = 80;
            // 
            // TimeHeader
            // 
            this.TimeHeader.Text = "Time";
            // 
            // LengthHeader
            // 
            this.LengthHeader.Text = "Length";
            this.LengthHeader.Width = 80;
            // 
            // TrackHeader
            // 
            this.TrackHeader.Text = "Track";
            this.TrackHeader.Width = 150;
            // 
            // Laps
            // 
            this.Laps.Text = "Laps";
            // 
            // BestHeader
            // 
            this.BestHeader.Text = "Best";
            this.BestHeader.Width = 100;
            // 
            // AverageHeader
            // 
            this.AverageHeader.Text = "Avg.";
            this.AverageHeader.Width = 100;
            // 
            // RiderHeader
            // 
            this.RiderHeader.Text = "Rider";
            this.RiderHeader.Width = 150;
            // 
            // BikeHeader
            // 
            this.BikeHeader.Text = "Bike";
            this.BikeHeader.Width = 120;
            // 
            // ImportTimer
            // 
            this.ImportTimer.Enabled = true;
            this.ImportTimer.Interval = 1000;
            this.ImportTimer.Tick += new System.EventHandler(this.ImportTimer_Tick);
            // 
            // MainTabs
            // 
            this.MainTabs.Controls.Add(this.LogLibraryTab);
            this.MainTabs.Controls.Add(this.MapTab);
            this.MainTabs.Controls.Add(this.TrackLibraryTab);
            this.MainTabs.Controls.Add(this.ExperimentTab);
            this.MainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabs.Location = new System.Drawing.Point(0, 33);
            this.MainTabs.Name = "MainTabs";
            this.MainTabs.SelectedIndex = 0;
            this.MainTabs.Size = new System.Drawing.Size(1574, 994);
            this.MainTabs.TabIndex = 2;
            // 
            // LogLibraryTab
            // 
            this.LogLibraryTab.Controls.Add(this.LogLibraryList);
            this.LogLibraryTab.Location = new System.Drawing.Point(4, 29);
            this.LogLibraryTab.Name = "LogLibraryTab";
            this.LogLibraryTab.Padding = new System.Windows.Forms.Padding(3);
            this.LogLibraryTab.Size = new System.Drawing.Size(1566, 961);
            this.LogLibraryTab.TabIndex = 0;
            this.LogLibraryTab.Text = "Logs";
            this.LogLibraryTab.UseVisualStyleBackColor = true;
            // 
            // MapTab
            // 
            this.MapTab.Controls.Add(this.MapAnalysisSplitter);
            this.MapTab.Controls.Add(this.TrackBarPanel);
            this.MapTab.Location = new System.Drawing.Point(4, 29);
            this.MapTab.Name = "MapTab";
            this.MapTab.Padding = new System.Windows.Forms.Padding(3);
            this.MapTab.Size = new System.Drawing.Size(1566, 961);
            this.MapTab.TabIndex = 2;
            this.MapTab.Text = "Map";
            this.MapTab.UseVisualStyleBackColor = true;
            // 
            // MapAnalysisSplitter
            // 
            this.MapAnalysisSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MapAnalysisSplitter.BackColor = System.Drawing.Color.Transparent;
            this.MapAnalysisSplitter.Cursor = System.Windows.Forms.Cursors.Default;
            this.MapAnalysisSplitter.Location = new System.Drawing.Point(8, 6);
            this.MapAnalysisSplitter.Name = "MapAnalysisSplitter";
            // 
            // MapAnalysisSplitter.Panel1
            // 
            this.MapAnalysisSplitter.Panel1.Controls.Add(this.MapLapsSplitter);
            this.MapAnalysisSplitter.Panel1MinSize = 100;
            // 
            // MapAnalysisSplitter.Panel2
            // 
            this.MapAnalysisSplitter.Panel2.Controls.Add(this.AnalysisInputTabs);
            this.MapAnalysisSplitter.Panel2MinSize = 100;
            this.MapAnalysisSplitter.Size = new System.Drawing.Size(1555, 846);
            this.MapAnalysisSplitter.SplitterDistance = 500;
            this.MapAnalysisSplitter.SplitterWidth = 50;
            this.MapAnalysisSplitter.TabIndex = 5;
            // 
            // MapLapsSplitter
            // 
            this.MapLapsSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MapLapsSplitter.BackColor = System.Drawing.Color.Transparent;
            this.MapLapsSplitter.Cursor = System.Windows.Forms.Cursors.Default;
            this.MapLapsSplitter.Location = new System.Drawing.Point(0, 0);
            this.MapLapsSplitter.Name = "MapLapsSplitter";
            this.MapLapsSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MapLapsSplitter.Panel1
            // 
            this.MapLapsSplitter.Panel1.Controls.Add(this.MapOverlayLapList);
            this.MapLapsSplitter.Panel1MinSize = 100;
            // 
            // MapLapsSplitter.Panel2
            // 
            this.MapLapsSplitter.Panel2.Controls.Add(this.Map);
            this.MapLapsSplitter.Panel2MinSize = 500;
            this.MapLapsSplitter.Size = new System.Drawing.Size(500, 846);
            this.MapLapsSplitter.SplitterDistance = 290;
            this.MapLapsSplitter.SplitterWidth = 50;
            this.MapLapsSplitter.TabIndex = 0;
            // 
            // MapOverlayLapList
            // 
            this.MapOverlayLapList.BackColor = System.Drawing.SystemColors.Window;
            this.MapOverlayLapList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OverlayLapHeader,
            this.OverlayTimeHeader,
            this.OverlayTopSpeedHeader,
            this.OverlayMinSpeedHeader,
            this.OverlayAvgSpeedHeader});
            this.MapOverlayLapList.ContextMenuStrip = this.MapLapListMenu;
            this.MapOverlayLapList.Cursor = System.Windows.Forms.Cursors.Default;
            this.MapOverlayLapList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapOverlayLapList.FullRowSelect = true;
            this.MapOverlayLapList.Location = new System.Drawing.Point(0, 0);
            this.MapOverlayLapList.Name = "MapOverlayLapList";
            this.MapOverlayLapList.Size = new System.Drawing.Size(500, 290);
            this.MapOverlayLapList.TabIndex = 0;
            this.MapOverlayLapList.UseCompatibleStateImageBehavior = false;
            this.MapOverlayLapList.View = System.Windows.Forms.View.Details;
            this.MapOverlayLapList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MapOverlayLapList_MouseDoubleClick);
            // 
            // OverlayLapHeader
            // 
            this.OverlayLapHeader.Text = "Lap";
            // 
            // OverlayTimeHeader
            // 
            this.OverlayTimeHeader.Text = "Time";
            this.OverlayTimeHeader.Width = 120;
            // 
            // OverlayTopSpeedHeader
            // 
            this.OverlayTopSpeedHeader.Text = "Max";
            this.OverlayTopSpeedHeader.Width = 70;
            // 
            // OverlayMinSpeedHeader
            // 
            this.OverlayMinSpeedHeader.Text = "Min";
            this.OverlayMinSpeedHeader.Width = 70;
            // 
            // OverlayAvgSpeedHeader
            // 
            this.OverlayAvgSpeedHeader.Text = "Avg.";
            this.OverlayAvgSpeedHeader.Width = 70;
            // 
            // MapLapListMenu
            // 
            this.MapLapListMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MapLapListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareMapLaps});
            this.MapLapListMenu.Name = "MapLapListMenu";
            this.MapLapListMenu.Size = new System.Drawing.Size(158, 34);
            // 
            // compareMapLaps
            // 
            this.compareMapLaps.Name = "compareMapLaps";
            this.compareMapLaps.Size = new System.Drawing.Size(157, 30);
            this.compareMapLaps.Text = "Compare";
            this.compareMapLaps.Click += new System.EventHandler(this.compareMapLaps_Click);
            // 
            // Map
            // 
            this.Map.Bearing = 0F;
            this.Map.CanDragMap = true;
            this.Map.Cursor = System.Windows.Forms.Cursors.Default;
            this.Map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Map.EmptyTileColor = System.Drawing.Color.Navy;
            this.Map.GrayScaleMode = false;
            this.Map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Map.LevelsKeepInMemmory = 5;
            this.Map.Location = new System.Drawing.Point(0, 0);
            this.Map.MarkersEnabled = true;
            this.Map.MaxZoom = 20;
            this.Map.MinZoom = 5;
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
            this.Map.Size = new System.Drawing.Size(500, 506);
            this.Map.TabIndex = 0;
            this.Map.Zoom = 0D;
            // 
            // AnalysisInputTabs
            // 
            this.AnalysisInputTabs.Controls.Add(this.AnalysisOverviewTab);
            this.AnalysisInputTabs.Cursor = System.Windows.Forms.Cursors.Default;
            this.AnalysisInputTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnalysisInputTabs.Location = new System.Drawing.Point(0, 0);
            this.AnalysisInputTabs.Name = "AnalysisInputTabs";
            this.AnalysisInputTabs.SelectedIndex = 0;
            this.AnalysisInputTabs.Size = new System.Drawing.Size(1005, 846);
            this.AnalysisInputTabs.TabIndex = 2;
            this.AnalysisInputTabs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AnalysisInputTabs_MouseClick);
            // 
            // AnalysisOverviewTab
            // 
            this.AnalysisOverviewTab.Controls.Add(this.AnalysisOverviewChart);
            this.AnalysisOverviewTab.Location = new System.Drawing.Point(4, 29);
            this.AnalysisOverviewTab.Name = "AnalysisOverviewTab";
            this.AnalysisOverviewTab.Padding = new System.Windows.Forms.Padding(3);
            this.AnalysisOverviewTab.Size = new System.Drawing.Size(997, 813);
            this.AnalysisOverviewTab.TabIndex = 0;
            this.AnalysisOverviewTab.Text = "Overview";
            this.AnalysisOverviewTab.UseVisualStyleBackColor = true;
            // 
            // AnalysisOverviewChart
            // 
            this.AnalysisOverviewChart.BackColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BorderColor = System.Drawing.Color.White;
            chartArea1.Name = "Overview";
            this.AnalysisOverviewChart.ChartAreas.Add(chartArea1);
            this.AnalysisOverviewChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Black;
            legendCellColumn1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legendCellColumn1.Name = "CheckboxColumn";
            legendCellColumn1.Text = "#CUSTOMPROPERTY(CHECK)";
            legendCellColumn2.ColumnType = System.Windows.Forms.DataVisualization.Charting.LegendCellColumnType.SeriesSymbol;
            legendCellColumn2.Name = "Symbol";
            legendCellColumn3.Name = "Title";
            legend1.CellColumns.Add(legendCellColumn1);
            legend1.CellColumns.Add(legendCellColumn2);
            legend1.CellColumns.Add(legendCellColumn3);
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.HeaderSeparatorColor = System.Drawing.Color.White;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.White;
            legend1.Name = "Legend";
            legend1.TitleBackColor = System.Drawing.Color.Black;
            legend1.TitleForeColor = System.Drawing.Color.White;
            legend1.TitleSeparatorColor = System.Drawing.Color.White;
            this.AnalysisOverviewChart.Legends.Add(legend1);
            this.AnalysisOverviewChart.Location = new System.Drawing.Point(3, 3);
            this.AnalysisOverviewChart.Name = "AnalysisOverviewChart";
            series1.ChartArea = "Overview";
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend";
            series1.Name = "Series1";
            this.AnalysisOverviewChart.Series.Add(series1);
            this.AnalysisOverviewChart.Size = new System.Drawing.Size(991, 807);
            this.AnalysisOverviewChart.TabIndex = 0;
            this.AnalysisOverviewChart.Text = "Overview";
            this.AnalysisOverviewChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnalysisOverviewChart_MouseDown);
            // 
            // TrackBarPanel
            // 
            this.TrackBarPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TrackBarPanel.Controls.Add(this.MapTrackBar);
            this.TrackBarPanel.Controls.Add(this.MapShowMarkers);
            this.TrackBarPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TrackBarPanel.Location = new System.Drawing.Point(3, 853);
            this.TrackBarPanel.Name = "TrackBarPanel";
            this.TrackBarPanel.Size = new System.Drawing.Size(1560, 105);
            this.TrackBarPanel.TabIndex = 4;
            // 
            // MapTrackBar
            // 
            this.MapTrackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MapTrackBar.Location = new System.Drawing.Point(0, 36);
            this.MapTrackBar.Maximum = 1;
            this.MapTrackBar.Name = "MapTrackBar";
            this.MapTrackBar.Size = new System.Drawing.Size(1560, 69);
            this.MapTrackBar.TabIndex = 2;
            this.MapTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.MapTrackBar.Scroll += new System.EventHandler(this.MapTrackbar_Scroll);
            // 
            // MapShowMarkers
            // 
            this.MapShowMarkers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MapShowMarkers.AutoSize = true;
            this.MapShowMarkers.BackColor = System.Drawing.SystemColors.Control;
            this.MapShowMarkers.Location = new System.Drawing.Point(4, 5);
            this.MapShowMarkers.Name = "MapShowMarkers";
            this.MapShowMarkers.Size = new System.Drawing.Size(136, 24);
            this.MapShowMarkers.TabIndex = 3;
            this.MapShowMarkers.Text = "Show Markers";
            this.MapShowMarkers.UseVisualStyleBackColor = false;
            this.MapShowMarkers.CheckedChanged += new System.EventHandler(this.MapShowMarkers_CheckedChanged);
            // 
            // TrackLibraryTab
            // 
            this.TrackLibraryTab.Controls.Add(this.TrackLibraryMap);
            this.TrackLibraryTab.Controls.Add(this.TrackLibraryList);
            this.TrackLibraryTab.Location = new System.Drawing.Point(4, 29);
            this.TrackLibraryTab.Name = "TrackLibraryTab";
            this.TrackLibraryTab.Padding = new System.Windows.Forms.Padding(3);
            this.TrackLibraryTab.Size = new System.Drawing.Size(1566, 961);
            this.TrackLibraryTab.TabIndex = 3;
            this.TrackLibraryTab.Text = "Tracks";
            this.TrackLibraryTab.UseVisualStyleBackColor = true;
            // 
            // TrackLibraryMap
            // 
            this.TrackLibraryMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrackLibraryMap.Bearing = 0F;
            this.TrackLibraryMap.CanDragMap = true;
            this.TrackLibraryMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.TrackLibraryMap.GrayScaleMode = false;
            this.TrackLibraryMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.TrackLibraryMap.LevelsKeepInMemmory = 5;
            this.TrackLibraryMap.Location = new System.Drawing.Point(668, 3);
            this.TrackLibraryMap.MarkersEnabled = true;
            this.TrackLibraryMap.MaxZoom = 20;
            this.TrackLibraryMap.MinZoom = 5;
            this.TrackLibraryMap.MouseWheelZoomEnabled = true;
            this.TrackLibraryMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.TrackLibraryMap.Name = "TrackLibraryMap";
            this.TrackLibraryMap.NegativeMode = false;
            this.TrackLibraryMap.PolygonsEnabled = true;
            this.TrackLibraryMap.RetryLoadTile = 0;
            this.TrackLibraryMap.RoutesEnabled = true;
            this.TrackLibraryMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.TrackLibraryMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.TrackLibraryMap.ShowTileGridLines = false;
            this.TrackLibraryMap.Size = new System.Drawing.Size(880, 760);
            this.TrackLibraryMap.TabIndex = 9;
            this.TrackLibraryMap.Zoom = 0D;
            // 
            // TrackLibraryList
            // 
            this.TrackLibraryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.changedHeader});
            this.TrackLibraryList.Dock = System.Windows.Forms.DockStyle.Left;
            this.TrackLibraryList.Location = new System.Drawing.Point(3, 3);
            this.TrackLibraryList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TrackLibraryList.Name = "TrackLibraryList";
            this.TrackLibraryList.Size = new System.Drawing.Size(656, 955);
            this.TrackLibraryList.TabIndex = 8;
            this.TrackLibraryList.UseCompatibleStateImageBehavior = false;
            this.TrackLibraryList.View = System.Windows.Forms.View.Details;
            this.TrackLibraryList.SelectedIndexChanged += new System.EventHandler(this.TrackLibraryList_SelectedIndexChanged);
            this.TrackLibraryList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrackLibraryList_MouseDoubleClick);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            this.nameHeader.Width = 340;
            // 
            // changedHeader
            // 
            this.changedHeader.Text = "Changed Date";
            this.changedHeader.Width = 144;
            // 
            // ExperimentTab
            // 
            this.ExperimentTab.Controls.Add(this.ExperimentalChart);
            this.ExperimentTab.Location = new System.Drawing.Point(4, 29);
            this.ExperimentTab.Name = "ExperimentTab";
            this.ExperimentTab.Padding = new System.Windows.Forms.Padding(3);
            this.ExperimentTab.Size = new System.Drawing.Size(1566, 961);
            this.ExperimentTab.TabIndex = 4;
            this.ExperimentTab.Text = "Experiments";
            this.ExperimentTab.UseVisualStyleBackColor = true;
            // 
            // ExperimentalChart
            // 
            chartArea2.CursorX.SelectionEnd = 3D;
            chartArea2.CursorX.SelectionStart = 2D;
            chartArea2.Name = "ChartArea1";
            this.ExperimentalChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ExperimentalChart.Legends.Add(legend2);
            this.ExperimentalChart.Location = new System.Drawing.Point(34, 32);
            this.ExperimentalChart.Name = "ExperimentalChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series2";
            series3.Points.Add(dataPoint1);
            series3.Points.Add(dataPoint2);
            series3.Points.Add(dataPoint3);
            series3.Points.Add(dataPoint4);
            series3.Points.Add(dataPoint5);
            series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.ExperimentalChart.Series.Add(series2);
            this.ExperimentalChart.Series.Add(series3);
            this.ExperimentalChart.Size = new System.Drawing.Size(1235, 548);
            this.ExperimentalChart.TabIndex = 0;
            this.ExperimentalChart.Text = "chart1";
            // 
            // InputTabContextMenu
            // 
            this.InputTabContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.InputTabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newInputToolStripMenuItem,
            this.editInputToolStripMenuItem,
            this.newAnalysisToolStripMenuItem,
            this.editAnalysisToolStripMenuItem});
            this.InputTabContextMenu.Name = "InputTapContextMenu";
            this.InputTabContextMenu.Size = new System.Drawing.Size(189, 124);
            // 
            // newInputToolStripMenuItem
            // 
            this.newInputToolStripMenuItem.Name = "newInputToolStripMenuItem";
            this.newInputToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.newInputToolStripMenuItem.Text = "New Input";
            this.newInputToolStripMenuItem.Click += new System.EventHandler(this.NewInputButton_Click);
            // 
            // editInputToolStripMenuItem
            // 
            this.editInputToolStripMenuItem.Name = "editInputToolStripMenuItem";
            this.editInputToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.editInputToolStripMenuItem.Text = "Edit Input";
            this.editInputToolStripMenuItem.Click += new System.EventHandler(this.editInputToolStripMenuItem_Click);
            // 
            // newAnalysisToolStripMenuItem
            // 
            this.newAnalysisToolStripMenuItem.Name = "newAnalysisToolStripMenuItem";
            this.newAnalysisToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.newAnalysisToolStripMenuItem.Text = "New Analysis";
            // 
            // editAnalysisToolStripMenuItem
            // 
            this.editAnalysisToolStripMenuItem.Name = "editAnalysisToolStripMenuItem";
            this.editAnalysisToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.editAnalysisToolStripMenuItem.Text = "Edit Analysis";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 1027);
            this.Controls.Add(this.MainTabs);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "OpenLog Analyzer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainTabs.ResumeLayout(false);
            this.LogLibraryTab.ResumeLayout(false);
            this.MapTab.ResumeLayout(false);
            this.MapAnalysisSplitter.Panel1.ResumeLayout(false);
            this.MapAnalysisSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapAnalysisSplitter)).EndInit();
            this.MapAnalysisSplitter.ResumeLayout(false);
            this.MapLapsSplitter.Panel1.ResumeLayout(false);
            this.MapLapsSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapLapsSplitter)).EndInit();
            this.MapLapsSplitter.ResumeLayout(false);
            this.MapLapListMenu.ResumeLayout(false);
            this.AnalysisInputTabs.ResumeLayout(false);
            this.AnalysisOverviewTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AnalysisOverviewChart)).EndInit();
            this.TrackBarPanel.ResumeLayout(false);
            this.TrackBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapTrackBar)).EndInit();
            this.TrackLibraryTab.ResumeLayout(false);
            this.ExperimentTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExperimentalChart)).EndInit();
            this.InputTabContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportFromCardButton;
        private System.Windows.Forms.ListView LogLibraryList;
        private System.Windows.Forms.ColumnHeader DateHeader;
        private System.Windows.Forms.ColumnHeader TimeHeader;
        private System.Windows.Forms.ColumnHeader TrackHeader;
        private System.Windows.Forms.ColumnHeader BestHeader;
        private System.Windows.Forms.ColumnHeader AverageHeader;
        private System.Windows.Forms.ColumnHeader RiderHeader;
        private System.Windows.Forms.ToolStripMenuItem ManualImportButton;
        private System.Windows.Forms.Timer ImportTimer;
        private System.Windows.Forms.TabControl MainTabs;
        private System.Windows.Forms.TabPage LogLibraryTab;
        private System.Windows.Forms.ColumnHeader LengthHeader;
        private System.Windows.Forms.ColumnHeader Laps;
        private System.Windows.Forms.TabPage MapTab;
        private GMap.NET.WindowsForms.GMapControl Map;
        private System.Windows.Forms.TabPage TrackLibraryTab;
        private GMap.NET.WindowsForms.GMapControl TrackLibraryMap;
        private System.Windows.Forms.ListView TrackLibraryList;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader changedHeader;
        private System.Windows.Forms.ListView MapOverlayLapList;
        private System.Windows.Forms.ColumnHeader OverlayLapHeader;
        private System.Windows.Forms.ColumnHeader OverlayTimeHeader;
        private System.Windows.Forms.ColumnHeader OverlayTopSpeedHeader;
        private System.Windows.Forms.ColumnHeader OverlayMinSpeedHeader;
        private System.Windows.Forms.ColumnHeader OverlayAvgSpeedHeader;
        private System.Windows.Forms.TrackBar MapTrackBar;
        private System.Windows.Forms.CheckBox MapShowMarkers;
        private System.Windows.Forms.Panel TrackBarPanel;
        private System.Windows.Forms.ToolStripMenuItem NewTrackButton;
        private System.Windows.Forms.ContextMenuStrip MapLapListMenu;
        private System.Windows.Forms.ToolStripMenuItem compareMapLaps;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forkSensorEditorToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip InputTabContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editAnalysisToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader BikeHeader;
        private System.Windows.Forms.FolderBrowserDialog FolderSelector;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineCOnfigToolStripMenuItem;
        private System.Windows.Forms.SplitContainer MapAnalysisSplitter;
        private System.Windows.Forms.SplitContainer MapLapsSplitter;
        private System.Windows.Forms.TabControl AnalysisInputTabs;
        private System.Windows.Forms.TabPage ExperimentTab;
        private System.Windows.Forms.DataVisualization.Charting.Chart ExperimentalChart;
        private System.Windows.Forms.TabPage AnalysisOverviewTab;
        private System.Windows.Forms.DataVisualization.Charting.Chart AnalysisOverviewChart;
    }
}

