using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
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
    public partial class frmCustomerForm : MetroForm
    {
        ICustomerService _customerService;
        private int _id;
        public frmCustomerForm(ICustomerService customerService)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            _customerService = customerService;
        }
        public frmCustomerForm(ICustomerService customerService, int id)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            _customerService = customerService;
            _id = id;
        }

        private async void frmCustomerForm_Load(object sender, EventArgs e)
        {
            // set values to input
            try
            {
                if(_id > 0)
                {
                    var customer = await _customerService.Get(_id);
                    txtFullName.Text = customer.FullName;
                    txtAddress.Text = customer.Address;
                    txtContactNum.Text = customer.ContactNumber;
                }
               


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                var customer = new CustomerModel();
                customer.FullName = txtFullName.Text;
                customer.Address = txtAddress.Text;
                customer.ContactNumber = txtContactNum.Text;
                //edit
                if (_id > 0)
                {
                    await _customerService.Edit(_id, customer);
                }
                else
                {
                    //add
                    await _customerService.Add(customer);
                }
                this.Close();
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
           
           
        }
    }
}
