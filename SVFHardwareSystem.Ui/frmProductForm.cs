using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Extensions;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using SVFHardwareSystem.Ui.Extensions;
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
    public partial class frmProductForm : MetroForm
    {
        IProductService _productService;
        private ICategoryService _categoryService;
        private int _productID;
        private ISupplierService _supplierService;
        private int _categoryID;
        private int _supplierID;

        public frmProductForm(IProductService productService, ICategoryService categoryService, ISupplierService supplierService)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;

        }

        public frmProductForm(IProductService productService, ICategoryService categoryService, ISupplierService supplierService, int productID)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            _productService = productService;
            _categoryService = categoryService;
            _productID = productID;
            _supplierService = supplierService;

        }

        private void frmProductForm_Load(object sender, EventArgs e)
        {
           
            LoadCategories();
            SetProductData();
        }

        private async void SetProductData()
        {
            try
            {
                if (_productID > 0)
                {


                    var product = await _productService.GetAsync(_productID);

                    txtCode.Text = product.Code;
                   
                    txtLimit.Text = product.Limit.ToString();
                    txtName.Text = product.Name;
                    txtPrice.Text = product.Price.ToCurrencyFormat();
                    txtQuantity.Text = product.Quantity.ToString();
                    cboCategory.SelectedItem = cboCategory.Items.SelectItemByID(product.CategoryID);
                    
                    txtUnit.Text = product.Unit;
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        

        private async void LoadCategories()
        {
            var suppliers = await _categoryService.GetAllAsync();
            foreach (var item in suppliers)
            {
                cboCategory.Items.Add(new ItemX(item.Name, item.CategoryID.ToString()));

            }
        }

        private void btnSave_ClickAsync(object sender, EventArgs e)
        {

            Save();

        }

        private async void Save()
        {
            try
            {
                var productModel = new ProductModel();
                productModel.ProductID = _productID;
                productModel.Code = txtCode.Text;
                productModel.Name = txtName.Text;
                productModel.Price = txtPrice.Text.ToDecimal();
                productModel.Unit = txtUnit.Text;
               
                productModel.CategoryID = _categoryID;
                productModel.Limit = txtLimit.Text.ToInt();

                //edit
                if (_productID > 0)
                {
                    await _productService.EditAsync(_productID, productModel);
                }
                else
                {
                    //add
                    await _productService.AddAsync(productModel);
                }
                this.Close();
            }
            catch (InvalidFieldException ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void txtCategory_Click(object sender, EventArgs e)
        {

        }

       

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            _categoryID = ((ItemX)cboCategory.SelectedItem).Key.ToInt();
        }

        private void txtQuantity_ButtonClick(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "For updating quantity of this product, please go to Purchases.", "Adding Product Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
