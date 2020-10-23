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
    public partial class frmProductSaleInventory : MetroForm
    {
        private ISalesService _salesService;

        public frmProductSaleInventory(ISalesService salesService)
        {
            InitializeComponent();
            _salesService = salesService;
        }

        private async void frmProductSaleInventory_Load(object sender, EventArgs e)
        {
            await LoadProductSaleInventory();
        }

        private async Task LoadProductSaleInventory()
        {
            try
            {
                var productSales = await _salesService.GetAllProductSaleInventoryByMonthYear(10, 2020);

            }
            catch (CustomBaseException ex)
            {

                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
