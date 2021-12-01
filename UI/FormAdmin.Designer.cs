
namespace QuanLyRapChieuPhim.UI
{
    partial class FormAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnAdmin = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAccountUC = new System.Windows.Forms.Button();
            this.btnCustomerUC = new System.Windows.Forms.Button();
            this.btnStaffUC = new System.Windows.Forms.Button();
            this.btnDataUC = new System.Windows.Forms.Button();
            this.btnRevenueUC = new System.Windows.Forms.Button();
            this.btnSeller = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnAdmin
            // 
            this.pnAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnAdmin.Location = new System.Drawing.Point(0, 100);
            this.pnAdmin.Name = "pnAdmin";
            this.pnAdmin.Size = new System.Drawing.Size(1340, 620);
            this.pnAdmin.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.btnAccountUC);
            this.panel1.Controls.Add(this.btnSeller);
            this.panel1.Controls.Add(this.btnCustomerUC);
            this.panel1.Controls.Add(this.btnStaffUC);
            this.panel1.Controls.Add(this.btnDataUC);
            this.panel1.Controls.Add(this.btnRevenueUC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1343, 100);
            this.panel1.TabIndex = 3;
            // 
            // btnAccountUC
            // 
            this.btnAccountUC.Location = new System.Drawing.Point(906, 29);
            this.btnAccountUC.Name = "btnAccountUC";
            this.btnAccountUC.Size = new System.Drawing.Size(109, 39);
            this.btnAccountUC.TabIndex = 4;
            this.btnAccountUC.Text = "Tài khoản";
            this.btnAccountUC.UseVisualStyleBackColor = true;
            this.btnAccountUC.Click += new System.EventHandler(this.btnAccountUC_Click);
            // 
            // btnCustomerUC
            // 
            this.btnCustomerUC.Location = new System.Drawing.Point(720, 29);
            this.btnCustomerUC.Name = "btnCustomerUC";
            this.btnCustomerUC.Size = new System.Drawing.Size(109, 39);
            this.btnCustomerUC.TabIndex = 3;
            this.btnCustomerUC.Text = "Khách hàng";
            this.btnCustomerUC.UseVisualStyleBackColor = true;
            this.btnCustomerUC.Click += new System.EventHandler(this.btnCustomerUC_Click);
            // 
            // btnStaffUC
            // 
            this.btnStaffUC.Location = new System.Drawing.Point(541, 29);
            this.btnStaffUC.Name = "btnStaffUC";
            this.btnStaffUC.Size = new System.Drawing.Size(109, 39);
            this.btnStaffUC.TabIndex = 2;
            this.btnStaffUC.Text = "Nhân viên";
            this.btnStaffUC.UseVisualStyleBackColor = true;
            this.btnStaffUC.Click += new System.EventHandler(this.btnStaffUC_Click);
            // 
            // btnDataUC
            // 
            this.btnDataUC.Location = new System.Drawing.Point(343, 29);
            this.btnDataUC.Name = "btnDataUC";
            this.btnDataUC.Size = new System.Drawing.Size(109, 39);
            this.btnDataUC.TabIndex = 1;
            this.btnDataUC.Text = "Dữ liệu";
            this.btnDataUC.UseVisualStyleBackColor = true;
            this.btnDataUC.Click += new System.EventHandler(this.btnDataUC_Click);
            // 
            // btnRevenueUC
            // 
            this.btnRevenueUC.Location = new System.Drawing.Point(155, 29);
            this.btnRevenueUC.Name = "btnRevenueUC";
            this.btnRevenueUC.Size = new System.Drawing.Size(109, 39);
            this.btnRevenueUC.TabIndex = 0;
            this.btnRevenueUC.Text = "Doanh thu";
            this.btnRevenueUC.UseVisualStyleBackColor = true;
            this.btnRevenueUC.Click += new System.EventHandler(this.btnRevenueUC_Click);
            // 
            // btnSeller
            // 
            this.btnSeller.Location = new System.Drawing.Point(1079, 29);
            this.btnSeller.Name = "btnSeller";
            this.btnSeller.Size = new System.Drawing.Size(109, 39);
            this.btnSeller.TabIndex = 5;
            this.btnSeller.Text = "Bán vé";
            this.btnSeller.UseVisualStyleBackColor = true;
            this.btnSeller.Click += new System.EventHandler(this.btnSeller_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 720);
            this.Controls.Add(this.pnAdmin);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnAdmin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAccountUC;
        private System.Windows.Forms.Button btnCustomerUC;
        private System.Windows.Forms.Button btnStaffUC;
        private System.Windows.Forms.Button btnDataUC;
        private System.Windows.Forms.Button btnRevenueUC;
        private System.Windows.Forms.Button btnSeller;
    }
}