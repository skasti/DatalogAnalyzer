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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 100D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.01D, 150D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.02D, 140D);
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleSpeedAcc = new System.Windows.Forms.Button();
            this.toggleSpeed = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.segmentAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.segmentsList = new System.Windows.Forms.ListView();
            this.segmentsLabel = new System.Windows.Forms.Label();
            this.indexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.DimGray;
            chartArea3.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisX.ScaleView.SmallScrollMinSize = 0.01D;
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Color = System.Drawing.Color.Red;
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            series13.Points.Add(dataPoint7);
            series13.Points.Add(dataPoint8);
            series13.Points.Add(dataPoint9);
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.Legend = "Legend1";
            series14.Name = "Series2";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.Legend = "Legend1";
            series15.Name = "Series3";
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series16.Legend = "Legend1";
            series16.Name = "Series4";
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series17.Legend = "Legend1";
            series17.Name = "Series5";
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series18.Legend = "Legend1";
            series18.Name = "Series6";
            this.chart1.Series.Add(series13);
            this.chart1.Series.Add(series14);
            this.chart1.Series.Add(series15);
            this.chart1.Series.Add(series16);
            this.chart1.Series.Add(series17);
            this.chart1.Series.Add(series18);
            this.chart1.Size = new System.Drawing.Size(1027, 576);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseUp);
            // 
            // ChannelToggleButtonTemplate
            // 
            this.ChannelToggleButtonTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChannelToggleButtonTemplate.Location = new System.Drawing.Point(12, 620);
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
            this.logWindow.Location = new System.Drawing.Point(12, 668);
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
            this.toggleDelta.Location = new System.Drawing.Point(1389, 620);
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
            this.gMap.Size = new System.Drawing.Size(425, 210);
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
            this.analysisToolStripMenuItem});
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
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
            this.startFinishToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.startFinishToolStripMenuItem.Text = "Start/Finish";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.aToolStripMenuItem.Text = "Point A";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // pointBToolStripMenuItem
            // 
            this.pointBToolStripMenuItem.Name = "pointBToolStripMenuItem";
            this.pointBToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.pointBToolStripMenuItem.Text = "Point B";
            this.pointBToolStripMenuItem.Click += new System.EventHandler(this.pointBToolStripMenuItem_Click);
            // 
            // pointCToolStripMenuItem
            // 
            this.pointCToolStripMenuItem.Name = "pointCToolStripMenuItem";
            this.pointCToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.pointCToolStripMenuItem.Text = "Point C";
            this.pointCToolStripMenuItem.Click += new System.EventHandler(this.pointCToolStripMenuItem_Click);
            // 
            // pointDToolStripMenuItem
            // 
            this.pointDToolStripMenuItem.Name = "pointDToolStripMenuItem";
            this.pointDToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.pointDToolStripMenuItem.Text = "Point D";
            this.pointDToolStripMenuItem.Click += new System.EventHandler(this.pointDToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
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
            this.segmentsToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.segmentsToolStripMenuItem.Text = "Segments";
            // 
            // toggleSpeedAcc
            // 
            this.toggleSpeedAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleSpeedAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSpeedAcc.ForeColor = System.Drawing.Color.White;
            this.toggleSpeedAcc.Location = new System.Drawing.Point(1200, 620);
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
            this.toggleSpeed.Location = new System.Drawing.Point(1104, 620);
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
            // segmentAToolStripMenuItem
            // 
            this.segmentAToolStripMenuItem.Name = "segmentAToolStripMenuItem";
            this.segmentAToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.segmentAToolStripMenuItem.Text = "Segment A";
            this.segmentAToolStripMenuItem.Click += new System.EventHandler(this.segmentAToolStripMenuItem_Click);
            // 
            // segmentBToolStripMenuItem
            // 
            this.segmentBToolStripMenuItem.Name = "segmentBToolStripMenuItem";
            this.segmentBToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.segmentBToolStripMenuItem.Text = "Segment B";
            this.segmentBToolStripMenuItem.Click += new System.EventHandler(this.segmentBToolStripMenuItem_Click);
            // 
            // segmentCToolStripMenuItem
            // 
            this.segmentCToolStripMenuItem.Name = "segmentCToolStripMenuItem";
            this.segmentCToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.segmentCToolStripMenuItem.Text = "Segment C";
            this.segmentCToolStripMenuItem.Click += new System.EventHandler(this.segmentCToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(211, 30);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1456, 576);
            this.splitContainer1.SplitterDistance = 1027;
            this.splitContainer1.TabIndex = 10;
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
            this.splitContainer2.Size = new System.Drawing.Size(425, 576);
            this.splitContainer2.SplitterDistance = 362;
            this.splitContainer2.TabIndex = 6;
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
            this.segmentsList.Size = new System.Drawing.Size(419, 336);
            this.segmentsList.TabIndex = 0;
            this.segmentsList.UseCompatibleStateImageBehavior = false;
            this.segmentsList.View = System.Windows.Forms.View.Details;
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
            this.ClientSize = new System.Drawing.Size(1486, 837);
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
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
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
    }
}

