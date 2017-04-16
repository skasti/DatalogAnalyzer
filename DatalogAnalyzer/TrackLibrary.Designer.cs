namespace DatalogAnalyzer
{
    partial class TrackLibrary
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
            this.trackList = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.changedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackMap = new GMap.NET.WindowsForms.GMapControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackList
            // 
            this.trackList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.changedHeader});
            this.trackList.Location = new System.Drawing.Point(18, 42);
            this.trackList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackList.Name = "trackList";
            this.trackList.Size = new System.Drawing.Size(657, 375);
            this.trackList.TabIndex = 0;
            this.trackList.UseCompatibleStateImageBehavior = false;
            this.trackList.View = System.Windows.Forms.View.Details;
            this.trackList.SelectedIndexChanged += new System.EventHandler(this.trackList_SelectedIndexChanged);
            this.trackList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trackList_MouseDoubleClick);
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
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTrackToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1196, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newTrackToolStripMenuItem
            // 
            this.newTrackToolStripMenuItem.Name = "newTrackToolStripMenuItem";
            this.newTrackToolStripMenuItem.Size = new System.Drawing.Size(103, 29);
            this.newTrackToolStripMenuItem.Text = "New Track";
            this.newTrackToolStripMenuItem.Click += new System.EventHandler(this.newTrackToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(67, 29);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
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
            this.trackMap.Location = new System.Drawing.Point(682, 42);
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
            this.trackMap.Size = new System.Drawing.Size(502, 375);
            this.trackMap.TabIndex = 7;
            this.trackMap.Zoom = 0D;
            // 
            // TrackLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 431);
            this.Controls.Add(this.trackMap);
            this.Controls.Add(this.trackList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TrackLibrary";
            this.Text = "Track Library";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView trackList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader changedHeader;
        private GMap.NET.WindowsForms.GMapControl trackMap;
    }
}