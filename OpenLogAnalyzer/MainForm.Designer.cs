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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFromCardButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualImportButton = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTrackButton = new System.Windows.Forms.ToolStripMenuItem();
            this.NewInputButton = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forkSensorEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.AnalysisViewMapButton = new System.Windows.Forms.Button();
            this.AnalysisTrackBar = new System.Windows.Forms.TrackBar();
            this.AnalysisShowMarkers = new System.Windows.Forms.CheckBox();
            this.AnalysisLapList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AnalysisListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CompareAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.AnalysisInputTabs = new System.Windows.Forms.TabControl();
            this.InputTapContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MapTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MapTrackBar = new System.Windows.Forms.TrackBar();
            this.MapShowMarkers = new System.Windows.Forms.CheckBox();
            this.MapOverlayPanel = new System.Windows.Forms.Panel();
            this.MapOverlayLapList = new System.Windows.Forms.ListView();
            this.OverlayLapHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OverlayTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OverlayTopSpeedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OverlayMinSpeedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OverlayAvgSpeedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MapLapListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.compareMapLaps = new System.Windows.Forms.ToolStripMenuItem();
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.TrackLibraryTab = new System.Windows.Forms.TabPage();
            this.TrackLibraryMap = new GMap.NET.WindowsForms.GMapControl();
            this.TrackLibraryList = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.changedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainMenu.SuspendLayout();
            this.MainTabs.SuspendLayout();
            this.LogLibraryTab.SuspendLayout();
            this.AnalysisTab.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnalysisTrackBar)).BeginInit();
            this.AnalysisListMenu.SuspendLayout();
            this.InputTapContextMenu.SuspendLayout();
            this.MapTab.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapTrackBar)).BeginInit();
            this.MapOverlayPanel.SuspendLayout();
            this.MapLapListMenu.SuspendLayout();
            this.TrackLibraryTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testToolStripMenuItem});
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
            // NewTrackButton
            // 
            this.NewTrackButton.Name = "NewTrackButton";
            this.NewTrackButton.Size = new System.Drawing.Size(234, 30);
            this.NewTrackButton.Text = "New track";
            this.NewTrackButton.Click += new System.EventHandler(this.NewTrackButton_Click);
            // 
            // NewInputButton
            // 
            this.NewInputButton.Name = "NewInputButton";
            this.NewInputButton.Size = new System.Drawing.Size(234, 30);
            this.NewInputButton.Text = "New input";
            this.NewInputButton.Visible = false;
            this.NewInputButton.Click += new System.EventHandler(this.NewInputButton_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forkSensorEditorToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // forkSensorEditorToolStripMenuItem
            // 
            this.forkSensorEditorToolStripMenuItem.Name = "forkSensorEditorToolStripMenuItem";
            this.forkSensorEditorToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.forkSensorEditorToolStripMenuItem.Text = "ForkSensorEditor";
            this.forkSensorEditorToolStripMenuItem.Click += new System.EventHandler(this.forkSensorEditorToolStripMenuItem_Click);
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
            this.LogLibraryTab.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.LogLibraryTab.Size = new System.Drawing.Size(1550, 766);
            this.LogLibraryTab.TabIndex = 0;
            this.LogLibraryTab.Text = "Logs";
            this.LogLibraryTab.UseVisualStyleBackColor = true;
            // 
            // AnalysisTab
            // 
            this.AnalysisTab.Controls.Add(this.panel2);
            this.AnalysisTab.Controls.Add(this.AnalysisLapList);
            this.AnalysisTab.Controls.Add(this.AnalysisInputTabs);
            this.AnalysisTab.Location = new System.Drawing.Point(4, 29);
            this.AnalysisTab.Name = "AnalysisTab";
            this.AnalysisTab.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.AnalysisTab.Size = new System.Drawing.Size(1550, 766);
            this.AnalysisTab.TabIndex = 1;
            this.AnalysisTab.Text = "Analysis";
            this.AnalysisTab.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.AnalysisViewMapButton);
            this.panel2.Controls.Add(this.AnalysisTrackBar);
            this.panel2.Controls.Add(this.AnalysisShowMarkers);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 654);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1544, 109);
            this.panel2.TabIndex = 5;
            // 
            // AnalysisViewMapButton
            // 
            this.AnalysisViewMapButton.Location = new System.Drawing.Point(147, 6);
            this.AnalysisViewMapButton.Name = "AnalysisViewMapButton";
            this.AnalysisViewMapButton.Size = new System.Drawing.Size(108, 29);
            this.AnalysisViewMapButton.TabIndex = 4;
            this.AnalysisViewMapButton.Text = "View Map";
            this.AnalysisViewMapButton.UseVisualStyleBackColor = true;
            // 
            // AnalysisTrackBar
            // 
            this.AnalysisTrackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AnalysisTrackBar.Location = new System.Drawing.Point(0, 40);
            this.AnalysisTrackBar.Maximum = 1;
            this.AnalysisTrackBar.Name = "AnalysisTrackBar";
            this.AnalysisTrackBar.Size = new System.Drawing.Size(1544, 69);
            this.AnalysisTrackBar.TabIndex = 2;
            this.AnalysisTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.AnalysisTrackBar.Scroll += new System.EventHandler(this.AnalysisTrackBar_Scroll_1);
            // 
            // AnalysisShowMarkers
            // 
            this.AnalysisShowMarkers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AnalysisShowMarkers.AutoSize = true;
            this.AnalysisShowMarkers.BackColor = System.Drawing.SystemColors.Control;
            this.AnalysisShowMarkers.Location = new System.Drawing.Point(4, 10);
            this.AnalysisShowMarkers.Name = "AnalysisShowMarkers";
            this.AnalysisShowMarkers.Size = new System.Drawing.Size(136, 24);
            this.AnalysisShowMarkers.TabIndex = 3;
            this.AnalysisShowMarkers.Text = "Show Markers";
            this.AnalysisShowMarkers.UseVisualStyleBackColor = false;
            this.AnalysisShowMarkers.CheckedChanged += new System.EventHandler(this.AnalysisShowMarkers_CheckedChanged);
            // 
            // AnalysisLapList
            // 
            this.AnalysisLapList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnalysisLapList.BackColor = System.Drawing.SystemColors.Window;
            this.AnalysisLapList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.AnalysisLapList.ContextMenuStrip = this.AnalysisListMenu;
            this.AnalysisLapList.FullRowSelect = true;
            this.AnalysisLapList.Location = new System.Drawing.Point(1100, 6);
            this.AnalysisLapList.Name = "AnalysisLapList";
            this.AnalysisLapList.Size = new System.Drawing.Size(439, 370);
            this.AnalysisLapList.TabIndex = 2;
            this.AnalysisLapList.UseCompatibleStateImageBehavior = false;
            this.AnalysisLapList.View = System.Windows.Forms.View.Details;
            this.AnalysisLapList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AnalysisLapList_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Lap";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Max";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Min";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Avg.";
            this.columnHeader5.Width = 70;
            // 
            // AnalysisListMenu
            // 
            this.AnalysisListMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.AnalysisListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CompareAnalysis});
            this.AnalysisListMenu.Name = "AnalysisListMenu";
            this.AnalysisListMenu.Size = new System.Drawing.Size(158, 34);
            // 
            // CompareAnalysis
            // 
            this.CompareAnalysis.Name = "CompareAnalysis";
            this.CompareAnalysis.Size = new System.Drawing.Size(157, 30);
            this.CompareAnalysis.Text = "Compare";
            this.CompareAnalysis.Click += new System.EventHandler(this.CompareAnalysis_Click);
            // 
            // AnalysisInputTabs
            // 
            this.AnalysisInputTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnalysisInputTabs.ContextMenuStrip = this.InputTapContextMenu;
            this.AnalysisInputTabs.Location = new System.Drawing.Point(3, 6);
            this.AnalysisInputTabs.Name = "AnalysisInputTabs";
            this.AnalysisInputTabs.SelectedIndex = 0;
            this.AnalysisInputTabs.Size = new System.Drawing.Size(1090, 642);
            this.AnalysisInputTabs.TabIndex = 1;
            // 
            // InputTapContextMenu
            // 
            this.InputTapContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.InputTapContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newInputToolStripMenuItem,
            this.editInputToolStripMenuItem,
            this.newAnalysisToolStripMenuItem,
            this.editAnalysisToolStripMenuItem});
            this.InputTapContextMenu.Name = "InputTapContextMenu";
            this.InputTapContextMenu.Size = new System.Drawing.Size(189, 124);
            // 
            // newInputToolStripMenuItem
            // 
            this.newInputToolStripMenuItem.Name = "newInputToolStripMenuItem";
            this.newInputToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.newInputToolStripMenuItem.Text = "New Input";
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
            // MapTab
            // 
            this.MapTab.Controls.Add(this.panel1);
            this.MapTab.Controls.Add(this.MapOverlayPanel);
            this.MapTab.Controls.Add(this.Map);
            this.MapTab.Location = new System.Drawing.Point(4, 29);
            this.MapTab.Name = "MapTab";
            this.MapTab.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.MapTab.Size = new System.Drawing.Size(1550, 762);
            this.MapTab.TabIndex = 2;
            this.MapTab.Text = "Map";
            this.MapTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.MapTrackBar);
            this.panel1.Controls.Add(this.MapShowMarkers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 654);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1544, 105);
            this.panel1.TabIndex = 4;
            // 
            // MapTrackBar
            // 
            this.MapTrackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MapTrackBar.Location = new System.Drawing.Point(0, 36);
            this.MapTrackBar.Maximum = 1;
            this.MapTrackBar.Name = "MapTrackBar";
            this.MapTrackBar.Size = new System.Drawing.Size(1544, 69);
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
            // MapOverlayPanel
            // 
            this.MapOverlayPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MapOverlayPanel.Controls.Add(this.MapOverlayLapList);
            this.MapOverlayPanel.Location = new System.Drawing.Point(6, 6);
            this.MapOverlayPanel.Name = "MapOverlayPanel";
            this.MapOverlayPanel.Size = new System.Drawing.Size(620, 299);
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
            this.MapOverlayLapList.ContextMenuStrip = this.MapLapListMenu;
            this.MapOverlayLapList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapOverlayLapList.FullRowSelect = true;
            this.MapOverlayLapList.Location = new System.Drawing.Point(0, 0);
            this.MapOverlayLapList.Name = "MapOverlayLapList";
            this.MapOverlayLapList.Size = new System.Drawing.Size(616, 295);
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
            this.Map.Size = new System.Drawing.Size(1544, 756);
            this.Map.TabIndex = 0;
            this.Map.Zoom = 0D;
            // 
            // TrackLibraryTab
            // 
            this.TrackLibraryTab.Controls.Add(this.TrackLibraryMap);
            this.TrackLibraryTab.Controls.Add(this.TrackLibraryList);
            this.TrackLibraryTab.Location = new System.Drawing.Point(4, 29);
            this.TrackLibraryTab.Name = "TrackLibraryTab";
            this.TrackLibraryTab.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.TrackLibraryTab.Size = new System.Drawing.Size(1550, 762);
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
            this.TrackLibraryList.Size = new System.Drawing.Size(656, 756);
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnalysisTrackBar)).EndInit();
            this.AnalysisListMenu.ResumeLayout(false);
            this.InputTapContextMenu.ResumeLayout(false);
            this.MapTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapTrackBar)).EndInit();
            this.MapOverlayPanel.ResumeLayout(false);
            this.MapLapListMenu.ResumeLayout(false);
            this.TrackLibraryTab.ResumeLayout(false);
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
        private System.Windows.Forms.TrackBar MapTrackBar;
        private System.Windows.Forms.CheckBox MapShowMarkers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem NewTrackButton;
        private System.Windows.Forms.ToolStripMenuItem NewInputButton;
        private System.Windows.Forms.TabControl AnalysisInputTabs;
        private System.Windows.Forms.ListView AnalysisLapList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar AnalysisTrackBar;
        private System.Windows.Forms.CheckBox AnalysisShowMarkers;
        private System.Windows.Forms.Button AnalysisViewMapButton;
        private System.Windows.Forms.ContextMenuStrip AnalysisListMenu;
        private System.Windows.Forms.ToolStripMenuItem CompareAnalysis;
        private System.Windows.Forms.ContextMenuStrip MapLapListMenu;
        private System.Windows.Forms.ToolStripMenuItem compareMapLaps;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forkSensorEditorToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip InputTapContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editAnalysisToolStripMenuItem;
    }
}

