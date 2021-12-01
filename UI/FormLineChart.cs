using QuanLyRapChieuPhim.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.UI
{
    public partial class FormLineChart : Form
    {
        public FormLineChart()
        {
            InitializeComponent();
        }

        void loadChart()
        {
            var objChart = chartRevenue.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            objChart.AxisX.Minimum = 1;
            objChart.AxisX.Maximum = 12;

            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = getMaxValue(dtgvRevenueOfYear);

            chartRevenue.Series.Clear();

            Random ra = new Random();

            for (int i = 0; i < dtgvRevenueOfYear.RowCount; i++)
            {
                string location = dtgvRevenueOfYear.Rows[i].Cells[0].Value.ToString();
                chartRevenue.Series.Add(location);
                chartRevenue.Series[location].ChartArea = "ChartArea1";
                chartRevenue.Series[location].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chartRevenue.Series[location].BorderWidth = 3;
                for (int j = 1; j < dtgvRevenueOfYear.ColumnCount; j++)
                {
                    chartRevenue.Series[location].Points.AddXY(j, Double.Parse(dtgvRevenueOfYear.Rows[i].Cells[j].Value.ToString()));

                }
            }
        }

        void loadDataGridView()
        {
            try
            {
                dtgvRevenueOfYear.DataSource = RevenueDAO.GetRevenueOfYear(txbYear.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public double getMaxValue (DataGridView dataGrid)
        {
            double maxValue = Double.Parse(dataGrid.Rows[0].Cells[0].Value.ToString());
            for (int i = 0; i < dtgvRevenueOfYear.RowCount; i++)
            {
                for (int j = 1; j < dtgvRevenueOfYear.ColumnCount; j++)
                {
                    if (maxValue < Double.Parse(dataGrid.Rows[i].Cells[j].Value.ToString()))
                    {
                        maxValue = Double.Parse(dataGrid.Rows[i].Cells[j].Value.ToString());
                    }
                }    
            }
            return maxValue;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            loadDataGridView();
            loadChart();
        }
    }
}
