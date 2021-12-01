using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DTO
{
    public class ShowTimes
    {

        public ShowTimes(string maxuatchieu, string tenphim, string tenphongchieu, 
            DateTime thoigianchieu, float giaVe, string mamanhinh, string trangthai)
        {
            Maxuatchieu = maxuatchieu;
            Tenphim = tenphim;
            Tenphongchieu = tenphongchieu;
            Thoigianchieu = thoigianchieu;
            GiaVe = giaVe;
            Mamanhinh = mamanhinh;
            Trangthai = trangthai;
        }

        public ShowTimes(DataRow row)
        {
            this.Maxuatchieu = row["MaXuatChieu"].ToString();
            this.Tenphongchieu = row["TenPhongChieu"].ToString();
            this.Tenphim = row["TenPhim"].ToString();
            this.Thoigianchieu = DateTime.Parse(row["ThoiGianChieu"].ToString());
            this.Mamanhinh = row["MaMH"].ToString();
            if (row["GiaXuatChieu"].ToString() == "")
            {
                this.GiaVe= 0;
            }
            else
            {
                this.GiaVe= float.Parse(row["GiaXuatChieu"].ToString());
            }
            this.Trangthai = row["TrangThai"].ToString();
        }


        public string Maxuatchieu { get; set; }
        public string Tenphim { get; set; }
        public string Tenphongchieu { get; set; }
        public DateTime Thoigianchieu { get; set; }
        public float GiaVe { get; set; }
        public string Mamanhinh { get; set; }
        public string Trangthai { get; set; }
    }
}
