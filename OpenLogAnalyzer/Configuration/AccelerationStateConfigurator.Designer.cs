namespace OpenLogAnalyzer.Configuration
{
    partial class AccelerationStateConfigurator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lineOpacityInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lineWidthInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.thresholdInput = new System.Windows.Forms.TextBox();
            this.colorPickerButton = new System.Windows.Forms.Button();
            this.ColorPicker = new System.Windows.Forms.ColorDialog();
            this.resetButton = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.resetButton);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.lineOpacityInput);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.lineWidthInput);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.thresholdInput);
            this.groupBox.Controls.Add(this.colorPickerButton);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(550, 100);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = " DISPLAYNAME ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Opacity";
            // 
            // lineOpacityInput
            // 
            this.lineOpacityInput.Location = new System.Drawing.Point(281, 62);
            this.lineOpacityInput.Name = "lineOpacityInput";
            this.lineOpacityInput.Size = new System.Drawing.Size(119, 26);
            this.lineOpacityInput.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Line Width";
            // 
            // lineWidthInput
            // 
            this.lineWidthInput.Location = new System.Drawing.Point(152, 62);
            this.lineWidthInput.Name = "lineWidthInput";
            this.lineWidthInput.Size = new System.Drawing.Size(119, 26);
            this.lineWidthInput.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Threshold (m/s²)";
            // 
            // thresholdInput
            // 
            this.thresholdInput.Location = new System.Drawing.Point(23, 62);
            this.thresholdInput.Name = "thresholdInput";
            this.thresholdInput.Size = new System.Drawing.Size(119, 26);
            this.thresholdInput.TabIndex = 2;
            // 
            // colorPickerButton
            // 
            this.colorPickerButton.Location = new System.Drawing.Point(406, 56);
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.Size = new System.Drawing.Size(67, 38);
            this.colorPickerButton.TabIndex = 0;
            this.colorPickerButton.Text = "Color";
            this.colorPickerButton.UseVisualStyleBackColor = true;
            this.colorPickerButton.Click += new System.EventHandler(this.colorPickerButton_Click);
            // 
            // ColorPicker
            // 
            this.ColorPicker.SolidColorOnly = true;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(477, 56);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(67, 38);
            this.resetButton.TabIndex = 8;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // AccelerationStateConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.MaximumSize = new System.Drawing.Size(5000, 100);
            this.MinimumSize = new System.Drawing.Size(490, 100);
            this.Name = "AccelerationStateConfigurator";
            this.Size = new System.Drawing.Size(550, 100);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ColorDialog ColorPicker;
        private System.Windows.Forms.Button colorPickerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox thresholdInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lineOpacityInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lineWidthInput;
        private System.Windows.Forms.Button resetButton;
    }
}
