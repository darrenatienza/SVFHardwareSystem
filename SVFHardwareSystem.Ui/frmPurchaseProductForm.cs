using MetroFramework;
using MetroFramework.Forms;
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
    public partial class frmPurchaseProductForm : MetroForm
    {
        private IProductService _productService;
        private int _purchaseID;
        private ICategoryService _categoryService;
        private IPurchaseService _purchaseService;
        private int _productID;
        private int _categoryID;
        private int _purchaseProductID;
        public frmPurchaseProductForm(IProductService productService, ICategoryService categoryService,IPurchaseService purchaseService, int purchaseID)
        {
            InitializeComponent();
            _productService = productService;
            _purchaseID = purchaseID;
            _categoryService = categoryService;
            _purchaseService = purchaseService;
        }
        public frmPurchaseProductForm(IProductService productService,ICategoryService categoryService, IPurchaseService purchaseService, int purchaseID, int productID)
        {
            InitializeComponent();
            _productService = productService;
            _purchaseID = purchaseID;
            _productID = productID;
            _categoryService = categoryService;
            _purchaseService = purchaseService;
        }
        private void frmPurchaseProductForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            SetPurchaseProductData();
        }

        private async  void SetPurchaseProductData()
        {
            try
            {
                if (_purchaseID != 0)
                {


                    var purchaseProduct = await _purchaseService.GetPurchaseProduct(_purchaseID, _productID);
                    if (purchaseProduct != null)
                    {
                        if (!purchaseProduct.IsQuantityUploaded)
                        {
                            _purchaseProductID = purchaseProduct.PurchaseProductID;
                            txtQuantity.Text = purchaseProduct.Quantity.ToString();
                            cboCategory.SelectedItem = cboCategory.Items.SelectItemByID(purchaseProduct.ProductCategoryID);
                            await Task.Delay(1);
                            cboProduct.SelectedItem = cboProduct.Items.SelectItemByID(purchaseProduct.ProductID);
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Purchase Product where quantity was uploaded to Product Inventory can't be edit!", "Edit Purchase Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }


                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "No Purchase is selected. Please select on purchase dates!", "Edit Purchase Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }




            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadProducts()
        {
            try
            {
                var suppliers = await _productService.GetAllByCategoryID(_categoryID);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private async void Save()
        {
            try
            {
                var purchaseProduct = new PurchaseProductModel();
                purchaseProduct.PurchaseProductID = _purchaseProductID;
                purchaseProduct.ProductID = _productID;
                purchaseProduct.Quantity = txtQuantity.Text.ToInt();
                //purchaseProduct.IsQuantityUploaded = chkUploadQuantity.Checked;
                purchaseProduct.Price = txtPrice.Text.ToDecimal();
                if (_purchaseProductID > 0)
                {
                    // edit
                    await _purchaseService.EditPurchaseProduct(purchaseProduct);
                }
                else
                {
                    // add
                    await _purchaseService.AddPurchaseProductAsync(_purchaseID,purchaseProduct);
                }
                this.Close();
            }
            catch (InvalidFieldException ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (RecordAlreadyExistsException ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private  void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCategoryID();
             LoadProducts();
        }

        private void SetCategoryID()
        {
            _categoryID = ((ItemX)cboCategory.SelectedItem).Key.ToInt();
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetProductID();
            SetProductData();
        }

        private void SetProductData()
        {
            try
            {
                var product = _productService.Get(_productID);
                txtUnit.Text = product.Unit;
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

        private void SetProductID()
        {
            _productID = ((ItemX)cboProduct.SelectedItem).Key.ToInt();
        }
    }
}
