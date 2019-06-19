namespace SalajansBoyaMusteri.PanelForms
{
    partial class OdemeTakip
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.TutarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblbuguntutar = new System.Windows.Forms.Label();
            this.lbldun = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.AracChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.TutarChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AracChart)).BeginInit();
            this.SuspendLayout();
            // 
            // TutarChart
            // 
            this.TutarChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.TutarChart.BorderSkin.BackColor = System.Drawing.Color.Lavender;
            chartArea1.Name = "ChartArea1";
            this.TutarChart.ChartAreas.Add(chartArea1);
            legend1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            legend1.BorderWidth = 0;
            legend1.HeaderSeparatorColor = System.Drawing.Color.Maroon;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.LightSalmon;
            legend1.Name = "Legend1";
            this.TutarChart.Legends.Add(legend1);
            this.TutarChart.Location = new System.Drawing.Point(12, 12);
            this.TutarChart.Name = "TutarChart";
            series1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.BorderWidth = 0;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.CustomProperties = "DrawingStyle=Wedge";
            series1.EmptyPointStyle.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.EmptyPointStyle.BorderWidth = 0;
            series1.EmptyPointStyle.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.EmptyPointStyle.LabelBorderWidth = 0;
            series1.Legend = "Legend1";
            series1.Name = "Tutar";
            this.TutarChart.Series.Add(series1);
            this.TutarChart.Size = new System.Drawing.Size(638, 468);
            this.TutarChart.TabIndex = 0;
            this.TutarChart.Text = "chart1";
            title1.Font = new System.Drawing.Font("Calibri", 12F);
            title1.Name = "Title1";
            title1.Text = "Haftalık Ödeme Grafiği";
            this.TutarChart.Titles.Add(title1);
            // 
            // lblbuguntutar
            // 
            this.lblbuguntutar.AutoSize = true;
            this.lblbuguntutar.Location = new System.Drawing.Point(447, 477);
            this.lblbuguntutar.Name = "lblbuguntutar";
            this.lblbuguntutar.Size = new System.Drawing.Size(68, 13);
            this.lblbuguntutar.TabIndex = 1;
            this.lblbuguntutar.Text = "lblbuguntutar";
            // 
            // lbldun
            // 
            this.lbldun.AutoSize = true;
            this.lbldun.Location = new System.Drawing.Point(393, 477);
            this.lbldun.Name = "lbldun";
            this.lbldun.Size = new System.Drawing.Size(35, 13);
            this.lbldun.TabIndex = 2;
            this.lbldun.Text = "lbldun";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(339, 477);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(23, 13);
            this.lbl5.TabIndex = 3;
            this.lbl5.Text = "lbl5";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(285, 477);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(23, 13);
            this.lbl4.TabIndex = 4;
            this.lbl4.Text = "lbl4";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(230, 477);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(23, 13);
            this.lbl3.TabIndex = 5;
            this.lbl3.Text = "lbl3";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(170, 477);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(23, 13);
            this.lbl2.TabIndex = 6;
            this.lbl2.Text = "lbl2";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(115, 477);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(23, 13);
            this.lbl1.TabIndex = 7;
            this.lbl1.Text = "lbl1";
            // 
            // AracChart
            // 
            this.AracChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.AracChart.BorderSkin.BackColor = System.Drawing.Color.Lavender;
            chartArea2.Name = "ChartArea1";
            this.AracChart.ChartAreas.Add(chartArea2);
            legend2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            legend2.BorderWidth = 0;
            legend2.HeaderSeparatorColor = System.Drawing.Color.Maroon;
            legend2.ItemColumnSeparatorColor = System.Drawing.Color.LightSalmon;
            legend2.Name = "Legend1";
            this.AracChart.Legends.Add(legend2);
            this.AracChart.Location = new System.Drawing.Point(671, 12);
            this.AracChart.Name = "AracChart";
            this.AracChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.AracChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Orange,
        System.Drawing.Color.DarkCyan,
        System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(92)))), ((int)(((byte)(169))))),
        System.Drawing.Color.LightSkyBlue,
        System.Drawing.Color.Gray,
        System.Drawing.Color.DarkOrchid};
            series2.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
            series2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.BorderWidth = 0;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.CustomProperties = "DrawingStyle=Wedge";
            series2.EmptyPointStyle.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.EmptyPointStyle.BorderWidth = 0;
            series2.EmptyPointStyle.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.EmptyPointStyle.LabelBorderWidth = 0;
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.Name = "Arac";
            series2.YValuesPerPoint = 6;
            this.AracChart.Series.Add(series2);
            this.AracChart.Size = new System.Drawing.Size(638, 468);
            this.AracChart.TabIndex = 8;
            this.AracChart.Text = "chart1";
            title2.Font = new System.Drawing.Font("Calibri", 12F);
            title2.Name = "Title1";
            title2.Text = "Haftalık Araç Grafiği";
            this.AracChart.Titles.Add(title2);
            // 
            // OdemeTakip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1348, 579);
            this.Controls.Add(this.AracChart);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbldun);
            this.Controls.Add(this.lblbuguntutar);
            this.Controls.Add(this.TutarChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OdemeTakip";
            this.Text = "OdemeList";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OdemeTakip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TutarChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AracChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart TutarChart;
        private System.Windows.Forms.Label lblbuguntutar;
        private System.Windows.Forms.Label lbldun;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.DataVisualization.Charting.Chart AracChart;
    }
}