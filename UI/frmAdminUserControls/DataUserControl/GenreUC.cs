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

namespace QuanLyRapChieuPhim.UI.frmAdminUserControls.DataUserControl
{
    public partial class GenreUC : UserControl
    {
        BindingSource genre_list = new BindingSource();
        public GenreUC()
        {
            InitializeComponent();
            loadGenre();
        }

        #region Method
        void loadGenre()
        {
            dtgvGenre.DataSource = genre_list;
            LoadGenreList();
            AddGenreBinding();
        }
        void LoadGenreList()
        {
            genre_list.DataSource = GenreDAO.GetGenre();
        }
        void AddGenreBinding()
        {
            txtGenreID.DataBindings.Add("Text", dtgvGenre.DataSource, "Mã thể loại", true, DataSourceUpdateMode.Never);
            txtGenreName.DataBindings.Add("Text", dtgvGenre.DataSource, "Tên thể loại", true, DataSourceUpdateMode.Never);
            txtGenreDesc.DataBindings.Add("Text", dtgvGenre.DataSource, "Mô tả", true, DataSourceUpdateMode.Never);
        }

        bool checkNameGenre()
        {
            try
            {
                string query = "USP_GetNameGenre @tentheloai";
                DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { txtGenreName.Text });
                if (data.Rows.Count > 0)
                {
                    MessageBox.Show("Tên thể loại đã có trong cơ sở dữ liệu", "Thông báo");
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
        private void btnInsertGenre_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkNameGenre())
                {
                    string query = "USP_InsertGenre @matheloai , @tentheloai , @mota";
                    int data = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtGenreID.Text, txtGenreName.Text, txtGenreDesc.Text });
                    if (data > 0)
                    {
                        MessageBox.Show("Bạn đã thêm thể loại " + txtGenreName.Text + " thành công", "Thông báo");
                        LoadGenreList();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Mã thể loại đã tồn tại", "Thông báo");

            }
        }

        private void btnDeleteGenre_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn xoá thể loại phim có mã " + txtGenreID.Text.Trim() + " không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string query = "USP_DeleteGenre @matheloai";
                    int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtGenreID.Text });
                    if (result > 0)
                    {
                        MessageBox.Show("Bạn đã xoá thể loại có mã " + txtGenreID.Text.Trim() + " thành công", "Thông báo");
                        LoadGenreList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdateGenre_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin thể loại có mã " + txtGenreID.Text.Trim() + " không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog ==  DialogResult.Yes)
            {
                try
                {
                    string query = "USP_UpdateGenre @matheloai , @tentheloai , @mota";
                    int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtGenreID.Text, txtGenreName.Text, txtGenreDesc.Text });
                    if (result > 0)
                    {
                        MessageBox.Show("Bạn đã cập nhật thông tin thể loại mã " + txtGenreID.Text.Trim() + " thành công", "Thông báo");
                        LoadGenreList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnShowGenre_Click(object sender, EventArgs e)
        {
            LoadGenreList();
        }
        #endregion

    }
}
