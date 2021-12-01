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
    public partial class StaffUC : UserControl
    {
        BindingSource staff_list = new BindingSource();
        public StaffUC()
        {
            InitializeComponent();
            LoadStaff();
        }

        #region Method
        void LoadStaff()
        {
            dtgvStaff.DataSource = staff_list;
            LoadStaffList();
            AddStaffBinding();
        }
        void LoadStaffList()
        {
            staff_list.DataSource = StaffDAO.GetListStaff();
        }
        void AddStaffBinding()
        {
            txtStaffId.DataBindings.Add("Text", dtgvStaff.DataSource, "Mã nhân viên", true, DataSourceUpdateMode.Never);
            txtStaffName.DataBindings.Add("Text", dtgvStaff.DataSource, "Họ tên", true, DataSourceUpdateMode.Never);
            txbGender.DataBindings.Add("Text", dtgvStaff.DataSource, "Giới tính", true, DataSourceUpdateMode.Never);
            dtpkBirth.DataBindings.Add("Text", dtgvStaff.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never);
            txtStaffAddress.DataBindings.Add("Text", dtgvStaff.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never);
            txtStaffPhone.DataBindings.Add("Text", dtgvStaff.DataSource, "SĐT", true, DataSourceUpdateMode.Never);
        }

        #endregion

        #region Event
        private void btnShowStaff_Click(object sender, EventArgs e)
        {
            LoadStaffList();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            FormAddStaff f = new FormAddStaff();
            this.Hide();
            f.ShowDialog();
            this.Show();
            LoadStaffList();
        }

        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            string ngaysinh = dtpkBirth.Value.Year.ToString() + "-" + dtpkBirth.Value.Month.ToString() + "-" + dtpkBirth.Value.Day.ToString();
            dialog = MessageBox.Show("Bạn chắc chắn muốn thay đổi thông tin nhân viên mã " + txtStaffId.Text.Trim() + " không?", "Thông báo" ,MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string query = string.Format("update NHANVIEN set TenNhanVien = N'{0}', GioiTinh = N'{1}', NgaySinh = '{2}', SoDT = '{3}', DiaChi = N'{4}' where MaNhanVien = '{5}'", txtStaffName.Text, txbGender.Text, ngaysinh, txtStaffPhone.Text, txtStaffAddress.Text, txtStaffId.Text);
                    int result = DataProvider.Instance.ExcuteNonQuery(query);
                    if (result > 0)
                    {
                        MessageBox.Show("Nhân viên mã " + txtStaffId.Text.Trim() + " đã được cập nhật");
                        LoadStaffList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            int result = 0;
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn xoá nhân viên có mã " + txtStaffId.Text.Trim() + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string query = "USP_DeleteStaff @manv";
                    result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtStaffId.Text });
                    if (result > 0)
                    {
                        MessageBox.Show("Xoá nhân viên mã " + txtStaffId.Text.Trim() + " thành công");
                        LoadStaffList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnSearchStaff_Click(object sender, EventArgs e)
        {
           try
            {
                DataTable data = StaffDAO.SearchStaffByName(txtSearchStaff.Text);
                if (data.Rows.Count > 0)
                {
                    staff_list.DataSource = data;
                }
                else
                {
                    MessageBox.Show("Nhân viên bạn cần tìm không tồn tại", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        #endregion

    }
}
