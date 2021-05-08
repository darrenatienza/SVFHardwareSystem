using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Extensions;
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
    public partial class frmInitialProductQuantity : MetroForm
    {
        private int _categoryID;
        private IProductService _productService;
        private ICategoryService _categoryService;
        private int _productID;
        private bool quantityHasError;
        private bool priceHasError;
        private bool categoryHasError;
        private bool productHasError;

        public frmInitialProductQuantity(IProductService productService, ICategoryService categoryService)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;


        }

        private void frmInitialProductQuantity_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }
        private async void LoadCategories()
        {
            try
            {
                var suppliers = await _categoryService.GetAllAsync();
                foreach (var item in suppliers)
                {
                    cboCategory.Items.Add(new ItemX(item.Name, item.CategoryID.ToString()));

                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SetCategoryID()
        {
            _categoryID = ((ItemX)cboCategory.SelectedItem).Key.ToInt();
        }
        private async void LoadProducts()
        {
            try
            {
                var suppliers = await _productService.GetAllWithZeroBeginningQuantityByCategoryID(_categoryID);
                cboProduct.Items.Clear();
                foreach (var item in suppliers)
                {
                    cboProduct.Items.Add(new ItemX(item.Name, item.ProductID.ToString()));
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCategoryID();
            LoadProducts();
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetProductID();
            SetProductData();
        }
        private void SetProductID()
        {
            _productID = ((ItemX)cboProduct.SelectedItem).Key.ToInt();
        }
        private void SetProductData()
        {
            try
            {
                var product = _productService.GetBeginningInventory(_productID);
                lblBegQty.Text = string.Format("Beginning Quantity: {0}", product.Quantity.ToString());
                
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // update the quantity of beginning inventory
            // update the quantity of product inventory

            try
            {
                if (quantityHasError
                    || priceHasError
                    || categoryHasError
                    ||productHasError)
                {
                    MetroMessageBox.Show(this, "Invalid input found!", "Update Beginning Quantity",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
                else
                {
                    var productOnInventory = _productService.Get(_productID);
                    if(productOnInventory.ProductID > 0)
                    {
                        var dialog = MetroMessageBox.Show(this, "Are you sure you want to update quantity of this record? " +
                   "\n" +
                   "You cannot revert the changes after you update!", "Update Beginning Quantity",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning);
                        if (dialog == DialogResult.Yes)
                        {
                            var quantity = txtQuantity.Text.ToDecimal();
                            var price = txtPrice.Text.ToDecimal();
                            _productService.EditBeginningInventoryQuantity(_productID, quantity, price);
                            _productService.EditProductQuantity(_productID, quantity,price);
                            LoadProducts();
                            txtQuantity.Text = "";
                            txtPrice.Text = "";
                            lblBegQty.Text = string.Format("Beginning Quantity: {0}", "Please select product...");
                            MetroMessageBox.Show(this, "Beginning quantity has been updated!", "Update Beginning Quantity",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Product on inventory not exists!", "Update Beginning Quantity",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                    }
                    
                }
               
                

               
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

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            var quantity = txtQuantity.Text;
            if (quantity == "" || quantity.ToDecimal() == 0)
            {
                errorProvider1.SetError(txtQuantity, "Please provide valid quantity!");
                quantityHasError = true;
        
            }
            else
            {
               
                errorProvider1.SetError(txtQuantity, null);
                quantityHasError = false;

            }
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            var price = txtPrice.Text;
            if (price == "" || price.ToDecimal() == 0)
            {
                errorProvider1.SetError(txtPrice, "Please provide valid price!");
                priceHasError = true;
               


            }
            else
            {
                errorProvider1.SetError(txtPrice, null);
                priceHasError = false;
            }
        }

        private void cboCategory_Validating(object sender, CancelEventArgs e)
        {
            var category = cboCategory.Text;
            if (category == "")
            {
                errorProvider1.SetError(cboCategory, "Please provide valid category!");
                categoryHasError = true;



            }
            else
            {
                errorProvider1.SetError(cboCategory, null);
                categoryHasError = false;
            }
        }

        private void cboProduct_Validating(object sender, CancelEventArgs e)
        {
            var product = cboProduct.Text;
            if (product == "")
            {
                errorProvider1.SetError(cboProduct, "Please provide valid product!");
                productHasError = true;



            }
            else
            {
                errorProvider1.SetError(cboProduct, null);
                productHasError = false;
            }
        }
    }
}
