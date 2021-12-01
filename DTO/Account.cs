using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DTO
{
    class Account
    {


        public Account(string maTK, string tenTaiKhoan, string matKhau, string maVaiTro)
        {
            MaTK = maTK;
            TenTaiKhoan = tenTaiKhoan;
            MatKhau = matKhau;
            MaVaiTro = maVaiTro;
        }

        public Account(DataRow row)
        {
            this.MaTK = row["MaTK"].ToString();
            this.TenTaiKhoan = row["TenTaiKhoan"].ToString();
            this.MatKhau = row["MatKhau"].ToString();
            this.MaVaiTro = row["MaVaiTro"].ToString();
        }

        public string MaTK { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string MaVaiTro { get; set; }
    }
}
