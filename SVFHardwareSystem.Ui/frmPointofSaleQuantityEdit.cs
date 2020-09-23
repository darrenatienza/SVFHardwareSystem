using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services;
using SVFHardwareSystem.Services.Exceptions;
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
    public partial class frmPointofSaleQuantityEdit : MetroForm
    {
        private IProductService _productService;
        private int _posTransactionID;
        private ITransactionProductService _transactionProductService;
        private int productID;
        private int availableQuantity;

        public frmPointofSaleQuantityEdit(IProductService productService,ITransactionProductService transactionProductService, int posTransactionID)
        {
            InitializeComponent();
            _productService = productService;
            _posTransactionID = posTransactionID;
            _transactionProductService = transactionProductService;
        }

        private void frmPointofSaleQuantityEdit_Load(object sender, EventArgs e)
        {
            loadProductAutoCompleteData();
        }
        private async void loadProductAutoCompleteData()
        {

            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            var productNames = await _productService.GetAll();
            foreach (var item in productNames)
            {
                txtProductName.AutoCompleteCustomSource.Add(item.Name);
            }

        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //get product by productname and set values to productid and lblavailable;
                    var productName = txtProductName.Text;
                    var product = _productService.GetByProductName(productName);
                    
                        productID = product.ProductID;
                    availableQuantity = product.Quantity;
                        lblavailable.Text = string.Format("Available: {0}", product.Quantity.ToString());

                }
            }
            catch (KeyNotFoundException)
            {
                // no record found on selected product name
                productID = 0;
                lblavailable.Text = string.Format("Available: {0}", 0);
                txtProductName.WithError = true;
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
            
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtProductName.Text == "" || productID == 0)
                {
                    MetroMessageBox.Show(this, "Product is required!", "Quantity Edit",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtProductName.WithError = true;
                    return;
                }
                if (txtQuantity.Text == "" || txtQuantity.Text == "0")
                {
                    MetroMessageBox.Show(this, "Quantity is required!", "Quantity Edit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantity.WithError = true;
                    return;
                }
                var transactionProduct = new TransactionProductModel();
                transactionProduct.IsPaid = false;
                transactionProduct.IsToPay = true;
                transactionProduct.POSTransactionID = _posTransactionID;
                transactionProduct.ProductID = productID;
                transactionProduct.Quantity = int.Parse(txtQuantity.Text);
                transactionProduct.UpdateTimeStamp = DateTime.Now;
                await _transactionProductService.AddNewTransactionProductAsync(transactionProduct);
                this.Close();
            }
            catch(LimitMustNoReachException ex)
            {
                MetroMessageBox.Show(this, ex.Message);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }
    }
}
