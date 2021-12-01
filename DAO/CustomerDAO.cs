using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DAO
{
    public class CustomerDAO
    {
        public static DataTable GetCustomerMember(string customer_id, string customer_name)
        {
            string query = "SELECT * from KHACHHANG where MaKH = '" + customer_id + "' and TenKH = N'" + customer_name + "'";
            return DataProvider.Instance.ExcuteQuery(query);
        }

        public static DataTable GetListCustomer()
        {
            return DataProvider.Instance.ExcuteQuery("USP_GetCustomer");
        }

        public static bool UpdatePointCustomer(string makh, int diemtl)
        {
            string command = string.Format("UPDATE KHACHHANG SET  DiemTichLuy = {0} WHERE MaKH = '{1}'", diemtl, makh);
            int result = DataProvider.Instance.ExcuteNonQuery(command);
            return result > 0;
        }
    }
}
