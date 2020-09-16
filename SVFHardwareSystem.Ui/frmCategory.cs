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
    public partial class frmCategory : MetroForm
    {
        ICategoryService _categoryService;

        public frmCategory(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;

        }

        private void frmCategory_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var category = new CategoryModel();
            category.Name = txtName.Text;
           await  Task.Run(() =>_categoryService.Add(category).ConfigureAwait(false));

        }
    }
}
