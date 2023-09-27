using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class UserBUS
    {
        #region Constructor
        private static UserBUS instance;

        /// <summary>
        /// Hàm tạo riêng tư để đảm bảo mô hình singleton.
        /// </summary>
        private UserBUS() { }
        #endregion

        #region Properties
        /// <summary>
        /// Lấy thể hiện của lớp UserBUS.
        /// </summary>
        public static UserBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserBUS();
                }
                return instance;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Điền dữ liệu vào DataGridView.
        /// </summary>
        /// <param name="dataGridView">DataGridView cần điền dữ liệu.</param>
        public void FillGrid(C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid)
        {
            // Thực hiện truy vấn SQL và lấy dữ liệu từ bảng Users
            DataTable dataTable = UserDAL.Instance.GetAllUsers();

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
                    row["Không hiển thị"] = false;
                }
            }

            // Đặt C1FlexGrid.DataSource bằng DataTable đã chỉnh sửa
            c1FlexGrid.DataSource = dataTable;
            c1FlexGrid.Cols["Số Thứ Tự"].Move(1); // Đặt lại thứ tự cột
            c1FlexGrid.Cols["UserID"].Caption = "Mã nhân viên";
            c1FlexGrid.Cols["UserName"].Caption = "Tên nhân viên";
            c1FlexGrid.Cols["Password"].Visible = false;
            c1FlexGrid.Cols["Email"].Caption = "Email";
            c1FlexGrid.Cols["Tel"].Caption = "Số điện thoại";
            c1FlexGrid.Cols["Disable"].Visible = false;
            c1FlexGrid.Cols["Không hiển thị"].Caption = "Không hiển thị";
        }


        /// <summary>
        /// Xóa người dùng được chọn từ DataGridView.
        /// </summary>
        /// <param name="dataGridView">DataGridView chứa danh sách người dùng.</param>
        /// <returns>Trả về true nếu xóa thành công; ngược lại, trả về false.</returns>
        public bool DeleteUser(C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid)
        {
            string userId = c1FlexGrid[c1FlexGrid.RowSel, "UserID"].ToString();

            if (UserDAL.Instance.deleteUser(userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Chèn người dùng mới vào cơ sở dữ liệu.
        /// </summary>
        /// <param name="userid">ID người dùng.</param>
        /// <param name="username">Tên người dùng.</param>
        /// <param name="password">Mật khẩu.</param>
        /// <param name="email">Địa chỉ email.</param>
        /// <param name="tel">Số điện thoại.</param>
        /// <param name="disable">Trạng thái vô hiệu hóa.</param>
        /// <returns>Trả về true nếu chèn thành công; ngược lại, trả về false.</returns>
        public bool InsertUser(string userid, string username, string password, string email, string tel, int disable)
        {
            if (UserDAL.Instance.insertUser(userid, username, password, email, tel, disable))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sửa thông tin người dùng.
        /// </summary>
        /// <param name="userid">ID người dùng.</param>
        /// <param name="username">Tên người dùng mới.</param>
        /// <param name="password">Mật khẩu mới.</param>
        /// <param name="email">Địa chỉ email mới.</param>
        /// <param name="tel">Số điện thoại mới.</param>
        /// <param name="disable">Trạng thái vô hiệu hóa mới.</param>
        /// <returns>Trả về true nếu sửa thông tin thành công; ngược lại, trả về false.</returns>
        public bool EditUser(string userid, string username, string password, string email, string tel, int disable)
        {
            if (UserDAL.Instance.editUser(userid, username, password, email, tel, disable))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra xem các trường dữ liệu cần thiết có rỗng hay không.
        /// </summary>
        /// <param name="UserId">ID người dùng.</param>
        /// <param name="UserName">Tên người dùng.</param>
        /// <returns>Trả về true nếu không có trường nào rỗng; ngược lại, trả về false.</returns>
        public bool CheckEmpty(string UserId, string UserName)
        {
            if (UserId.Trim() == ""
               || UserName.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của địa chỉ email.
        /// </summary>
        /// <param name="email">Địa chỉ email cần kiểm tra.</param>
        /// <returns>Trả về true nếu địa chỉ email hợp lệ; ngược lại, trả về false.</returns>
        public bool CheckEmail(string email)
        {
            if (UserDAL.Instance.checkEmail(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của người dùng theo ID.
        /// </summary>
        /// <param name="userid">ID người dùng cần kiểm tra.</param>
        /// <returns>Trả về true nếu người dùng tồn tại; ngược lại, trả về false.</returns>
        public bool CheckUserExists(string userid)
        {
            if (UserDAL.Instance.checkUserExists(userid))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
