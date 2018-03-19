namespace OpenLogAnalyzer.Transforms
{
    partial class AngleBasedForkPositionEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AngleBasedForkPositionEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.arm1LengthInput = new System.Windows.Forms.TextBox();
            this.arm2LengthInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.legToSensorInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bottomOutToSensorInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.upperLegOffsetInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.visualizationBox = new System.Windows.Forms.PictureBox();
            this.visualizationPositionInput = new System.Windows.Forms.TrackBar();
            this.forkPositionLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.visualizationBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizationPositionInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arm1 Length (mm)";
            // 
            // arm1LengthInput
            // 
            this.arm1LengthInput.Location = new System.Drawing.Point(16, 32);
            this.arm1LengthInput.Name = "arm1LengthInput";
            this.arm1LengthInput.Size = new System.Drawing.Size(198, 26);
            this.arm1LengthInput.TabIndex = 1;
            this.arm1LengthInput.TextChanged += new System.EventHandler(this.arm1LengthInput_TextChanged);
            // 
            // arm2LengthInput
            // 
            this.arm2LengthInput.Location = new System.Drawing.Point(16, 94);
            this.arm2LengthInput.Name = "arm2LengthInput";
            this.arm2LengthInput.Size = new System.Drawing.Size(198, 26);
            this.arm2LengthInput.TabIndex = 3;
            this.arm2LengthInput.TextChanged += new System.EventHandler(this.arm2LengthInput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Arm2 Length (mm)";
            // 
            // legToSensorInput
            // 
            this.legToSensorInput.Location = new System.Drawing.Point(16, 156);
            this.legToSensorInput.Name = "legToSensorInput";
            this.legToSensorInput.Size = new System.Drawing.Size(198, 26);
            this.legToSensorInput.TabIndex = 5;
            this.legToSensorInput.TextChanged += new System.EventHandler(this.legToSensorInput_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Leg to Sensor (mm)";
            // 
            // bottomOutToSensorInput
            // 
            this.bottomOutToSensorInput.Location = new System.Drawing.Point(16, 218);
            this.bottomOutToSensorInput.Name = "bottomOutToSensorInput";
            this.bottomOutToSensorInput.Size = new System.Drawing.Size(198, 26);
            this.bottomOutToSensorInput.TabIndex = 7;
            this.bottomOutToSensorInput.TextChanged += new System.EventHandler(this.bottomOutToSensorInput_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Bottom-out to Sensor (mm)";
            // 
            // upperLegOffsetInput
            // 
            this.upperLegOffsetInput.Location = new System.Drawing.Point(16, 280);
            this.upperLegOffsetInput.Name = "upperLegOffsetInput";
            this.upperLegOffsetInput.Size = new System.Drawing.Size(198, 26);
            this.upperLegOffsetInput.TabIndex = 9;
            this.upperLegOffsetInput.TextChanged += new System.EventHandler(this.upperLegOffsetInput_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Upper leg offset (mm)";
            // 
            // visualizationBox
            // 
            this.visualizationBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visualizationBox.Image = ((System.Drawing.Image)(resources.GetObject("visualizationBox.Image")));
            this.visualizationBox.Location = new System.Drawing.Point(231, 12);
            this.visualizationBox.Name = "visualizationBox";
            this.visualizationBox.Size = new System.Drawing.Size(337, 452);
            this.visualizationBox.TabIndex = 10;
            this.visualizationBox.TabStop = false;
            // 
            // visualizationPositionInput
            // 
            this.visualizationPositionInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visualizationPositionInput.Location = new System.Drawing.Point(12, 464);
            this.visualizationPositionInput.Maximum = 90;
            this.visualizationPositionInput.Minimum = -90;
            this.visualizationPositionInput.Name = "visualizationPositionInput";
            this.visualizationPositionInput.Size = new System.Drawing.Size(556, 69);
            this.visualizationPositionInput.TabIndex = 11;
            this.visualizationPositionInput.Scroll += new System.EventHandler(this.visualizationPositionInput_Scroll);
            // 
            // forkPositionLabel
            // 
            this.forkPositionLabel.AutoSize = true;
            this.forkPositionLabel.Location = new System.Drawing.Point(12, 441);
            this.forkPositionLabel.Name = "forkPositionLabel";
            this.forkPositionLabel.Size = new System.Drawing.Size(88, 20);
            this.forkPositionLabel.TabIndex = 12;
            this.forkPositionLabel.Text = "120.00 mm";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(16, 370);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(198, 46);
            this.CancelButton.TabIndex = 14;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(16, 314);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(198, 46);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AngleBasedForkPositionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 530);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.forkPositionLabel);
            this.Controls.Add(this.visualizationPositionInput);
            this.Controls.Add(this.visualizationBox);
            this.Controls.Add(this.upperLegOffsetInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bottomOutToSensorInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.legToSensorInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.arm2LengthInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.arm1LengthInput);
            this.Controls.Add(this.label1);
            this.Name = "AngleBasedForkPositionEditor";
            this.Text = "AngleBasedForkPositionEditor";
            this.Load += new System.EventHandler(this.AngleBasedForkPositionEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.visualizationBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizationPositionInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox arm1LengthInput;
        private System.Windows.Forms.TextBox arm2LengthInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox legToSensorInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bottomOutToSensorInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox upperLegOffsetInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox visualizationBox;
        private System.Windows.Forms.TrackBar visualizationPositionInput;
        private System.Windows.Forms.Label forkPositionLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
    }
}