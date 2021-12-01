using QuanLyRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DAO
{
    public class ShowTimesDAO
    {
        public static DataTable GetListShowTimeByFormatMovie (string id, DateTime date)
        {
            string query = "USP_GetListShowTimesByMovieID @ID , @Date";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { id, date });
            return data;
        }
        public static DataTable GetListShowtime()
        {
            return DataProvider.Instance.ExcuteQuery("USP_GetShowtime");
        }
        public static DataTable SearchShowtimeByMovieName(string movieName)
        {
            string query = "USP_SearchShowtimeByMovieName @tenPhim ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { movieName });
            return data;
        }
        public static DataTable GetYear()
        {
            string query = "USP_GetYear";
            return DataProvider.Instance.ExcuteQuery(query);
        }

        public static List<ShowTimes> GetAllListShowTimes()
        {
            List<ShowTimes> showTimes_list = new List<ShowTimes>();
            string query = "USP_GetAllListShowTimes";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                ShowTimes showTimes = new ShowTimes(row);
                showTimes_list.Add(showTimes);
            }
            return showTimes_list;
        }
        public static int UpdateStatusShowTimes(string showTimesID, string status)
        {
            string query = "USP_UpdateStatus @idLichChieu , @status";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { showTimesID, status });
        }
        public static List<ShowTimes> GetListShowTimesNotCreateTickets()
        {
            List<ShowTimes> listShowTimes = new List<ShowTimes>();
            DataTable data = DataProvider.Instance.ExcuteQuery("USP_GetListShowTimesNotCreateTicket ");
            foreach (DataRow row in data.Rows)
            {
                ShowTimes showTimes = new ShowTimes(row);
                listShowTimes.Add(showTimes);
            }
            return listShowTimes;
        }
    }
}
