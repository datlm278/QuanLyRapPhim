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
    public partial class FormSeller : Form
    {
        public FormSeller()
        {
            InitializeComponent();
            dtpThoiGian.Value = DateTime.Now;
            LoadMovie(dtpThoiGian.Value);
        }

        #region method
        private void LoadMovie(DateTime date) 
        {
            cboFilmName.DataSource = MovieDAO.GetListMovieByDate(date);
            cboFilmName.DisplayMember = "TenPhim";
            cboFilmName.ValueMember = "MaPhim";
        }

        private void LoadListShowTimeByFilm (string movieID) 
        {
            DataTable data = ShowTimesDAO.GetListShowTimeByFormatMovie(movieID, dtpThoiGian.Value);

            foreach (DataRow row in data.Rows)
            {
                ShowTimes showTimes = new ShowTimes(row);
                ListViewItem listView = new ListViewItem("");
                listView.SubItems.Add(showTimes.Tenphongchieu);
                listView.SubItems.Add(showTimes.Tenphim);
                listView.SubItems.Add(showTimes.Thoigianchieu.ToShortTimeString());
                listView.Tag = showTimes;

                string statusShowTimes = TicketDAO.CountTheNumberOfTicketsSoldByShowTime(showTimes.Maxuatchieu)
                    + "/" + TicketDAO.CountToltalTicketByShowTime(showTimes.Maxuatchieu);

                listView.SubItems.Add(statusShowTimes);

                float status = (float)TicketDAO.CountTheNumberOfTicketsSoldByShowTime(showTimes.Maxuatchieu)
                    / TicketDAO.CountToltalTicketByShowTime(showTimes.Maxuatchieu);

                //thêm ảnh status
                if (status == 1)
                    listView.ImageIndex = 2;
                else if (status > 0.5f)
                    listView.ImageIndex = 1;
                else
                    listView.ImageIndex = 0;

                lvLichChieu.Items.Add(listView);
            }
        }

        #endregion
        #region Event
        private void FormSeller_Load(object sender, EventArgs e)
        {
            LoadMovie(dtpThoiGian.Value);
            /*timer1.Start();*/
        }

        private void dtpThoiGian_ValueChanged(object sender, EventArgs e)
        {
            LoadMovie(dtpThoiGian.Value);
        }

        private void cboFilmName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilmName.SelectedIndex != -1)
            {
                /*cboFormatFilm.DataSource = null;*/
                lvLichChieu.Items.Clear();
                Movie movie = cboFilmName.SelectedItem as Movie;
                cboFormatFilm.DataSource = FormatMovieDAO.GetListFormatMovieByMovie(movie.MaPhim);
                cboFormatFilm.DisplayMember = "LoaiMH";
            }
            
        }
        private void cboFormatFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFormatFilm.SelectedIndex != 1)
            {
                lvLichChieu.Items.Clear();
                FormatMovie format = cboFormatFilm.SelectedItem as FormatMovie;
                LoadListShowTimeByFilm(format.Maphim);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*this.OnLoad(null);*/
        }

        private void lvLichChieu_Click(object sender, EventArgs e)
        {
            if (lvLichChieu.SelectedItems.Count > 0)
            {
                /*timer1.Stop();*/
                ShowTimes show = lvLichChieu.SelectedItems[0].Tag as ShowTimes;
                Movie movie = cboFilmName.SelectedItem as Movie;
                FormTheatre f = new FormTheatre(show, movie);
                this.Hide();
                f.ShowDialog();
                this.OnLoad(null);
                this.Show();
            }
        }


        #endregion
    }
}
