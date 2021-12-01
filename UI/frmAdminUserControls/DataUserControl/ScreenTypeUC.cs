using QuanLyRapChieuPhim.DAO;
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
    public partial class ScreenTypeUC : UserControl
    {
        BindingSource screen_type_list = new BindingSource();

        public ScreenTypeUC()
        {
            InitializeComponent();
            LoadScreenType();
        }

        #region Method
        void LoadScreenType()
        {
            dtgvScreenType.DataSource = screen_type_list;
            LoadScreenTypeList();
            AddScreenTypeBinding();
        }
        void LoadScreenTypeList()
        {
            screen_type_list.DataSource = ScreenTypeDAO.GetScreenType();
        }
        void AddScreenTypeBinding()
        {
            txtScreenTypeID.DataBindings.Add("Text", dtgvScreenType.DataSource, "Mã màn hình", true, DataSourceUpdateMode.Never);
            txtScreenTypeName.DataBindings.Add("Text", dtgvScreenType.DataSource, "Loại màn hình", true, DataSourceUpdateMode.Never);

        }
        bool checkNameScreenType()
        {
            try
            {
                string query = "SELECT * FROM MANHINH WHERE LoaiMH = @loaimn";
                DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { txtScreenTypeName.Text });
                if (data.Rows.Count > 0)
                {
                    MessageBox.Show("Loại màn hinh đã có trong cơ sở dữ liệu", "Thông báo");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return true;
        }
        #endregion

        #region Event
        private void btnInsertScreenType_Click(object sender, EventArgs e)
        {
            if (checkNameScreenType())
            {
                try
                {
                    string query = "USP_InsertScreenType @mamh , @loaimh";
                    int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtScreenTypeID.Text, txtScreenTypeName.Text });
                    if (result > 0)
                    {
                        MessageBox.Show("Bạn đã thêm loại màn hình " + txtScreenTypeName.Text + " thành công", "Thông báo");
                        LoadScreenTypeList();
                    }
                }
                catch 
                {
                    MessageBox.Show("Mã loại màn hình đã tồn tại", "Thông báo");
                }
            }
        }

        private void btnDeleteScreenType_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có chắc chắn muốn xoá loại màn hình " + txtScreenTypeName.Text.Trim() + " không?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string query = "USP_DeleteScreenType @mamh";
                    int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtScreenTypeID.Text });
                    if (result > 0)
                    {
                        MessageBox.Show("Bạn đã xoá loại màn hình " + txtScreenTypeName.Text + " thành công", "Thông báo");
                        LoadScreenTypeList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdateScreenType_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có chắc chắn muốn thay đổi thông tin màn hình mã " + txtScreenTypeID.Text.Trim() + " không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog ==  DialogResult.Yes)
            {
                if (checkNameScreenType()) 
                {
                    try
                    {
                        string query = "USP_UpdateScreenType @mamh , @loaimh";
                        int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { txtScreenTypeID.Text, txtScreenTypeName.Text });
                        if (result > 0)
                        {
                            MessageBox.Show("Bạn đã cập nhật thông tin màn hình mã " + txtScreenTypeID.Text + " thành công", "Thông báo");
                            LoadScreenTypeList();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnShowScreenType_Click(object sender, EventArgs e)
        {
            LoadScreenTypeList();
        }
        #endregion


    }
}
