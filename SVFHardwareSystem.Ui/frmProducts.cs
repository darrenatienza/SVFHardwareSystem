using MetroFramework;
using MetroFramework.Forms;
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
    public partial class frmProducts : MetroForm
    {
        private ICategoryService _categoryService;
        private IProductService _productService;
        private int _productID;

        public frmProducts(ICategoryService categoryService, IProductService productService)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            _categoryService = categoryService;
            _productService = productService;
        }


        //AutoCompleteData Method
        private async void LoadAutoCompleteCategoriesData()
        {

            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtCategories.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtCategories.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            var customerNames = await _categoryService.GetAll();
            foreach (var item in customerNames)
            {
                txtCategories.AutoCompleteCustomSource.Add(item.Name.ToString());

            }

        }
        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadAutoCompleteCategoriesData();
            LoadProducts();
        }
        private void LoadProducts()
        {
            try
            {
                var category = txtCategories.Text;
                var criteria = txtSearch.Text;
                var products = _productService.GetAll(category, criteria);
                int count = 0;
                gridProducts.Rows.Clear();
                foreach (var item in products)
                {
                    count++;
                    gridProducts.Rows.Add(new object[] {
                            item.ProductID.ToString(),
                            count.ToString(),
                            item.CategoryName,
                            item.Code,
                            item.Name,
                    item.Unit,
                    item.Price,
                    item.DealersPrice,
                    item.Quantity,
                    item.Limit});
                }


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void txtSearch_ButtonClick(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditProduct();
        }

        private void EditProduct()
        {
            FormHandler.OpenProductForm(_productID).ShowDialog();
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void AddProduct()
        {
            FormHandler.OpenProductForm().ShowDialog();
            LoadProducts();
        }

        private void gridProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SetProductID();
        }

        private void SetProductID()
        {
            var grid = gridProducts;

            if (grid.SelectedRows.Count > 0)
            {
                _productID = int.Parse(grid.SelectedRows[0].Cells[0].Value.ToString());



            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteProduct();
        }

        private async void DeleteProduct()
        {
            try
            {
                if (_productID > 0)
                {
                    var dialogResult = MetroMessageBox.Show(this, "Do you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        await _productService.Remove(_productID);

                    }
                    _productID = 0;
                    LoadProducts();

                }
                else
                {
                    MetroMessageBox.Show(this, "No record selected to remove", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }
    }
}
