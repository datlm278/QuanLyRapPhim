using QuanLyRapChieuPhim.DAO;
using QuanLyRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.UI.frmAdminUserControls.DataUserControl
{
    public partial class CinemaUC : UserControl
    {
        BindingSource cineme_list = new BindingSource();
        public CinemaUC()
        {
            InitializeComponent();
            LoadCinema();
        }
        #region Method
        void LoadCinema()
        {
            dtgvCinema.DataSource = cineme_list;
            LoadCinemaList();
            AddCinemaBinding();
            
        }
        void LoadCinemaList()
        {
            cineme_list.DataSource = CinemaDAO.GetListCinema();
        }

        void AddCinemaBinding()
        {
            txtCinemaID.DataBindings.Add("Text", dtgvCinema.DataSource, "Mã phòng", true, DataSourceUpdateMode.Never);
            txtCinemaName.DataBindings.Add("Text", dtgvCinema.DataSource, "Tên phòng", true, DataSourceUpdateMode.Never);
            txtCinemaSeats.DataBindings.Add("Text", dtgvCinema.DataSource, "Số chỗ ngồi", true, DataSourceUpdateMode.Never);
            txtCinemaStatus.DataBindings.Add("Text", dtgvCinema.DataSource, "Tình trạng", true, DataSourceUpdateMode.Never);
            txtNumberOfRows.DataBindings.Add("Text", dtgvCinema.DataSource, "Số hàng ghế", true, DataSourceUpdateMode.Never);
            txtSeatsPerRow.DataBindings.Add("Text", dtgvCinema.DataSource, "Ghế mỗi hàng", true, DataSourceUpdateMode.Never);
            cboCinemaScreenType.DataBindings.Add("Text", dtgvCinema.DataSource, "Loại màn hình", true, DataSourceUpdateMode.Never);
            LoadScreenTypeIntoComboBox(cboCinemaScreenType);
        }
        void LoadScreenTypeIntoComboBox(ComboBox comboBox)
        {
            comboBox.DataSource = ScreenTypeDAO.GetListScreenType();
            comboBox.DisplayMember = "LoaiMH";
            comboBox.ValueMember = "MaMH";
        }

        bool checkNameCinema()
        {
            try
            {
                string query = "SELECT * FROM PHONGCHIEU WHERE TenPhongChieu = @tenpc";
                DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { txtCinemaName.Text });
                if (data.Rows.Count > 0)
                {
                    MessageBox.Show("Tên phòng chiếu đã có trong cơ sở dữ liệu", "Thông báo");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return true;
        }
        #endregion

        #region Event
        private void btnInsertCinema_Click(object sender, EventArgs e)
        {
            if (checkNameCinema())
            {
                try
                {
                    string query = "USP_InsertCinema @mapc , @tenpc , @mamh , @tinhtrang , @hangghe , @soghemothang";
                    int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtCinemaID.Text, txtCinemaName.Text, cboCinemaScreenType.SelectedValue.ToString(),
                        txtCinemaStatus.Text, int.Parse(txtNumberOfRows.Text), int.Parse(txtSeatsPerRow.Text) });
                    if (result > 0)
                    {
                        MessageBox.Show("Phòng chiếu mã " + txtCinemaID.Text.Trim() + " đã được thêm thành công", "Thông báo");
                        LoadCinemaList();
                    }
                }
                catch 
                {
                    MessageBox.Show("Mã phòng chiếu đã tồn tại", "Thông báo");
                }
            }
        }

        private void btnDeleteCinema_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn xoá phòng chiếu mã " + txtCinemaID.Text.Trim() + " không?", "Thông báo", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string query = "USP_DeleteCinema @mapc";
                    int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtCinemaID.Text });
                    if (result > 0)
                    {
                        MessageBox.Show("Phòng chiếu mã " + txtCinemaID.Text + " đã được xoá thành công", "Thông báo");
                        LoadCinemaList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdateCinema_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có chắn chắn muốn thay đổi thông tin phòng chiêu mã " + txtCinemaID.Text.Trim() + " không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {

                try
                {
                    string query = "USP_UpdateCinema @mapc , @tenpc , @mamh , @tinhtrang , @hangghe , @soghemothang";
                    int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtCinemaID.Text, txtCinemaName.Text, cboCinemaScreenType.SelectedValue.ToString(),
                    txtCinemaStatus.Text, int.Parse(txtNumberOfRows.Text), int.Parse(txtSeatsPerRow.Text) });
                    if (result > 0)
                    {
                        MessageBox.Show("Thông tin phòng chiếu mã " + txtCinemaID.Text.Trim() + " đã được cập nhật thành công", "Thông báo");
                        LoadCinemaList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                
            }
        }

        private void btnShowCinema_Click(object sender, EventArgs e)
        {
            LoadCinemaList();
        }
        #endregion


    }
}
