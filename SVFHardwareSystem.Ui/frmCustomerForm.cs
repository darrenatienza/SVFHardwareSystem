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
        public frmCustomerForm(ICustomerService customerService)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            _customerService = customerService;

        }

        private void frmCustomerForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var customer = new CustomerModel();
                customer.FullName = txtFullName.Text;
                customer.Address = txtAddress.Text;
                customer.ContactNumber = txtContactNum.Text;
                await Task.Run(() => _customerService.Add(customer).ConfigureAwait(false));
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
