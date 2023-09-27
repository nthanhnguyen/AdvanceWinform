using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        #region Constructor
        /// <summary>
        /// Khởi tạo một đối tượng User với các thông tin cơ bản.
        /// </summary>
        /// <param name="userid">Mã người dùng.</param>
        /// <param name="username">Tên người dùng.</param>
        /// <param name="password">Mật khẩu.</param>
        /// <param name="email">Địa chỉ email.</param>
        /// <param name="tel">Số điện thoại.</param>
        /// <param name="disable">Trạng thái vô hiệu hóa.</param>
        public User(string userid, string username, string password, string email, string tel, int disable)
        {
            this.UserId = userid;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Tel = tel;
            this.Disable = disable;
        }
        #endregion

        #region Variables
        private string userId;
        private string usermame;
        private string password;
        private string email;
        private string tel;
        private int disable;
        #endregion

        #region Properties
        public string UserId { get => userId; set => userId = value; }
        public string Username { get => usermame; set => usermame = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Tel { get => tel; set => tel = value; }
        public int Disable { get => disable; set => disable = value; }
        #endregion
    }
}
