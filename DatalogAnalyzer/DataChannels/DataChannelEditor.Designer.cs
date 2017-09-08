namespace DatalogAnalyzer.DataChannels
{
    partial class DataChannelEditor
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
            this.scalingInput = new System.Windows.Forms.TextBox();
            this.scalingLabel = new System.Windows.Forms.Label();
            this.zeroPointInput = new System.Windows.Forms.TextBox();
            this.zeroPointLabel = new System.Windows.Forms.Label();
            this.chartInput = new System.Windows.Forms.ComboBox();
            this.chartLabel = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.sourceInput = new System.Windows.Forms.NumericUpDown();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.iconPicture = new System.Windows.Forms.PictureBox();
            this.iconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.channelIcons = new System.Windows.Forms.ImageList(this.components);
            this.smoothingInput = new System.Windows.Forms.TextBox();
            this.smoothingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sourceInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // scalingInput
            // 
            this.scalingInput.Location = new System.Drawing.Point(211, 61);
            this.scalingInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scalingInput.Name = "scalingInput";
            this.scalingInput.Size = new System.Drawing.Size(81, 20);
            this.scalingInput.TabIndex = 19;
            // 
            // scalingLabel
            // 
            this.scalingLabel.AutoSize = true;
            this.scalingLabel.Location = new System.Drawing.Point(209, 46);
            this.scalingLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.scalingLabel.Name = "scalingLabel";
            this.scalingLabel.Size = new System.Drawing.Size(42, 13);
            this.scalingLabel.TabIndex = 18;
            this.scalingLabel.Text = "Scaling";
            // 
            // zeroPointInput
            // 
            this.zeroPointInput.Location = new System.Drawing.Point(111, 61);
            this.zeroPointInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.zeroPointInput.Name = "zeroPointInput";
            this.zeroPointInput.Size = new System.Drawing.Size(81, 20);
            this.zeroPointInput.TabIndex = 17;
            // 
            // zeroPointLabel
            // 
            this.zeroPointLabel.AutoSize = true;
            this.zeroPointLabel.Location = new System.Drawing.Point(109, 46);
            this.zeroPointLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.zeroPointLabel.Name = "zeroPointLabel";
            this.zeroPointLabel.Size = new System.Drawing.Size(56, 13);
            this.zeroPointLabel.TabIndex = 16;
            this.zeroPointLabel.Text = "Zero Point";
            // 
            // chartInput
            // 
            this.chartInput.FormattingEnabled = true;
            this.chartInput.Location = new System.Drawing.Point(331, 19);
            this.chartInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartInput.Name = "chartInput";
            this.chartInput.Size = new System.Drawing.Size(145, 21);
            this.chartInput.TabIndex = 15;
            // 
            // chartLabel
            // 
            this.chartLabel.AutoSize = true;
            this.chartLabel.Location = new System.Drawing.Point(329, 6);
            this.chartLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.chartLabel.Name = "chartLabel";
            this.chartLabel.Size = new System.Drawing.Size(32, 13);
            this.chartLabel.TabIndex = 14;
            this.chartLabel.Text = "Chart";
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(211, 20);
            this.nameInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(101, 20);
            this.nameInput.TabIndex = 13;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(209, 6);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 12;
            this.nameLabel.Text = "Name";
            // 
            // sourceInput
            // 
            this.sourceInput.Location = new System.Drawing.Point(111, 21);
            this.sourceInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sourceInput.Name = "sourceInput";
            this.sourceInput.Size = new System.Drawing.Size(80, 20);
            this.sourceInput.TabIndex = 11;
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(109, 6);
            this.sourceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(41, 13);
            this.sourceLabel.TabIndex = 10;
            this.sourceLabel.Text = "Source";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(426, 71);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(50, 21);
            this.saveButton.TabIndex = 20;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(426, 46);
            this.resetButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(50, 21);
            this.resetButton.TabIndex = 21;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // iconPicture
            // 
            this.iconPicture.ContextMenuStrip = this.iconContextMenu;
            this.iconPicture.Location = new System.Drawing.Point(8, 8);
            this.iconPicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconPicture.Name = "iconPicture";
            this.iconPicture.Size = new System.Drawing.Size(85, 83);
            this.iconPicture.TabIndex = 22;
            this.iconPicture.TabStop = false;
            // 
            // iconContextMenu
            // 
            this.iconContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.iconContextMenu.Name = "iconContextMenu";
            this.iconContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // channelIcons
            // 
            this.channelIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.channelIcons.ImageSize = new System.Drawing.Size(64, 64);
            this.channelIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // smoothingInput
            // 
            this.smoothingInput.Location = new System.Drawing.Point(311, 61);
            this.smoothingInput.Margin = new System.Windows.Forms.Padding(2);
            this.smoothingInput.Name = "smoothingInput";
            this.smoothingInput.Size = new System.Drawing.Size(81, 20);
            this.smoothingInput.TabIndex = 24;
            // 
            // smoothingLabel
            // 
            this.smoothingLabel.AutoSize = true;
            this.smoothingLabel.Location = new System.Drawing.Point(309, 46);
            this.smoothingLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.smoothingLabel.Name = "smoothingLabel";
            this.smoothingLabel.Size = new System.Drawing.Size(57, 13);
            this.smoothingLabel.TabIndex = 23;
            this.smoothingLabel.Text = "Smoothing";
            // 
            // DataChannelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 100);
            this.Controls.Add(this.smoothingInput);
            this.Controls.Add(this.smoothingLabel);
            this.Controls.Add(this.iconPicture);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.scalingInput);
            this.Controls.Add(this.scalingLabel);
            this.Controls.Add(this.zeroPointInput);
            this.Controls.Add(this.zeroPointLabel);
            this.Controls.Add(this.chartInput);
            this.Controls.Add(this.chartLabel);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.sourceInput);
            this.Controls.Add(this.sourceLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DataChannelEditor";
            this.Text = "DataChannelEditor";
            ((System.ComponentModel.ISupportInitialize)(this.sourceInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox scalingInput;
        private System.Windows.Forms.Label scalingLabel;
        private System.Windows.Forms.TextBox zeroPointInput;
        private System.Windows.Forms.Label zeroPointLabel;
        private System.Windows.Forms.ComboBox chartInput;
        private System.Windows.Forms.Label chartLabel;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.NumericUpDown sourceInput;
        private System.Windows.Forms.Label sourceLabel;
        protected System.Windows.Forms.Button saveButton;
        protected System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.PictureBox iconPicture;
        private System.Windows.Forms.ImageList channelIcons;
        private System.Windows.Forms.ContextMenuStrip iconContextMenu;
        private System.Windows.Forms.TextBox smoothingInput;
        private System.Windows.Forms.Label smoothingLabel;
    }
}