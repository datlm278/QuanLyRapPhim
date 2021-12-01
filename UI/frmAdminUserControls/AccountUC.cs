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

namespace QuanLyRapChieuPhim.UI.frmAdminUserControls
{
    public partial class AccountUC : UserControl
    {
        BindingSource account_list = new BindingSource();

        #region Method
        public AccountUC()
        {
            InitializeComponent();
            LoadAccount();
            LoadTypeAccountIntoComboBox(cboAccountType);
        }

        void LoadAccount()
        {
            dtgvAccount.DataSource = account_list;
            LoadAccountList();
            AddAccountBinding();

        }

        public void LoadAccountList()
        {
            account_list.DataSource = AccountDAO.Instance.GetAccountList();
        }

        void AddAccountBinding()
        {
            txtUsername.DataBindings.Add("Text", dtgvAccount.DataSource, "Tên tài khoản", true, DataSourceUpdateMode.Never);
            txtAccount_Role.DataBindings.Add("Text", dtgvAccount.DataSource, "Mã vai trò", true, DataSourceUpdateMode.Never);
            cboAccountType.DataBindings.Add("Text", dtgvAccount.DataSource, "Tên vai trò", true, DataSourceUpdateMode.Never);
            txbAccountId.DataBindings.Add("Text", dtgvAccount.DataSource, "Mã tài khoản", true, DataSourceUpdateMode.Never);
        }

        void LoadTypeAccountIntoComboBox(ComboBox combo)
        {
            combo.DataSource = AccountDAO.Instance.GetTypeAccount();
            combo.DisplayMember = "TenVaiTro";
            combo.ValueMember = "MaVaiTro";
        }

        void reset()
        {
            txbAccountId.Text = "";
            txtUsername.Text = "";
            cboAccountType.Text = null;
            txtAccount_Role.Text = "";
        }
        #endregion

        #region Event
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }

        private void btnInsertAccount_Click(object sender, EventArgs e)
        {
            FormAddAccount f = new FormAddAccount();
            this.Hide();
            f.ShowDialog();
            this.Show();
            LoadAccountList();
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "USP_update_account @tentaikhoan , @mavaitro , @matk";
                int data = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtUsername.Text, txtAccount_Role.Text, txbAccountId.Text });
                if (data > 0)
                {
                    MessageBox.Show("Tài khoản " + txbAccountId.Text + " đã được cập nhật!", "Thông báo");
                    LoadAccountList();
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            

        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn xoá tài khoản " + txtUsername.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string query = "USP_delete_account @tentk";
                    int data = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtUsername.Text });
                    if (data > 0)
                    {
                        MessageBox.Show("Xoá tài khoản thành công!", "Thông báo");
                        LoadAccountList();
                        reset();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "exec USP_searchAccount @hoten";
                DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { txtSearchAccount.Text });
                if (data.Rows.Count > 0)
                {
                    account_list.DataSource = data;
                    reset();
                }
                else
                {
                    MessageBox.Show("Nhân viên cần tìm không tồn tại!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtAccount_Role_TextChanged(object sender, EventArgs e)
        {
            string RoleId = txtAccount_Role.Text;

            cboAccountType.DataSource = null;

            try
            {
                cboAccountType.DataSource = RoleDAO.GetRoleById(RoleId);
                cboAccountType.DisplayMember = "TenVaiTro";
                cboAccountType.ValueMember = "MaVaiTro";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        #endregion


    }
}
