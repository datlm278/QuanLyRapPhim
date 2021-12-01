using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DTO
{
    public class Movie
    {
        public Movie(string maPhim, string tenPhim, float thoiLuong
            , DateTime ngayKhoiChieu, DateTime ngayKetThuc, string nhaSanXuat
            , string daoDien, DateTime namSanXuat, byte[] poster)
        {
            this.MaPhim = MaPhim;
            this.TenPhim = tenPhim;
            this.ThoiLuong = thoiLuong;
            this.NgayKhoiChieu = ngayKhoiChieu;
            this.NgayKetThuc = ngayKetThuc;
            this.NhaSanXuat = nhaSanXuat;
            this.DaoDien = daoDien;
            this.NamSanXuat = namSanXuat;
            this.Poster = poster;
        }

        public Movie(DataRow row)
        {
            this.MaPhim = row["MaPhim"].ToString();
            this.TenPhim = row["TenPhim"].ToString();
            this.ThoiLuong = float.Parse(row["ThoiLuong"].ToString());
            this.NgayKhoiChieu = (DateTime)row["NgayKhoiChieu"];
            this.NgayKetThuc = (DateTime)row["NgayKetThuc"];
            this.NhaSanXuat = row["NhaSanXuat"].ToString();
            this.DaoDien = row["DaoDien"].ToString();
            this.NamSanXuat = (DateTime)row["NamSX"];
            if (row["Poster"].ToString() == "")
                this.Poster = null;
            else
                this.Poster = (byte[])row["Poster"];
        }

        public string MaPhim { get; set; }

        public string TenPhim { get; set; }

        public float ThoiLuong { get; set; }

        public DateTime NgayKhoiChieu { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public string NhaSanXuat { get; set; }

        public DateTime NamSanXuat { get; set; }

        public string DaoDien { get; set; }

        public byte[] Poster { get; set; }
    }
}
