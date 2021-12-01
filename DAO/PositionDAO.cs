using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DAO
{
    public class PositionDAO
    {
        public static DataTable GetPosition()
        {
            string query = "SELECT * FROM CHUCVU";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }
    }
}
