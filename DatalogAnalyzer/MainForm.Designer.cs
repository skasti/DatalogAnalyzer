namespace DatalogAnalyzer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ChannelToggleButtonTemplate = new System.Windows.Forms.Button();
            this.logWindow = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toggleDelta = new System.Windows.Forms.Button();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepBeforeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepAfterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startFinishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleSpeedAcc = new System.Windows.Forms.Button();
            this.toggleSpeed = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.speedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartsSplitter = new System.Windows.Forms.SplitContainer();
            this.tempChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sensorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.segmentsLabel = new System.Windows.Forms.Label();
            this.segmentsList = new System.Windows.Forms.ListView();
            this.indexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartsSplitter)).BeginInit();
            this.chartsSplitter.Panel1.SuspendLayout();
            this.chartsSplitter.Panel2.SuspendLayout();
            this.chartsSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChannelToggleButtonTemplate
            // 
            this.ChannelToggleButtonTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChannelToggleButtonTemplate.Location = new System.Drawing.Point(12, 1191);
            this.ChannelToggleButtonTemplate.Name = "ChannelToggleButtonTemplate";
            this.ChannelToggleButtonTemplate.Size = new System.Drawing.Size(140, 42);
            this.ChannelToggleButtonTemplate.TabIndex = 1;
            this.ChannelToggleButtonTemplate.Text = "Channel toggle";
            this.ChannelToggleButtonTemplate.UseVisualStyleBackColor = true;
            this.ChannelToggleButtonTemplate.Visible = false;
            // 
            // logWindow
            // 
            this.logWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logWindow.Location = new System.Drawing.Point(12, 1239);
            this.logWindow.Name = "logWindow";
            this.logWindow.ReadOnly = true;
            this.logWindow.Size = new System.Drawing.Size(1456, 150);
            this.logWindow.TabIndex = 2;
            this.logWindow.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.LOG";
            this.openFileDialog.FileName = "SAMPLE.LOG";
            this.openFileDialog.Filter = "Log files (*.log)|*.LOG";
            // 
            // toggleDelta
            // 
            this.toggleDelta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleDelta.ForeColor = System.Drawing.Color.White;
            this.toggleDelta.Location = new System.Drawing.Point(1389, 1191);
            this.toggleDelta.Name = "toggleDelta";
            this.toggleDelta.Size = new System.Drawing.Size(81, 42);
            this.toggleDelta.TabIndex = 3;
            this.toggleDelta.Text = "Delta";
            this.toggleDelta.UseVisualStyleBackColor = true;
            this.toggleDelta.Click += new System.EventHandler(this.toggleDelta_Click);
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(0, 0);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 20;
            this.gMap.MinZoom = 1;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(427, 833);
            this.gMap.TabIndex = 5;
            this.gMap.Zoom = 0D;
            this.gMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseDown);
            this.gMap.MouseLeave += new System.EventHandler(this.gMap_MouseLeave);
            this.gMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseMove);
            this.gMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseUp);
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.analysisToolStripMenuItem,
            this.zoomToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.MainMenu.Size = new System.Drawing.Size(1486, 35);
            this.MainMenu.TabIndex = 7;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channelConfigToolStripMenuItem,
            this.splitToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // channelConfigToolStripMenuItem
            // 
            this.channelConfigToolStripMenuItem.Name = "channelConfigToolStripMenuItem";
            this.channelConfigToolStripMenuItem.Size = new System.Drawing.Size(218, 30);
            this.channelConfigToolStripMenuItem.Text = "Channel Config";
            this.channelConfigToolStripMenuItem.Click += new System.EventHandler(this.channelConfigToolStripMenuItem_Click);
            // 
            // splitToolStripMenuItem
            // 
            this.splitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepBeforeToolStripMenuItem,
            this.keepAfterToolStripMenuItem});
            this.splitToolStripMenuItem.Name = "splitToolStripMenuItem";
            this.splitToolStripMenuItem.Size = new System.Drawing.Size(218, 30);
            this.splitToolStripMenuItem.Text = "Split";
            // 
            // keepBeforeToolStripMenuItem
            // 
            this.keepBeforeToolStripMenuItem.Name = "keepBeforeToolStripMenuItem";
            this.keepBeforeToolStripMenuItem.Size = new System.Drawing.Size(193, 30);
            this.keepBeforeToolStripMenuItem.Text = "Keep before";
            this.keepBeforeToolStripMenuItem.Click += new System.EventHandler(this.keepBeforeToolStripMenuItem_Click);
            // 
            // keepAfterToolStripMenuItem
            // 
            this.keepAfterToolStripMenuItem.Name = "keepAfterToolStripMenuItem";
            this.keepAfterToolStripMenuItem.Size = new System.Drawing.Size(193, 30);
            this.keepAfterToolStripMenuItem.Text = "Keep after";
            this.keepAfterToolStripMenuItem.Click += new System.EventHandler(this.keepAfterToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startFinishToolStripMenuItem,
            this.testToolStripMenuItem,
            this.segmentsToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.analysisToolStripMenuItem.Text = "Analysis";
            // 
            // startFinishToolStripMenuItem
            // 
            this.startFinishToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem,
            this.pointBToolStripMenuItem,
            this.pointCToolStripMenuItem,
            this.pointDToolStripMenuItem,
            this.saveToolStripMenuItem1,
            this.loadToolStripMenuItem});
            this.startFinishToolStripMenuItem.Name = "startFinishToolStripMenuItem";
            this.startFinishToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.startFinishToolStripMenuItem.Text = "Start/Finish";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.aToolStripMenuItem.Text = "Point A";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // pointBToolStripMenuItem
            // 
            this.pointBToolStripMenuItem.Name = "pointBToolStripMenuItem";
            this.pointBToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.pointBToolStripMenuItem.Text = "Point B";
            this.pointBToolStripMenuItem.Click += new System.EventHandler(this.pointBToolStripMenuItem_Click);
            // 
            // pointCToolStripMenuItem
            // 
            this.pointCToolStripMenuItem.Name = "pointCToolStripMenuItem";
            this.pointCToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.pointCToolStripMenuItem.Text = "Point C";
            this.pointCToolStripMenuItem.Click += new System.EventHandler(this.pointCToolStripMenuItem_Click);
            // 
            // pointDToolStripMenuItem
            // 
            this.pointDToolStripMenuItem.Name = "pointDToolStripMenuItem";
            this.pointDToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.pointDToolStripMenuItem.Text = "Point D";
            this.pointDToolStripMenuItem.Click += new System.EventHandler(this.pointDToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(155, 30);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // segmentsToolStripMenuItem
            // 
            this.segmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.segmentAToolStripMenuItem,
            this.segmentBToolStripMenuItem,
            this.segmentCToolStripMenuItem});
            this.segmentsToolStripMenuItem.Name = "segmentsToolStripMenuItem";
            this.segmentsToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.segmentsToolStripMenuItem.Text = "Segments";
            // 
            // segmentAToolStripMenuItem
            // 
            this.segmentAToolStripMenuItem.Name = "segmentAToolStripMenuItem";
            this.segmentAToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.segmentAToolStripMenuItem.Text = "Segment A";
            this.segmentAToolStripMenuItem.Click += new System.EventHandler(this.segmentAToolStripMenuItem_Click);
            // 
            // segmentBToolStripMenuItem
            // 
            this.segmentBToolStripMenuItem.Name = "segmentBToolStripMenuItem";
            this.segmentBToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.segmentBToolStripMenuItem.Text = "Segment B";
            this.segmentBToolStripMenuItem.Click += new System.EventHandler(this.segmentBToolStripMenuItem_Click);
            // 
            // segmentCToolStripMenuItem
            // 
            this.segmentCToolStripMenuItem.Name = "segmentCToolStripMenuItem";
            this.segmentCToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.segmentCToolStripMenuItem.Text = "Segment C";
            this.segmentCToolStripMenuItem.Click += new System.EventHandler(this.segmentCToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.segmentToolStripMenuItem,
            this.secToolStripMenuItem,
            this.secToolStripMenuItem1,
            this.secToolStripMenuItem2,
            this.secToolStripMenuItem3,
            this.secToolStripMenuItem4});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(72, 29);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // segmentToolStripMenuItem
            // 
            this.segmentToolStripMenuItem.Name = "segmentToolStripMenuItem";
            this.segmentToolStripMenuItem.Size = new System.Drawing.Size(168, 30);
            this.segmentToolStripMenuItem.Text = "Segment";
            this.segmentToolStripMenuItem.Click += new System.EventHandler(this.segmentToolStripMenuItem_Click);
            // 
            // secToolStripMenuItem
            // 
            this.secToolStripMenuItem.Name = "secToolStripMenuItem";
            this.secToolStripMenuItem.Size = new System.Drawing.Size(168, 30);
            this.secToolStripMenuItem.Text = "60 sec";
            this.secToolStripMenuItem.Click += new System.EventHandler(this.secToolStripMenuItem_Click);
            // 
            // secToolStripMenuItem1
            // 
            this.secToolStripMenuItem1.Name = "secToolStripMenuItem1";
            this.secToolStripMenuItem1.Size = new System.Drawing.Size(168, 30);
            this.secToolStripMenuItem1.Text = "30 sec";
            this.secToolStripMenuItem1.Click += new System.EventHandler(this.secToolStripMenuItem1_Click);
            // 
            // secToolStripMenuItem2
            // 
            this.secToolStripMenuItem2.Name = "secToolStripMenuItem2";
            this.secToolStripMenuItem2.Size = new System.Drawing.Size(168, 30);
            this.secToolStripMenuItem2.Text = "15 sec";
            this.secToolStripMenuItem2.Click += new System.EventHandler(this.secToolStripMenuItem2_Click);
            // 
            // secToolStripMenuItem3
            // 
            this.secToolStripMenuItem3.Name = "secToolStripMenuItem3";
            this.secToolStripMenuItem3.Size = new System.Drawing.Size(168, 30);
            this.secToolStripMenuItem3.Text = "5 sec";
            this.secToolStripMenuItem3.Click += new System.EventHandler(this.secToolStripMenuItem3_Click);
            // 
            // secToolStripMenuItem4
            // 
            this.secToolStripMenuItem4.Name = "secToolStripMenuItem4";
            this.secToolStripMenuItem4.Size = new System.Drawing.Size(168, 30);
            this.secToolStripMenuItem4.Text = "1 sec";
            this.secToolStripMenuItem4.Click += new System.EventHandler(this.secToolStripMenuItem4_Click);
            // 
            // toggleSpeedAcc
            // 
            this.toggleSpeedAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleSpeedAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSpeedAcc.ForeColor = System.Drawing.Color.White;
            this.toggleSpeedAcc.Location = new System.Drawing.Point(1200, 1191);
            this.toggleSpeedAcc.Name = "toggleSpeedAcc";
            this.toggleSpeedAcc.Size = new System.Drawing.Size(183, 42);
            this.toggleSpeedAcc.TabIndex = 8;
            this.toggleSpeedAcc.Text = "Speed Accuracy";
            this.toggleSpeedAcc.UseVisualStyleBackColor = true;
            this.toggleSpeedAcc.Click += new System.EventHandler(this.toggleSpeedAcc_Click);
            // 
            // toggleSpeed
            // 
            this.toggleSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSpeed.ForeColor = System.Drawing.Color.White;
            this.toggleSpeed.Location = new System.Drawing.Point(1104, 1191);
            this.toggleSpeed.Name = "toggleSpeed";
            this.toggleSpeed.Size = new System.Drawing.Size(90, 42);
            this.toggleSpeed.TabIndex = 9;
            this.toggleSpeed.Text = "Speed";
            this.toggleSpeed.UseVisualStyleBackColor = true;
            this.toggleSpeed.Click += new System.EventHandler(this.toggleSpeed_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.LOG";
            this.saveFileDialog.FileName = "SAMPLE.LOG";
            this.saveFileDialog.Filter = "Log files (*.log)|*.LOG";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 38);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.speedChart);
            this.splitContainer1.Panel1.Controls.Add(this.chartsSplitter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1456, 1146);
            this.splitContainer1.SplitterDistance = 1025;
            this.splitContainer1.TabIndex = 10;
            // 
            // speedChart
            // 
            this.speedChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.speedChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.speedChart.Legends.Add(legend1);
            this.speedChart.Location = new System.Drawing.Point(3, 3);
            this.speedChart.Name = "speedChart";
            this.speedChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.speedChart.Series.Add(series1);
            this.speedChart.Size = new System.Drawing.Size(1019, 288);
            this.speedChart.TabIndex = 0;
            this.speedChart.Text = "chart1";
            this.speedChart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.speedChart_AxisViewChanged);
            this.speedChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.speedChart_MouseDown);
            // 
            // chartsSplitter
            // 
            this.chartsSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartsSplitter.Location = new System.Drawing.Point(0, 297);
            this.chartsSplitter.Name = "chartsSplitter";
            this.chartsSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // chartsSplitter.Panel1
            // 
            this.chartsSplitter.Panel1.Controls.Add(this.tempChart);
            // 
            // chartsSplitter.Panel2
            // 
            this.chartsSplitter.Panel2.Controls.Add(this.sensorChart);
            this.chartsSplitter.Size = new System.Drawing.Size(1025, 846);
            this.chartsSplitter.SplitterDistance = 275;
            this.chartsSplitter.TabIndex = 0;
            // 
            // tempChart
            // 
            chartArea2.Name = "ChartArea1";
            this.tempChart.ChartAreas.Add(chartArea2);
            this.tempChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.tempChart.Legends.Add(legend2);
            this.tempChart.Location = new System.Drawing.Point(0, 0);
            this.tempChart.Name = "tempChart";
            this.tempChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.tempChart.Series.Add(series2);
            this.tempChart.Size = new System.Drawing.Size(1025, 275);
            this.tempChart.TabIndex = 0;
            this.tempChart.Text = "chart1";
            this.tempChart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.tempChart_AxisViewChanged);
            this.tempChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tempChart_MouseDown);
            // 
            // sensorChart
            // 
            chartArea3.Name = "ChartArea1";
            this.sensorChart.ChartAreas.Add(chartArea3);
            this.sensorChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.sensorChart.Legends.Add(legend3);
            this.sensorChart.Location = new System.Drawing.Point(0, 0);
            this.sensorChart.Name = "sensorChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.sensorChart.Series.Add(series3);
            this.sensorChart.Size = new System.Drawing.Size(1025, 567);
            this.sensorChart.TabIndex = 0;
            this.sensorChart.Text = "chart1";
            this.sensorChart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.sensorChart_AxisViewChanged);
            this.sensorChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sensorChart_MouseDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.segmentsLabel);
            this.splitContainer2.Panel1.Controls.Add(this.segmentsList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gMap);
            this.splitContainer2.Size = new System.Drawing.Size(427, 1146);
            this.splitContainer2.SplitterDistance = 308;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 6;
            // 
            // segmentsLabel
            // 
            this.segmentsLabel.AutoSize = true;
            this.segmentsLabel.Location = new System.Drawing.Point(3, 0);
            this.segmentsLabel.Name = "segmentsLabel";
            this.segmentsLabel.Size = new System.Drawing.Size(82, 20);
            this.segmentsLabel.TabIndex = 1;
            this.segmentsLabel.Text = "Segments";
            // 
            // segmentsList
            // 
            this.segmentsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.segmentsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.indexColumn,
            this.timeColumn});
            this.segmentsList.Location = new System.Drawing.Point(3, 23);
            this.segmentsList.Name = "segmentsList";
            this.segmentsList.Size = new System.Drawing.Size(422, 283);
            this.segmentsList.TabIndex = 0;
            this.segmentsList.UseCompatibleStateImageBehavior = false;
            this.segmentsList.View = System.Windows.Forms.View.Details;
            this.segmentsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.segmentsList_MouseDoubleClick);
            // 
            // indexColumn
            // 
            this.indexColumn.Text = "Segment No.";
            // 
            // timeColumn
            // 
            this.timeColumn.Text = "Duration";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 1408);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toggleSpeed);
            this.Controls.Add(this.toggleSpeedAcc);
            this.Controls.Add(this.toggleDelta);
            this.Controls.Add(this.logWindow);
            this.Controls.Add(this.ChannelToggleButtonTemplate);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "SR Datalog Analyzer";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).EndInit();
            this.chartsSplitter.Panel1.ResumeLayout(false);
            this.chartsSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartsSplitter)).EndInit();
            this.chartsSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tempChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ChannelToggleButtonTemplate;
        private System.Windows.Forms.RichTextBox logWindow;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button toggleDelta;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepBeforeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepAfterToolStripMenuItem;
        private System.Windows.Forms.Button toggleSpeedAcc;
        private System.Windows.Forms.Button toggleSpeed;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startFinishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label segmentsLabel;
        private System.Windows.Forms.ListView segmentsList;
        private System.Windows.Forms.ColumnHeader indexColumn;
        private System.Windows.Forms.ColumnHeader timeColumn;
        private System.Windows.Forms.SplitContainer chartsSplitter;
        private System.Windows.Forms.DataVisualization.Charting.Chart speedChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart tempChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart sensorChart;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem4;
    }
}

