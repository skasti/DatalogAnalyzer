namespace DatalogAnalyzer
{
    partial class ChannelConfigForm
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
            this.chNameTemplate = new System.Windows.Forms.TextBox();
            this.chZeroTemplate = new System.Windows.Forms.TextBox();
            this.chScalingTemplate = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.zeroLabel = new System.Windows.Forms.Label();
            this.scalingLabel = new System.Windows.Forms.Label();
            this.applyBtnTemplate = new System.Windows.Forms.Button();
            this.resetBtnTemplate = new System.Windows.Forms.Button();
            this.chArm1LengthTemplate = new System.Windows.Forms.TextBox();
            this.arm1LengthLabel = new System.Windows.Forms.Label();
            this.arm2LengthLabel = new System.Windows.Forms.Label();
            this.chArm2LengthTemplate = new System.Windows.Forms.TextBox();
            this.ChannelConfigMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.armAxisDistanceLabel = new System.Windows.Forms.Label();
            this.chArmAxisDistanceTemplate = new System.Windows.Forms.TextBox();
            this.chIsTempTemplate = new System.Windows.Forms.CheckBox();
            this.isTempLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ChannelConfigMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // chNameTemplate
            // 
            this.chNameTemplate.Location = new System.Drawing.Point(52, 80);
            this.chNameTemplate.Name = "chNameTemplate";
            this.chNameTemplate.Size = new System.Drawing.Size(178, 26);
            this.chNameTemplate.TabIndex = 0;
            this.chNameTemplate.Text = "Channel 1";
            this.chNameTemplate.Visible = false;
            // 
            // chZeroTemplate
            // 
            this.chZeroTemplate.Location = new System.Drawing.Point(237, 80);
            this.chZeroTemplate.Name = "chZeroTemplate";
            this.chZeroTemplate.Size = new System.Drawing.Size(100, 26);
            this.chZeroTemplate.TabIndex = 1;
            this.chZeroTemplate.Visible = false;
            // 
            // chScalingTemplate
            // 
            this.chScalingTemplate.Location = new System.Drawing.Point(342, 80);
            this.chScalingTemplate.Name = "chScalingTemplate";
            this.chScalingTemplate.Size = new System.Drawing.Size(100, 26);
            this.chScalingTemplate.TabIndex = 2;
            this.chScalingTemplate.Visible = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(48, 49);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(114, 20);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Channel Name";
            // 
            // zeroLabel
            // 
            this.zeroLabel.AutoSize = true;
            this.zeroLabel.Location = new System.Drawing.Point(232, 49);
            this.zeroLabel.Name = "zeroLabel";
            this.zeroLabel.Size = new System.Drawing.Size(82, 20);
            this.zeroLabel.TabIndex = 4;
            this.zeroLabel.Text = "Zero Point";
            // 
            // scalingLabel
            // 
            this.scalingLabel.AutoSize = true;
            this.scalingLabel.Location = new System.Drawing.Point(339, 49);
            this.scalingLabel.Name = "scalingLabel";
            this.scalingLabel.Size = new System.Drawing.Size(61, 20);
            this.scalingLabel.TabIndex = 5;
            this.scalingLabel.Text = "Scaling";
            // 
            // applyBtnTemplate
            // 
            this.applyBtnTemplate.Location = new System.Drawing.Point(772, 74);
            this.applyBtnTemplate.Name = "applyBtnTemplate";
            this.applyBtnTemplate.Size = new System.Drawing.Size(75, 42);
            this.applyBtnTemplate.TabIndex = 6;
            this.applyBtnTemplate.Text = "Apply";
            this.applyBtnTemplate.UseVisualStyleBackColor = true;
            this.applyBtnTemplate.Visible = false;
            // 
            // resetBtnTemplate
            // 
            this.resetBtnTemplate.Location = new System.Drawing.Point(854, 74);
            this.resetBtnTemplate.Name = "resetBtnTemplate";
            this.resetBtnTemplate.Size = new System.Drawing.Size(75, 42);
            this.resetBtnTemplate.TabIndex = 7;
            this.resetBtnTemplate.Text = "Reset";
            this.resetBtnTemplate.UseVisualStyleBackColor = true;
            this.resetBtnTemplate.Visible = false;
            // 
            // chArm1LengthTemplate
            // 
            this.chArm1LengthTemplate.Location = new System.Drawing.Point(448, 80);
            this.chArm1LengthTemplate.Name = "chArm1LengthTemplate";
            this.chArm1LengthTemplate.Size = new System.Drawing.Size(100, 26);
            this.chArm1LengthTemplate.TabIndex = 8;
            this.chArm1LengthTemplate.Visible = false;
            // 
            // arm1LengthLabel
            // 
            this.arm1LengthLabel.AutoSize = true;
            this.arm1LengthLabel.Location = new System.Drawing.Point(444, 49);
            this.arm1LengthLabel.Name = "arm1LengthLabel";
            this.arm1LengthLabel.Size = new System.Drawing.Size(60, 20);
            this.arm1LengthLabel.TabIndex = 9;
            this.arm1LengthLabel.Text = "Arm #1";
            // 
            // arm2LengthLabel
            // 
            this.arm2LengthLabel.AutoSize = true;
            this.arm2LengthLabel.Location = new System.Drawing.Point(552, 49);
            this.arm2LengthLabel.Name = "arm2LengthLabel";
            this.arm2LengthLabel.Size = new System.Drawing.Size(60, 20);
            this.arm2LengthLabel.TabIndex = 11;
            this.arm2LengthLabel.Text = "Arm #2";
            // 
            // chArm2LengthTemplate
            // 
            this.chArm2LengthTemplate.Location = new System.Drawing.Point(556, 80);
            this.chArm2LengthTemplate.Name = "chArm2LengthTemplate";
            this.chArm2LengthTemplate.Size = new System.Drawing.Size(100, 26);
            this.chArm2LengthTemplate.TabIndex = 10;
            this.chArm2LengthTemplate.Visible = false;
            // 
            // ChannelConfigMenu
            // 
            this.ChannelConfigMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ChannelConfigMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.ChannelConfigMenu.Location = new System.Drawing.Point(0, 0);
            this.ChannelConfigMenu.Name = "ChannelConfigMenu";
            this.ChannelConfigMenu.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.ChannelConfigMenu.Size = new System.Drawing.Size(946, 35);
            this.ChannelConfigMenu.TabIndex = 12;
            this.ChannelConfigMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(140, 30);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(140, 30);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // armAxisDistanceLabel
            // 
            this.armAxisDistanceLabel.AutoSize = true;
            this.armAxisDistanceLabel.Location = new System.Drawing.Point(660, 49);
            this.armAxisDistanceLabel.Name = "armAxisDistanceLabel";
            this.armAxisDistanceLabel.Size = new System.Drawing.Size(105, 20);
            this.armAxisDistanceLabel.TabIndex = 14;
            this.armAxisDistanceLabel.Text = "Arm-Axis dist.";
            // 
            // chArmAxisDistanceTemplate
            // 
            this.chArmAxisDistanceTemplate.Location = new System.Drawing.Point(664, 80);
            this.chArmAxisDistanceTemplate.Name = "chArmAxisDistanceTemplate";
            this.chArmAxisDistanceTemplate.Size = new System.Drawing.Size(100, 26);
            this.chArmAxisDistanceTemplate.TabIndex = 13;
            this.chArmAxisDistanceTemplate.Visible = false;
            // 
            // chIsTempTemplate
            // 
            this.chIsTempTemplate.AutoSize = true;
            this.chIsTempTemplate.Location = new System.Drawing.Point(22, 85);
            this.chIsTempTemplate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chIsTempTemplate.Name = "chIsTempTemplate";
            this.chIsTempTemplate.Size = new System.Drawing.Size(22, 21);
            this.chIsTempTemplate.TabIndex = 15;
            this.chIsTempTemplate.UseVisualStyleBackColor = true;
            this.chIsTempTemplate.Visible = false;
            // 
            // isTempLabel
            // 
            this.isTempLabel.AutoSize = true;
            this.isTempLabel.Location = new System.Drawing.Point(18, 49);
            this.isTempLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.isTempLabel.Name = "isTempLabel";
            this.isTempLabel.Size = new System.Drawing.Size(25, 20);
            this.isTempLabel.TabIndex = 16;
            this.isTempLabel.Text = "°C";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.channels";
            this.openFileDialog.Filter = "Channel config files|*.channels";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.channels";
            this.saveFileDialog.Filter = "Channel config files|*.channels";
            // 
            // ChannelConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(946, 129);
            this.Controls.Add(this.isTempLabel);
            this.Controls.Add(this.chIsTempTemplate);
            this.Controls.Add(this.armAxisDistanceLabel);
            this.Controls.Add(this.chArmAxisDistanceTemplate);
            this.Controls.Add(this.arm2LengthLabel);
            this.Controls.Add(this.chArm2LengthTemplate);
            this.Controls.Add(this.arm1LengthLabel);
            this.Controls.Add(this.chArm1LengthTemplate);
            this.Controls.Add(this.resetBtnTemplate);
            this.Controls.Add(this.applyBtnTemplate);
            this.Controls.Add(this.scalingLabel);
            this.Controls.Add(this.zeroLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.chScalingTemplate);
            this.Controls.Add(this.chZeroTemplate);
            this.Controls.Add(this.chNameTemplate);
            this.Controls.Add(this.ChannelConfigMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.ChannelConfigMenu;
            this.Name = "ChannelConfigForm";
            this.Text = "ChannelConfigForm";
            this.ChannelConfigMenu.ResumeLayout(false);
            this.ChannelConfigMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox chNameTemplate;
        private System.Windows.Forms.TextBox chZeroTemplate;
        private System.Windows.Forms.TextBox chScalingTemplate;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label zeroLabel;
        private System.Windows.Forms.Label scalingLabel;
        private System.Windows.Forms.Button applyBtnTemplate;
        private System.Windows.Forms.Button resetBtnTemplate;
        private System.Windows.Forms.TextBox chArm1LengthTemplate;
        private System.Windows.Forms.Label arm1LengthLabel;
        private System.Windows.Forms.Label arm2LengthLabel;
        private System.Windows.Forms.TextBox chArm2LengthTemplate;
        private System.Windows.Forms.MenuStrip ChannelConfigMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label armAxisDistanceLabel;
        private System.Windows.Forms.TextBox chArmAxisDistanceTemplate;
        private System.Windows.Forms.CheckBox chIsTempTemplate;
        private System.Windows.Forms.Label isTempLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}