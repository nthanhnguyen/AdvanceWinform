using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvanceWinform
{
    public partial class EditUserForm : Form
    {
        #region Constructor
        public EditUserForm()
        {
            InitializeComponent();
        }

        

        public EditUserForm(string userId, string username, string password, string email, string tel, bool disable)
        {
            InitializeComponent();

            // Lưu trữ thông tin người dùng vào các biến thành viên
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.email = email;
            this.tel = tel;
            this.disable = disable;

            // Khóa mã người dùng
            LockUserId();
        }
        #endregion

        #region Variables
        private bool isUserIdLocked = false;
        private string userId;
        private string username;
        private string password;
        private string email;
        private string tel;
        private bool disable;
        #endregion

        #region Private Methods
        public void LockUserId()
        {
            isUserIdLocked = true;
            txtId.Enabled = false;
        }
        #endregion

        #region Public Methods
        public void HideNextButton()
        {
            btnNext.Enabled = false;
        }

        public void HideSaveButton()
        {
            btnSave.Enabled = false;
        }

        public void LockAll()
        {
            txtId.Enabled = false;
            txtName.Enabled = false;
            txtPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;
            txtEmail.Enabled = false;
            txtTel.Enabled = false;
        }
        #endregion

        #region Handle Events
        private void EditUserForm_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng từ các biến thành viên
            txtId.Text = userId;
            txtName.Text = username;
            txtPassword.Text = password;
            txtConfirmPassword.Text = password;
            txtEmail.Text = email;
            txtTel.Text = tel;
            checkDisplay.Checked = disable;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            this.Close();
            mainform.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string UserId = txtId.Text;
            string Username = txtName.Text;
            string Password = txtPassword.Text;
            string ConfirmPassword = txtConfirmPassword.Text;

            if (ConfirmPassword != Password)
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Không thực hiện thêm nếu xác nhận mật khẩu không đúng
            }

            string Email = txtEmail.Text;
            string Tel = txtTel.Text;

            int Disable = 0;
            if (checkDisplay.Checked)
            {
                Disable = 1;
            }

            if (UserBUS.Instance.CheckEmpty(UserId, Username))
            {
                try
                {
                    if (UserBUS.Instance.CheckEmail(Email))
                    {
                        MessageBox.Show("Email người dùng không hợp lệ!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (isUserIdLocked)
                    {
                        if (UserBUS.Instance.EditUser(UserId, Username, Password, Email, Tel, Disable))
                        {
                            MessageBox.Show("Đã sửa thông tin thành công", "Sửa thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (UserBUS.Instance.CheckUserExists(UserId))
                    {
                        MessageBox.Show("Mã người dùng đã tồn tại. Vui lòng chọn mã người dùng khác.", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Không thực hiện thêm hoặc sửa nếu mã người dùng đã tồn tại
                    }
                    else if (UserBUS.Instance.InsertUser(UserId, Username, Password, Email, Tel, Disable))
                    {
                        MessageBox.Show("Đã thêm người dùng thành công", "Thêm người dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Sau khi lưu thành công, làm cho nút btnSave trở thành mờ đi
                        btnSave.Enabled = false;

                        // Hiện nút "Nhập tiếp"
                        btnNext.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Không được để trống Mã nhân viên hay Tên nhân viên.", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion
    }
}
