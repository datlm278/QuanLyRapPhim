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

namespace QuanLyRapChieuPhim.UI
{
    public partial class FormAddShowTime : Form
    {
        public FormAddShowTime()
        {
            InitializeComponent();
            loadComboBoxCinemaId(cboCinemaId);
            loadComboBoxMovieId(cboMovieId);
            loadComboBoxScreenId(cboScreenId);
            loadComboBoxStatus(cboStatus);

        }

        #region Method
        void loadComboBoxMovieId(ComboBox combo)
        {
            combo.DataSource = MovieDAO.GetMovie();
            combo.DisplayMember = "Tên phim";
            combo.ValueMember = "Mã phim";
        }
        void loadComboBoxScreenId(ComboBox combo)
        {
            combo.DataSource = ScreenTypeDAO.GetScreenType();
            combo.DisplayMember = "Loại màn hình";
            combo.ValueMember = "Mã màn hình";
        }
        void loadComboBoxCinemaId(ComboBox combo)
        {
            combo.DataSource = CinemaDAO.GetListCinema();
            combo.DisplayMember = "Tên phòng";
            combo.ValueMember = "Mã phòng";
        }
        void loadComboBoxStatus(ComboBox combo)
        {
            combo.Items.Add("Đã tạo");
            combo.Items.Add("Chưa tạo");
        }

        bool check()
        {
            if (txbPrice.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá xuất chiếu", "Thông báo");
                txbPrice.Focus();
                return false;
            }
            return true;
        }
        void reset()
        {
            txbShowTimeId.Text = "";
            cboCinemaId.Text = null;
            cboScreenId.Text = null;
            cboMovieId.Text = null;
            dtmShowtimeDate.Value = DateTime.Now;
            dtmShowtimeTime.Value = DateTime.Now;
            cboStatus.Text = null;
            txbPrice.Text = "";
        }
        #endregion

        #region Event
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime time = new DateTime(dtmShowtimeDate.Value.Year, dtmShowtimeDate.Value.Month, dtmShowtimeDate.Value.Day, dtmShowtimeTime.Value.Hour, dtmShowtimeTime.Value.Minute, dtmShowtimeTime.Value.Second);
            MessageBox.Show(/*cboMovieId.SelectedValue.ToString()*/ time.ToString() );
            if (check())
            {
                try
                {
                    string query = "USP_InsertShowTime @maxc , @tgian , @giaxc , @mapc , @trangthai , @mamh , @maphim";
                    int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txbShowTimeId.Text, time, float.Parse(txbPrice.Text), cboCinemaId.SelectedValue.ToString(), cboStatus.SelectedItem.ToString(), cboScreenId.SelectedValue.ToString(), cboMovieId.SelectedValue.ToString() });
                    if (result > 0)
                    {
                        MessageBox.Show("Bạn đã thêm xuất chiếu mã " + txbShowTimeId.Text.Trim() + " thành công", "Thông báo");
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
        private void cboScreenId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string screen_type = cboScreenId.SelectedValue.ToString();
            cboCinemaId.DataSource = null;
            cboCinemaId.DataSource = CinemaDAO.GetCinemaByScreenTypeID(screen_type);
            cboCinemaId.DisplayMember = "TenPhongChieu";
        }


        #endregion


    }
}
