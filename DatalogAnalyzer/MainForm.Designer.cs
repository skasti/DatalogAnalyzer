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
            this.components = new System.ComponentModel.Container();
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepBeforeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepAfterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tracksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleSpeedAcc = new System.Windows.Forms.Button();
            this.toggleSpeed = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.segmentsList = new System.Windows.Forms.ListView();
            this.indexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LapContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sensorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tempChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.speedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lapsTab = new System.Windows.Forms.TabPage();
            this.speedChartTab = new System.Windows.Forms.TabPage();
            this.sensorChartTab = new System.Windows.Forms.TabPage();
            this.tempChartTab = new System.Windows.Forms.TabPage();
            this.toggleAccelerationButton = new System.Windows.Forms.Button();
            this.lapColors = new System.Windows.Forms.ImageList(this.components);
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.lapsTab.SuspendLayout();
            this.speedChartTab.SuspendLayout();
            this.sensorChartTab.SuspendLayout();
            this.tempChartTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChannelToggleButtonTemplate
            // 
            this.ChannelToggleButtonTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChannelToggleButtonTemplate.Location = new System.Drawing.Point(12, 1000);
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
            this.logWindow.Location = new System.Drawing.Point(12, 1048);
            this.logWindow.Name = "logWindow";
            this.logWindow.ReadOnly = true;
            this.logWindow.Size = new System.Drawing.Size(1172, 181);
            this.logWindow.TabIndex = 2;
            this.logWindow.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.LOG";
            this.openFileDialog.FileName = "SAMPLE.LOG";
            this.openFileDialog.Filter = "Log files (*.LogSegment)|*.LOG";
            // 
            // toggleDelta
            // 
            this.toggleDelta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleDelta.ForeColor = System.Drawing.Color.White;
            this.toggleDelta.Location = new System.Drawing.Point(1099, 1000);
            this.toggleDelta.Name = "toggleDelta";
            this.toggleDelta.Size = new System.Drawing.Size(81, 42);
            this.toggleDelta.TabIndex = 3;
            this.toggleDelta.Text = "Delta";
            this.toggleDelta.UseVisualStyleBackColor = true;
            this.toggleDelta.Click += new System.EventHandler(this.toggleDelta_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.analysisToolStripMenuItem,
            this.zoomToolStripMenuItem,
            this.tracksToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.MainMenu.Size = new System.Drawing.Size(1196, 35);
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(205, 30);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(205, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(205, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.splitToolStripMenuItem,
            this.newChannelsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // splitToolStripMenuItem
            // 
            this.splitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepBeforeToolStripMenuItem,
            this.keepAfterToolStripMenuItem});
            this.splitToolStripMenuItem.Name = "splitToolStripMenuItem";
            this.splitToolStripMenuItem.Size = new System.Drawing.Size(202, 30);
            this.splitToolStripMenuItem.Text = "Split";
            // 
            // keepBeforeToolStripMenuItem
            // 
            this.keepBeforeToolStripMenuItem.Name = "keepBeforeToolStripMenuItem";
            this.keepBeforeToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.keepBeforeToolStripMenuItem.Text = "Keep before";
            this.keepBeforeToolStripMenuItem.Click += new System.EventHandler(this.keepBeforeToolStripMenuItem_Click);
            // 
            // keepAfterToolStripMenuItem
            // 
            this.keepAfterToolStripMenuItem.Name = "keepAfterToolStripMenuItem";
            this.keepAfterToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.keepAfterToolStripMenuItem.Text = "Keep after";
            this.keepAfterToolStripMenuItem.Click += new System.EventHandler(this.keepAfterToolStripMenuItem_Click);
            // 
            // newChannelsToolStripMenuItem
            // 
            this.newChannelsToolStripMenuItem.Name = "newChannelsToolStripMenuItem";
            this.newChannelsToolStripMenuItem.Size = new System.Drawing.Size(202, 30);
            this.newChannelsToolStripMenuItem.Text = "Edit Channels";
            this.newChannelsToolStripMenuItem.Click += new System.EventHandler(this.newChannelsToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.analysisToolStripMenuItem.Text = "Analysis";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.testToolStripMenuItem.Text = "Analyze Log";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
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
            this.segmentToolStripMenuItem.Size = new System.Drawing.Size(167, 30);
            this.segmentToolStripMenuItem.Text = "Segment";
            this.segmentToolStripMenuItem.Click += new System.EventHandler(this.segmentToolStripMenuItem_Click);
            // 
            // secToolStripMenuItem
            // 
            this.secToolStripMenuItem.Name = "secToolStripMenuItem";
            this.secToolStripMenuItem.Size = new System.Drawing.Size(167, 30);
            this.secToolStripMenuItem.Text = "60 sec";
            this.secToolStripMenuItem.Click += new System.EventHandler(this.secToolStripMenuItem_Click);
            // 
            // secToolStripMenuItem1
            // 
            this.secToolStripMenuItem1.Name = "secToolStripMenuItem1";
            this.secToolStripMenuItem1.Size = new System.Drawing.Size(167, 30);
            this.secToolStripMenuItem1.Text = "30 sec";
            this.secToolStripMenuItem1.Click += new System.EventHandler(this.secToolStripMenuItem1_Click);
            // 
            // secToolStripMenuItem2
            // 
            this.secToolStripMenuItem2.Name = "secToolStripMenuItem2";
            this.secToolStripMenuItem2.Size = new System.Drawing.Size(167, 30);
            this.secToolStripMenuItem2.Text = "15 sec";
            this.secToolStripMenuItem2.Click += new System.EventHandler(this.secToolStripMenuItem2_Click);
            // 
            // secToolStripMenuItem3
            // 
            this.secToolStripMenuItem3.Name = "secToolStripMenuItem3";
            this.secToolStripMenuItem3.Size = new System.Drawing.Size(167, 30);
            this.secToolStripMenuItem3.Text = "5 sec";
            this.secToolStripMenuItem3.Click += new System.EventHandler(this.secToolStripMenuItem3_Click);
            // 
            // secToolStripMenuItem4
            // 
            this.secToolStripMenuItem4.Name = "secToolStripMenuItem4";
            this.secToolStripMenuItem4.Size = new System.Drawing.Size(167, 30);
            this.secToolStripMenuItem4.Text = "1 sec";
            this.secToolStripMenuItem4.Click += new System.EventHandler(this.secToolStripMenuItem4_Click);
            // 
            // tracksToolStripMenuItem
            // 
            this.tracksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openLibraryToolStripMenuItem});
            this.tracksToolStripMenuItem.Name = "tracksToolStripMenuItem";
            this.tracksToolStripMenuItem.Size = new System.Drawing.Size(71, 29);
            this.tracksToolStripMenuItem.Text = "Tracks";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(198, 30);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openLibraryToolStripMenuItem
            // 
            this.openLibraryToolStripMenuItem.Name = "openLibraryToolStripMenuItem";
            this.openLibraryToolStripMenuItem.Size = new System.Drawing.Size(198, 30);
            this.openLibraryToolStripMenuItem.Text = "Open Library";
            this.openLibraryToolStripMenuItem.Click += new System.EventHandler(this.openLibraryToolStripMenuItem_Click);
            // 
            // toggleSpeedAcc
            // 
            this.toggleSpeedAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleSpeedAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSpeedAcc.ForeColor = System.Drawing.Color.White;
            this.toggleSpeedAcc.Location = new System.Drawing.Point(910, 1000);
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
            this.toggleSpeed.Location = new System.Drawing.Point(814, 1000);
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
            this.saveFileDialog.Filter = "Log files (*.LogSegment)|*.LOG";
            // 
            // segmentsList
            // 
            this.segmentsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.indexColumn,
            this.timeColumn});
            this.segmentsList.ContextMenuStrip = this.LapContextMenu;
            this.segmentsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.segmentsList.Location = new System.Drawing.Point(3, 3);
            this.segmentsList.Name = "segmentsList";
            this.segmentsList.Size = new System.Drawing.Size(1158, 268);
            this.segmentsList.SmallImageList = this.lapColors;
            this.segmentsList.TabIndex = 0;
            this.segmentsList.UseCompatibleStateImageBehavior = false;
            this.segmentsList.View = System.Windows.Forms.View.Details;
            this.segmentsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.segmentsList_MouseDoubleClick);
            // 
            // indexColumn
            // 
            this.indexColumn.Text = "Lap";
            // 
            // timeColumn
            // 
            this.timeColumn.Text = "Duration";
            // 
            // LapContextMenu
            // 
            this.LapContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.LapContextMenu.Name = "LapContextMenu";
            this.LapContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // sensorChart
            // 
            this.sensorChart.BackColor = System.Drawing.SystemColors.WindowFrame;
            chartArea1.BackColor = System.Drawing.SystemColors.WindowFrame;
            chartArea1.Name = "ChartArea1";
            this.sensorChart.ChartAreas.Add(chartArea1);
            this.sensorChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.sensorChart.Legends.Add(legend1);
            this.sensorChart.Location = new System.Drawing.Point(3, 3);
            this.sensorChart.Name = "sensorChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.sensorChart.Series.Add(series1);
            this.sensorChart.Size = new System.Drawing.Size(1158, 268);
            this.sensorChart.TabIndex = 1;
            this.sensorChart.Text = "chart1";
            this.sensorChart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.sensorChart_AxisViewChanged);
            this.sensorChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sensorChart_MouseDown);
            // 
            // tempChart
            // 
            this.tempChart.BackColor = System.Drawing.SystemColors.WindowFrame;
            chartArea2.BackColor = System.Drawing.SystemColors.WindowFrame;
            chartArea2.Name = "ChartArea1";
            this.tempChart.ChartAreas.Add(chartArea2);
            this.tempChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.tempChart.Legends.Add(legend2);
            this.tempChart.Location = new System.Drawing.Point(3, 3);
            this.tempChart.Name = "tempChart";
            this.tempChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.tempChart.Series.Add(series2);
            this.tempChart.Size = new System.Drawing.Size(1158, 268);
            this.tempChart.TabIndex = 2;
            this.tempChart.Text = "chart1";
            this.tempChart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.tempChart_AxisViewChanged);
            this.tempChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tempChart_MouseDown);
            // 
            // speedChart
            // 
            this.speedChart.BackColor = System.Drawing.SystemColors.WindowFrame;
            chartArea3.BackColor = System.Drawing.SystemColors.WindowFrame;
            chartArea3.Name = "ChartArea1";
            this.speedChart.ChartAreas.Add(chartArea3);
            this.speedChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.speedChart.Legends.Add(legend3);
            this.speedChart.Location = new System.Drawing.Point(3, 3);
            this.speedChart.Name = "speedChart";
            this.speedChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.speedChart.Series.Add(series3);
            this.speedChart.Size = new System.Drawing.Size(1158, 268);
            this.speedChart.TabIndex = 3;
            this.speedChart.Text = "chart1";
            this.speedChart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.speedChart_AxisViewChanged);
            this.speedChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.speedChart_MouseDown);
            // 
            // gMap
            // 
            this.gMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(8, 38);
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
            this.gMap.Size = new System.Drawing.Size(1172, 595);
            this.gMap.TabIndex = 6;
            this.gMap.Zoom = 0D;
            this.gMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseDown);
            this.gMap.MouseLeave += new System.EventHandler(this.gMap_MouseLeave);
            this.gMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseMove);
            this.gMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.lapsTab);
            this.tabControl1.Controls.Add(this.speedChartTab);
            this.tabControl1.Controls.Add(this.sensorChartTab);
            this.tabControl1.Controls.Add(this.tempChartTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 687);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1172, 307);
            this.tabControl1.TabIndex = 10;
            // 
            // lapsTab
            // 
            this.lapsTab.Controls.Add(this.segmentsList);
            this.lapsTab.Location = new System.Drawing.Point(4, 29);
            this.lapsTab.Name = "lapsTab";
            this.lapsTab.Padding = new System.Windows.Forms.Padding(3);
            this.lapsTab.Size = new System.Drawing.Size(1164, 274);
            this.lapsTab.TabIndex = 3;
            this.lapsTab.Text = "Laps";
            this.lapsTab.UseVisualStyleBackColor = true;
            // 
            // speedChartTab
            // 
            this.speedChartTab.Controls.Add(this.speedChart);
            this.speedChartTab.Location = new System.Drawing.Point(4, 29);
            this.speedChartTab.Name = "speedChartTab";
            this.speedChartTab.Padding = new System.Windows.Forms.Padding(3);
            this.speedChartTab.Size = new System.Drawing.Size(1164, 274);
            this.speedChartTab.TabIndex = 0;
            this.speedChartTab.Text = "Speed";
            this.speedChartTab.UseVisualStyleBackColor = true;
            // 
            // sensorChartTab
            // 
            this.sensorChartTab.Controls.Add(this.sensorChart);
            this.sensorChartTab.Location = new System.Drawing.Point(4, 29);
            this.sensorChartTab.Name = "sensorChartTab";
            this.sensorChartTab.Padding = new System.Windows.Forms.Padding(3);
            this.sensorChartTab.Size = new System.Drawing.Size(1164, 274);
            this.sensorChartTab.TabIndex = 1;
            this.sensorChartTab.Text = "Sensors";
            this.sensorChartTab.UseVisualStyleBackColor = true;
            // 
            // tempChartTab
            // 
            this.tempChartTab.Controls.Add(this.tempChart);
            this.tempChartTab.Location = new System.Drawing.Point(4, 29);
            this.tempChartTab.Name = "tempChartTab";
            this.tempChartTab.Padding = new System.Windows.Forms.Padding(3);
            this.tempChartTab.Size = new System.Drawing.Size(1164, 274);
            this.tempChartTab.TabIndex = 2;
            this.tempChartTab.Text = "Temperatures";
            this.tempChartTab.UseVisualStyleBackColor = true;
            // 
            // toggleAccelerationButton
            // 
            this.toggleAccelerationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleAccelerationButton.Location = new System.Drawing.Point(984, 639);
            this.toggleAccelerationButton.Name = "toggleAccelerationButton";
            this.toggleAccelerationButton.Size = new System.Drawing.Size(200, 42);
            this.toggleAccelerationButton.TabIndex = 11;
            this.toggleAccelerationButton.Text = "Acceleration Overlay";
            this.toggleAccelerationButton.UseVisualStyleBackColor = true;
            this.toggleAccelerationButton.Click += new System.EventHandler(this.toggleAccelerationButton_Click);
            // 
            // lapColors
            // 
            this.lapColors.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.lapColors.ImageSize = new System.Drawing.Size(16, 16);
            this.lapColors.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 1241);
            this.Controls.Add(this.toggleAccelerationButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gMap);
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
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.lapsTab.ResumeLayout(false);
            this.speedChartTab.ResumeLayout(false);
            this.sensorChartTab.ResumeLayout(false);
            this.tempChartTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ChannelToggleButtonTemplate;
        private System.Windows.Forms.RichTextBox logWindow;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button toggleDelta;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepBeforeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepAfterToolStripMenuItem;
        private System.Windows.Forms.Button toggleSpeedAcc;
        private System.Windows.Forms.Button toggleSpeed;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ListView segmentsList;
        private System.Windows.Forms.ColumnHeader indexColumn;
        private System.Windows.Forms.ColumnHeader timeColumn;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tracksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLibraryToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip LapContextMenu;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.DataVisualization.Charting.Chart sensorChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart tempChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart speedChart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage speedChartTab;
        private System.Windows.Forms.TabPage sensorChartTab;
        private System.Windows.Forms.TabPage tempChartTab;
        private System.Windows.Forms.TabPage lapsTab;
        private System.Windows.Forms.Button toggleAccelerationButton;
        private System.Windows.Forms.ToolStripMenuItem newChannelsToolStripMenuItem;
        private System.Windows.Forms.ImageList lapColors;
    }
}

