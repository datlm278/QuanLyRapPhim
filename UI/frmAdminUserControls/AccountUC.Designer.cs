
namespace QuanLyRapChieuPhim.UI.frmAdminUserControls
{
    partial class AccountUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblUsername = new System.Windows.Forms.Label();
            this.dtgvAccount = new System.Windows.Forms.DataGridView();
            this.btnSearchAccount = new System.Windows.Forms.Button();
            this.txtSearchAccount = new System.Windows.Forms.TextBox();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.btnUpdateAccount = new System.Windows.Forms.Button();
            this.btnInsertAccount = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.btnShowAccount = new System.Windows.Forms.Button();
            this.grpAccount = new System.Windows.Forms.GroupBox();
            this.cboAccountType = new System.Windows.Forms.ComboBox();
            this.txbAccountId = new System.Windows.Forms.TextBox();
            this.txtAccount_Role = new System.Windows.Forms.TextBox();
            this.lblAccountId = new System.Windows.Forms.Label();
            this.lblAccount_Role = new System.Windows.Forms.Label();
            this.toolTipAccountType = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).BeginInit();
            this.grpAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(43, 41);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(114, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Tên tài khoản:";
            // 
            // dtgvAccount
            // 
            this.dtgvAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvAccount.Location = new System.Drawing.Point(118, 229);
            this.dtgvAccount.Name = "dtgvAccount";
            this.dtgvAccount.Size = new System.Drawing.Size(851, 361);
            this.dtgvAccount.TabIndex = 28;
            // 
            // btnSearchAccount
            // 
            this.btnSearchAccount.Location = new System.Drawing.Point(894, 186);
            this.btnSearchAccount.Name = "btnSearchAccount";
            this.btnSearchAccount.Size = new System.Drawing.Size(75, 37);
            this.btnSearchAccount.TabIndex = 27;
            this.btnSearchAccount.Text = "Tìm";
            this.btnSearchAccount.UseVisualStyleBackColor = true;
            this.btnSearchAccount.Click += new System.EventHandler(this.btnSearchAccount_Click);
            // 
            // txtSearchAccount
            // 
            this.txtSearchAccount.Location = new System.Drawing.Point(771, 191);
            this.txtSearchAccount.Name = "txtSearchAccount";
            this.txtSearchAccount.Size = new System.Drawing.Size(117, 27);
            this.txtSearchAccount.TabIndex = 26;
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(652, 186);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(75, 37);
            this.btnDeleteAccount.TabIndex = 24;
            this.btnDeleteAccount.Text = "Xoá";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // btnUpdateAccount
            // 
            this.btnUpdateAccount.Location = new System.Drawing.Point(554, 186);
            this.btnUpdateAccount.Name = "btnUpdateAccount";
            this.btnUpdateAccount.Size = new System.Drawing.Size(75, 37);
            this.btnUpdateAccount.TabIndex = 23;
            this.btnUpdateAccount.Text = "Sửa";
            this.btnUpdateAccount.UseVisualStyleBackColor = true;
            this.btnUpdateAccount.Click += new System.EventHandler(this.btnUpdateAccount_Click);
            // 
            // btnInsertAccount
            // 
            this.btnInsertAccount.Location = new System.Drawing.Point(457, 186);
            this.btnInsertAccount.Name = "btnInsertAccount";
            this.btnInsertAccount.Size = new System.Drawing.Size(75, 37);
            this.btnInsertAccount.TabIndex = 22;
            this.btnInsertAccount.Text = "Thêm";
            this.btnInsertAccount.UseVisualStyleBackColor = true;
            this.btnInsertAccount.Click += new System.EventHandler(this.btnInsertAccount_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(176, 38);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(118, 27);
            this.txtUsername.TabIndex = 4;
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(43, 105);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(118, 20);
            this.lblAccountType.TabIndex = 2;
            this.lblAccountType.Text = "Loại tài khoản:";
            // 
            // btnShowAccount
            // 
            this.btnShowAccount.Location = new System.Drawing.Point(118, 186);
            this.btnShowAccount.Name = "btnShowAccount";
            this.btnShowAccount.Size = new System.Drawing.Size(75, 37);
            this.btnShowAccount.TabIndex = 21;
            this.btnShowAccount.Text = "Xem";
            this.btnShowAccount.UseVisualStyleBackColor = true;
            this.btnShowAccount.Click += new System.EventHandler(this.btnShowAccount_Click);
            // 
            // grpAccount
            // 
            this.grpAccount.Controls.Add(this.cboAccountType);
            this.grpAccount.Controls.Add(this.txbAccountId);
            this.grpAccount.Controls.Add(this.txtAccount_Role);
            this.grpAccount.Controls.Add(this.txtUsername);
            this.grpAccount.Controls.Add(this.lblAccountId);
            this.grpAccount.Controls.Add(this.lblAccountType);
            this.grpAccount.Controls.Add(this.lblAccount_Role);
            this.grpAccount.Controls.Add(this.lblUsername);
            this.grpAccount.Location = new System.Drawing.Point(118, 24);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(609, 156);
            this.grpAccount.TabIndex = 20;
            this.grpAccount.TabStop = false;
            this.grpAccount.Text = "Thông tin tài khoản:";
            // 
            // cboAccountType
            // 
            this.cboAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountType.FormattingEnabled = true;
            this.cboAccountType.Location = new System.Drawing.Point(176, 102);
            this.cboAccountType.Name = "cboAccountType";
            this.cboAccountType.Size = new System.Drawing.Size(118, 28);
            this.cboAccountType.TabIndex = 29;
            // 
            // txbAccountId
            // 
            this.txbAccountId.Location = new System.Drawing.Point(434, 38);
            this.txbAccountId.Name = "txbAccountId";
            this.txbAccountId.Size = new System.Drawing.Size(98, 27);
            this.txbAccountId.TabIndex = 4;
            // 
            // txtAccount_Role
            // 
            this.txtAccount_Role.Location = new System.Drawing.Point(434, 102);
            this.txtAccount_Role.Name = "txtAccount_Role";
            this.txtAccount_Role.Size = new System.Drawing.Size(98, 27);
            this.txtAccount_Role.TabIndex = 4;
            this.txtAccount_Role.TextChanged += new System.EventHandler(this.txtAccount_Role_TextChanged);
            // 
            // lblAccountId
            // 
            this.lblAccountId.AutoSize = true;
            this.lblAccountId.Location = new System.Drawing.Point(332, 41);
            this.lblAccountId.Name = "lblAccountId";
            this.lblAccountId.Size = new System.Drawing.Size(63, 20);
            this.lblAccountId.TabIndex = 1;
            this.lblAccountId.Text = "Mã TK:";
            // 
            // lblAccount_Role
            // 
            this.lblAccount_Role.AutoSize = true;
            this.lblAccount_Role.Location = new System.Drawing.Point(332, 105);
            this.lblAccount_Role.Name = "lblAccount_Role";
            this.lblAccount_Role.Size = new System.Drawing.Size(93, 20);
            this.lblAccount_Role.TabIndex = 1;
            this.lblAccount_Role.Text = "Mã vai trò :";
            // 
            // AccountUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtgvAccount);
            this.Controls.Add(this.btnSearchAccount);
            this.Controls.Add(this.txtSearchAccount);
            this.Controls.Add(this.btnDeleteAccount);
            this.Controls.Add(this.btnUpdateAccount);
            this.Controls.Add(this.btnInsertAccount);
            this.Controls.Add(this.btnShowAccount);
            this.Controls.Add(this.grpAccount);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AccountUC";
            this.Size = new System.Drawing.Size(1086, 614);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).EndInit();
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.DataGridView dtgvAccount;
        private System.Windows.Forms.Button btnSearchAccount;
        private System.Windows.Forms.TextBox txtSearchAccount;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Button btnUpdateAccount;
        private System.Windows.Forms.Button btnInsertAccount;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.Button btnShowAccount;
        private System.Windows.Forms.GroupBox grpAccount;
        private System.Windows.Forms.Label lblAccount_Role;
        private System.Windows.Forms.ToolTip toolTipAccountType;
        private System.Windows.Forms.ComboBox cboAccountType;
        private System.Windows.Forms.TextBox txtAccount_Role;
        private System.Windows.Forms.TextBox txbAccountId;
        private System.Windows.Forms.Label lblAccountId;
    }
}
