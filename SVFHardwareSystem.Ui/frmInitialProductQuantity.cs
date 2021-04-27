using MetroFramework;
using MetroFramework.Forms;
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
    }
}
