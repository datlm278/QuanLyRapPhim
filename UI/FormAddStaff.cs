using QuanLyRapChieuPhim.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.UI
{
    public partial class FormAddStaff : Form
    { 
        public FormAddStaff()
        {
            InitializeComponent();
            addComboBox();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string manv = txbStaffId.Text;
            string tennv = txbStaffName.Text;
            string gioitinh = cboStaffGender.Text;
            DateTime ngaysinh = DateTime.Parse(dtpkBirth.Text);
            string diachi = txbAddress.Text;
            string sodienthoai = txbPhone.Text;
            string matk = txbAccountId.Text;
            string macv = cboRoleId.SelectedValue.ToString();
            int result = 0;
            if (check())
            {
                try
                {
                    string query = "USP_InsertStaff @manv , @tennv , @gioitinh , @ngaysinh , @sdt , @diachi , @matk , @macv";
                    result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { manv, tennv, gioitinh, ngaysinh, sodienthoai, diachi , matk, macv });
                    if (result > 0)
                    {
                        MessageBox.Show("Bạn thêm nhân viên mã " + manv + " thành công", "Thông báo");
                        reset();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        bool check()
        {
            string sodt = txbPhone.Text;
            long dienthoai;
            char[] mangSoDt = sodt.ToCharArray();

            if (txbStaffId.Text == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Thông báo");
                txbStaffId.Focus();
                return false;
            }
            if (txbStaffName.Text == "")
            {
                MessageBox.Show("Tên nhân viên không được để trống", "Thông báo");
                txbStaffName.Focus();
                return false;
            }
            if (cboStaffGender.Text == "")
            {
                MessageBox.Show("Giới tính không được để trống", "Thông báo");
                cboStaffGender.Focus();
                return false;
            }
            if (txbPhone.Text == "")
            {
                MessageBox.Show("Số điện thoại không được để trống", "Thông báo");
                txbPhone.Focus();
                return false;
            }
            if (!long.TryParse(sodt, out dienthoai))
            {
                MessageBox.Show("Hãy nhập đúng định dạng số điện thoại", "Thông báo");
                txbPhone.Focus();
                return false;
            }
            if (dienthoai < 0)
            {
                MessageBox.Show("Số điện thoại không được âm!", "Thông báo");
                txbPhone.Focus();
                return false;
            }
            if (mangSoDt.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đúng đủ 10 chữ số!", "Thông báo");
                txbPhone.Focus();
                return false;
            }
            if (txbAddress.Text == "")
            {
                MessageBox.Show("Địa chỉ không được để trống", "Thông báo");
                txbAddress.Focus();
                return false;
            }
            if (txbAccountId.Text == "")
            {
                MessageBox.Show("Mã tài khoản không được để trống", "Thông báo");
                txbAccountId.Focus();
                return false;
            }
            if (cboRoleId.Text == "")
            {
                MessageBox.Show("Chức vụ không được để trống", "Thông báo");
                cboRoleId.Focus();
                return false;
            }
            return true;
        }
        void addComboBox()
        {
            cboStaffGender.Items.Add("Nam");
            cboStaffGender.Items.Add("Nữ");
            cboRoleId.DataSource = PositionDAO.GetPosition();
            cboRoleId.DisplayMember = "TenChucVu";
            cboRoleId.ValueMember = "MaChucVu";
        }
        void reset()
        {
            txbStaffId.Text = "";
            txbStaffName.Text = "";
            cboStaffGender.Text = "";
            dtpkBirth.Value = DateTime.Now;
            txbPhone.Text = "";
            txbAddress.Text = "";
            txbAccountId.Text = "";
            cboRoleId.Text = null;
        }
    }
}
