﻿namespace OpenLogAnalyzer
{
    partial class ConfigForm
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
            this.StartNumberLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.StartNumberInput = new System.Windows.Forms.TextBox();
            this.NameInput = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.BikeNameLabel = new System.Windows.Forms.Label();
            this.BikeNameInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StartNumberLabel
            // 
            this.StartNumberLabel.AutoSize = true;
            this.StartNumberLabel.Location = new System.Drawing.Point(12, 9);
            this.StartNumberLabel.Name = "StartNumberLabel";
            this.StartNumberLabel.Size = new System.Drawing.Size(57, 20);
            this.StartNumberLabel.TabIndex = 0;
            this.StartNumberLabel.Text = "Start #";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(85, 9);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(51, 20);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name";
            // 
            // StartNumberInput
            // 
            this.StartNumberInput.Location = new System.Drawing.Point(12, 32);
            this.StartNumberInput.Name = "StartNumberInput";
            this.StartNumberInput.Size = new System.Drawing.Size(67, 26);
            this.StartNumberInput.TabIndex = 2;
            // 
            // NameInput
            // 
            this.NameInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameInput.Location = new System.Drawing.Point(85, 32);
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(232, 26);
            this.NameInput.TabIndex = 3;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveButton.Location = new System.Drawing.Point(12, 141);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(67, 35);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(236, 142);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(84, 35);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BikeNameLabel
            // 
            this.BikeNameLabel.AutoSize = true;
            this.BikeNameLabel.Location = new System.Drawing.Point(12, 70);
            this.BikeNameLabel.Name = "BikeNameLabel";
            this.BikeNameLabel.Size = new System.Drawing.Size(84, 20);
            this.BikeNameLabel.TabIndex = 6;
            this.BikeNameLabel.Text = "Bike name";
            // 
            // BikeNameInput
            // 
            this.BikeNameInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BikeNameInput.Location = new System.Drawing.Point(12, 93);
            this.BikeNameInput.Name = "BikeNameInput";
            this.BikeNameInput.Size = new System.Drawing.Size(305, 26);
            this.BikeNameInput.TabIndex = 7;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 184);
            this.Controls.Add(this.BikeNameInput);
            this.Controls.Add(this.BikeNameLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.NameInput);
            this.Controls.Add(this.StartNumberInput);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.StartNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StartNumberLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox StartNumberInput;
        private System.Windows.Forms.TextBox NameInput;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label BikeNameLabel;
        private System.Windows.Forms.TextBox BikeNameInput;
    }
}