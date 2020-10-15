using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services;
using SVFHardwareSystem.Services.Extensions;
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
    public partial class frmPurchaseSaleInventories : MetroForm
    {
        private IPurchaseSaleInventoryService _purchaseSaleInventoryService;

        public frmPurchaseSaleInventories(IPurchaseSaleInventoryService purchaseSaleInventoryService)
        {
            InitializeComponent();
            _purchaseSaleInventoryService = purchaseSaleInventoryService;
        }

        private void frmPurchaseSaleInventories_Load(object sender, EventArgs e)
        {
           
        }
        private async Task LoadPurchaseSaleInventories()
        {
            try
            {
                var year = cboYear.Text.ToInt();
                var inventories =   await _purchaseSaleInventoryService.GetYearlyInventory(year);
                int count = 0;
                var grid = gridInventory;
                grid.Rows.Clear();
                foreach (var item in inventories)
                {
                    count++;
                    grid.Rows.Add(new object[] {
                            item.ProductSaleInventoryID,
                            count.ToString(),
                            item.CategoryName,
                            item.Name,
                            item.Unit,
                            item.BeginningQuantity,
                            item.BeginningUnitCost,
                            item.BeginningAmount,
                            item.PurchaseQuantity,
                            item.PurchaseUnitCost,
                            item.PurchaseAmount,
                            item.SalesQuantity,
                            item.SalesUnitCost,
                            item.SalesAmount,
                            item.EndingQuantity,
                            item.EndingUnitCost,
                            item.EndingAmount
                    }); ;
                }


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await Save();
        }
        private async Task Save()
        {
            try
            {
                var year = cboYear.Text.ToInt();
                await _purchaseSaleInventoryService.SaveAsync(year);
                MetroMessageBox.Show(this, "Record has been saved.", "Purchase and sale Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadPurchaseSaleInventories();
        }
    }
}
