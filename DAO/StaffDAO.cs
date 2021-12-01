using QuanLyRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DAO
{
    public class StaffDAO
    {
        public static Staff GetStaffByID (string id)
        {
            Staff staff = null;
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from NHANVIEN where MaNhanVien = '" + id + "'");
            foreach(DataRow item in data.Rows)
            {
                staff = new Staff(item);
                return staff;
            }
            return staff;
        }

        public static List<Staff> GetStaff()
        {
            List<Staff> staffList = new List<Staff>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM NHANVIEN");
            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                staffList.Add(staff);
            }
            return staffList;
        }

        public static DataTable GetListStaff()
        {
            return DataProvider.Instance.ExcuteQuery("EXEC USP_GetStaff");
        }

        public static DataTable SearchStaffByName (string name)
        {
            string query = "USP_SearchStaff @tennv";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { name });
            return data;
        }
    }
}
