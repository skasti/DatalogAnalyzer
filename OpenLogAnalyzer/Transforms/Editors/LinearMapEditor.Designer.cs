namespace OpenLogAnalyzer.Transforms.Editors
{
    partial class LinearMapEditor
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
            this.FromMinInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FromMaxInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ToMinInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ToMaxInput = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FromMinInput
            // 
            this.FromMinInput.Location = new System.Drawing.Point(22, 38);
            this.FromMinInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FromMinInput.Name = "FromMinInput";
            this.FromMinInput.Size = new System.Drawing.Size(148, 26);
            this.FromMinInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "From min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "From max";
            // 
            // FromMaxInput
            // 
            this.FromMaxInput.Location = new System.Drawing.Point(186, 38);
            this.FromMaxInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FromMaxInput.Name = "FromMaxInput";
            this.FromMaxInput.Size = new System.Drawing.Size(148, 26);
            this.FromMaxInput.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "To min";
            // 
            // ToMinInput
            // 
            this.ToMinInput.Location = new System.Drawing.Point(22, 114);
            this.ToMinInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ToMinInput.Name = "ToMinInput";
            this.ToMinInput.Size = new System.Drawing.Size(148, 26);
            this.ToMinInput.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 89);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "To max";
            // 
            // ToMaxInput
            // 
            this.ToMaxInput.Location = new System.Drawing.Point(186, 114);
            this.ToMaxInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ToMaxInput.Name = "ToMaxInput";
            this.ToMaxInput.Size = new System.Drawing.Size(148, 26);
            this.ToMaxInput.TabIndex = 6;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(22, 169);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(112, 46);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(224, 169);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(112, 46);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // LinearMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 234);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ToMaxInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ToMinInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FromMaxInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FromMinInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LinearMapEditor";
            this.Text = "LinearMapEditor";
            this.Load += new System.EventHandler(this.LinearMapEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FromMinInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FromMaxInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ToMinInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ToMaxInput;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
    }
}