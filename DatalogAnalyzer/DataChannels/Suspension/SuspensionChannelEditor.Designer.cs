namespace DatalogAnalyzer.DataChannels.Suspension
{
    partial class SuspensionChannelEditor
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
            this.armAxisInput = new System.Windows.Forms.TextBox();
            this.armAxisLabel = new System.Windows.Forms.Label();
            this.arm2Input = new System.Windows.Forms.TextBox();
            this.arm2Label = new System.Windows.Forms.Label();
            this.arm1Input = new System.Windows.Forms.TextBox();
            this.arm1Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(626, 151);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(545, 149);
            // 
            // armAxisInput
            // 
            this.armAxisInput.Location = new System.Drawing.Point(316, 156);
            this.armAxisInput.Name = "armAxisInput";
            this.armAxisInput.Size = new System.Drawing.Size(120, 26);
            this.armAxisInput.TabIndex = 27;
            // 
            // armAxisLabel
            // 
            this.armAxisLabel.AutoSize = true;
            this.armAxisLabel.Location = new System.Drawing.Point(312, 133);
            this.armAxisLabel.Name = "armAxisLabel";
            this.armAxisLabel.Size = new System.Drawing.Size(87, 20);
            this.armAxisLabel.TabIndex = 26;
            this.armAxisLabel.Text = "Arm to axis";
            // 
            // arm2Input
            // 
            this.arm2Input.Location = new System.Drawing.Point(166, 156);
            this.arm2Input.Name = "arm2Input";
            this.arm2Input.Size = new System.Drawing.Size(120, 26);
            this.arm2Input.TabIndex = 25;
            // 
            // arm2Label
            // 
            this.arm2Label.AutoSize = true;
            this.arm2Label.Location = new System.Drawing.Point(162, 133);
            this.arm2Label.Name = "arm2Label";
            this.arm2Label.Size = new System.Drawing.Size(51, 20);
            this.arm2Label.TabIndex = 24;
            this.arm2Label.Text = "Arm 2";
            // 
            // arm1Input
            // 
            this.arm1Input.Location = new System.Drawing.Point(16, 156);
            this.arm1Input.Name = "arm1Input";
            this.arm1Input.Size = new System.Drawing.Size(120, 26);
            this.arm1Input.TabIndex = 23;
            // 
            // arm1Label
            // 
            this.arm1Label.AutoSize = true;
            this.arm1Label.Location = new System.Drawing.Point(12, 133);
            this.arm1Label.Name = "arm1Label";
            this.arm1Label.Size = new System.Drawing.Size(51, 20);
            this.arm1Label.TabIndex = 22;
            this.arm1Label.Text = "Arm 1";
            // 
            // SuspensionChannelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 196);
            this.Controls.Add(this.armAxisInput);
            this.Controls.Add(this.armAxisLabel);
            this.Controls.Add(this.arm2Input);
            this.Controls.Add(this.arm2Label);
            this.Controls.Add(this.arm1Input);
            this.Controls.Add(this.arm1Label);
            this.Name = "SuspensionChannelEditor";
            this.Text = "SuspensionChannelEditor";
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.resetButton, 0);
            this.Controls.SetChildIndex(this.arm1Label, 0);
            this.Controls.SetChildIndex(this.arm1Input, 0);
            this.Controls.SetChildIndex(this.arm2Label, 0);
            this.Controls.SetChildIndex(this.arm2Input, 0);
            this.Controls.SetChildIndex(this.armAxisLabel, 0);
            this.Controls.SetChildIndex(this.armAxisInput, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox armAxisInput;
        private System.Windows.Forms.Label armAxisLabel;
        private System.Windows.Forms.TextBox arm2Input;
        private System.Windows.Forms.Label arm2Label;
        private System.Windows.Forms.TextBox arm1Input;
        private System.Windows.Forms.Label arm1Label;
    }
}