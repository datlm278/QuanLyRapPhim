using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DTO
{
    public class Genre
    {
        public Genre(string maTheLoai, string tenTheLoai, string moTa = null)
        {
            this.MaTheLoai = maTheLoai;
            this.TenTheLoai = tenTheLoai;
            this.MoTa = moTa;
        }

        public Genre(DataRow row)
        {
            this.MaTheLoai = row["MaTheLoai"].ToString();
            this.TenTheLoai = row["TenTheLoai"].ToString();
            if (row["MoTa"].ToString() != "")
                this.MoTa = row["MoTa"].ToString();
            else
                this.MoTa = "";
        }

        public string MaTheLoai { get; set; }

        public string TenTheLoai { get; set; }

        public string MoTa { get; set; }
    }
}
