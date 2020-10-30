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
        private ISaleProductService _transactionProductService;
        private int productID;
        private int availableQuantity;

        public frmPointofSaleQuantityEdit(IProductService productService,ISaleProductService transactionProductService, int posTransactionID)
        {
            InitializeComponent();

            //setup product names listbox search
            var x = txtProductName.Location.X;
            var y = txtProductName.Location.Y + txtProductName.Size.Height; ;
            lbProducts.Location = new Point(x, y);
            lbProducts.Width = txtProductName.Width;
            lbProducts.Visible = false;
            lbProducts.KeyDown += lbProducts_KeyDown;




            _productService = productService;
            _posTransactionID = posTransactionID;
            _transactionProductService = transactionProductService;
        }

       
        private void frmPointofSaleQuantityEdit_Load(object sender, EventArgs e)
        {

            
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
                var transactionProduct = new SaleProductModel();
                transactionProduct.IsPaid = false;
                transactionProduct.IsToPay = true;
                transactionProduct.SaleID = _posTransactionID;
                transactionProduct.ProductID = productID;
                transactionProduct.Quantity = int.Parse(txtQuantity.Text);
                transactionProduct.UpdateTimeStamp = DateTime.Now;
                await _transactionProductService.AddNewTransactionProductAsync(transactionProduct);
                this.Close();
            }
            catch(LimitMustNotReachException ex)
            {
                MetroMessageBox.Show(this, ex.Message);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        #region Product Name List Box Implementations

        /// <summary>
        /// Occurs when a keyboard key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //get product by productname and set values to productid and lblavailable;
                    var productName = txtProductName.Text;
                var product = _productService.GetByProductName(productName);

                productID = product.ProductID;
                availableQuantity = product.Quantity;
                lblavailable.Text = string.Format("Available: {0}", product.Quantity.ToString());
                lbProducts.Visible = false;
                }
            catch (RecordNotFoundException)
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
            if (e.KeyCode == Keys.Down)
            {
                lbProducts.Focus();
            }

        }

        /// <summary>
        /// Occurs when a keyboard key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void lbProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lbProducts.SelectedIndex == 0)
                {
                    txtProductName.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (lbProducts.SelectedIndex >= 0)
                {
                    txtProductName.Text = lbProducts.Text;
                    txtProductName_TextChanged(sender, e);
                    txtProductName.Focus();
                    lbProducts.Visible = false;
                }
            }
        }

        /// <summary>
        /// Occurs when a text changed happen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var criteria = txtProductName.Text;
                await LoadProductSearchList(criteria);
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

        private async Task LoadProductSearchList(string criteria)
        {
            Dictionary<int, string> productNames = new Dictionary<int, string>();
            if (criteria != "")
            {
                productNames = await _productService.GetProductNamesAsync(criteria);
            }
            UpdateProductSearchList(productNames);
        }

        private void UpdateProductSearchList(Dictionary<int, string> productNames)
        {
            lbProducts.Visible = false;
            if (productNames.Count > 0)
            {
                lbProducts.Visible = true;
                lbProducts.Items.Clear();
                foreach (var item in productNames)
                {
                    lbProducts.Items.Add(item.Value);
                }
            }


        }

        #endregion
    }
}
