using QuanLyRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DAO
{
    public class FormatMovieDAO
    {
        public static List<FormatMovie> GetListFormatMovieByMovie (string maphim)
        {
            List<FormatMovie> listFormat = new List<FormatMovie>();
            string query = "USP_GetListFormatMovieByMovie @maphim";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { maphim });
            foreach (DataRow row in data.Rows)
            {
                FormatMovie format = new FormatMovie(row);
                listFormat.Add(format);
            }
            return listFormat;
        }
        public static List<FormatMovie> GetFormatMovie()
        {
            List<FormatMovie> formatMovieList = new List<FormatMovie>();
            DataTable data = DataProvider.Instance.ExcuteQuery("USP_GetFormatMovie");
            foreach (DataRow item in data.Rows)
            {
                FormatMovie formatMovie = new FormatMovie(item);
                formatMovieList.Add(formatMovie);
            }
            return formatMovieList;
        }
    }
}
