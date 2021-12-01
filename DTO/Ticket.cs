using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DTO
{
    public class Ticket
    {
        public Ticket(string maVe, int loaiVe, string maXuatChieu, string maGheNgoi, string maKH, float giaVe, string trangThai)
        {
            MaVe = maVe;
            LoaiVe = loaiVe;
            MaXuatChieu = maXuatChieu;
            MaGheNgoi = maGheNgoi;
            MaKH = maKH;
            GiaVe = giaVe;
            TrangThai = trangThai;
        }

        public Ticket(DataRow row)
        {
            this.MaVe = row["MaVe"].ToString();
            this.LoaiVe = (int)row["LoaiVe"];
            this.MaXuatChieu = row["MaXuatChieu"].ToString();
            this.MaGheNgoi = row["MaGheNgoi"].ToString();
            this.MaKH = row["MaKH"].ToString();
            this.TrangThai = row["TrangThai"].ToString();
            if (row["GiaVe"].ToString() == "")
            {
                this.GiaVe = 0;
            }
            else
                this.GiaVe = float.Parse(row["GiaVe"].ToString());
        }

        public string MaVe { get; set; }
        public int LoaiVe { get; set; }
        public string MaXuatChieu { get; set; }
        public string MaGheNgoi { get; set; }
        public string MaKH { get; set; }
        public float GiaVe { get; set; }
        public string TrangThai { get; set; }
    }
}
