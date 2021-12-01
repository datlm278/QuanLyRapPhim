using QuanLyRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DAO
{
    public class MovieByGenreDAO
    {
        public static List<Genre> GetListGenreByMovieID (string maphim)
        {
            List<Genre> genreList = new List<Genre>();
            DataTable data = DataProvider.Instance.ExcuteQuery("EXEC USP_GetListGenreByMovie @maphim", new object[] { maphim });
            foreach (DataRow item in data.Rows)
            {
                Genre genre = new Genre(item);
                genreList.Add(genre);
            }
            return genreList;
        }
        public static void InsertMovie_Genre(string maphim, List<Genre> genreList)
        {
            foreach (Genre item in genreList)
            {
                string command = string.Format("INSERT CHITIETPHIM (MaPhim, MaTheLoai) VALUES  ('{0}','{1}')", maphim, item.MaTheLoai);
                DataProvider.Instance.ExcuteNonQuery(command);
            }
        }
        public static void UpdateMovie_Genre(string maphim, List<Genre> genreList)
        {
            DataProvider.Instance.ExcuteNonQuery("DELETE CHITIETPHIM WHERE maphim = '" + maphim + "'");
            foreach (Genre item in genreList)
            {
                string command = string.Format("INSERT CHITIETPHIM (MaPhim, MaTheLoai) VALUES  ('{0}','{1}')", maphim, item.MaTheLoai);
                DataProvider.Instance.ExcuteNonQuery(command);
            }
        }
    }
}
