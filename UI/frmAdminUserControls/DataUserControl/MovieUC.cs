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
    public partial class MovieUC : UserControl
    {
        BindingSource movie_list = new BindingSource();
        public MovieUC()
        {
            InitializeComponent();
            //dtgvMovie.Columns["Poster"].Visible = false;
            LoadMovie();
        }

        #region Method
        void LoadMovie()
        {
            dtgvMovie.DataSource = movie_list;
            LoadMovieList();
            AddMovieBinding();
        }

        void LoadMovieList()
        {
            movie_list.DataSource = MovieDAO.GetMovie();
        }
        void AddMovieBinding()
        {
            txtMovieID.DataBindings.Add("Text", dtgvMovie.DataSource, "Mã Phim", true, DataSourceUpdateMode.Never);
            txtMovieName.DataBindings.Add("Text", dtgvMovie.DataSource, "Tên Phim", true, DataSourceUpdateMode.Never);
            txtMovieLength.DataBindings.Add("Text", dtgvMovie.DataSource, "Thời lượng", true, DataSourceUpdateMode.Never);
            dtmMovieStart.DataBindings.Add("Value", dtgvMovie.DataSource, "Ngày khởi chiếu", true, DataSourceUpdateMode.Never);
            dtmMovieEnd.DataBindings.Add("Value", dtgvMovie.DataSource, "Ngày kết thúc", true, DataSourceUpdateMode.Never);
            txtMovieProductor.DataBindings.Add("Text", dtgvMovie.DataSource, "Nhà sản xuất", true, DataSourceUpdateMode.Never);
            txtMovieDirector.DataBindings.Add("Text", dtgvMovie.DataSource, "Đạo diễn", true, DataSourceUpdateMode.Never);
            dtpkYear.DataBindings.Add("Value", dtgvMovie.DataSource, "Năm SX", true, DataSourceUpdateMode.Never);
            picFilm.DataBindings.Add("Image", dtgvMovie.DataSource, "Poster", true, DataSourceUpdateMode.Never);
            LoadGenre(clbMovieGenre);
        }
        void LoadGenre(CheckedListBox checkedList) 
        {
            List<Genre> genre_list = GenreDAO.GetListGenre();
            checkedList.DataSource = genre_list;
            checkedList.DisplayMember = "TenTheLoai";
        }

        public void InsertMovieGenre(string maphim, CheckedListBox genre_list)
        {
            List<Genre> checkedGenreList = new List<Genre>();
            foreach(Genre genre in genre_list.CheckedItems)
            {
                checkedGenreList.Add(genre);
            }
            MovieByGenreDAO.InsertMovie_Genre(maphim, checkedGenreList);
        }

        public void UpdateMovieGenre(string maphim, CheckedListBox genre_list)
        {
            List<Genre> checkedGenreList = new List<Genre>();
            foreach (Genre genre in genre_list.CheckedItems)
            {
                checkedGenreList.Add(genre);
            }
            MovieByGenreDAO.UpdateMovie_Genre(maphim, checkedGenreList);
        }
        #endregion

        #region Event
        private void btnShowMovie_Click(object sender, EventArgs e)
        {
            LoadMovieList();
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            string ngayketthuc = dtmMovieEnd.Value.Year.ToString() + "-" + dtmMovieEnd.Value.Month.ToString() + "-" + dtmMovieEnd.Value.Day.ToString();
            string ngaykhoichieu = dtmMovieStart.Value.Year.ToString() + "-" + dtmMovieStart.Value.Month.ToString() + "-" + dtmMovieStart.Value.Day.ToString();
            string namsx = dtpkYear.Value.Year.ToString() + "-" + dtpkYear.Value.Month.ToString() + "-" + dtpkYear.Value.Day.ToString();
            if (picFilm.Image == null)
            {
                MessageBox.Show("Bạn chưa thêm hình ảnh cho phim", "Thông báo");
                return;
            } 
            else
            {
                try
                {
                    string query = "USP_InsertMovie @maphim , @tenphim , @thoiluong , @ngaykc , @ngaykt , @nhasx , @daodien , @namsx , @poster ";
                    int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtMovieID.Text, txtMovieName.Text, txtMovieLength.Text, ngaykhoichieu, ngayketthuc,
                        txtMovieProductor.Text, txtMovieDirector.Text, namsx, MovieDAO.imageToByteArray(picFilm.Image) });
                    InsertMovieGenre(txtMovieID.Text, clbMovieGenre);
                    if (result > 0)
                    {
                        MessageBox.Show("Bạn đã thêm phim có mã " + txtMovieID.Text + " thành công", "Thông báo");
                        LoadMovieList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            string ngayketthuc = dtmMovieEnd.Value.Year.ToString() + "-" + dtmMovieEnd.Value.Month.ToString() + "-" + dtmMovieEnd.Value.Day.ToString();
            string ngaykhoichieu = dtmMovieStart.Value.Year.ToString() + "-" + dtmMovieStart.Value.Month.ToString() + "-" + dtmMovieStart.Value.Day.ToString();
            string namsx = dtpkYear.Value.Year.ToString() + "-" + dtpkYear.Value.Month.ToString() + "-" + dtpkYear.Value.Day.ToString();

            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có chắc chắn muốn thay đổi thông tin phim có mã " + txtMovieID.Text.Trim() + " không?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                if (picFilm.Image == null)
                {
                    MessageBox.Show("Bạn chưa cập nhật hình ảnh cho phim", "Thông báo");
                    return;
                }
                else
                {
                    try
                    {
                        string query = "USP_UpdateMovie @maphim , @tenphim , @thoiluong , @ngaykc , @ngaykt , @nhasx , @daodien , @namsx , @poster ";
                        int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtMovieID.Text, txtMovieName.Text, txtMovieLength.Text, ngaykhoichieu, ngayketthuc,
                            txtMovieProductor.Text, txtMovieDirector.Text, namsx, MovieDAO.imageToByteArray(picFilm.Image) });
                        UpdateMovieGenre(txtMovieID.Text, clbMovieGenre);
                        if (result > 0)
                        {
                            MessageBox.Show("Thông tin phim có mã " + txtMovieID.Text.Trim() + " đã được cập nhật thành công!", "Thông báo");
                            LoadMovieList();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

            }
        }

        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có chắc chắn muốn xoá phim có mã " + txtMovieID.Text.Trim() + " không?", 
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string query = "USP_DeleteMovie @maphim";
                    int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtMovieID.Text });
                    if (result > 0)
                    {
                        MessageBox.Show("Phim có mã " + txtMovieID.Text.Trim() + " đã được xoá thành công", "Thông báo");
                        LoadMovieList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }    

        }
        private void btnUpLoadPictureFilm_Click(object sender, EventArgs e)
        {
            try
            {
                string filePathImage = null;
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                openFile.RestoreDirectory = true;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    filePathImage = openFile.FileName;
                    picFilm.Image = Image.FromFile(filePathImage.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtMovieID_TextChanged(object sender, EventArgs e)
        {
            picFilm.Image = null;
            for (int i = 0; i < clbMovieGenre.Items.Count; i++)
            {
                clbMovieGenre.SetItemChecked(i, false);
                //Uncheck all CheckBox first
            }

            List<Genre> listGenreOfMovie = MovieByGenreDAO.GetListGenreByMovieID(txtMovieID.Text);
            for (int i = 0; i < clbMovieGenre.Items.Count; i++)
            {
                Genre genre = (Genre)clbMovieGenre.Items[i];
                foreach (Genre item in listGenreOfMovie)
                {
                    if (genre.MaTheLoai == item.MaTheLoai)
                    {
                        clbMovieGenre.SetItemChecked(i, true);
                        break;
                    }
                }
            }

            Movie movie = MovieDAO.GetMovieByID(txtMovieID.Text);

            if (movie == null)
                return;

            if (movie.Poster != null)
                picFilm.Image = MovieDAO.byteArrayToImage(movie.Poster);
        }
        #endregion


    }
}
