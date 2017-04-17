namespace DatalogAnalyzer
{
    partial class TrackEditor
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.trackMap = new GMap.NET.WindowsForms.GMapControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startFinishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHideToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.defineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abortSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(18, 45);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(51, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(18, 69);
            this.nameInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(343, 26);
            this.nameInput.TabIndex = 1;
            // 
            // trackMap
            // 
            this.trackMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackMap.Bearing = 0F;
            this.trackMap.CanDragMap = true;
            this.trackMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.trackMap.GrayScaleMode = false;
            this.trackMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.trackMap.LevelsKeepInMemmory = 5;
            this.trackMap.Location = new System.Drawing.Point(16, 108);
            this.trackMap.MarkersEnabled = true;
            this.trackMap.MaxZoom = 20;
            this.trackMap.MinZoom = 1;
            this.trackMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.trackMap.Name = "trackMap";
            this.trackMap.NegativeMode = false;
            this.trackMap.PolygonsEnabled = true;
            this.trackMap.RetryLoadTile = 0;
            this.trackMap.RoutesEnabled = true;
            this.trackMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.trackMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.trackMap.ShowTileGridLines = false;
            this.trackMap.Size = new System.Drawing.Size(1090, 698);
            this.trackMap.TabIndex = 6;
            this.trackMap.Zoom = 0D;
            this.trackMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackMap_MouseDown);
            this.trackMap.MouseLeave += new System.EventHandler(this.trackMap_MouseLeave);
            this.trackMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trackMap_MouseMove);
            this.trackMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackMap_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.startFinishToolStripMenuItem,
            this.areaToolStripMenuItem,
            this.polygonToolStripMenuItem,
            this.newSectionToolStripMenuItem,
            this.finishSectionToolStripMenuItem,
            this.abortSectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1124, 35);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(139, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(139, 30);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // startFinishToolStripMenuItem
            // 
            this.startFinishToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideToolStripMenuItem,
            this.defineToolStripMenuItem});
            this.startFinishToolStripMenuItem.Name = "startFinishToolStripMenuItem";
            this.startFinishToolStripMenuItem.Size = new System.Drawing.Size(112, 29);
            this.startFinishToolStripMenuItem.Text = "Start/Finish";
            // 
            // showHideToolStripMenuItem
            // 
            this.showHideToolStripMenuItem.Name = "showHideToolStripMenuItem";
            this.showHideToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.showHideToolStripMenuItem.Text = "Show/Hide";
            this.showHideToolStripMenuItem.Click += new System.EventHandler(this.showHideToolStripMenuItem_Click);
            // 
            // defineToolStripMenuItem
            // 
            this.defineToolStripMenuItem.Name = "defineToolStripMenuItem";
            this.defineToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.defineToolStripMenuItem.Text = "Define";
            this.defineToolStripMenuItem.Click += new System.EventHandler(this.defineToolStripMenuItem_Click);
            // 
            // areaToolStripMenuItem
            // 
            this.areaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideToolStripMenuItem1,
            this.defineToolStripMenuItem1});
            this.areaToolStripMenuItem.Name = "areaToolStripMenuItem";
            this.areaToolStripMenuItem.Size = new System.Drawing.Size(60, 29);
            this.areaToolStripMenuItem.Text = "Area";
            // 
            // showHideToolStripMenuItem1
            // 
            this.showHideToolStripMenuItem1.Name = "showHideToolStripMenuItem1";
            this.showHideToolStripMenuItem1.Size = new System.Drawing.Size(184, 30);
            this.showHideToolStripMenuItem1.Text = "Show/Hide";
            this.showHideToolStripMenuItem1.Click += new System.EventHandler(this.showHideToolStripMenuItem1_Click);
            // 
            // defineToolStripMenuItem1
            // 
            this.defineToolStripMenuItem1.Name = "defineToolStripMenuItem1";
            this.defineToolStripMenuItem1.Size = new System.Drawing.Size(184, 30);
            this.defineToolStripMenuItem1.Text = "Define";
            this.defineToolStripMenuItem1.Click += new System.EventHandler(this.defineToolStripMenuItem1_Click);
            // 
            // polygonToolStripMenuItem
            // 
            this.polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            this.polygonToolStripMenuItem.Size = new System.Drawing.Size(136, 29);
            this.polygonToolStripMenuItem.Text = "Reset Polygon";
            this.polygonToolStripMenuItem.Click += new System.EventHandler(this.polygonToolStripMenuItem_Click);
            // 
            // newSectionToolStripMenuItem
            // 
            this.newSectionToolStripMenuItem.Name = "newSectionToolStripMenuItem";
            this.newSectionToolStripMenuItem.Size = new System.Drawing.Size(120, 29);
            this.newSectionToolStripMenuItem.Text = "New section";
            this.newSectionToolStripMenuItem.Click += new System.EventHandler(this.newSectionToolStripMenuItem_Click);
            // 
            // finishSectionToolStripMenuItem
            // 
            this.finishSectionToolStripMenuItem.Name = "finishSectionToolStripMenuItem";
            this.finishSectionToolStripMenuItem.Size = new System.Drawing.Size(130, 29);
            this.finishSectionToolStripMenuItem.Text = "Finish section";
            this.finishSectionToolStripMenuItem.Click += new System.EventHandler(this.finishSectionToolStripMenuItem_Click);
            // 
            // abortSectionToolStripMenuItem
            // 
            this.abortSectionToolStripMenuItem.Name = "abortSectionToolStripMenuItem";
            this.abortSectionToolStripMenuItem.Size = new System.Drawing.Size(131, 29);
            this.abortSectionToolStripMenuItem.Text = "Abort section";
            this.abortSectionToolStripMenuItem.Click += new System.EventHandler(this.abortSectionToolStripMenuItem_Click);
            // 
            // TrackEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 823);
            this.Controls.Add(this.trackMap);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TrackEditor";
            this.Text = "TrackEditor";
            this.Load += new System.EventHandler(this.TrackEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameInput;
        private GMap.NET.WindowsForms.GMapControl trackMap;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startFinishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHideToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem defineToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finishSectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abortSectionToolStripMenuItem;
    }
}