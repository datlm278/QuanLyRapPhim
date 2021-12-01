using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DAO
{
    public class RevenueDAO
    {
        public static DataTable GetRevenue (string maPhim, DateTime fromDate, DateTime toDate) 
        {
            string query = "USP_GetRevenueByMovieAndDate @idMovie , @fromDate , @toDate";
            return DataProvider.Instance.ExcuteQuery(query, new object[] { maPhim, fromDate, toDate });
        }
        public static DataTable GetRevenueOfYear (string nam)
        {
            string query = "USP_GetRevenue @nam";
            return DataProvider.Instance.ExcuteQuery(query, new object[] { nam });
        }

    }
}
