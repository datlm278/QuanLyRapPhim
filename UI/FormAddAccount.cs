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
    public partial class FormAddAccount : Form
    {
        public FormAddAccount()
        {
            InitializeComponent();
            addComboBox(cboRole);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int result = 0;
            string tentk = txbUsername.Text;
            string matk = txbAccountId.Text;
            string mk = txbPassWord.Text;
            string vaitro = cboRole.SelectedValue.ToString();

            if (check())
            {
                try
                {
                    string query = "USP_insertAccount @matk , @tentk , @matkhau , @mavaitro";
                    result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { matk, tentk, MD5Helper.PasswordEncryption(mk), vaitro });
                    
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo");
                    reset();
                }
                catch
                {
                    lblCompare.Text = "Mã tài khoản đã tồn tại";
                }

            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!", "Thông báo");

            }

        }

        bool check()
        {
            if (txbAccountId.Text == "")
            {
                MessageBox.Show("Mã tài khoản không được để trống", "Thông báo");
                txbAccountId.Focus();
                return false;
            }
            if (txbUsername.Text == "")
            {
                MessageBox.Show("Tên tài khoản không được để trống", "Thông báo");
                txbUsername.Focus();
                return false;
            }
            if (txbPassWord.Text == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo");
                txbPassWord.Focus();
                return false;
            }
            if (txbConfirmPassword.Text == "")
            {
                MessageBox.Show("Bạn chưa xác nhận lại mật khẩu", "Thông báo");
                txbConfirmPassword.Focus();
                return false;
            }
            if (txbPassWord.Text != txbConfirmPassword.Text)
            {
                lblConfirm.Text = "*Mật khẩu bạn nhập không đúng";
                txbConfirmPassword.Focus();
                return false;
            }

            string query = "USP_select_accountName @tentk";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { txbUsername.Text });
            if (data.Rows.Count > 0)
            {
                label7.Text = "Tên tài khoản đã tồn tại";
                return false;
            }
            else
            {
                label7.Text = "";
                
            }

            return true;
        }

        void reset()
        {
            txbAccountId.Text = "";
            txbConfirmPassword.Text = "";
            txbPassWord.Text = "";
            txbUsername.Text = "";
            lblConfirm.Text = "";
            lblCompare.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void addComboBox (ComboBox combo)
        {
            combo.DataSource = RoleDAO.GetRole();
            combo.DisplayMember = "TenVaiTro";
            combo.ValueMember = "MaVaiTro";
        }
    }
}
