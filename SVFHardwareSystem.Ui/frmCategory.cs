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
                var categories = await _categoryService.GetAllAsync();
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
                    await _categoryService.EditAsync(id,category);
                }
                else
                {
                    //add
                    await _categoryService.AddAsync(category);
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
                    var category = await _categoryService.GetAsync(id);
                    txtName.Text = category.Name;
                }
                
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {
                    var dialogResult = MetroMessageBox.Show(this, "Do you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                       await _categoryService.RemoveAsync(id);
                        id = 0;
                        ResetInputValues();
                    }
                    await LoadCategories();
                    
                }
                else
                {
                    MetroMessageBox.Show(this, "No record selected to remove", "Notification", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void ResetInputValues()
        {
            txtName.ResetText();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResetInputValues();
            id = 0;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var categories = await _categoryService.GetAll(txtSearch.Text);
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
    }
}
