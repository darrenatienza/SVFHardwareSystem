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
    public partial class frmSupplierForm : MetroForm
    {
        ISupplierService _supplierService;
        private int _supplierID;
        public frmSupplierForm(ISupplierService supplierService)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            _supplierService = supplierService;
        }
        public frmSupplierForm(ISupplierService customerService, int supplierID)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            _supplierService = customerService;
            _supplierID = supplierID;
        }

        private async void frmSupplierForm_Load(object sender, EventArgs e)
        {
            // set values to input
            try
            {
                if (_supplierID > 0)
                {
                    var supplierModel = await _supplierService.GetAsync(_supplierID);
                    txtFullName.Text = supplierModel.Name;
                    txtAddress.Text = supplierModel.Address;
                    txtContactNum.Text = supplierModel.ContactNumber;
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
                var supplierModel = new SupplierModel();
                supplierModel.SupplierID = _supplierID;
                supplierModel.Name = txtFullName.Text;
                supplierModel.Address = txtAddress.Text;
                supplierModel.ContactNumber = txtContactNum.Text;
                //edit
                if (_supplierID > 0)
                {
                    await _supplierService.EditAsync(_supplierID, supplierModel);
                }
                else
                {
                    //add
                    await _supplierService.AddAsync(supplierModel);
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
