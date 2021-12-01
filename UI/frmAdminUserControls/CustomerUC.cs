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
    public partial class CustomerUC : UserControl
    {
        BindingSource customer_list = new BindingSource();
        public CustomerUC()
        {
            InitializeComponent();
            LoadCustomer();
        }

        #region Method
        void LoadCustomer()
        {
            dtgvCustomer.DataSource = customer_list;
            LoadCustomerList();
            AddCustomerBinding();
        }

        void LoadCustomerList()
        {
            customer_list.DataSource = CustomerDAO.GetListCustomer();
        }

        void AddCustomerBinding()
        {
            txtCusID.DataBindings.Add("Text", dtgvCustomer.DataSource, "Mã khách hàng", true, DataSourceUpdateMode.Never);
            txtCusName.DataBindings.Add("Text", dtgvCustomer.DataSource, "Họ tên", true, DataSourceUpdateMode.Never);
            txtCusGender.DataBindings.Add("Text", dtgvCustomer.DataSource, "Giới tính", true, DataSourceUpdateMode.Never);
            dtpkCusBirth.DataBindings.Add("Text", dtgvCustomer.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never);
            txtCusAddress.DataBindings.Add("Text", dtgvCustomer.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never);
            txtCusPhone.DataBindings.Add("Text", dtgvCustomer.DataSource, "SĐT", true, DataSourceUpdateMode.Never);
            txtCusINumber.DataBindings.Add("Text", dtgvCustomer.DataSource, "CCCD", true, DataSourceUpdateMode.Never);
            nudPoint.DataBindings.Add("Value", dtgvCustomer.DataSource, "Điểm", true, DataSourceUpdateMode.Never);
        }
        #endregion

        #region Event
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            FormAddCustomer f = new FormAddCustomer();
            this.Hide();
            f.ShowDialog();
            this.Show();
            LoadCustomerList();
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            string ngaysinh = dtpkCusBirth.Value.Year.ToString() + "-" + dtpkCusBirth.Value.Month.ToString() + "-" + dtpkCusBirth.Value.Day.ToString();
            int result = 0;
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có chắc chắn muốn thay đổi thông tin khách hàng " + txtCusID.Text.Trim() + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string query = string.Format(
                        "update KHACHHANG set TenKH = N'{0}', " +
                        "GioiTinh = N'{1}', " +
                        "NgaySinh = '{2}', " +
                        "DiaChi = N'{3}', " +
                        "SoDT = '{4}', " +
                        "CCCD = '{5}', " +
                        "DiemTichLuy = '{6}'  " +
                        "where MaKH = '{7}'", txtCusName.Text, txtCusGender.Text, ngaysinh, txtCusAddress.Text, txtCusPhone.Text, txtCusINumber.Text, nudPoint.Value, txtCusID.Text);
                    result = DataProvider.Instance.ExcuteNonQuery(query);
                    if (result > 0)
                    {
                        MessageBox.Show("Bạn đã cập nhật thông tin khách hàng " + txtCusID.Text + " thành công", "Thông báo");
                        LoadCustomerList();
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            int result = 0;
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có chắc muốn xoá khách hàng " + txtCusID.Text.Trim() + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
            if (dialog ==  DialogResult.Yes)
            {
                try
                {
                    string query = "USP_DeleteCustomer @makh";
                    result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtCusID.Text });
                    if (result > 0)
                    {
                        MessageBox.Show("Xoá khách hàng mã " + txtCusID.Text.Trim() + " thành công");
                        LoadCustomerList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnSearchCus_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "USP_SearchCustomer @tenkh";
                DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { txtSearchCus.Text });
                if (data.Rows.Count > 0)
                {
                    customer_list.DataSource = data;
                }
                else
                {
                    MessageBox.Show("Khách hàng bạn tìm kiếm không tồn tại!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnShowCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomerList();
        }

        #endregion
    }
}
