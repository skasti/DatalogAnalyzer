namespace OpenLogAnalyzer
{
    partial class AzureB2CDIalog
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
            this.loginButton = new System.Windows.Forms.Button();
            this.TokenInfoText = new System.Windows.Forms.RichTextBox();
            this.ResultText = new System.Windows.Forms.RichTextBox();
            this.testButton = new System.Windows.Forms.Button();
            this.secretId = new System.Windows.Forms.TextBox();
            this.test2Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(12, 12);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 30);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // TokenInfoText
            // 
            this.TokenInfoText.Location = new System.Drawing.Point(12, 48);
            this.TokenInfoText.Name = "TokenInfoText";
            this.TokenInfoText.Size = new System.Drawing.Size(776, 293);
            this.TokenInfoText.TabIndex = 1;
            this.TokenInfoText.Text = "";
            // 
            // ResultText
            // 
            this.ResultText.Location = new System.Drawing.Point(12, 347);
            this.ResultText.Name = "ResultText";
            this.ResultText.Size = new System.Drawing.Size(776, 293);
            this.ResultText.TabIndex = 2;
            this.ResultText.Text = "";
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(93, 12);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 30);
            this.testButton.TabIndex = 3;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // secretId
            // 
            this.secretId.Location = new System.Drawing.Point(174, 18);
            this.secretId.Name = "secretId";
            this.secretId.Size = new System.Drawing.Size(100, 20);
            this.secretId.TabIndex = 4;
            // 
            // test2Button
            // 
            this.test2Button.Location = new System.Drawing.Point(280, 12);
            this.test2Button.Name = "test2Button";
            this.test2Button.Size = new System.Drawing.Size(75, 30);
            this.test2Button.TabIndex = 5;
            this.test2Button.Text = "Test Secret";
            this.test2Button.UseVisualStyleBackColor = true;
            this.test2Button.Click += new System.EventHandler(this.test2Button_Click);
            // 
            // AzureB2CDIalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 743);
            this.Controls.Add(this.test2Button);
            this.Controls.Add(this.secretId);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.ResultText);
            this.Controls.Add(this.TokenInfoText);
            this.Controls.Add(this.loginButton);
            this.Name = "AzureB2CDIalog";
            this.Text = "AzureB2CDIalog";
            this.Load += new System.EventHandler(this.AzureB2CDIalog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.RichTextBox TokenInfoText;
        private System.Windows.Forms.RichTextBox ResultText;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.TextBox secretId;
        private System.Windows.Forms.Button test2Button;
    }
}