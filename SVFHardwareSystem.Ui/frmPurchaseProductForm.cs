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
    public partial class frmPurchaseProductForm : MetroForm
    {
        private IProductService _productService;
        private int _purchaseID;
        private int _productID;

        public frmPurchaseProductForm(IProductService productService, int purchaseID)
        {
            InitializeComponent();
            _productService = productService;
            _purchaseID = purchaseID;
        }
        public frmPurchaseProductForm(IProductService productService, int purchaseID, int productID)
        {
            InitializeComponent();
            _productService = productService;
            _purchaseID = purchaseID;
            _productID = productID;
        }
        private void frmPurchaseProductForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }
        private async void LoadProducts()
        {
            try
            {
                var suppliers = await _productService.GetAllAsync();
                foreach (var item in suppliers)
                {
                    cboProduct.Items.Add(new ItemX(item.Name, item.ProductID.ToString()));

                }
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
