using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Extensions;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using SVFHardwareSystem.Ui.Interfaces;
using SVFHardwareSystem.Ui.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVFHardwareSystem.Ui
{
    public partial class frmUserForm : MetroForm
    {
        private IUserService _userService;
        private IAuthenticationService _authenticationService;
        private int _userID;

        public frmUserForm(IUserService userService,IAuthenticationService authenticationService)
        {
            InitializeComponent();
            _userService = userService;
            _authenticationService = authenticationService;
        }

        private async void frmUserForm_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                cboUsers.Items.Clear();
                foreach (var item in users)
                {
                    cboUsers.Items.Add(new ItemX(item.UserName, item.UserID.ToString()));
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cboUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selecteItem = ((ItemX)cboUsers.SelectedItem);
            _userID = selecteItem!= null ? selecteItem.Key.ToInt() : 0;
            if (_userID != 0)
            {
                await SetUserData();
            }
          
        }

        private async Task SetUserData()
        {
            try
            {
                var user = await _userService.GetAsync(_userID);
                if (user != null)
                {
                    txtUserName.Text = user.UserName;
                    txtPassword.Text = _authenticationService.DecodeFrom64(user.Password);
                    
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void ResetFields()
        {
            txtPassword.Clear();
            txtUserName.Clear();
            _userID = 0;
            cboUsers.SelectedIndex = -1;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
            try
            {
                var pass = txtPassword.Text;
                
                var user = new UserModel();
                user.UserID = _userID;
                user.UserName = txtUserName.Text;
                user.Password = _authenticationService.EncodePasswordToBase64(pass);

                if (_userID == 0)
                {
                    await _userService.AddAsync(user);
                }
                else
                {
                    await _userService.EditAsync(_userID, user);
                }

                MetroMessageBox.Show(this, "User has been saved!", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadUsersAsync();
                ResetFields();
            }
            
            catch (CustomBaseException ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult d = MetroMessageBox.Show(this, "Do you want to delete this record?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    if (_userID >= 0)
                    {
                        await _userService.RemoveAsync(_userID);
                    }
                    MetroMessageBox.Show(this, "User has been removed!", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsersAsync();
                    ResetFields();
                }
               

                

            }

            catch (CustomBaseException ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
