﻿using QuanLyRapChieuPhim.DAO;
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

namespace QuanLyRapChieuPhim.UI
{
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
        }

        public Customer customer;
        private void btnCofirm_Click(object sender, EventArgs e)
        {
            DataTable data = CustomerDAO.GetCustomerMember(txtCustomerID.Text, txtCustomerName.Text);

            if (data.Rows.Count == 0)
            {
                MessageBox.Show("ID hoặc Họ tên của Khách Hàng không chính xác!\nVui lòng nhập lại thông tin.");
                return;
            }
            customer = new Customer(data.Rows[0]);

            DialogResult = DialogResult.OK;
        }
    }
}
