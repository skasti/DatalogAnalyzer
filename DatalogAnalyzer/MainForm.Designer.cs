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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series43 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint22 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 100D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint23 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.01D, 150D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint24 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.02D, 140D);
            System.Windows.Forms.DataVisualization.Charting.Series series44 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series45 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series46 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series47 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series48 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.toggleSpeedAcc = new System.Windows.Forms.Button();
            this.toggleSpeed = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.startFinishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.DimGray;
            chartArea8.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea8.AxisX.ScaleView.SmallScrollMinSize = 0.01D;
            chartArea8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart1.Legends.Add(legend8);
            this.chart1.Location = new System.Drawing.Point(8, 26);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series43.ChartArea = "ChartArea1";
            series43.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series43.Color = System.Drawing.Color.Red;
            series43.Legend = "Legend1";
            series43.Name = "Series1";
            series43.Points.Add(dataPoint22);
            series43.Points.Add(dataPoint23);
            series43.Points.Add(dataPoint24);
            series44.ChartArea = "ChartArea1";
            series44.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series44.Legend = "Legend1";
            series44.Name = "Series2";
            series45.ChartArea = "ChartArea1";
            series45.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series45.Legend = "Legend1";
            series45.Name = "Series3";
            series46.ChartArea = "ChartArea1";
            series46.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series46.Legend = "Legend1";
            series46.Name = "Series4";
            series47.ChartArea = "ChartArea1";
            series47.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series47.Legend = "Legend1";
            series47.Name = "Series5";
            series48.ChartArea = "ChartArea1";
            series48.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series48.Legend = "Legend1";
            series48.Name = "Series6";
            this.chart1.Series.Add(series43);
            this.chart1.Series.Add(series44);
            this.chart1.Series.Add(series45);
            this.chart1.Series.Add(series46);
            this.chart1.Series.Add(series47);
            this.chart1.Series.Add(series48);
            this.chart1.Size = new System.Drawing.Size(595, 373);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseUp);
            // 
            // ChannelToggleButtonTemplate
            // 
            this.ChannelToggleButtonTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChannelToggleButtonTemplate.Location = new System.Drawing.Point(8, 403);
            this.ChannelToggleButtonTemplate.Margin = new System.Windows.Forms.Padding(2);
            this.ChannelToggleButtonTemplate.Name = "ChannelToggleButtonTemplate";
            this.ChannelToggleButtonTemplate.Size = new System.Drawing.Size(93, 27);
            this.ChannelToggleButtonTemplate.TabIndex = 1;
            this.ChannelToggleButtonTemplate.Text = "Channel toggle";
            this.ChannelToggleButtonTemplate.UseVisualStyleBackColor = true;
            this.ChannelToggleButtonTemplate.Visible = false;
            // 
            // logWindow
            // 
            this.logWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logWindow.Location = new System.Drawing.Point(8, 434);
            this.logWindow.Margin = new System.Windows.Forms.Padding(2);
            this.logWindow.Name = "logWindow";
            this.logWindow.ReadOnly = true;
            this.logWindow.Size = new System.Drawing.Size(972, 99);
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
            this.toggleDelta.Location = new System.Drawing.Point(926, 403);
            this.toggleDelta.Margin = new System.Windows.Forms.Padding(2);
            this.toggleDelta.Name = "toggleDelta";
            this.toggleDelta.Size = new System.Drawing.Size(54, 27);
            this.toggleDelta.TabIndex = 3;
            this.toggleDelta.Text = "Delta";
            this.toggleDelta.UseVisualStyleBackColor = true;
            this.toggleDelta.Click += new System.EventHandler(this.toggleDelta_Click);
            // 
            // gMap
            // 
            this.gMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(607, 26);
            this.gMap.Margin = new System.Windows.Forms.Padding(2);
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
            this.gMap.Size = new System.Drawing.Size(373, 373);
            this.gMap.TabIndex = 5;
            this.gMap.Zoom = 0D;
            this.gMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseDown);
            this.gMap.MouseLeave += new System.EventHandler(this.gMap_MouseLeave);
            this.gMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseMove);
            this.gMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseUp);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(991, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channelConfigToolStripMenuItem,
            this.splitToolStripMenuItem,
            this.startFinishToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // channelConfigToolStripMenuItem
            // 
            this.channelConfigToolStripMenuItem.Name = "channelConfigToolStripMenuItem";
            this.channelConfigToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.channelConfigToolStripMenuItem.Text = "Channel Config";
            this.channelConfigToolStripMenuItem.Click += new System.EventHandler(this.channelConfigToolStripMenuItem_Click);
            // 
            // splitToolStripMenuItem
            // 
            this.splitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepBeforeToolStripMenuItem,
            this.keepAfterToolStripMenuItem});
            this.splitToolStripMenuItem.Name = "splitToolStripMenuItem";
            this.splitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.splitToolStripMenuItem.Text = "Split";
            // 
            // keepBeforeToolStripMenuItem
            // 
            this.keepBeforeToolStripMenuItem.Name = "keepBeforeToolStripMenuItem";
            this.keepBeforeToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.keepBeforeToolStripMenuItem.Text = "Keep before";
            this.keepBeforeToolStripMenuItem.Click += new System.EventHandler(this.keepBeforeToolStripMenuItem_Click);
            // 
            // keepAfterToolStripMenuItem
            // 
            this.keepAfterToolStripMenuItem.Name = "keepAfterToolStripMenuItem";
            this.keepAfterToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.keepAfterToolStripMenuItem.Text = "Keep after";
            this.keepAfterToolStripMenuItem.Click += new System.EventHandler(this.keepAfterToolStripMenuItem_Click);
            // 
            // toggleSpeedAcc
            // 
            this.toggleSpeedAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleSpeedAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSpeedAcc.ForeColor = System.Drawing.Color.White;
            this.toggleSpeedAcc.Location = new System.Drawing.Point(800, 403);
            this.toggleSpeedAcc.Margin = new System.Windows.Forms.Padding(2);
            this.toggleSpeedAcc.Name = "toggleSpeedAcc";
            this.toggleSpeedAcc.Size = new System.Drawing.Size(122, 27);
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
            this.toggleSpeed.Location = new System.Drawing.Point(736, 403);
            this.toggleSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.toggleSpeed.Name = "toggleSpeed";
            this.toggleSpeed.Size = new System.Drawing.Size(60, 27);
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
            // startFinishToolStripMenuItem
            // 
            this.startFinishToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem,
            this.pointBToolStripMenuItem});
            this.startFinishToolStripMenuItem.Name = "startFinishToolStripMenuItem";
            this.startFinishToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.startFinishToolStripMenuItem.Text = "Start/Finish";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aToolStripMenuItem.Text = "Point A";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // pointBToolStripMenuItem
            // 
            this.pointBToolStripMenuItem.Name = "pointBToolStripMenuItem";
            this.pointBToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pointBToolStripMenuItem.Text = "Point B";
            this.pointBToolStripMenuItem.Click += new System.EventHandler(this.pointBToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 544);
            this.Controls.Add(this.toggleSpeed);
            this.Controls.Add(this.toggleSpeedAcc);
            this.Controls.Add(this.gMap);
            this.Controls.Add(this.toggleDelta);
            this.Controls.Add(this.logWindow);
            this.Controls.Add(this.ChannelToggleButtonTemplate);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "SR Datalog Analyzer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem startFinishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointBToolStripMenuItem;
    }
}

