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
    public partial class frmPointofSale : MetroForm
    {
        private int id;
        private IPOSTransactionService _posTransactionService;
        private IProductService _productService;
        private ITransactionProductService _transactionProductService;

        public frmPointofSale(IPOSTransactionService posTransactionService, 
            IProductService productService, ITransactionProductService transactionProductService)
        {

            InitializeComponent();
            txtProductName.CustomButton.Click += CustomButton_Click;
            _posTransactionService = posTransactionService;
            _productService = productService;
            _transactionProductService = transactionProductService;
        }

        private  void frmPointofSale_Load(object sender, EventArgs e)

        {

             loadAutoCompleteData();
            LoadProductsOnTransaction();

        }

        private async void btnSaveTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                var posTransaction = new POSTransactionModel();
                id = 2;
                posTransaction.CustomerID = 2;
                posTransaction.Cost = txtCost.Text;
                posTransaction.CreateTimeStamp = DateTime.Now;
                posTransaction.SIDR = txtSIDR.Text;
                //edit
                if (id > 0)
                {
                    await _posTransactionService.Edit(id, posTransaction);
                }
                else
                {
                    //add
                    await _posTransactionService.Add(posTransaction);
                }

               // await LoadCategories();
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        //AutoCompleteData Method
        private async void loadAutoCompleteData()
        {
            
            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            var productNames = await _productService.GetAll();
            foreach (var item in productNames)
            {
                txtProductName.AutoCompleteCustomSource.Add(item.Name);
            }
            
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddProductOnTransaction();
            }
        }

        private async  void AddProductOnTransaction()
        {
            try
            {

                //get the product id according to its name
                var productID = _productService.GetProductID(txtProductName.Text);
                var transactionProductModel = new TransactionProductModel();
                transactionProductModel.ProductID = productID;
                transactionProductModel.IsPaid = false;
                transactionProductModel.POSTransactionID = 2;
                transactionProductModel.Quantity = 1;
                transactionProductModel.UpdateTimeStamp = DateTime.Now;
                await _transactionProductService.Add(transactionProductModel);
                LoadProductsOnTransaction();


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void txtProductName_Click(object sender, EventArgs e)
        {
            
        }

        private async void LoadProductsOnTransaction()
        {
            try
            {
                var productsOnTransaction = await _transactionProductService.GetProductsByTransactionID(2);
                int count = 0;
                gridList.Rows.Clear();
                foreach (var item in productsOnTransaction)
                {
                    gridList.Rows.Add(new string[] {
                            item.TransactionProductID.ToString(),
                            count.ToString(),
                            item.ProductName,
                            item.ProductPrice.ToString(),
                    item.Quantity.ToString(),
                    item.Total.ToString()});
                }
               
                
                
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private async  void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {
                    var dialogResult = MetroMessageBox.Show(this, "Do you want to delete this product?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        await _transactionProductService.Remove(id);
                        id = 0;
                    }
                    LoadProductsOnTransaction();

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

        private void gridList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = gridList;

            if (grid.SelectedRows.Count > 0)
            {
                id = int.Parse(grid.SelectedRows[0].Cells[0].Value.ToString());

            }
        }
    }
}
