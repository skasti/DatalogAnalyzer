namespace OpenLogAnalyzer.Analyses
{
    partial class AnalysisRenderer
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ToStringLabel = new System.Windows.Forms.Label();
            this.AnalysisChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.AnalysisChart)).BeginInit();
            this.SuspendLayout();
            // 
            // ToStringLabel
            // 
            this.ToStringLabel.AutoSize = true;
            this.ToStringLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToStringLabel.Location = new System.Drawing.Point(3, 10);
            this.ToStringLabel.Name = "ToStringLabel";
            this.ToStringLabel.Size = new System.Drawing.Size(171, 29);
            this.ToStringLabel.TabIndex = 0;
            this.ToStringLabel.Text = "Some Analysis";
            // 
            // AnalysisChart
            // 
            this.AnalysisChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisY.ScaleView.Zoomable = false;
            chartArea1.AxisY2.ScaleView.Zoomable = false;
            chartArea1.CursorX.Interval = 0.01D;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorY.Interval = 0.01D;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.CursorY.LineColor = System.Drawing.Color.RoyalBlue;
            chartArea1.CursorY.SelectionColor = System.Drawing.Color.LightGreen;
            chartArea1.Name = "ChartArea1";
            this.AnalysisChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.AnalysisChart.Legends.Add(legend1);
            this.AnalysisChart.Location = new System.Drawing.Point(0, 42);
            this.AnalysisChart.Name = "AnalysisChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.AnalysisChart.Series.Add(series1);
            this.AnalysisChart.Size = new System.Drawing.Size(597, 555);
            this.AnalysisChart.TabIndex = 6;
            this.AnalysisChart.Text = "chart1";
            // 
            // AnalysisRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.AnalysisChart);
            this.Controls.Add(this.ToStringLabel);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "AnalysisRenderer";
            this.Size = new System.Drawing.Size(600, 600);
            ((System.ComponentModel.ISupportInitialize)(this.AnalysisChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ToStringLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart AnalysisChart;
    }
}
