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
            this.chArmLengthTemplate = new System.Windows.Forms.TextBox();
            this.armLengthLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chNameTemplate
            // 
            this.chNameTemplate.Location = new System.Drawing.Point(12, 40);
            this.chNameTemplate.Name = "chNameTemplate";
            this.chNameTemplate.Size = new System.Drawing.Size(178, 26);
            this.chNameTemplate.TabIndex = 0;
            this.chNameTemplate.Text = "Channel 1";
            this.chNameTemplate.Visible = false;
            // 
            // chZeroTemplate
            // 
            this.chZeroTemplate.Location = new System.Drawing.Point(196, 40);
            this.chZeroTemplate.Name = "chZeroTemplate";
            this.chZeroTemplate.Size = new System.Drawing.Size(100, 26);
            this.chZeroTemplate.TabIndex = 1;
            this.chZeroTemplate.Visible = false;
            // 
            // chScalingTemplate
            // 
            this.chScalingTemplate.Location = new System.Drawing.Point(302, 40);
            this.chScalingTemplate.Name = "chScalingTemplate";
            this.chScalingTemplate.Size = new System.Drawing.Size(100, 26);
            this.chScalingTemplate.TabIndex = 2;
            this.chScalingTemplate.Visible = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(8, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(114, 20);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Channel Name";
            // 
            // zeroLabel
            // 
            this.zeroLabel.AutoSize = true;
            this.zeroLabel.Location = new System.Drawing.Point(192, 9);
            this.zeroLabel.Name = "zeroLabel";
            this.zeroLabel.Size = new System.Drawing.Size(82, 20);
            this.zeroLabel.TabIndex = 4;
            this.zeroLabel.Text = "Zero Point";
            // 
            // scalingLabel
            // 
            this.scalingLabel.AutoSize = true;
            this.scalingLabel.Location = new System.Drawing.Point(298, 9);
            this.scalingLabel.Name = "scalingLabel";
            this.scalingLabel.Size = new System.Drawing.Size(61, 20);
            this.scalingLabel.TabIndex = 5;
            this.scalingLabel.Text = "Scaling";
            // 
            // applyBtnTemplate
            // 
            this.applyBtnTemplate.Location = new System.Drawing.Point(514, 32);
            this.applyBtnTemplate.Name = "applyBtnTemplate";
            this.applyBtnTemplate.Size = new System.Drawing.Size(75, 42);
            this.applyBtnTemplate.TabIndex = 6;
            this.applyBtnTemplate.Text = "Apply";
            this.applyBtnTemplate.UseVisualStyleBackColor = true;
            this.applyBtnTemplate.Visible = false;
            // 
            // resetBtnTemplate
            // 
            this.resetBtnTemplate.Location = new System.Drawing.Point(595, 32);
            this.resetBtnTemplate.Name = "resetBtnTemplate";
            this.resetBtnTemplate.Size = new System.Drawing.Size(75, 42);
            this.resetBtnTemplate.TabIndex = 7;
            this.resetBtnTemplate.Text = "Reset";
            this.resetBtnTemplate.UseVisualStyleBackColor = true;
            this.resetBtnTemplate.Visible = false;
            // 
            // chArmLengthTemplate
            // 
            this.chArmLengthTemplate.Location = new System.Drawing.Point(408, 40);
            this.chArmLengthTemplate.Name = "chArmLengthTemplate";
            this.chArmLengthTemplate.Size = new System.Drawing.Size(100, 26);
            this.chArmLengthTemplate.TabIndex = 8;
            this.chArmLengthTemplate.Visible = false;
            // 
            // armLengthLabel
            // 
            this.armLengthLabel.AutoSize = true;
            this.armLengthLabel.Location = new System.Drawing.Point(404, 9);
            this.armLengthLabel.Name = "armLengthLabel";
            this.armLengthLabel.Size = new System.Drawing.Size(92, 20);
            this.armLengthLabel.TabIndex = 9;
            this.armLengthLabel.Text = "Arm Length";
            // 
            // ChannelConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(682, 90);
            this.Controls.Add(this.armLengthLabel);
            this.Controls.Add(this.chArmLengthTemplate);
            this.Controls.Add(this.resetBtnTemplate);
            this.Controls.Add(this.applyBtnTemplate);
            this.Controls.Add(this.scalingLabel);
            this.Controls.Add(this.zeroLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.chScalingTemplate);
            this.Controls.Add(this.chZeroTemplate);
            this.Controls.Add(this.chNameTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChannelConfigForm";
            this.Text = "ChannelConfigForm";
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
        private System.Windows.Forms.TextBox chArmLengthTemplate;
        private System.Windows.Forms.Label armLengthLabel;
    }
}