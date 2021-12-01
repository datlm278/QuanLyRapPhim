using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DTO
{
    public class Staff
    {
        public Staff(string maNV, string tenNV, string gioiTinh, DateTime ngaySinh, string soDT, string diaChi, string maTK, string maCV)
        {
            MaNV = maNV;
            TenNV = tenNV;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            SoDT = soDT;
            DiaChi = diaChi;
            MaTK = maTK;
            MaCV = maCV;
        }

        public Staff(DataRow row)
        {
            this.MaNV = row["MaNhanVien"].ToString();
            this.TenNV = row["TenNhanVien"].ToString();
            this.GioiTinh = row["GioiTinh"].ToString();
            this.NgaySinh = DateTime.Parse(row["NgaySinh"].ToString());
            this.SoDT = row["SoDT"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.MaTK = row["MaTK"].ToString();
            this.MaCV = row["MaChucVu"].ToString();
        }

        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoDT { get; set; }
        public string DiaChi { get; set; }
        public string MaTK { get; set; }
        public string MaCV { get; set; }
    }
}
