namespace DatalogAnalyzer.DataChannels
{
    partial class ChannelManagementForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suspensionChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelListView = new System.Windows.Forms.ListView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editChannelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelIcons = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.newToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(757, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(135, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(135, 30);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataChannelToolStripMenuItem,
            this.suspensionChannelToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(59, 29);
            this.newToolStripMenuItem.Text = "New";
            // 
            // dataChannelToolStripMenuItem
            // 
            this.dataChannelToolStripMenuItem.Name = "dataChannelToolStripMenuItem";
            this.dataChannelToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.dataChannelToolStripMenuItem.Text = "Data channel";
            this.dataChannelToolStripMenuItem.Click += new System.EventHandler(this.dataChannelToolStripMenuItem_Click);
            // 
            // suspensionChannelToolStripMenuItem
            // 
            this.suspensionChannelToolStripMenuItem.Name = "suspensionChannelToolStripMenuItem";
            this.suspensionChannelToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.suspensionChannelToolStripMenuItem.Text = "Suspension channel";
            this.suspensionChannelToolStripMenuItem.Click += new System.EventHandler(this.suspensionChannelToolStripMenuItem_Click);
            // 
            // channelListView
            // 
            this.channelListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.channelListView.ContextMenuStrip = this.contextMenuStrip;
            this.channelListView.LargeImageList = this.channelIcons;
            this.channelListView.Location = new System.Drawing.Point(12, 36);
            this.channelListView.Name = "channelListView";
            this.channelListView.Size = new System.Drawing.Size(733, 370);
            this.channelListView.TabIndex = 1;
            this.channelListView.TileSize = new System.Drawing.Size(1, 1);
            this.channelListView.UseCompatibleStateImageBehavior = false;
            this.channelListView.DoubleClick += new System.EventHandler(this.channelListView_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editChannelMenuItem,
            this.deleteMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(135, 64);
            // 
            // editChannelMenuItem
            // 
            this.editChannelMenuItem.Name = "editChannelMenuItem";
            this.editChannelMenuItem.Size = new System.Drawing.Size(134, 30);
            this.editChannelMenuItem.Text = "Edit";
            this.editChannelMenuItem.Click += new System.EventHandler(this.editChannelMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(134, 30);
            this.deleteMenuItem.Text = "Delete";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // channelIcons
            // 
            this.channelIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.channelIcons.ImageSize = new System.Drawing.Size(128, 128);
            this.channelIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Channels.channels";
            this.openFileDialog.Filter = "Channel Files|*.channels";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Channel Files|*.channels";
            // 
            // ChannelManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 418);
            this.Controls.Add(this.channelListView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChannelManagementForm";
            this.Text = "Channels";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suspensionChannelToolStripMenuItem;
        private System.Windows.Forms.ListView channelListView;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ImageList channelIcons;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editChannelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
    }
}