using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Extensions;
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
    public partial class frmPointOfSaleDiscountForm : MetroForm
    {
        private int _saleProductID;
        private ISaleProductService _saleProductService;

        public frmPointOfSaleDiscountForm(ISaleProductService saleProductService, int saleProductID)
        {
            InitializeComponent();
            _saleProductID = saleProductID;
            _saleProductService = saleProductService;
        }

        private void frmPointOfSaleDiscountForm_Load(object sender, EventArgs e)
        {
            GetSaleProductData();
        }

        private void GetSaleProductData()
        {
            try
            {
                var saleProduct = _saleProductService.Get(_saleProductID);
                lblProductName.Text = saleProduct.ProductName;
                lblQuantity.Text = saleProduct.Quantity.ToString();
                lblSellingPrice.Text = saleProduct.Price.ToCurrencyFormat();
                lblTotal.Text = saleProduct.Total.ToCurrencyFormat();

            }catch(Exception e)
            {
                ShowError(e.ToString());
            }
        }

        private void ShowError(string message)
        {
            MetroMessageBox.Show(this,message, "Discount Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnUpdateDiscount_Click(object sender, EventArgs e)
        {
           await UpdateDiscount();
        }

        private async Task UpdateDiscount()
        {
            try
            {
                var saleProduct = _saleProductService.Get(_saleProductID);
                decimal discount = decimal.Parse(txtDiscount.Text);
                // calculate the total amount after product discounted
                decimal newTotal = saleProduct.Total - discount;
                // compute for new product selling price after discount
                decimal newSaleProductPrice = newTotal / saleProduct.Quantity;
                //update to database
                saleProduct.Price = newSaleProductPrice;
                await _saleProductService.EditAsync(_saleProductID, saleProduct);
                this.Close();
            }
            catch (Exception e)
            {
                ShowError(e.ToString());
            }
        }
    }
}
