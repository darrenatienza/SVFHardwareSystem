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
    }
}
