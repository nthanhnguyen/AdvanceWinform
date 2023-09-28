using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvanceWinform
{
    public partial class MainForm : Form
    {
        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Handle Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            UserBUS.Instance.FillGrid(c1FlexGrid1);

        }
        
        private void btnAdd_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            EditUserForm editUserForm = new EditUserForm();
            this.Hide();
            editUserForm.Show();
        }

        private void btnEdit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            // Kiểm tra xem có người dùng nào được chọn trong C1FlexGrid chưa
            if (c1FlexGrid1.RowSel > 0)
            {
                // Lấy thông tin người dùng được chọn
                string userId = c1FlexGrid1[c1FlexGrid1.RowSel, "UserID"].ToString();
                string username = c1FlexGrid1[c1FlexGrid1.RowSel, "UserName"].ToString();
                string password = c1FlexGrid1[c1FlexGrid1.RowSel, "Password"].ToString();
                string email = c1FlexGrid1[c1FlexGrid1.RowSel, "Email"].ToString();
                string tel = c1FlexGrid1[c1FlexGrid1.RowSel, "Tel"].ToString();
                bool disable = (bool)c1FlexGrid1[c1FlexGrid1.RowSel, "Không hiển thị"];

                // Tạo một instance của EditUsers và truyền thông tin người dùng
                EditUserForm editUserForm = new EditUserForm(userId, username, password, email, tel, disable);
                this.Hide();
                editUserForm.Show();

                // Ẩn nút "Nhập tiếp"
                editUserForm.HideNextButton();

                // Khóa mã người dùng
                editUserForm.LockUserId();
            }

        }

        private void btnDetail_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            // Kiểm tra xem có người dùng nào được chọn trong C1FlexGrid chưa
            if (c1FlexGrid1.RowSel > 0)
            {
                // Lấy thông tin người dùng được chọn
                string userId = c1FlexGrid1[c1FlexGrid1.RowSel, "UserID"].ToString();
                string username = c1FlexGrid1[c1FlexGrid1.RowSel, "UserName"].ToString();
                string password = c1FlexGrid1[c1FlexGrid1.RowSel, "Password"].ToString();
                string email = c1FlexGrid1[c1FlexGrid1.RowSel, "Email"].ToString();
                string tel = c1FlexGrid1[c1FlexGrid1.RowSel, "Tel"].ToString();
                bool disable = (bool)c1FlexGrid1[c1FlexGrid1.RowSel, "Không hiển thị"];

                // Tạo một instance của EditUsers và truyền thông tin người dùng
                EditUserForm editUserForm = new EditUserForm(userId, username, password, email, tel, disable);
                this.Hide();
                editUserForm.Show();

                // Ẩn nút "Nhập tiếp"
                editUserForm.HideNextButton();

                // Ẩn nút "Lưu"
                editUserForm.HideSaveButton();

                editUserForm.LockAll();
            }
        }

        private void btnDelete_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xoá loại nhân viên này không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                if (UserBUS.Instance.DeleteUser(c1FlexGrid1))
                {
                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xoá thất bại, người dùng không tồn tại hoặc có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Sau khi xóa, cập nhật lại C1FlexGrid
                UserBUS.Instance.FillGrid(c1FlexGrid1);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
