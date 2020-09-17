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
    public partial class frmCategory : MetroForm
    {
        ICategoryService _categoryService;
        private int id;

        public frmCategory(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;

        }

        private async void frmCategory_Load(object sender, EventArgs e)
        {
            await LoadCategories();
        }
        private async Task LoadCategories()
        {
            try
            {
                var categories = await _categoryService.GetAll();
                int count = 0;
                lvCategories.Items.Clear();
                foreach (var item in categories)
                {
                    count++;
                    var lvi = new ListViewItem(count.ToString());
                    lvi.SubItems.Add(item.Name);
                    lvi.Tag = item.CategoryID;
                    lvCategories.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }
        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var category = new CategoryModel();
                category.Name = txtName.Text;
                //edit
                if (id > 0)
                {
                    await _categoryService.Edit(id,category);
                }
                else
                {
                    //add
                   
                    await _categoryService.Add(category);
                }
                
                await LoadCategories();
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
            

        }

        private async void lvCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id = lvCategories.SelectedItems.Count > 0 ? int.Parse(lvCategories.SelectedItems[0].Tag.ToString()) : 0;
                if(id > 0)
                {
                    var category = await _categoryService.Get(id);
                    txtName.Text = category.Name;
                }
                
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }
    }
}
