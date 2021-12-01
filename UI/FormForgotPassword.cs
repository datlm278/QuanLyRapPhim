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
    public partial class FormForgotPassword : Form
    {
        public FormForgotPassword()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (choose_username())
            {
                FormNewPassword f = new FormNewPassword();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên tài khoản bạn nhập chưa chính xác!", "Thông báo");
            }
        }

        private bool choose_username ()
        {
            string query = "USP_ChooseAccount @username";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { txbUsername.Text });
            return data.Rows.Count > 0;
        }
    }
}
