using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Ui.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace SVFHardwareSystem.Ui
{
    public partial class frmLogin : MetroForm
    {
        private IAuthenticationService _authenticationService;
        private IUserService _userService;
        public bool IsLoginSuccess { get; internal set; }
        public frmLogin(IAuthenticationService authenticationService, IUserService userService)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            _authenticationService = authenticationService;
            _userService = userService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = txtUserName.Text;
            var pass = txtPassword.Text;

            var user = await _userService.Get(userName);
            
            if (user != null)
            {
                var encrypPass = _authenticationService.EncodePasswordToBase64(pass);
                if (user.Password == encrypPass)
                {
                    MetroMessageBox.Show(this, "Login success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IsLoginSuccess = true;
                    this.Close();
                }
                else
                {
                    MetroMessageBox.Show(this, "Invalid UserName or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Invalid UserName or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
