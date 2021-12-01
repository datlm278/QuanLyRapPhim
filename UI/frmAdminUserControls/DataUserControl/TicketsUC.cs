using QuanLyRapChieuPhim.DAO;
using QuanLyRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.UI.frmAdminUserControls.DataUserControl
{
    public partial class TicketsUC : UserControl
    {
        public TicketsUC()
        {
            InitializeComponent();
            LoadAllListShowTimes();
        }

        #region Method
        void LoadAllListShowTimes()
        {
            lsvAllListShowTimes.Items.Clear();
            List<ShowTimes> showTimes_list = ShowTimesDAO.GetAllListShowTimes();

            foreach (ShowTimes showTimes in showTimes_list)
            {
                ListViewItem listViewItem = new ListViewItem(showTimes.Tenphongchieu);
                listViewItem.SubItems.Add(showTimes.Tenphim);
                listViewItem.SubItems.Add(showTimes.Thoigianchieu.ToString("HH:mm:ss dd/MM/yyyy"));
                listViewItem.Tag = showTimes;

                if (showTimes.Trangthai == "Đã tạo")
                {
                    listViewItem.SubItems.Add("Đã tạo");
                }
                else
                {
                    listViewItem.SubItems.Add("Chưa tạo");
                }
                lsvAllListShowTimes.Items.Add(listViewItem);
            }

        }
        void LoadTicketsByShowTimes(string showTimes_id)
        {
            try
            {
                List<Ticket> tickets_list = TicketDAO.GetListTicketsByShowTimes(showTimes_id);
                dtgvTicket.DataSource = tickets_list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        void LoadTicketsBought(string showTimes_id)
        {
            List<Ticket> tickets_list = TicketDAO.GetListTicketsBoughtByShowTimes(showTimes_id);
            dtgvTicket.DataSource = tickets_list;
        }
        void AutoCreateTickets(ShowTimes showTimes)
        {
            int result = 0;
            Cinema cinema = CinemaDAO.GetCinemaByName(showTimes.Tenphongchieu);
            int Row = cinema.SoHang;
            int Column = cinema.SoGheMotHang;

            for (int i = 0; i < Row; i++)
            {
                int temp = i + 65;
                char row_name = (char)(temp);
                for (int j = 1; j <= Column; j++)
                {
                    try
                    {
                        string seat_name = row_name.ToString() + j;
                        result += TicketDAO.InsertTicketByShowTimes(showTimes.Maxuatchieu, seat_name);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            if (result == Row * Column)
            {
                try
                {
                    int update = ShowTimesDAO.UpdateStatusShowTimes(showTimes.Maxuatchieu, "Đã tạo");
                    if (update > 0)
                    {
                        MessageBox.Show("TẠO VÉ THÀNH CÔNG", "THÔNG BÁO");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("TẠO VÉ THẤT BẠI", "THÔNG BÁO");
            }
        }
        void loadListShowTimesNotCreateTicket()
        {
            lsvAllListShowTimes.Items.Clear();

            List<ShowTimes> showTimes_list = ShowTimesDAO.GetListShowTimesNotCreateTickets();

            foreach (ShowTimes showTimes in showTimes_list)
            {
                ListViewItem listViewItem = new ListViewItem(showTimes.Tenphongchieu);
                listViewItem.SubItems.Add(showTimes.Tenphim);
                listViewItem.SubItems.Add(showTimes.Thoigianchieu.ToString("HH:mm:ss dd/MM/yyyy"));
                listViewItem.Tag = showTimes;

                if (showTimes.Trangthai == "Đã tạo")
                {
                    listViewItem.SubItems.Add("Đã tạo");
                }
                else
                {
                    listViewItem.SubItems.Add("Chưa Tạo");
                }
                lsvAllListShowTimes.Items.Add(listViewItem);
            }
        }

        void DeleteTickets(ShowTimes showTimes)
        {
            Cinema cinema = CinemaDAO.GetCinemaByName(showTimes.Tenphongchieu);
            int Row = cinema.SoHang;
            int Column = cinema.SoGheMotHang;
            int result = TicketDAO.DeleteTickets(showTimes.Maxuatchieu);
            if (result == Row * Column)
            {
                try
                {
                    int update = ShowTimesDAO.UpdateStatusShowTimes(showTimes.Maxuatchieu, "Chưa tạo");
                    if (update > 0)
                        MessageBox.Show("XÓA TẤT CẢ CÁC VÉ CỦA LỊCH CHIẾU CÓ MÃ " + showTimes.Maxuatchieu + " THÀNH CÔNG!", "THÔNG BÁO");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
                MessageBox.Show("XÓA TẤT CẢ CÁC VÉ CỦA LỊCH CHIẾU CÓ MÃ " + showTimes.Maxuatchieu + " THẤT BẠI!", "THÔNG BÁO");
        }
        #endregion

        #region Event
        private void btnAddTicketsByShowTime_Click(object sender, EventArgs e)
        {
            if (lsvAllListShowTimes.SelectedItems.Count > 0)
            {
                try
                {
                    ShowTimes showTimes = lsvAllListShowTimes.SelectedItems[0].Tag as ShowTimes;
                    if (showTimes.Trangthai == "Đã tạo")
                    {
                        MessageBox.Show("LỊCH CHIẾU NÀY ĐÃ ĐƯỢC TẠO VÉ!!!", "THÔNG BÁO");
                        return;
                    }
                    AutoCreateTickets(showTimes);
                    LoadAllListShowTimes();
                    LoadTicketsByShowTimes(showTimes.Maxuatchieu);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("BẠN CHƯA CHỌN LỊCH CHIẾU ĐỂ TẠO!!!", "THÔNG BÁO");
            }
        }

        private void btnDeleteTicketsByShowTime_Click(object sender, EventArgs e)
        {
            if (lsvAllListShowTimes.SelectedItems.Count > 0)
            {
                try
                {
                    ShowTimes showTimes = lsvAllListShowTimes.SelectedItems[0].Tag as ShowTimes;
                    if (showTimes.Trangthai == "Chưa tạo")
                    {
                        MessageBox.Show("LỊCH CHIẾU NÀY CHƯA ĐƯỢC TẠO VÉ!!!", "THÔNG BÁO");
                        return;
                    }
                    DialogResult dialog;
                    dialog = MessageBox.Show("Bạn có chắc chắn muốn xoá tất cả vé của lịch chiếu mã " + showTimes.Maxuatchieu + " không?", "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ;
                    if (dialog == DialogResult.Yes)
                    {
                        DeleteTickets(showTimes);
                        LoadAllListShowTimes();
                        LoadTicketsByShowTimes(showTimes.Maxuatchieu);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("BẠN CHƯA CHỌN LỊCH CHIẾU ĐỂ XÓA!!!", "THÔNG BÁO");
            }
        }

        private void btnShowAllTicketsBoughtByShowTime_Click(object sender, EventArgs e)
        {
            if (lsvAllListShowTimes.SelectedItems.Count > 0)
            {
                ShowTimes showTimes = lsvAllListShowTimes.SelectedItems[0].Tag as ShowTimes;
                LoadTicketsBought(showTimes.Maxuatchieu);
            }
            else
            {
                MessageBox.Show("BẠN CHƯA CHỌN LỊCH CHIẾU ĐỂ XEM!!!", "THÔNG BÁO");
            }
        }

        private void btnShowAllTicketsByShowTime_Click(object sender, EventArgs e)
        {
            if (lsvAllListShowTimes.SelectedItems.Count > 0)
            {
                ShowTimes showTimes = lsvAllListShowTimes.SelectedItems[0].Tag as ShowTimes;
                LoadTicketsByShowTimes(showTimes.Maxuatchieu);
            }
            else
            {
                MessageBox.Show("BẠN CHƯA CHỌN LỊCH CHIẾU ĐỂ XEM!!!", "THÔNG BÁO");
            }
        }

        private void btnShowShowTimeNotCreateTickets_Click(object sender, EventArgs e)
        {
            loadListShowTimesNotCreateTicket();
        }

        private void btnAllListShowTimes_Click(object sender, EventArgs e)
        {
            LoadAllListShowTimes();
        }
        private void lsvAllListShowTimes_Click(object sender, EventArgs e)
        {
            if (lsvAllListShowTimes.SelectedItems.Count > 0)
            {
                ShowTimes showTimes = lsvAllListShowTimes.SelectedItems[0].Tag as ShowTimes;
                LoadTicketsByShowTimes(showTimes.Maxuatchieu);
            }
        }
        #endregion


    }
}
