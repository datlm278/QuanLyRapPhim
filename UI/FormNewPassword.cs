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
    public partial class FormNewPassword : Form
    {
        public FormNewPassword()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txbConfirmPassword.Text == txbNewPassword.Text)
            {
                change_password();
                MessageBox.Show("Bạn đã đổi mật khẩu thành công!", "Thông báo");
            }
            else
            {
                lblConfirmPassword.Text = "*Mật khẩu bạn nhập không giống nhau";
                txbConfirmPassword.Focus();
            }
        }

        private bool change_password ()
        {
            string query = "USP_ChangePassword @password";

            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { MD5Helper.PasswordEncryption(txbNewPassword.Text) });
            return data.Rows.Count > 0;
        }
    }
}
