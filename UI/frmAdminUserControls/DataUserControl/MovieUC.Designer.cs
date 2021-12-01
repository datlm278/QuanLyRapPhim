
namespace QuanLyRapChieuPhim.UI.frmAdminUserControls.DataUserControl
{
    partial class MovieUC
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnShowMovie = new System.Windows.Forms.Button();
            this.btnDeleteMovie = new System.Windows.Forms.Button();
            this.btnUpdateMovie = new System.Windows.Forms.Button();
            this.btnAddMovie = new System.Windows.Forms.Button();
            this.picFilm = new System.Windows.Forms.PictureBox();
            this.btnUpLoadPictureFilm = new System.Windows.Forms.Button();
            this.txtMovieDirector = new System.Windows.Forms.TextBox();
            this.dtmMovieEnd = new System.Windows.Forms.DateTimePicker();
            this.dtmMovieStart = new System.Windows.Forms.DateTimePicker();
            this.txtMovieProductor = new System.Windows.Forms.TextBox();
            this.txtMovieLength = new System.Windows.Forms.TextBox();
            this.clbMovieGenre = new System.Windows.Forms.CheckedListBox();
            this.txtMovieName = new System.Windows.Forms.TextBox();
            this.lblMovieYear = new System.Windows.Forms.Label();
            this.txtMovieID = new System.Windows.Forms.TextBox();
            this.dtgvMovie = new System.Windows.Forms.DataGridView();
            this.lblMovieDirector = new System.Windows.Forms.Label();
            this.lblMovieProductor = new System.Windows.Forms.Label();
            this.lblMovieEndDate = new System.Windows.Forms.Label();
            this.lblMovieStartDate = new System.Windows.Forms.Label();
            this.lblMovieLength = new System.Windows.Forms.Label();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.lblMovieID = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMovieGenre = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpkYear = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFilm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMovie)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.CausesValidation = false;
            this.panel2.Controls.Add(this.btnShowMovie);
            this.panel2.Controls.Add(this.btnDeleteMovie);
            this.panel2.Controls.Add(this.btnUpdateMovie);
            this.panel2.Controls.Add(this.btnAddMovie);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 521);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 55);
            this.panel2.TabIndex = 5;
            // 
            // btnShowMovie
            // 
            this.btnShowMovie.Location = new System.Drawing.Point(799, 18);
            this.btnShowMovie.Name = "btnShowMovie";
            this.btnShowMovie.Size = new System.Drawing.Size(75, 34);
            this.btnShowMovie.TabIndex = 31;
            this.btnShowMovie.Text = "Xem";
            this.btnShowMovie.UseVisualStyleBackColor = true;
            this.btnShowMovie.Click += new System.EventHandler(this.btnShowMovie_Click);
            // 
            // btnDeleteMovie
            // 
            this.btnDeleteMovie.Location = new System.Drawing.Point(466, 18);
            this.btnDeleteMovie.Name = "btnDeleteMovie";
            this.btnDeleteMovie.Size = new System.Drawing.Size(75, 34);
            this.btnDeleteMovie.TabIndex = 29;
            this.btnDeleteMovie.Text = "Xoá";
            this.btnDeleteMovie.UseVisualStyleBackColor = true;
            this.btnDeleteMovie.Click += new System.EventHandler(this.btnDeleteMovie_Click);
            // 
            // btnUpdateMovie
            // 
            this.btnUpdateMovie.Location = new System.Drawing.Point(635, 18);
            this.btnUpdateMovie.Name = "btnUpdateMovie";
            this.btnUpdateMovie.Size = new System.Drawing.Size(75, 34);
            this.btnUpdateMovie.TabIndex = 30;
            this.btnUpdateMovie.Text = "Sửa";
            this.btnUpdateMovie.UseVisualStyleBackColor = true;
            this.btnUpdateMovie.Click += new System.EventHandler(this.btnUpdateMovie_Click);
            // 
            // btnAddMovie
            // 
            this.btnAddMovie.Location = new System.Drawing.Point(292, 18);
            this.btnAddMovie.Name = "btnAddMovie";
            this.btnAddMovie.Size = new System.Drawing.Size(75, 34);
            this.btnAddMovie.TabIndex = 28;
            this.btnAddMovie.Text = "Thêm";
            this.btnAddMovie.UseVisualStyleBackColor = true;
            this.btnAddMovie.Click += new System.EventHandler(this.btnAddMovie_Click);
            // 
            // picFilm
            // 
            this.picFilm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFilm.Location = new System.Drawing.Point(799, 20);
            this.picFilm.Name = "picFilm";
            this.picFilm.Size = new System.Drawing.Size(146, 166);
            this.picFilm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFilm.TabIndex = 24;
            this.picFilm.TabStop = false;
            // 
            // btnUpLoadPictureFilm
            // 
            this.btnUpLoadPictureFilm.Location = new System.Drawing.Point(799, 192);
            this.btnUpLoadPictureFilm.Name = "btnUpLoadPictureFilm";
            this.btnUpLoadPictureFilm.Size = new System.Drawing.Size(146, 34);
            this.btnUpLoadPictureFilm.TabIndex = 23;
            this.btnUpLoadPictureFilm.Text = "Chọn hình ảnh";
            this.btnUpLoadPictureFilm.UseVisualStyleBackColor = true;
            this.btnUpLoadPictureFilm.Click += new System.EventHandler(this.btnUpLoadPictureFilm_Click);
            // 
            // txtMovieDirector
            // 
            this.txtMovieDirector.Location = new System.Drawing.Point(532, 152);
            this.txtMovieDirector.Name = "txtMovieDirector";
            this.txtMovieDirector.Size = new System.Drawing.Size(169, 27);
            this.txtMovieDirector.TabIndex = 21;
            // 
            // dtmMovieEnd
            // 
            this.dtmMovieEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmMovieEnd.Location = new System.Drawing.Point(532, 86);
            this.dtmMovieEnd.Name = "dtmMovieEnd";
            this.dtmMovieEnd.Size = new System.Drawing.Size(169, 27);
            this.dtmMovieEnd.TabIndex = 20;
            // 
            // dtmMovieStart
            // 
            this.dtmMovieStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmMovieStart.Location = new System.Drawing.Point(532, 53);
            this.dtmMovieStart.Name = "dtmMovieStart";
            this.dtmMovieStart.Size = new System.Drawing.Size(169, 27);
            this.dtmMovieStart.TabIndex = 19;
            // 
            // txtMovieProductor
            // 
            this.txtMovieProductor.Location = new System.Drawing.Point(532, 119);
            this.txtMovieProductor.Name = "txtMovieProductor";
            this.txtMovieProductor.Size = new System.Drawing.Size(169, 27);
            this.txtMovieProductor.TabIndex = 18;
            // 
            // txtMovieLength
            // 
            this.txtMovieLength.Location = new System.Drawing.Point(532, 20);
            this.txtMovieLength.Name = "txtMovieLength";
            this.txtMovieLength.Size = new System.Drawing.Size(169, 27);
            this.txtMovieLength.TabIndex = 16;
            // 
            // clbMovieGenre
            // 
            this.clbMovieGenre.FormattingEnabled = true;
            this.clbMovieGenre.Location = new System.Drawing.Point(69, 119);
            this.clbMovieGenre.Name = "clbMovieGenre";
            this.clbMovieGenre.Size = new System.Drawing.Size(210, 92);
            this.clbMovieGenre.TabIndex = 15;
            // 
            // txtMovieName
            // 
            this.txtMovieName.Location = new System.Drawing.Point(162, 53);
            this.txtMovieName.Name = "txtMovieName";
            this.txtMovieName.Size = new System.Drawing.Size(144, 27);
            this.txtMovieName.TabIndex = 13;
            // 
            // lblMovieYear
            // 
            this.lblMovieYear.AutoSize = true;
            this.lblMovieYear.Location = new System.Drawing.Point(411, 192);
            this.lblMovieYear.Name = "lblMovieYear";
            this.lblMovieYear.Size = new System.Drawing.Size(117, 20);
            this.lblMovieYear.TabIndex = 9;
            this.lblMovieYear.Text = "Năm sản xuất:";
            // 
            // txtMovieID
            // 
            this.txtMovieID.Location = new System.Drawing.Point(162, 20);
            this.txtMovieID.Name = "txtMovieID";
            this.txtMovieID.Size = new System.Drawing.Size(144, 27);
            this.txtMovieID.TabIndex = 10;
            this.txtMovieID.TextChanged += new System.EventHandler(this.txtMovieID_TextChanged);
            // 
            // dtgvMovie
            // 
            this.dtgvMovie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvMovie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvMovie.Location = new System.Drawing.Point(3, 6);
            this.dtgvMovie.Name = "dtgvMovie";
            this.dtgvMovie.Size = new System.Drawing.Size(1108, 248);
            this.dtgvMovie.TabIndex = 0;
            // 
            // lblMovieDirector
            // 
            this.lblMovieDirector.AutoSize = true;
            this.lblMovieDirector.Location = new System.Drawing.Point(411, 159);
            this.lblMovieDirector.Name = "lblMovieDirector";
            this.lblMovieDirector.Size = new System.Drawing.Size(80, 20);
            this.lblMovieDirector.TabIndex = 8;
            this.lblMovieDirector.Text = "Đạo diễn:";
            // 
            // lblMovieProductor
            // 
            this.lblMovieProductor.AutoSize = true;
            this.lblMovieProductor.Location = new System.Drawing.Point(411, 126);
            this.lblMovieProductor.Name = "lblMovieProductor";
            this.lblMovieProductor.Size = new System.Drawing.Size(79, 20);
            this.lblMovieProductor.TabIndex = 7;
            this.lblMovieProductor.Text = "Sản xuất:";
            // 
            // lblMovieEndDate
            // 
            this.lblMovieEndDate.AutoSize = true;
            this.lblMovieEndDate.Location = new System.Drawing.Point(411, 93);
            this.lblMovieEndDate.Name = "lblMovieEndDate";
            this.lblMovieEndDate.Size = new System.Drawing.Size(78, 20);
            this.lblMovieEndDate.TabIndex = 6;
            this.lblMovieEndDate.Text = "Ngày KT:";
            // 
            // lblMovieStartDate
            // 
            this.lblMovieStartDate.AutoSize = true;
            this.lblMovieStartDate.Location = new System.Drawing.Point(411, 60);
            this.lblMovieStartDate.Name = "lblMovieStartDate";
            this.lblMovieStartDate.Size = new System.Drawing.Size(80, 20);
            this.lblMovieStartDate.TabIndex = 5;
            this.lblMovieStartDate.Text = "Ngày KC:";
            // 
            // lblMovieLength
            // 
            this.lblMovieLength.AutoSize = true;
            this.lblMovieLength.Location = new System.Drawing.Point(411, 27);
            this.lblMovieLength.Name = "lblMovieLength";
            this.lblMovieLength.Size = new System.Drawing.Size(86, 20);
            this.lblMovieLength.TabIndex = 4;
            this.lblMovieLength.Text = "Thời lượng";
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.Location = new System.Drawing.Point(65, 60);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(83, 20);
            this.lblMovieName.TabIndex = 1;
            this.lblMovieName.Text = "Tên phim:";
            // 
            // lblMovieID
            // 
            this.lblMovieID.AutoSize = true;
            this.lblMovieID.Location = new System.Drawing.Point(65, 27);
            this.lblMovieID.Name = "lblMovieID";
            this.lblMovieID.Size = new System.Drawing.Size(78, 20);
            this.lblMovieID.TabIndex = 0;
            this.lblMovieID.Text = "Mã phim:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgvMovie);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 267);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1111, 254);
            this.panel3.TabIndex = 6;
            // 
            // lblMovieGenre
            // 
            this.lblMovieGenre.AutoSize = true;
            this.lblMovieGenre.Location = new System.Drawing.Point(65, 96);
            this.lblMovieGenre.Name = "lblMovieGenre";
            this.lblMovieGenre.Size = new System.Drawing.Size(73, 20);
            this.lblMovieGenre.TabIndex = 3;
            this.lblMovieGenre.Text = "Thể loại:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpkYear);
            this.panel1.Controls.Add(this.picFilm);
            this.panel1.Controls.Add(this.btnUpLoadPictureFilm);
            this.panel1.Controls.Add(this.txtMovieDirector);
            this.panel1.Controls.Add(this.dtmMovieEnd);
            this.panel1.Controls.Add(this.dtmMovieStart);
            this.panel1.Controls.Add(this.txtMovieProductor);
            this.panel1.Controls.Add(this.txtMovieLength);
            this.panel1.Controls.Add(this.clbMovieGenre);
            this.panel1.Controls.Add(this.txtMovieName);
            this.panel1.Controls.Add(this.txtMovieID);
            this.panel1.Controls.Add(this.lblMovieYear);
            this.panel1.Controls.Add(this.lblMovieDirector);
            this.panel1.Controls.Add(this.lblMovieProductor);
            this.panel1.Controls.Add(this.lblMovieEndDate);
            this.panel1.Controls.Add(this.lblMovieStartDate);
            this.panel1.Controls.Add(this.lblMovieLength);
            this.panel1.Controls.Add(this.lblMovieGenre);
            this.panel1.Controls.Add(this.lblMovieName);
            this.panel1.Controls.Add(this.lblMovieID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 267);
            this.panel1.TabIndex = 4;
            // 
            // dtpkYear
            // 
            this.dtpkYear.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkYear.Location = new System.Drawing.Point(532, 187);
            this.dtpkYear.Name = "dtpkYear";
            this.dtpkYear.Size = new System.Drawing.Size(169, 27);
            this.dtpkYear.TabIndex = 25;
            // 
            // MovieUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MovieUC";
            this.Size = new System.Drawing.Size(1111, 579);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFilm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMovie)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnShowMovie;
        private System.Windows.Forms.Button btnDeleteMovie;
        private System.Windows.Forms.Button btnUpdateMovie;
        private System.Windows.Forms.Button btnAddMovie;
        private System.Windows.Forms.PictureBox picFilm;
        private System.Windows.Forms.Button btnUpLoadPictureFilm;
        private System.Windows.Forms.TextBox txtMovieDirector;
        private System.Windows.Forms.DateTimePicker dtmMovieEnd;
        private System.Windows.Forms.DateTimePicker dtmMovieStart;
        private System.Windows.Forms.TextBox txtMovieProductor;
        private System.Windows.Forms.TextBox txtMovieLength;
        private System.Windows.Forms.CheckedListBox clbMovieGenre;
        private System.Windows.Forms.TextBox txtMovieName;
        private System.Windows.Forms.Label lblMovieYear;
        private System.Windows.Forms.TextBox txtMovieID;
        private System.Windows.Forms.DataGridView dtgvMovie;
        private System.Windows.Forms.Label lblMovieDirector;
        private System.Windows.Forms.Label lblMovieProductor;
        private System.Windows.Forms.Label lblMovieEndDate;
        private System.Windows.Forms.Label lblMovieStartDate;
        private System.Windows.Forms.Label lblMovieLength;
        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.Label lblMovieID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMovieGenre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpkYear;
    }
}
