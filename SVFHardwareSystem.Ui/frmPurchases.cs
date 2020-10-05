using MetroFramework.Forms;
using SVFHardwareSystem.Services.Interfaces;
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
    public partial class frmPurchases : MetroForm
    {
        private ISupplierService _supplierService;

        public frmPurchases(ISupplierService supplierService)
        {
            InitializeComponent();
            _supplierService = supplierService;
        }

        private void frmPurchases_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }
        private async void LoadSuppliers()
        {

            var suppliers = await _supplierService.GetAll();
            foreach (var item in suppliers)
            {
                cboSupplier.Items.Add(new ItemX(item.Name, item.SupplierID.ToString()));

            }
        }
    }
}
