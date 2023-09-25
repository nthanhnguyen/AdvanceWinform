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
        public MainForm()
        {
            InitializeComponent();
        }

        User user = new User();

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'winFormDbDataSet.user' table. You can move, or remove it, as needed.
            //this.userTableAdapter.Fill(this.winFormDbDataSet.user);
            // Thêm cột Disable là checkbox vào DataTable
            fillGrid();

        }

        private void fillGrid()
        {
            // Thực hiện truy vấn SQL và lấy dữ liệu từ bảng Users
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [user]");
            DataTable dataTable = user.GetAllUsers(sqlCommand);

            // Thêm cột số thứ tự vào DataTable
            dataTable.Columns.Add("Số Thứ Tự", typeof(int));
            int rowIndex = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                row["Số Thứ Tự"] = rowIndex;
                rowIndex++;
            }

            // Thêm cột Disable là checkbox vào DataTable
            dataTable.Columns.Add("Không hiển thị", typeof(bool));
            foreach (DataRow row in dataTable.Rows)
            {
                object disabledValue = row["Disable"];
                if (disabledValue != DBNull.Value && int.TryParse(disabledValue.ToString(), out int disabledIntValue))
                {
                    row["Không hiển thị"] = disabledIntValue == 1;
                }
                else
                {
                    row["Không hiển thị"] = false; // Hoặc bạn có thể đặt giá trị mặc định khác nếu cần
                }
            }

            

            // Đặt C1FlexGrid.DataSource bằng DataTable đã chỉnh sửa
            c1FlexGrid1.DataSource = dataTable;

            c1FlexGrid1.Cols.Move(c1FlexGrid1.Cols["Số Thứ Tự"].Index, 1);

            // Đặt lại tên hiển thị cho các cột
            c1FlexGrid1.Cols["Số Thứ Tự"].Caption = "Số Thứ Tự";
            c1FlexGrid1.Cols["UserID"].Caption = "Mã nhân viên";
            c1FlexGrid1.Cols["UserName"].Caption = "Tên nhân viên";
            c1FlexGrid1.Cols["Password"].Visible = false;
            c1FlexGrid1.Cols["Email"].Caption = "Email";
            c1FlexGrid1.Cols["Tel"].Caption = "Số điện thoại";
            c1FlexGrid1.Cols["Disable"].Visible = false;
            c1FlexGrid1.Cols["Không hiển thị"].Caption = "Không hiển thị";
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
            // Lấy giá trị UserID từ dòng được chọn trong C1FlexGrid
            string userId = c1FlexGrid1[c1FlexGrid1.RowSel, "UserID"].ToString();

            // Hiển thị hộp thoại xác nhận xóa
            DialogResult dg = MessageBox.Show("Bạn muốn xóa User này?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dg == DialogResult.Yes)
            {
                try
                {
                    // Gọi phương thức xóa người dùng từ đối tượng user
                    if (user.deleteUser(userId))
                    {
                        MessageBox.Show("Xóa thành công User", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillGrid(); // Cập nhật lại dữ liệu trong C1FlexGrid sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Lỗi!", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
