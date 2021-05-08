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
                var quantity = txtQuantity.Text.ToInt();
                _productService.EditBeginningInventoryQuantity(_productID, quantity);
                _productService.EditProductQuantity(_productID, quantity);
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
