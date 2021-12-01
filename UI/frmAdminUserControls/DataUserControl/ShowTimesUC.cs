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
    public partial class ShowTimesUC : UserControl
    {
        BindingSource showtime_list = new BindingSource();
        public ShowTimesUC()
        {
            InitializeComponent();
            LoadShowTime();

        }

        #region Method
        void LoadShowTime()
        {
            dtgvShowtime.DataSource = showtime_list;
            LoadShowTimeList();
            AddShowTimeBinding();
            toolTipCinema.SetToolTip(cboCinemaID_Showtime, "Danh sách phòng chiếu hỗ trợ loại màn hình trên");
        }
        void LoadShowTimeList()
        {
            showtime_list.DataSource = ShowTimesDAO.GetListShowtime();
        }
        void AddShowTimeBinding()
        {
            txtShowtimeID.DataBindings.Add("Text", dtgvShowtime.DataSource, "Mã lịch chiếu", true, DataSourceUpdateMode.Never);
            dtmShowtimeDate.DataBindings.Add("Value", dtgvShowtime.DataSource, "Thời gian chiếu", true, DataSourceUpdateMode.Never);
            dtmShowtimeTime.DataBindings.Add("Value", dtgvShowtime.DataSource, "Thời gian chiếu", true, DataSourceUpdateMode.Never);
            txtTicketPrice_Showtime.DataBindings.Add("Text", dtgvShowtime.DataSource, "Giá vé", true, DataSourceUpdateMode.Never);
            txbFormatID_Showtime.DataBindings.Add("Text", dtgvShowtime.DataSource, "Mã định dạng", true, DataSourceUpdateMode.Never);
            txtMovieName_Showtime.DataBindings.Add("Text", dtgvShowtime.DataSource, "Tên phim", true, DataSourceUpdateMode.Never);
        }

        #endregion


        #region Event
        private void btnInsertShowtime_Click(object sender, EventArgs e)
        {
            FormAddShowTime f = new FormAddShowTime();
            this.Hide();
            f.ShowDialog();
            this.Show();
            LoadShowTimeList();

        }

        private void btnDeleteShowtime_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có chắc chắn muốn xoá xuất chiếu mã " + txtShowtimeID.Text.Trim() + " không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string query = "USP_DeleteShowTime @maxc";
                    int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtShowtimeID.Text });
                    if (result > 0)
                    {
                        MessageBox.Show("Bạn đã xoá xuất chiếu mã " + txtShowtimeID.Text.Trim() + " thành công", "Thông báo");
                        LoadShowTimeList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdateShowtime_Click(object sender, EventArgs e)
        {
            DateTime time = new DateTime(dtmShowtimeDate.Value.Year, dtmShowtimeDate.Value.Month, dtmShowtimeDate.Value.Day, dtmShowtimeTime.Value.Hour, dtmShowtimeTime.Value.Minute, dtmShowtimeTime.Value.Second);

            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có chắc chắn muốn thay đổi thông tin xuất chiếu mã " + txtShowtimeID.Text.Trim() + " không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            /*MessageBox.Show(cboCinemaID_Showtime.SelectedItem.ToString());*/
            
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string query = "USP_UpdateShowTime @maxc , @tgian , @giaxc , @mapc , @mamh";
                    int result = DataProvider.Instance.ExcuteNonQuery(query, new object[]
                    {
                        txtShowtimeID.Text,
                        time,
                        txtTicketPrice_Showtime.Text,
                        cboCinemaID_Showtime.SelectedValue.ToString(),
                        cboScreenTypeName_Showtime.SelectedValue.ToString()
                    }) ;
                    if (result > 0)
                    {
                        MessageBox.Show("Bạn đã cập nhật xuất chiếu mã " + txtShowtimeID.Text.Trim() + " thành công", "Thông báo");
                        LoadShowTimeList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnShowShowtime_Click(object sender, EventArgs e)
        {
            LoadShowTimeList();
        }

        private void btnSearchShowtime_Click(object sender, EventArgs e)
        {
            string movie_name = txtSearchShowtime.Text;
            showtime_list.DataSource = ShowTimesDAO.SearchShowtimeByMovieName(movie_name);
        }

        private void txtScreenTypeName_Showtime_TextChanged(object sender, EventArgs e)
        {
/*            string screenTypeName = (string)dtgvShowtime.SelectedCells[0].OwningRow.Cells["Màn hình"].Value;

            cboCinemaID_Showtime.DataSource = null;
            ScreenType screenType = ScreenTypeDAO.GetScreenTypeByName(screenTypeName);
            cboCinemaID_Showtime.DataSource = CinemaDAO.GetCinemaByScreenTypeID(screenType.MaMH);
            cboCinemaID_Showtime.DisplayMember = "TenPhongChieu";
            cboCinemaID_Showtime.ValueMember = "MaPhongChieu";*/
        }

        private void txbFormatID_Showtime_TextChanged(object sender, EventArgs e)
        {
            string screen_type_id = txbFormatID_Showtime.Text;
            
            cboCinemaID_Showtime.DataSource = null;
            try
            {
                cboScreenTypeName_Showtime.DataSource = ScreenTypeDAO.GetScreenTypeById(screen_type_id);
                cboScreenTypeName_Showtime.DisplayMember = "LoaiMH";
                cboScreenTypeName_Showtime.ValueMember = "MaMH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            try
            {
                cboCinemaID_Showtime.DataSource = CinemaDAO.GetCinemaByScreenTypeID(screen_type_id);
                cboCinemaID_Showtime.DisplayMember = "TenPhongChieu";
                cboCinemaID_Showtime.ValueMember = "MaPhongChieu";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        #endregion

        private void cboCinemaID_Showtime_SelectedIndexChanged(object sender, EventArgs e)
        {
/*            FormatMovie formatMovieSelecting = (FormatMovie)cboCinemaID_Showtime.SelectedItem;
            txtScreenTypeName_Showtime.Text = formatMovieSelecting.LoaiMH;*/
        }
    }
}
