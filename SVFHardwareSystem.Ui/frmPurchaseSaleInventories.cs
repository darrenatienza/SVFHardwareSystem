using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services;
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
            LoadPurchaseSaleInventories();
        }
        private void LoadPurchaseSaleInventories()
        {
            try
            {
                var inventories = _purchaseSaleInventoryService.GetYearlyInventory(2020);
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
    }
}
