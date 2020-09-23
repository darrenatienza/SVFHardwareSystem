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
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVFHardwareSystem.Ui
{
    public partial class frmPointofSale : MetroForm
    {
        private int posTransactionID;
        private IPOSTransactionService _posTransactionService;
        private IProductService _productService;
        private ITransactionProductService _transactionProductService;
        private ICustomerService _customerService;
        private int transactionProductID;
        private int customerID;

        public frmPointofSale(IPOSTransactionService posTransactionService, 
            IProductService productService, ITransactionProductService transactionProductService,
            ICustomerService customerService)
        {

            InitializeComponent();
            _posTransactionService = posTransactionService;
            _productService = productService;
            _transactionProductService = transactionProductService;
            _customerService = customerService;
            gridList.CellValueChanged += GridList_CellValueChanged;
        }

        private async void frmPointofSale_Load(object sender, EventArgs e)

        {

            LoadAutoCompleteCustomersData();
            loadAutoCompleteData();
            await GenerateNewOrLoadUnFinishedPOSTransaction();

           
            
           
         

        }

        private async Task GenerateNewOrLoadUnFinishedPOSTransaction()
        {
            try
            {
                var previousPOSTransaction = _posTransactionService.GetUnFinishedTransaction();
                txtCost.Text = previousPOSTransaction.Cost;
                txtCustomerName.Text = previousPOSTransaction.CustomerFullName;
                customerID = previousPOSTransaction.CustomerID;
                txtSIDR.Text = previousPOSTransaction.SIDR;
                posTransactionID = previousPOSTransaction.POSTransactionID;
                await LoadProductsOnTransaction();
            }
            catch (KeyNotFoundException ex)
            {
                //no unfinished point of sale transaction found.
                //create new transaction
                MetroMessageBox.Show(this, "No unfinished transaction found, please create new transaction!","New Transaction",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private async void btnSaveTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                var posTransaction = new POSTransactionModel();
                posTransactionID = 2;
                posTransaction.CustomerID = 2;
                posTransaction.Cost = txtCost.Text;
                posTransaction.CreateTimeStamp = DateTime.Now;
                posTransaction.SIDR = txtSIDR.Text;
                //edit
                if (posTransactionID > 0)
                {
                    await _posTransactionService.Edit(posTransactionID, posTransaction);
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

        
        //AutoCompleteData Method
        private async void loadAutoCompleteData()
        {
            
            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtProductName2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtProductName2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            var productNames = await _productService.GetAll();
            foreach (var item in productNames)
            {
                txtProductName2.AutoCompleteCustomSource.Add(item.Name);
            }
            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            var customerNames = await _customerService.GetAll();
            foreach (var item in customerNames)
            {
                txtCustomerName.AutoCompleteCustomSource.Add(item.FullName.ToString());

            }

        }
        //AutoCompleteData Method
        private async void LoadAutoCompleteCustomersData()
        {

            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            var customerNames = await _customerService.GetAll();
            foreach (var item in customerNames)
            {
                txtCustomerName.AutoCompleteCustomSource.Add(item.FullName.ToString());
                
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
                var productID = _productService.GetProductID(txtProductName2.Text);
                var transactionProductModel = new TransactionProductModel();
                transactionProductModel.ProductID = productID;
                transactionProductModel.IsPaid = false;
                transactionProductModel.IsToPay = true;
                transactionProductModel.POSTransactionID = posTransactionID;
                transactionProductModel.Quantity = 1;
                transactionProductModel.UpdateTimeStamp = DateTime.Now;
                await _transactionProductService.Add(transactionProductModel);
                await LoadProductsOnTransaction();


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void txtProductName_Click(object sender, EventArgs e)
        {
            
        }

        private async Task LoadProductsOnTransaction()
        {
            try
            {
                var productsOnTransaction = await _transactionProductService.GetProductsByTransactionID(posTransactionID);
                
                int rowIndex = 0; // index of rows
                int checkboxColumnIndex = 1;
                gridList.Rows.Clear();
                decimal total = 0;
                foreach (var item in productsOnTransaction)
                {
                    gridList.Rows.Add(new object[] {
                            item.TransactionProductID.ToString(),
                           item.IsToPay,
                            item.ProductName,
                            item.ProductPrice.ToString(),
                    item.Quantity.ToString(),
                    item.Total.ToString()});
                    DataGridViewCheckBoxCell chk = gridList.Rows[rowIndex].Cells[checkboxColumnIndex] as DataGridViewCheckBoxCell;
                    if (item.IsPaid)
                    {
                        chk.ReadOnly = true;
                        chk.ToolTipText = "This item is already paid!";
                    }
                    rowIndex++; // increment for proceeding to new row;


                    //compute the total
                    total += item.Total;
                }

                txtTotal.Text = _posTransactionService.GetTotalAmount(posTransactionID).ToString();

                //select all check box state must be update to avoid confusion on current state of list
                UpdateSelecAllCheckboxState();


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
                if (transactionProductID > 0)
                {
                    var dialogResult = MetroMessageBox.Show(this, "Do you want to remove this product?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var transactionProduct = await _transactionProductService.Get(transactionProductID);
                        if (!transactionProduct.IsPaid)
                        {
                            await _transactionProductService.Remove(transactionProductID);
                            transactionProductID = 0;
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Product is already paid. You cannot remove the product!","Remove Product",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                       
                    }
                    await LoadProductsOnTransaction();

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

       

        
        private void SelectAllProducts()
        {
            var rows = gridList.Rows;
            int checkboxColumnIndex = 1;

            transactionProductID = 0;
            gridList.CellValueChanged -= GridList_CellValueChanged; // subscribe for future manual action
            gridList.CellMouseUp -= gridList_CellMouseUp;
            foreach (DataGridViewRow item in rows)
            {
                //row with readonly checkbox is already paid 
                //then must not change the value
                if (!item.Cells[checkboxColumnIndex].ReadOnly)
                {
                    var _transactionProductID = int.Parse(item.Cells[0].Value.ToString());
                    item.Cells[checkboxColumnIndex].Value = chkSelectAll.Checked;
                    var chkValue = bool.Parse(item.Cells[checkboxColumnIndex].Value.ToString());
                    _transactionProductService.EditIsToPay(_transactionProductID, chkValue);

                }
            }
            txtTotal.Text = _posTransactionService.GetTotalAmount(posTransactionID).ToString();
            gridList.CellValueChanged += GridList_CellValueChanged; // subscribe for future manual action
            gridList.CellMouseUp += gridList_CellMouseUp;
        }
        private void UpdateSelecAllCheckboxState()
        {
            // unsubcribe on checkbox event to avoid multiple event occurences 
            // on checkbox while updating the state of select all checkbox
            chkSelectAll.CheckedChanged -= ChkSelectAll_CheckedChanged; 

            int totalRows = gridList.Rows.Count;
            int unCheckRows = 0;
            var rows = gridList.Rows;
            int checkboxColumnIndex = 1;
            foreach (DataGridViewRow item in rows)
            {
                if (!bool.Parse(item.Cells[checkboxColumnIndex].Value.ToString()))
                {
                    unCheckRows++;
                }
            }
           
            if (unCheckRows == totalRows)
            {
                chkSelectAll.CheckState = CheckState.Unchecked;
            }
            if (unCheckRows > 0 && unCheckRows < totalRows)
            {
                chkSelectAll.CheckState = CheckState.Indeterminate;
            }
            if (unCheckRows == 0)
            {
                chkSelectAll.CheckState = CheckState.Checked;
            }
            chkSelectAll.CheckedChanged += ChkSelectAll_CheckedChanged; // subcribe on checkbox event to handle future manual action on select all checkbox;
        }

        private void gridList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // handles checkbox click event on datagridview
            int checkboxColumnIndex = 1;
            if (e.ColumnIndex == checkboxColumnIndex && e.RowIndex != -1)
            {
                gridList.EndEdit();
            }
        }

        private void gridList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = gridList;

            if (grid.SelectedRows.Count > 0)
            {
                transactionProductID = int.Parse(grid.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void frmPointofSale_Shown(object sender, EventArgs e)
        {
          
            //load only after all objects and event initialized to avoid
            //recursive action on updating the state of select all checkbox
            chkSelectAll.CheckedChanged += ChkSelectAll_CheckedChanged;
        }

        private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.CheckState != CheckState.Indeterminate)
            {
                SelectAllProducts();
            }
        }

        private void GridList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // handles checkbox click event on datagridview
                int checkboxColumnIndex = 1;
                if (e.ColumnIndex == checkboxColumnIndex && e.RowIndex != -1)
                {
                    if (transactionProductID > 0)
                    {
                        var rows = gridList.SelectedRows[0];
                        var chkValue = bool.Parse(rows.Cells[checkboxColumnIndex].Value.ToString());
                        _transactionProductService.EditIsToPay(transactionProductID, chkValue);
                        txtTotal.Text = _posTransactionService.GetTotalAmount(posTransactionID).ToString();
                    }

                }
                UpdateSelecAllCheckboxState();

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }


        private async Task SetTransactionData()
        {
            try
            {
                if (txtSIDR.Text != "")
                {
                   
                    var code = txtSIDR.Text;
                    var posTransaction = await _posTransactionService.Get(code);
                    posTransactionID = posTransaction.POSTransactionID;
                   txtCost.Text = posTransaction.Cost;
                    txtCustomerName.Text = posTransaction.CustomerFullName;
                    await LoadProductsOnTransaction();
                }
                else
                {
                    MetroMessageBox.Show(this, "Please provide SI/DR!", "SI/DR is empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSIDR.WithError = true;
                }
                
            }
            catch (KeyNotFoundException)
            {
                MetroMessageBox.Show(this, "No Record Found on SI/DR!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                gridList.Rows.Clear();
                txtCost.Text = "";
                txtCustomerName.Text = "";
                txtTotal.Text = "0.00";
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private async void txtSIDR_ButtonClick(object sender, EventArgs e)
        {
            await SetTransactionData();
            

        }

        private void txtProductName_ButtonClick(object sender, EventArgs e)
        {

        }

        private async void btnNewTransaction_Click(object sender, EventArgs e)
        {
            await AddNewPOSTransaction();
        }

        private async Task AddNewPOSTransaction()
        {
            try
            {
                if (posTransactionID == 0)
                {


                    if(ValidatePOSTransactionFields())
                    {
                        var newPOSTransaction = new POSTransactionModel();
                        newPOSTransaction.Cost = txtCost.Text;
                        newPOSTransaction.CreateTimeStamp = DateTime.Now;
                        newPOSTransaction.CustomerID = customerID;
                        newPOSTransaction.SIDR = txtSIDR.Text;
                        newPOSTransaction = await _posTransactionService.AddNew(newPOSTransaction);
                        posTransactionID = newPOSTransaction.POSTransactionID;
                        MetroMessageBox.Show(this, "New Point of Sale Transaction has been generated!", "New Point of Sale Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                }
                else
                {
                    MetroMessageBox.Show(this, "A Transaction is currently loaded. Generating new Transaction is not required.", "New Point of Sale Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private bool ValidatePOSTransactionFields()
        {

            //form validation
            if (txtCost.Text == "")
            {
                MetroMessageBox.Show(this, "Cost is required!", "New Point of Sale Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCost.WithError = true;
                return false;
            }
            if (txtSIDR.Text == "")
            {
                MetroMessageBox.Show(this, "SI/DR is required!", "New Point of Sale Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSIDR.WithError = true;
                return false;
            }
            if (txtCustomerName.Text == "" || customerID == 0)
            {
                MetroMessageBox.Show(this, "Customer is required!", "New Point of Sale Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.WithError = true;
                return false;
            }

            return true ;
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetCustomerIDField();
            }
        }

        private void SetCustomerIDField()
        {

            try
            {
                //if an update to customer is executed and a pos transaction is currently loaded
                // the customer id must be updated in the current pos transaction record
                //if no pos transaction is loaded, just set it to the customer id

                //get the custmer id according to its name
                customerID = _customerService.GetCustomerID(txtCustomerName.Text);
                
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }

        }

        private void txtCustomerName_ButtonClick(object sender, EventArgs e)
        {
            FormHandler.OpenCustomersForm().ShowDialog();
            LoadAutoCompleteCustomersData();
        }

        private async void btnUpdatePOSTransactionDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (posTransactionID > 0)
                {
                    if (ValidatePOSTransactionFields())
                    {
                        var posTransaction = await _posTransactionService.Get(posTransactionID);
                        posTransaction.Cost = txtCost.Text;
                        posTransaction.CustomerID = customerID;
                        posTransaction.SIDR = txtSIDR.Text;
                        await _posTransactionService.Edit(posTransactionID, posTransaction);
                        MetroMessageBox.Show(this, "Point of Sale Details has been updated", "Update Point of Sale Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                else
                {
                    MetroMessageBox.Show(this, "No Point of Sale Transaction is loaded!", "Update Point of Sale Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }
    }
}
