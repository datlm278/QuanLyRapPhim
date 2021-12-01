
namespace QuanLyRapChieuPhim.UI
{
    partial class FormLineChart
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
            this.dtgvRevenueOfYear = new System.Windows.Forms.DataGridView();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grbRevenue = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbYear = new System.Windows.Forms.TextBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvRevenueOfYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.grbRevenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvRevenueOfYear
            // 
            this.dtgvRevenueOfYear.AllowUserToAddRows = false;
            this.dtgvRevenueOfYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvRevenueOfYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvRevenueOfYear.Location = new System.Drawing.Point(7, 27);
            this.dtgvRevenueOfYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtgvRevenueOfYear.Name = "dtgvRevenueOfYear";
            this.dtgvRevenueOfYear.Size = new System.Drawing.Size(669, 156);
            this.dtgvRevenueOfYear.TabIndex = 0;
            // 
            // chartRevenue
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend1);
            this.chartRevenue.Location = new System.Drawing.Point(13, 14);
            this.chartRevenue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartRevenue.Name = "chartRevenue";
            this.chartRevenue.Size = new System.Drawing.Size(683, 272);
            this.chartRevenue.TabIndex = 1;
            this.chartRevenue.Text = "chart1";
            // 
            // grbRevenue
            // 
            this.grbRevenue.Controls.Add(this.dtgvRevenueOfYear);
            this.grbRevenue.Location = new System.Drawing.Point(13, 330);
            this.grbRevenue.Name = "grbRevenue";
            this.grbRevenue.Size = new System.Drawing.Size(683, 191);
            this.grbRevenue.TabIndex = 2;
            this.grbRevenue.TabStop = false;
            this.grbRevenue.Text = "Doanh thu từng tháng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhập năm:";
            // 
            // txbYear
            // 
            this.txbYear.Location = new System.Drawing.Point(108, 296);
            this.txbYear.Name = "txbYear";
            this.txbYear.Size = new System.Drawing.Size(104, 26);
            this.txbYear.TabIndex = 5;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(228, 294);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(97, 28);
            this.btnDisplay.TabIndex = 6;
            this.btnDisplay.Text = "Hiện thị";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // FormLineChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 533);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.txbYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grbRevenue);
            this.Controls.Add(this.chartRevenue);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormLineChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biểu đồ doanh thu từng năm";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvRevenueOfYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.grbRevenue.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvRevenueOfYear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.GroupBox grbRevenue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbYear;
        private System.Windows.Forms.Button btnDisplay;
    }
}