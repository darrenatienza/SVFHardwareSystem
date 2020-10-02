using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services;
using SVFHardwareSystem.Services.Extensions;
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
            LoadSupplierAutoComplete();
            LoadAutoCompleteCategoriesData();
            SetProductData();
        }

        private async void SetProductData()
        {
            try
            {
                if (_productID > 0)
                {


                    var product = await _productService.Get(_productID);
                    txtCategory.Text = product.CategoryName;
                    txtCode.Text = product.Code;
                    txtDealersPrice.Text = product.DealersPrice.ToString();
                    txtLimit.Text = product.Limit.ToString();
                    txtName.Text = product.Name;
                    txtPrice.Text = product.Price.ToString();
                    txtSupplier.Text = product.SupplierName;
                    txtUnit.Text = product.Unit;
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private async void LoadSupplierAutoComplete()
        {
            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtSupplier.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            var customerNames = await _supplierService.GetAll();
            foreach (var item in customerNames)
            {
                txtSupplier.AutoCompleteCustomSource.Add(item.Name.ToString());

            }
        }

        private async void LoadAutoCompleteCategoriesData()
        {

            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtCategory.AutoCompleteMode = AutoCompleteMode.Suggest;
            var customerNames = await _categoryService.GetAll();
            foreach (var item in customerNames)
            {
                txtCategory.AutoCompleteCustomSource.Add(item.Name.ToString());

            }

        }

        private  void btnSave_ClickAsync(object sender, EventArgs e)
        {

            Save();
           
        }

        private async void Save()
        {
            try
            {
                var productModel = new ProductModel();
                productModel.Code = txtCode.Text;
                productModel.Name = txtName.Text;
                productModel.Price = txtPrice.Text.ToDecimal();
                productModel.Unit = txtUnit.Text;
                productModel.SupplierName = txtSupplier.Text;
                productModel.CategoryName= txtCategory.Text;
                productModel.Limit = txtLimit.Text.ToInt();
                productModel.DealersPrice = txtLimit.Text.ToDecimal();
                //edit
                if (_productID > 0)
                {
                    await _productService.Edit(_productID, productModel);
                }
                else
                {
                    //add
                    await _productService.Add(productModel);
                }
                this.Close();
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void txtCategory_Click(object sender, EventArgs e)
        {
            
        }
    }
}
