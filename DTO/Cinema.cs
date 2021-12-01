using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DTO
{
    public class Cinema
    {
        public Cinema(string maPhongChieu, string tenPhongChieu, string maMH, string trangThai,
            int soGheNgoi, int soHang, int soGheMotHang)
        {
            MaPhongChieu = maPhongChieu;
            TenPhongChieu = tenPhongChieu;
            MaMH = maMH;
            TrangThai = trangThai;
            SoGheNgoi = soGheNgoi;
            SoHang = soHang;
            SoGheMotHang = soGheMotHang;
        }

        public Cinema(DataRow row)
        {
            this.MaPhongChieu = row["MaPhongChieu"].ToString();
            this.TenPhongChieu = row["TenPhongChieu"].ToString();
            this.MaMH = row["MaMH"].ToString();
            this.SoGheNgoi = (int)row["SoChoNgoi"];
            this.SoHang = (int)row["HangGhe"];
            this.SoGheMotHang = (int)row["SoGheMotHang"];
            this.TrangThai = row["TinhTrang"].ToString();
        }

        public string MaPhongChieu { get; }
        public string TenPhongChieu { get; }
        public string MaMH { get; }
        public string TrangThai { get; }
        public int SoGheNgoi { get; }
        public int SoHang { get; }
        public int SoGheMotHang { get; }
    }
}
