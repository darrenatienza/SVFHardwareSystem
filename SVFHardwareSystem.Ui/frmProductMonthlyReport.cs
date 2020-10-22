using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Interfaces;
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
    public partial class frmProductInventoryReport : MetroForm
    {
        private IPurchaseService _purchaseService;

        public frmProductInventoryReport(IPurchaseService purchaseService)
        {
            InitializeComponent();
            _purchaseService = purchaseService;
        }

        private async void frmProductMonthlyReport_Load(object sender, EventArgs e)
        {
            await LoadProductMonthlyReport();
        }

        private async Task LoadProductMonthlyReport()
        {
            try
            {
                var monthlyProducts = await _purchaseService.GetPurchaseMonthlyReport(2020, 10);

            }
            catch (CustomBaseException ex)
            {

                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
