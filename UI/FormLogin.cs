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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string passWord = txtPassword.Text;

            if (check())
            {
                if (Login_admin(userName, passWord))
                {
                    FormAdmin f = new FormAdmin();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();

                }

                if (Login_employee(userName, passWord))
                {
                    FormSeller f = new FormSeller();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }

                if (!Login_admin(userName, passWord) && !Login_employee(userName, passWord))
                {
                    MessageBox.Show("Bạn nhập sai tài khoản hoặc mật khẩu", "Thông báo");
                }
            }

        }

        bool Login_admin(string userName, string passWord)
        {
            return AccountDAO.Instance.Login_admin(userName, passWord);
        }
        bool Login_employee(string userName, string passWord)
        {
            return AccountDAO.Instance.Login_employee(userName, passWord);
        }

        private void lblForgotPassWord_Click(object sender, EventArgs e)
        {
            FormForgotPassword f = new FormForgotPassword();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        bool check()
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Tên tài khoản không được để trống!", "Thông báo");
                txtUsername.Focus();
                return false;
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Thông báo");
                txtPassword.Focus();
                return false;
            }
            return true;
        }
    }
}
