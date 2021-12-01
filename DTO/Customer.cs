using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DTO
{
    public class Customer
    {
        public Customer(string maKH, string tenKH, string gioiTinh, string diaChi, string soDT, string ngaySinh, string CCCD, int diemTL)
        {
            MaKH = maKH;
            TenKH = tenKH;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            SoDT = soDT;
            NgaySinh = ngaySinh;
            this.CCCD = CCCD;
            DiemTL = diemTL;
        }

        public Customer(DataRow row)
        {
            this.MaKH = row["MaKH"].ToString();
            this.TenKH = row["TenKH"].ToString();
            this.GioiTinh = row["GioiTinh"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.SoDT = row["SoDT"].ToString();
            this.NgaySinh = row["NgaySinh"].ToString();
            this.CCCD = row["CCCD"].ToString();
            this.DiemTL = (int)row["DiemTichLuy"];
        }

        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }
        public string NgaySinh { get; set; }
        public string CCCD { get; set; }
        public int DiemTL { get; set; }
    }
}
