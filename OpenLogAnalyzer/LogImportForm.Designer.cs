namespace OpenLogAnalyzer
{
    partial class LogImportForm
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
            this.DebugTextBox = new System.Windows.Forms.RichTextBox();
            this.AbortButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FinishedButton = new System.Windows.Forms.Button();
            this.AutoCloseCheckbox = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DebugTextBox
            // 
            this.DebugTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DebugTextBox.Location = new System.Drawing.Point(12, 44);
            this.DebugTextBox.Name = "DebugTextBox";
            this.DebugTextBox.Size = new System.Drawing.Size(554, 255);
            this.DebugTextBox.TabIndex = 0;
            this.DebugTextBox.Text = "";
            // 
            // AbortButton
            // 
            this.AbortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AbortButton.Location = new System.Drawing.Point(491, 305);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(75, 35);
            this.AbortButton.TabIndex = 1;
            this.AbortButton.Text = "Abort";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(12, 15);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(554, 23);
            this.ProgressBar.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 354);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(578, 30);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(103, 25);
            this.StatusLabel.Text = "Initializing...";
            // 
            // FinishedButton
            // 
            this.FinishedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FinishedButton.Location = new System.Drawing.Point(482, 305);
            this.FinishedButton.Name = "FinishedButton";
            this.FinishedButton.Size = new System.Drawing.Size(84, 35);
            this.FinishedButton.TabIndex = 4;
            this.FinishedButton.Text = "Finished";
            this.FinishedButton.UseVisualStyleBackColor = true;
            this.FinishedButton.Visible = false;
            this.FinishedButton.Click += new System.EventHandler(this.FinishedButton_Click);
            // 
            // AutoCloseCheckbox
            // 
            this.AutoCloseCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AutoCloseCheckbox.AutoSize = true;
            this.AutoCloseCheckbox.Location = new System.Drawing.Point(12, 311);
            this.AutoCloseCheckbox.Name = "AutoCloseCheckbox";
            this.AutoCloseCheckbox.Size = new System.Drawing.Size(176, 24);
            this.AutoCloseCheckbox.TabIndex = 5;
            this.AutoCloseCheckbox.Text = "Close when finished";
            this.AutoCloseCheckbox.UseVisualStyleBackColor = true;
            // 
            // LogImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 384);
            this.Controls.Add(this.AutoCloseCheckbox);
            this.Controls.Add(this.FinishedButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.DebugTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 270);
            this.Name = "LogImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import from sd-card";
            this.Load += new System.EventHandler(this.LogImportForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox DebugTextBox;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Button FinishedButton;
        private System.Windows.Forms.CheckBox AutoCloseCheckbox;
    }
}