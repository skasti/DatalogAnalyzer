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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFromCardButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualImportButton = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogLibraryList = new System.Windows.Forms.ListView();
            this.DateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LengthHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TrackHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Laps = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BestHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AverageHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RiderHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImportTimer = new System.Windows.Forms.Timer(this.components);
            this.MainTabs = new System.Windows.Forms.TabControl();
            this.LogLibraryTab = new System.Windows.Forms.TabPage();
            this.AnalysisTab = new System.Windows.Forms.TabPage();
            this.MapTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AnalysisTrackbar = new System.Windows.Forms.TrackBar();
            this.ShowMarkersCheckBox = new System.Windows.Forms.CheckBox();
            this.MapOverlayPanel = new System.Windows.Forms.Panel();
            this.MapOverlayLapList = new System.Windows.Forms.ListView();
            this.OverlayLapHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OverlayTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OverlayTopSpeedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OverlayMinSpeedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OverlayAvgSpeedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.TrackLibraryTab = new System.Windows.Forms.TabPage();
            this.TrackLibraryMap = new GMap.NET.WindowsForms.GMapControl();
            this.TrackLibraryList = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.changedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NewTrackButton = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.NewInputButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.MainTabs.SuspendLayout();
            this.LogLibraryTab.SuspendLayout();
            this.AnalysisTab.SuspendLayout();
            this.MapTab.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnalysisTrackbar)).BeginInit();
            this.MapOverlayPanel.SuspendLayout();
            this.TrackLibraryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1558, 33);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportFromCardButton,
            this.ManualImportButton,
            this.preferencesMenuItem,
            this.NewTrackButton,
            this.NewInputButton});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // ImportFromCardButton
            // 
            this.ImportFromCardButton.Name = "ImportFromCardButton";
            this.ImportFromCardButton.Size = new System.Drawing.Size(234, 30);
            this.ImportFromCardButton.Text = "Import from card";
            this.ImportFromCardButton.Click += new System.EventHandler(this.ImportFromCardButton_Click);
            // 
            // ManualImportButton
            // 
            this.ManualImportButton.Name = "ManualImportButton";
            this.ManualImportButton.Size = new System.Drawing.Size(234, 30);
            this.ManualImportButton.Text = "Manual import";
            // 
            // preferencesMenuItem
            // 
            this.preferencesMenuItem.Name = "preferencesMenuItem";
            this.preferencesMenuItem.Size = new System.Drawing.Size(234, 30);
            this.preferencesMenuItem.Text = "Preferences";
            this.preferencesMenuItem.Click += new System.EventHandler(this.preferencesMenuItem_Click);
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
            this.RiderHeader});
            this.LogLibraryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogLibraryList.FullRowSelect = true;
            this.LogLibraryList.Location = new System.Drawing.Point(3, 3);
            this.LogLibraryList.Name = "LogLibraryList";
            this.LogLibraryList.Size = new System.Drawing.Size(1544, 760);
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
            // ImportTimer
            // 
            this.ImportTimer.Enabled = true;
            this.ImportTimer.Interval = 1000;
            this.ImportTimer.Tick += new System.EventHandler(this.ImportTimer_Tick);
            // 
            // MainTabs
            // 
            this.MainTabs.Controls.Add(this.LogLibraryTab);
            this.MainTabs.Controls.Add(this.AnalysisTab);
            this.MainTabs.Controls.Add(this.MapTab);
            this.MainTabs.Controls.Add(this.TrackLibraryTab);
            this.MainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabs.Location = new System.Drawing.Point(0, 33);
            this.MainTabs.Name = "MainTabs";
            this.MainTabs.SelectedIndex = 0;
            this.MainTabs.Size = new System.Drawing.Size(1558, 799);
            this.MainTabs.TabIndex = 2;
            // 
            // LogLibraryTab
            // 
            this.LogLibraryTab.Controls.Add(this.LogLibraryList);
            this.LogLibraryTab.Location = new System.Drawing.Point(4, 29);
            this.LogLibraryTab.Name = "LogLibraryTab";
            this.LogLibraryTab.Padding = new System.Windows.Forms.Padding(3);
            this.LogLibraryTab.Size = new System.Drawing.Size(1550, 766);
            this.LogLibraryTab.TabIndex = 0;
            this.LogLibraryTab.Text = "Logs";
            this.LogLibraryTab.UseVisualStyleBackColor = true;
            // 
            // AnalysisTab
            // 
            this.AnalysisTab.Controls.Add(this.chart1);
            this.AnalysisTab.Location = new System.Drawing.Point(4, 29);
            this.AnalysisTab.Name = "AnalysisTab";
            this.AnalysisTab.Padding = new System.Windows.Forms.Padding(3);
            this.AnalysisTab.Size = new System.Drawing.Size(1550, 766);
            this.AnalysisTab.TabIndex = 1;
            this.AnalysisTab.Text = "Analysis";
            this.AnalysisTab.UseVisualStyleBackColor = true;
            // 
            // MapTab
            // 
            this.MapTab.Controls.Add(this.panel1);
            this.MapTab.Controls.Add(this.MapOverlayPanel);
            this.MapTab.Controls.Add(this.Map);
            this.MapTab.Location = new System.Drawing.Point(4, 29);
            this.MapTab.Name = "MapTab";
            this.MapTab.Padding = new System.Windows.Forms.Padding(3);
            this.MapTab.Size = new System.Drawing.Size(1550, 766);
            this.MapTab.TabIndex = 2;
            this.MapTab.Text = "Map";
            this.MapTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.AnalysisTrackbar);
            this.panel1.Controls.Add(this.ShowMarkersCheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 658);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1544, 105);
            this.panel1.TabIndex = 4;
            // 
            // AnalysisTrackbar
            // 
            this.AnalysisTrackbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AnalysisTrackbar.Location = new System.Drawing.Point(0, 36);
            this.AnalysisTrackbar.Maximum = 1;
            this.AnalysisTrackbar.Name = "AnalysisTrackbar";
            this.AnalysisTrackbar.Size = new System.Drawing.Size(1544, 69);
            this.AnalysisTrackbar.TabIndex = 2;
            this.AnalysisTrackbar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.AnalysisTrackbar.Scroll += new System.EventHandler(this.AnalysisTrackbar_Scroll);
            // 
            // ShowMarkersCheckBox
            // 
            this.ShowMarkersCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowMarkersCheckBox.AutoSize = true;
            this.ShowMarkersCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.ShowMarkersCheckBox.Location = new System.Drawing.Point(5, 6);
            this.ShowMarkersCheckBox.Name = "ShowMarkersCheckBox";
            this.ShowMarkersCheckBox.Size = new System.Drawing.Size(136, 24);
            this.ShowMarkersCheckBox.TabIndex = 3;
            this.ShowMarkersCheckBox.Text = "Show Markers";
            this.ShowMarkersCheckBox.UseVisualStyleBackColor = false;
            // 
            // MapOverlayPanel
            // 
            this.MapOverlayPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MapOverlayPanel.Controls.Add(this.MapOverlayLapList);
            this.MapOverlayPanel.Location = new System.Drawing.Point(6, 6);
            this.MapOverlayPanel.Name = "MapOverlayPanel";
            this.MapOverlayPanel.Size = new System.Drawing.Size(620, 300);
            this.MapOverlayPanel.TabIndex = 1;
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
            this.MapOverlayLapList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapOverlayLapList.FullRowSelect = true;
            this.MapOverlayLapList.Location = new System.Drawing.Point(0, 0);
            this.MapOverlayLapList.Name = "MapOverlayLapList";
            this.MapOverlayLapList.Size = new System.Drawing.Size(616, 296);
            this.MapOverlayLapList.TabIndex = 0;
            this.MapOverlayLapList.UseCompatibleStateImageBehavior = false;
            this.MapOverlayLapList.View = System.Windows.Forms.View.Details;
            this.MapOverlayLapList.SelectedIndexChanged += new System.EventHandler(this.MapOverlayLapList_SelectedIndexChanged);
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
            // Map
            // 
            this.Map.Bearing = 0F;
            this.Map.CanDragMap = true;
            this.Map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Map.EmptyTileColor = System.Drawing.Color.Navy;
            this.Map.GrayScaleMode = false;
            this.Map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Map.LevelsKeepInMemmory = 5;
            this.Map.Location = new System.Drawing.Point(3, 3);
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
            this.Map.Size = new System.Drawing.Size(1544, 760);
            this.Map.TabIndex = 0;
            this.Map.Zoom = 0D;
            // 
            // TrackLibraryTab
            // 
            this.TrackLibraryTab.Controls.Add(this.TrackLibraryMap);
            this.TrackLibraryTab.Controls.Add(this.TrackLibraryList);
            this.TrackLibraryTab.Location = new System.Drawing.Point(4, 29);
            this.TrackLibraryTab.Name = "TrackLibraryTab";
            this.TrackLibraryTab.Padding = new System.Windows.Forms.Padding(3);
            this.TrackLibraryTab.Size = new System.Drawing.Size(1550, 766);
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
            this.TrackLibraryMap.Location = new System.Drawing.Point(667, 3);
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
            this.TrackLibraryList.Size = new System.Drawing.Size(657, 760);
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
            // NewTrackButton
            // 
            this.NewTrackButton.Name = "NewTrackButton";
            this.NewTrackButton.Size = new System.Drawing.Size(234, 30);
            this.NewTrackButton.Text = "New track";
            this.NewTrackButton.Click += new System.EventHandler(this.NewTrackButton_Click);
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(102, 352);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(1172, 250);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // NewInputButton
            // 
            this.NewInputButton.Name = "NewInputButton";
            this.NewInputButton.Size = new System.Drawing.Size(234, 30);
            this.NewInputButton.Text = "New input";
            this.NewInputButton.Visible = false;
            this.NewInputButton.Click += new System.EventHandler(this.NewInputButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1558, 832);
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
            this.AnalysisTab.ResumeLayout(false);
            this.MapTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnalysisTrackbar)).EndInit();
            this.MapOverlayPanel.ResumeLayout(false);
            this.TrackLibraryTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem preferencesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManualImportButton;
        private System.Windows.Forms.Timer ImportTimer;
        private System.Windows.Forms.TabControl MainTabs;
        private System.Windows.Forms.TabPage LogLibraryTab;
        private System.Windows.Forms.TabPage AnalysisTab;
        private System.Windows.Forms.ColumnHeader LengthHeader;
        private System.Windows.Forms.ColumnHeader Laps;
        private System.Windows.Forms.TabPage MapTab;
        private GMap.NET.WindowsForms.GMapControl Map;
        private System.Windows.Forms.TabPage TrackLibraryTab;
        private GMap.NET.WindowsForms.GMapControl TrackLibraryMap;
        private System.Windows.Forms.ListView TrackLibraryList;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader changedHeader;
        private System.Windows.Forms.Panel MapOverlayPanel;
        private System.Windows.Forms.ListView MapOverlayLapList;
        private System.Windows.Forms.ColumnHeader OverlayLapHeader;
        private System.Windows.Forms.ColumnHeader OverlayTimeHeader;
        private System.Windows.Forms.ColumnHeader OverlayTopSpeedHeader;
        private System.Windows.Forms.ColumnHeader OverlayMinSpeedHeader;
        private System.Windows.Forms.ColumnHeader OverlayAvgSpeedHeader;
        private System.Windows.Forms.TrackBar AnalysisTrackbar;
        private System.Windows.Forms.CheckBox ShowMarkersCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem NewTrackButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem NewInputButton;
    }
}

