using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DTO
{
    public class Position
    {


        public Position(string macv, string tencv, float luong)
        {
            Macv = macv;
            Tencv = tencv;
            Luong = luong;
        }

        public Position(DataRow row)
        {
            this.Macv = row["MaChucVu"].ToString();
            this.Tencv = row["TenChucVu"].ToString();
            this.Luong = float.Parse(row["Luong"].ToString());
        }

        public string Macv { get; set; }
        public string Tencv { get; set; }
        public float Luong { get; set; }
    }
}
