using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DTO
{
    public class FormatMovie
    {
        public FormatMovie(string maxuatchieu, string maphim, string tenphim, string loaiMH, string maMH)  
        {
            Maxuatchieu = maxuatchieu;
            Maphim = maphim;
            Tenphim = tenphim;
            LoaiMH = loaiMH;
            MaMH = maMH;
        }

        public FormatMovie(DataRow row) 
        {
            this.Maxuatchieu = row["MaXuatChieu"].ToString();
            this.MaMH = row["MaMH"].ToString();
            this.Maphim = row["Maphim"].ToString();
            this.Tenphim = row["TenPhim"].ToString();
            this.LoaiMH = row["LoaiMH"].ToString();

        }

        public string Maxuatchieu { get; set; }
        public string Maphim { get; set; }
        public string Tenphim { get; set; }
        public string LoaiMH { get; set; }
        public string MaMH { get; set; }
    }
}
