using MetroFramework.Forms;
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
    public partial class frmDashboard : MetroForm
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void btnPointOfSale_Click(object sender, EventArgs e)
        {
            FormHandler.OpenPointofSaleForm().Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FormHandler.OpenSalesForm().Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FormHandler.OpenCategoriesForm().ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            FormHandler.OpenProductsForm().ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FormHandler.OpenCustomersForm().ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FormHandler.OpenSuppliersForm().ShowDialog();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            FormHandler.OpenPurchasesForm().ShowDialog();
        }
    }
}
