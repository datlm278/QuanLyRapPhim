using QuanLyRapChieuPhim.DAO;
using QuanLyRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.UI
{
    public partial class FormTheatre : Form
    {
        int SIZE = 30;//Size của ghế
        int GAP = 7;//Khoảng cách giữa các ghế

        List<Ticket> listSeat = new List<Ticket>();

        //dùng lưu vết các Ghế đang chọn
        List<Button> listSeatSelected = new List<Button>();

        float displayPrice = 0;//Hiện thị giá vé
        float ticketPrice = 0;//Lưu giá vé gốc
        float total = 0;//Tổng giá tiền
        float discount = 0;//Tiền được giảm
        float payment = 0;//Tiền phải trả
        int plusPoint = 0;//Số điểm tích lũy khi mua vé

        Customer customer; //lưu lại khách hàng thành viên

        ShowTimes Times;
        Movie Movie;
        public FormTheatre(ShowTimes showTimes, Movie movie)
        {
            InitializeComponent();
            Times = showTimes;
            Movie = movie;
        }


        #region Method
        private void LoadSeats (List<Ticket> list)
        {
            flpSeat.Controls.Clear();
            for(int i= 0; i< list.Count; i++)
            {
                Button btnSeat = new Button()
                {
                    Width = SIZE + 20,
                    Height = SIZE
                };
                btnSeat.Text = list[i].MaGheNgoi;
                if (list[i].TrangThai == "Đã bán")
                {
                    btnSeat.BackColor = Color.Red;
                }
                else
                {
                    btnSeat.BackColor = Color.White;
                }
                btnSeat.Click += BtnSeat_Click;
                flpSeat.Controls.Add(btnSeat);

                btnSeat.Tag = list[i];
            }
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btnSeat = sender as Button;
            if (btnSeat.BackColor == Color.White)
            {
                grpLoaiVe.Enabled = true;
                rdoAdult.Checked = true;

                btnSeat.BackColor = Color.Yellow;
                Ticket ticket = btnSeat.Tag as Ticket;

                ticket.GiaVe = ticketPrice;
                displayPrice = ticket.GiaVe;
                total += ticketPrice;
                payment = total - discount;
                ticket.LoaiVe = 1;
                listSeatSelected.Add(btnSeat);
                plusPoint++;
                lblPlusPoint.Text = plusPoint + "";
            }
            else if (btnSeat.BackColor ==  Color.Yellow)
            {
                btnSeat.BackColor = Color.White;
                Ticket ticket = btnSeat.Tag as Ticket;

                total -= ticket.GiaVe;
                payment = total - discount;
                ticket.GiaVe = 0;
                displayPrice = ticket.GiaVe;
                ticket.LoaiVe = 0;

                listSeatSelected.Remove(btnSeat);
                plusPoint--;
                lblPlusPoint.Text = plusPoint + "";

                if (listSeatSelected.Count == 0)
                {
                    grpLoaiVe.Enabled = false;
                }
 
            }
            else if (btnSeat.BackColor == Color.Red)
            {
                MessageBox.Show("Ghế mã [" + btnSeat.Text.Trim() + "] đã có người chọn! Mời bạn chọn ghế khác");
            }
            LoadBill();
            if (listSeatSelected.Count > 0)
            {
                chkCustomer.Enabled = true;
            }
            else
            {
                chkCustomer.Enabled = false;
            }
        }

        private void LoadBill()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            //Đổi culture vùng quốc gia để đổi đơn vị tiền tệ 

            //Thread.CurrentThread.CurrentCulture = culture;
            //dùng thread để chuyển cả luồng đang chạy về vùng quốc gia đó

            lblTicketPrice.Text = displayPrice.ToString("c", culture);
            lblTotal.Text = total.ToString("c", culture);
            lblDiscount.Text = discount.ToString("c", culture);
            lblPayment.Text = payment.ToString("c", culture);

            //Đổi đơn vị tiền tệ
            //gán culture chỗ này thì chỉ có chỗ này sd culture này còn
            //lại sài mặc định
        }
        private void LoadDataCinema(string cinemaName)
        {
            Cinema cinema = CinemaDAO.GetCinemaByName(cinemaName);
            int Row = cinema.SoHang;
            int Column = cinema.SoGheMotHang;
            flpSeat.Size = new Size((SIZE + 20 + GAP) * Column, (SIZE + GAP) * Row);
        }

        private void label_point()
        {
            if (chkCustomer.Checked == true)
            {
                pnCustomer.Visible = true;
            }
            else
            {
                pnCustomer.Visible = false;
            }
        }

        private void Reset()
        {
            listSeatSelected.Clear();

            rdoAdult.Checked = true;
            grpLoaiVe.Enabled = false;
            chkCustomer.Checked = false;
            chkCustomer.Enabled = false;

            label_point();

            total = 0;
            displayPrice = 0;
            discount = 0;
            payment = 0;
            plusPoint = 0;

            LoadBill();

        }

        #endregion

        #region Event
        private void FormTheatre_Load(object sender, EventArgs e)
        {
            ticketPrice = Times.GiaVe;

            lblInformation.Text = "CGV Hung Vuong | " + Times.Tenphongchieu + " | " + Times.Tenphim;
            lblTime.Text = Times.Thoigianchieu.ToShortDateString() + " | "
                + Times.Thoigianchieu.ToShortTimeString() + " - "
                + Times.Thoigianchieu.AddMinutes(Movie.ThoiLuong).ToShortTimeString();

            if (Movie.Poster != null)
            {
                picFilm.Image = MovieDAO.byteArrayToImage(Movie.Poster);
            }

            rdoAdult.Checked = true;
            chkCustomer.Enabled = false;
            grpLoaiVe.Enabled = false;

            LoadDataCinema(Times.Tenphongchieu);

            label_point();

            listSeat = TicketDAO.GetListTicketsByShowTimes(Times.Maxuatchieu);

            LoadSeats(listSeat);

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            string message = "Bạn có chắc chắn muốn mua những vé: \n";
            if (listSeatSelected.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé trước khi thanh toán!", "Thông báo");
                return;
            }
            foreach (Button button in listSeatSelected)
            {
                message += "[" + button.Text.Trim() + "] ";
            }
            message += " \nKhông";
            DialogResult dialog;
            dialog = MessageBox.Show(message, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        
            if (dialog == DialogResult.OK)
            {
                int result = 0;
                if (chkCustomer.Checked == true)
                {
                    foreach (Button button in listSeatSelected)
                    {
                        try
                        {
                            Ticket ticket = button.Tag as Ticket;
                            result += TicketDAO.BuyTicketCustomer(ticket.MaVe, ticket.LoaiVe, customer.MaKH, ticket.GiaVe);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                    customer.DiemTL += plusPoint;
                    try
                    {
                        CustomerDAO.UpdatePointCustomer(customer.MaKH, customer.DiemTL);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);

                    }
                }
                else
                {
                    foreach (Button button in listSeatSelected)
                    {
                        try
                        {
                            Ticket ticket = button.Tag as Ticket;
                            result += TicketDAO.BuyTicketNormal(ticket.MaVe, ticket.LoaiVe, ticket.GiaVe);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);

                        }
                    }
                }
                if (result == listSeatSelected.Count)
                {
                    MessageBox.Show("Bạn đã mua vé thành công!", "Thông báo");
                }
                Reset();
                this.OnLoad(new EventArgs());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có chắc chắn huỷ tất cả những chỗ đã chọn không?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                foreach(Button btn in listSeatSelected)
                {
                    btn.BackColor = Color.White;
                }
                Reset();
                this.OnLoad(new EventArgs());
            }
            else
            {
                return;
            }
        }
        private void rdoAdult_Click(object sender, EventArgs e)
        {
            if (rdoAdult.Checked == true)
            {
                if (listSeatSelected.Count != 0)
                {
                    Ticket ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ticket;
                    ticket.LoaiVe = 1;

                    float current_price = ticket.GiaVe;
                    ticket.GiaVe = ticketPrice;
                    displayPrice = ticket.GiaVe;
                    total = total + ticket.GiaVe - current_price;

                    payment = total - discount;

                }
                else
                {
                    return;
                }
                LoadBill();
            }
        }

        private void rdoStudent_Click(object sender, EventArgs e)
        {
            if (rdoStudent.Checked == true)
            {
                if (listSeatSelected.Count != 0)
                {
                    Ticket ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ticket;
                    ticket.LoaiVe = 2;

                    float oldPrice = ticket.GiaVe;
                    ticket.GiaVe = 0.8f * ticketPrice;
                    displayPrice = ticket.GiaVe;
                    total = total + ticket.GiaVe - oldPrice;
                    payment = total - discount;
                }
                else
                {
                    return;
                }
            }
            LoadBill();
        }

        private void rdoChild_Click(object sender, EventArgs e)
        {
            if (rdoChild.Checked == true)
            {
                if (listSeatSelected.Count != 0)
                {
                    Ticket ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ticket;
                    ticket.LoaiVe = 3;

                    float oldPrice = ticket.GiaVe;
                    ticket.GiaVe = 0.7f * ticketPrice;
                    displayPrice = ticket.GiaVe;
                    total = total + ticket.GiaVe - oldPrice;
                    payment = total - discount;
                }
                else
                    return;
            }
            LoadBill();
        }

        private void btnFreeTicket_Click(object sender, EventArgs e)
        {
            int freeTickets = (int)numericFreeTickets.Value;
            if (freeTickets <= 0)
            {
                return;
            }
            if (freeTickets > listSeat.Count)
            {
                MessageBox.Show("BẠN CHỈ ĐỔI ĐƯỢC TỐI ĐA " + listSeatSelected.Count + " VÉ", "Thông báo");
                return;
            }
            int pointFreeTicket = freeTickets * 20;
            if (customer.DiemTL < pointFreeTicket)
            {
                MessageBox.Show("BẠN KHÔNG ĐỦ ĐIỂM TÍCH LUỸ ĐỂ ĐỔI " + freeTickets + " VÉ", "Thông báo");
                return;
            }
            else
            {
                DialogResult dialog;
                dialog = MessageBox.Show("BẠN CÓ MUỐN DÙNG ĐIỂM TÍCH LUỸ ĐỂ ĐỔI " + freeTickets + " VÉ MIỄN PHÍ KHÔNG?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    customer.DiemTL -= pointFreeTicket;
                    plusPoint -= freeTickets;

                    if(CustomerDAO.UpdatePointCustomer(customer.MaKH, customer.DiemTL))
                    {
                        MessageBox.Show("BẠN ĐÃ ĐỔI THÀNH CÔNG " + freeTickets + " VÉ", "THÔNG BÁO");
                    }
                    lblPoint.Text = "" + customer.DiemTL;
                    lblPlusPoint.Text = "" + plusPoint;

                    for (int i= 0; i< listSeatSelected.Count && freeTickets > 0; i++)
                    {
                        Ticket ticket = listSeatSelected[i].Tag as Ticket;
                        if (ticket.GiaVe != 0)
                        {
                            discount += ticket.GiaVe;
                            ticket.GiaVe = 0;
                            freeTickets--;
                        }
                    }
                }
                payment = total - discount;
                LoadBill();
            }

        }
        private void chkCustomer_Click(object sender, EventArgs e)
        {
            if (chkCustomer.Checked == true)
            {
                FormCustomer f = new FormCustomer();
                if (f.ShowDialog() ==  DialogResult.OK)
                {
                    customer = f.customer;
                    lblCustomerName.Text = customer.TenKH;
                    lblPoint.Text = customer.DiemTL + "";
                    label_point();
                }
                else
                {
                    chkCustomer.Checked = false;
                }
            }
            else
            {
                label_point();
                customer = null;
            }
        }

        #endregion


    }
}
