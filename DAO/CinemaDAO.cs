using QuanLyRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DAO
{
    class CinemaDAO
    {
        public static Cinema GetCinemaByName(string cinemaName)
        {
            string query = "SELECT * FROM PHONGCHIEU WHERE TenPhongChieu = '" + cinemaName + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return new Cinema(data.Rows[0]);
        }
        public static Cinema GetCinemaByID(string maPhongChieu)
        {
            string query = "SELECT * FROM PHONGCHIEU WHERE MaPhongChieu = '" + maPhongChieu + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            if (data.Rows.Count > 0)
                return new Cinema(data.Rows[0]);
            return null;
        }
        public static List<Cinema> GetCinemaByScreenTypeID(string screenTypeID)
        {
            List<Cinema> cinemaList = new List<Cinema>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.PHONGCHIEU WHERE MaMH ='" + screenTypeID + "'");
            foreach (DataRow item in data.Rows)
            {
                Cinema cinema = new Cinema(item);
                cinemaList.Add(cinema);
            }
            return cinemaList;
        }
        public static DataTable GetListCinema()
        {
            return DataProvider.Instance.ExcuteQuery("USP_GetCinema");
        }
    }
}
