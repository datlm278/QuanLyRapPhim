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
    public partial class FormAddCustomer : Form
    {
        public FormAddCustomer()
        {
            InitializeComponent();
            addComboBox();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime ngaysinh = DateTime.Parse(dtpkCustomerBirth.Text);
            if (check())
            {
                try
                {
                    string query = "USP_InsertCustomer @makh , @tenkh , @gioitinh , @diachi , @sodt , @ngaysinh , @cccd , @diem";
                    int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txbCustomerId.Text, txbCustomerName.Text, cboGender.Text, 
                    txbCustomerAddress.Text, txbCustomerPhone.Text, ngaysinh, txbCustomerIdNumber.Text, txbCustomerPoint.Text});
                    if (result > 0)
                    {
                        MessageBox.Show("Khách hàng mã " + txbCustomerId.Text + " đã được thêm thành công", "Thông báo");
                        reset();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool check()
        {
            string id = txbCustomerIdNumber.Text;
            long ketqua;
            char[] mangId = id.ToCharArray();

            string sodt = txbCustomerPhone.Text;
            long dienthoai;
            char[] mangSoDt = sodt.ToCharArray();

            if (txbCustomerId.Text == "")
            {
                MessageBox.Show("Mã khách hàng không được để trống", "Thông báo");
                txbCustomerId.Focus();
                return false;
            }
            if (txbCustomerName.Text == "")
            {
                MessageBox.Show("Tên khách hàng không được để trống", "Thông báo");
                txbCustomerName.Focus();
                return false;
            }
            if (cboGender.Text == "")
            {
                MessageBox.Show("Giới tính không được để trống", "Thông báo");
                cboGender.Focus();
                return false;
            }
            if (txbCustomerAddress.Text == "")
            {
                MessageBox.Show("Địa chỉ không được để trống", "Thông báo");
                txbCustomerAddress.Focus();
                return false;
            }
            if (txbCustomerPhone.Text == "")
            {
                MessageBox.Show("Số điện thoại không được để trống", "Thông báo");
                txbCustomerPhone.Focus();
                return false;
            }
            if (!long.TryParse(sodt, out dienthoai))
            {
                MessageBox.Show("Hãy nhập đúng định dạng số điện thoại", "Thông báo");
                txbCustomerIdNumber.Focus();
                return false;
            }
            if (dienthoai < 0)
            {
                MessageBox.Show("Số điện thoại không được âm!", "Thông báo");
                txbCustomerPhone.Focus();
                return false;
            }
            if (mangSoDt.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đúng đủ 10 chữ số!", "Thông báo");
                txbCustomerPhone.Focus();
                return false;
            }
            if (txbCustomerIdNumber.Text == "")
            {
                MessageBox.Show("Số CCCD chưa được nhập", "Thông báo");
                txbCustomerIdNumber.Focus();
                return false;
            }
            if (!long.TryParse(id, out ketqua))
            {
                MessageBox.Show("Hãy nhập đúng định dạng số CCCD!", "Thông báo");
                txbCustomerIdNumber.Focus();
                return false;
            }
            if (ketqua < 0)
            {
                MessageBox.Show("Số CCCD không được âm!", "Thông báo");
                txbCustomerIdNumber.Focus();
                return false;
            }
            if (mangId.Length != 12)
            {
                MessageBox.Show("Số CCCD phải đúng đủ 12 chữ số!", "Thông báo");
                txbCustomerIdNumber.Focus();
                return false;
            }

            if (txbCustomerPoint.Text == "")
            {
                MessageBox.Show("Điểm tích luỹ chưa được nhập", "Thông báo");
                txbCustomerPoint.Focus();
                return false;
            }
            return true;
        }

        void addComboBox()
        {
            cboGender.Items.Add("Nam");
            cboGender.Items.Add("Nữ");
        }

        void reset()
        {
            txbCustomerId.Text = "";
            txbCustomerName.Text = "";
            cboGender.Text = "";
            txbCustomerAddress.Text = "";
            txbCustomerPhone.Text = "";
            dtpkCustomerBirth.Value = DateTime.Now;
            txbCustomerIdNumber.Text = "";
            txbCustomerPoint.Text = "";
        }
    }
}
