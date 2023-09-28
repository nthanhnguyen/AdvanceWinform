using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class UserDAL
    {
        #region Constructor
        private static UserDAL instance;

        /// <summary>
        /// Hàm tạo riêng tư để đảm bảo mô hình singleton.
        /// </summary>
        private UserDAL() { }
        #endregion


        #region Properties
        /// <summary>
        /// Lấy thể hiện của lớp UserDAL.
        /// </summary>
        public static UserDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAL();
                }
                return instance;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Truy xuất tất cả người dùng từ cơ sở dữ liệu.
        /// </summary>
        /// <returns>Một DataTable chứa dữ liệu người dùng.</returns>
        public DataTable GetAllUsers()
        {
            string query = "SELECT * FROM [user]";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        /// <summary>
        /// Xóa người dùng theo ID.
        /// </summary>
        /// <param name="userid">ID người dùng cần xóa.</param>
        /// <returns>Trả về true nếu xóa thành công; ngược lại, trả về false.</returns>
        public bool deleteUser(string userid)
        {
            string query = "DELETE FROM [user] WHERE UserID = @id";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { userid }) > 0;
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
        public bool insertUser(string userid, string username, string password, string email, string tel, int disable)
        {
            string query = "InsertUser @id , @username , @password , @email , @tel , @disable";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { userid, username, password, email, tel, disable }) > 0;
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
        public bool editUser(string userid, string username, string password, string email, string tel, int disable)
        {
            string query = "UpdateUser @id , @username , @password , @email , @tel , @disable";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { userid, username, password, email, tel, disable }) > 0;
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của người dùng theo ID.
        /// </summary>
        /// <param name="userid">ID người dùng cần kiểm tra.</param>
        /// <returns>Trả về true nếu người dùng tồn tại; ngược lại, trả về false.</returns>
        public bool checkUserExists(string userid)
        {
            string query = "CheckUserExists @id";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { userid }) > 0;
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của địa chỉ email.
        /// </summary>
        /// <param name="email">Địa chỉ email cần kiểm tra.</param>
        /// <returns>Trả về true nếu địa chỉ email hợp lệ; ngược lại, trả về false.</returns>
        public bool checkEmail(string email)
        {
            string query = "CheckValidEmail @email";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { email }) > 0;
        }
        #endregion

    }
}
