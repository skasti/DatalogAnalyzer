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
            this.channelIcons = new System.Windows.Forms.ImageList(this.components);
            this.iconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sourceInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // scalingInput
            // 
            this.scalingInput.Location = new System.Drawing.Point(305, 94);
            this.scalingInput.Name = "scalingInput";
            this.scalingInput.Size = new System.Drawing.Size(120, 26);
            this.scalingInput.TabIndex = 19;
            // 
            // scalingLabel
            // 
            this.scalingLabel.AutoSize = true;
            this.scalingLabel.Location = new System.Drawing.Point(301, 71);
            this.scalingLabel.Name = "scalingLabel";
            this.scalingLabel.Size = new System.Drawing.Size(61, 20);
            this.scalingLabel.TabIndex = 18;
            this.scalingLabel.Text = "Scaling";
            // 
            // zeroPointInput
            // 
            this.zeroPointInput.Location = new System.Drawing.Point(155, 94);
            this.zeroPointInput.Name = "zeroPointInput";
            this.zeroPointInput.Size = new System.Drawing.Size(120, 26);
            this.zeroPointInput.TabIndex = 17;
            // 
            // zeroPointLabel
            // 
            this.zeroPointLabel.AutoSize = true;
            this.zeroPointLabel.Location = new System.Drawing.Point(151, 71);
            this.zeroPointLabel.Name = "zeroPointLabel";
            this.zeroPointLabel.Size = new System.Drawing.Size(82, 20);
            this.zeroPointLabel.TabIndex = 16;
            this.zeroPointLabel.Text = "Zero Point";
            // 
            // chartInput
            // 
            this.chartInput.FormattingEnabled = true;
            this.chartInput.Location = new System.Drawing.Point(485, 29);
            this.chartInput.Name = "chartInput";
            this.chartInput.Size = new System.Drawing.Size(216, 28);
            this.chartInput.TabIndex = 15;
            // 
            // chartLabel
            // 
            this.chartLabel.AutoSize = true;
            this.chartLabel.Location = new System.Drawing.Point(481, 9);
            this.chartLabel.Name = "chartLabel";
            this.chartLabel.Size = new System.Drawing.Size(48, 20);
            this.chartLabel.TabIndex = 14;
            this.chartLabel.Text = "Chart";
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(305, 31);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(150, 26);
            this.nameInput.TabIndex = 13;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(301, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(51, 20);
            this.nameLabel.TabIndex = 12;
            this.nameLabel.Text = "Name";
            // 
            // sourceInput
            // 
            this.sourceInput.Location = new System.Drawing.Point(155, 32);
            this.sourceInput.Name = "sourceInput";
            this.sourceInput.Size = new System.Drawing.Size(120, 26);
            this.sourceInput.TabIndex = 11;
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(151, 9);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(60, 20);
            this.sourceLabel.TabIndex = 10;
            this.sourceLabel.Text = "Source";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(626, 101);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 33);
            this.saveButton.TabIndex = 20;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(545, 101);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 33);
            this.resetButton.TabIndex = 21;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // iconPicture
            // 
            this.iconPicture.ContextMenuStrip = this.iconContextMenu;
            this.iconPicture.Location = new System.Drawing.Point(12, 12);
            this.iconPicture.Name = "iconPicture";
            this.iconPicture.Size = new System.Drawing.Size(128, 128);
            this.iconPicture.TabIndex = 22;
            this.iconPicture.TabStop = false;
            // 
            // channelIcons
            // 
            this.channelIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.channelIcons.ImageSize = new System.Drawing.Size(64, 64);
            this.channelIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // iconContextMenu
            // 
            this.iconContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.iconContextMenu.Name = "iconContextMenu";
            this.iconContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // DataChannelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 146);
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
    }
}