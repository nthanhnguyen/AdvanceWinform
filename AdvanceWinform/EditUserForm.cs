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
        public EditUserForm()
        {
            InitializeComponent();
        }

        private bool isUserIdLocked = false;

        public EditUserForm(string userId, string username, string password, string email, string tel, bool disable)
        {
            InitializeComponent();

            // Hiển thị thông tin người dùng
            txtId.Text = userId;
            txtName.Text = username;
            txtPassword.Text = password;
            txtConfirmPassword.Text = password;
            txtEmail.Text = email;
            txtTel.Text = tel;
            checkDisplay.Checked = disable;

            // Khóa mã người dùng
            LockUserId();
        }

        public void LockUserId()
        {
            isUserIdLocked = true;
            txtId.Enabled = false;
        }

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

    }
}
