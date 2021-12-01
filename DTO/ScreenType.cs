using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DTO
{
    public class ScreenType
    {
        public ScreenType(string maMH, string loaiMH)
        {
            this.MaMH = maMH;
            this.LoaiMH = loaiMH;
        }

        public ScreenType(DataRow row)
        {
            this.MaMH = row["MaMH"].ToString();
            this.LoaiMH = row["LoaiMH"].ToString();
        }

        public string MaMH { get; set; }

        public string LoaiMH { get; set; }
    }
}
