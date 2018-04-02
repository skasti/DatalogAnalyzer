namespace OpenLogAnalyzer
{
    partial class InputPage
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.inputTabs = new System.Windows.Forms.TabControl();
            this.plainDataPage = new System.Windows.Forms.TabPage();
            this.RawChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.inputTabs.SuspendLayout();
            this.plainDataPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RawChart)).BeginInit();
            this.SuspendLayout();
            // 
            // inputTabs
            // 
            this.inputTabs.Controls.Add(this.plainDataPage);
            this.inputTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTabs.Location = new System.Drawing.Point(0, 0);
            this.inputTabs.Name = "inputTabs";
            this.inputTabs.SelectedIndex = 0;
            this.inputTabs.Size = new System.Drawing.Size(1278, 663);
            this.inputTabs.TabIndex = 0;
            // 
            // plainDataPage
            // 
            this.plainDataPage.Controls.Add(this.RawChart);
            this.plainDataPage.Location = new System.Drawing.Point(4, 29);
            this.plainDataPage.Name = "plainDataPage";
            this.plainDataPage.Padding = new System.Windows.Forms.Padding(3);
            this.plainDataPage.Size = new System.Drawing.Size(1270, 630);
            this.plainDataPage.TabIndex = 0;
            this.plainDataPage.Text = "Input";
            this.plainDataPage.UseVisualStyleBackColor = true;
            // 
            // RawChart
            // 
            chartArea1.AxisX.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.ScaleView.Zoomable = false;
            chartArea1.AxisY2.ScaleView.Zoomable = false;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.CursorX.Interval = 0.01D;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorY.Interval = 0.01D;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.CursorY.LineColor = System.Drawing.Color.RoyalBlue;
            chartArea1.CursorY.SelectionColor = System.Drawing.Color.LightGreen;
            chartArea1.Name = "ChartArea1";
            this.RawChart.ChartAreas.Add(chartArea1);
            this.RawChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.RawChart.Legends.Add(legend1);
            this.RawChart.Location = new System.Drawing.Point(3, 3);
            this.RawChart.Name = "RawChart";
            this.RawChart.Size = new System.Drawing.Size(1264, 624);
            this.RawChart.TabIndex = 6;
            this.RawChart.Text = "chart1";
            // 
            // InputPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inputTabs);
            this.Name = "InputPage";
            this.Size = new System.Drawing.Size(1278, 663);
            this.inputTabs.ResumeLayout(false);
            this.plainDataPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RawChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl inputTabs;
        private System.Windows.Forms.TabPage plainDataPage;
        private System.Windows.Forms.DataVisualization.Charting.Chart RawChart;
    }
}
