using QuanLyRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DAO
{
    public class TicketDAO
    {
        public static List<Ticket> GetListTicketsByShowTimes(string showTimesID)
        {
            List<Ticket> listTicket = new List<Ticket>();
            string query = "SELECT * FROM VE WHERE MaXuatChieu = '" + showTimesID + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Ticket ticket = new Ticket(row);
                listTicket.Add(ticket);
            }
            return listTicket;
        }
        public static List<Ticket> GetListTicketsBoughtByShowTimes(string showTimesID)
        {
            List<Ticket> listTicket = new List<Ticket>();
            string query = "SELECT * FROM VE WHERE MaXuatChieu = '" + showTimesID + "' and TrangThai = N'Đã bán'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Ticket ticket = new Ticket(row);
                listTicket.Add(ticket);
            }
            return listTicket;
        }
        public static int InsertTicketByShowTimes(string showTimesID, string seatName)
        {
            string query = "USP_InsertTicketByShowTimes @idlichChieu , @maGheNgoi";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { showTimesID, seatName });
        }
        public static int CountToltalTicketByShowTime(string showTimesID)
        {
            string query = "Select count (MaVe) from VE where MaXuatChieu ='" + showTimesID + "'";
            return (int)DataProvider.Instance.ExcuteScalar(query);
        }
        public static int CountTheNumberOfTicketsSoldByShowTime(string showTimesID)
        {
            string query = "Select count (MaVe) from VE where MaXuatChieu ='" + showTimesID + "' and TrangThai = N'Đã bán' ";
            return (int)DataProvider.Instance.ExcuteScalar(query);
        }
    
        public static int BuyTicketCustomer(string mave, int loaiVe, string makh, float giaVe)
        {
            string query = "USP_BuyTicketCustomer @mave , @loaiVe , @makh , @giave";
            int data = DataProvider.Instance.ExcuteNonQuery(query, new object[] { mave, loaiVe, makh, giaVe });
            return data;
        }

        public static int BuyTicketNormal(string mave, int loaiVe, float giaVe)
        {
            string query = "USP_BuyTicketNormal @mave , @loaiVe , @giave";
            int data = DataProvider.Instance.ExcuteNonQuery(query, new object[] { mave, loaiVe, giaVe });
            return data;
        }
        public static int DeleteTickets(string showTimesID)
        {
            string query = "USP_DeleteTickets @maxc";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { showTimesID });
        }
    }
        
}
