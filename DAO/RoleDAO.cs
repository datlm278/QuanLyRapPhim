using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DAO
{
    public class RoleDAO
    {
        public static DataTable GetRole ()
        {
            string query = "SELECT * FROM VAITRO";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

        public static DataTable GetRoleById(string mavaitro)
        {
            string query = "SELECT  * FROM VAITRO WHERE MaVaiTro = '" + mavaitro + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }
    }
}
