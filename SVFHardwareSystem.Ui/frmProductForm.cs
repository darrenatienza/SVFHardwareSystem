﻿using MetroFramework.Forms;
using SVFHardwareSystem.Services;
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
        ProductService productService;
        public frmProductForm()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            productService = new ProductService();
        }

        private void frmProductForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnSave_ClickAsync(object sender, EventArgs e)
        {
            var productModel = new ProductModel();
            productModel.Code = txtCode.Text;
            productModel.Name = txtName.Text;
            productModel.Price = decimal.Parse(txtPrice.Text);
            productModel.Unit = txtUnit.Text;
            await Task.Run(() =>productService.Add(productModel));
        }
        
       
    }
}
