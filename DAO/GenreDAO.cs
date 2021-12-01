using QuanLyRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DAO
{
    public class GenreDAO
    {
        public static List<Genre> GetListGenre()
        {
            List<Genre> genre_list = new List<Genre>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM THELOAI");
            foreach (DataRow item in data.Rows)
            {
                Genre genre = new Genre(item);
                genre_list.Add(genre);
            }
            return genre_list;
        }

        public static DataTable GetGenre()
        {
            string query = "Select MaTheLoai as N'Mã thể loại', TenTheLoai as N'Tên thể loại', MoTa as N'Mô tả' from THELOAI";
            return DataProvider.Instance.ExcuteQuery(query);
        }


    }
}
