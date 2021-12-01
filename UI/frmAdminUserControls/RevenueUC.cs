using QuanLyRapChieuPhim.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.UI.frmAdminUserControls
{
    public partial class RevenueUC : UserControl
    {
        public static string doanhthu;
        public RevenueUC()
        {
            InitializeComponent();
            LoadRevenue();
        }

        void LoadRevenue()
        {
            LoadMovieIntoCombobox(cboSelectMovie);
            LoadDateTimePickerRevenue();
            LoadRevenue(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
        }

        void LoadMovieIntoCombobox(ComboBox comboBox)
        {
            comboBox.DataSource = MovieDAO.GetListMovie();
            comboBox.DisplayMember = "TenPhim";
            comboBox.ValueMember = "MaPhim";
        }

        void LoadDateTimePickerRevenue()
        {
            dtmFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtmToDate.Value = dtmFromDate.Value.AddMonths(1).AddDays(-1);

        }

        void LoadRevenue(string MaPhim, DateTime fromDate, DateTime toDate)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            dtgvRevenue.DataSource = RevenueDAO.GetRevenue(MaPhim, fromDate, toDate);
            txtDoanhThu.Text = GetSumRevenue().ToString("c", culture);
            doanhthu = txtDoanhThu.Text;
        }

        decimal GetSumRevenue()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dtgvRevenue.Rows)
            {
                sum += Convert.ToDecimal(row.Cells["Tiền vé"].Value);
            }
            return sum;
        }

        private void btnShowRevenue_Click(object sender, EventArgs e)
        {
            LoadRevenue(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
        }

        private void btnReportRevenue_Click(object sender, EventArgs e)
        {
            if (dtgvRevenue.Rows.Count != 0)
            {
                if (saveFileExcel.ShowDialog() == DialogResult.OK)
                {
                    ExportFileExcel.export_excel(dtgvRevenue, saveFileExcel.FileName);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa thống kế doanh thu", "Thông báo");
            }
        }

        private void btnLineChart_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLineChart f = new FormLineChart();
            f.ShowDialog();
            this.Show();
        }
    }
}
