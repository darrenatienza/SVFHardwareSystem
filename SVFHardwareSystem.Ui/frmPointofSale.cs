using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Exceptions;
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
        private int _posTransactionID;
        private IPOSTransactionService _posTransactionService;
        private IProductService _productService;
        private ITransactionProductService _transactionProductService;
        private ICustomerService _customerService;
        private int _transactionProductID;
        private int customerID;
        private bool _isFinishedPosTransaction;
        private bool _isFullyPaid;

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
                _posTransactionID = previousPOSTransaction.POSTransactionID;
                txtReceivable.Text = "0.00"; // all unfinished transactions have 0.00 value
                _isFinishedPosTransaction = previousPOSTransaction.IsFinished;
                txtTotal.Text = previousPOSTransaction.TotalAmount.ToString();
                await LoadProductsOnTransaction();
            }
            catch (KeyNotFoundException ex)
            {

                txtCost.Text = "";
                txtCustomerName.Text = "";
                customerID = 0;
                txtSIDR.Text = "";
                _posTransactionID = 0;
                _isFinishedPosTransaction = false;
                txtTotal.Text = "0.00";
                txtReceivable.Text = "0.00";

                gridList.Rows.Clear();
                this.ActiveControl = txtCost;
                //no unfinished point of sale transaction found.
                //create new transaction
                MetroMessageBox.Show(this, "No unfinished transaction found, please create new transaction!", "New Transaction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                _posTransactionID = 2;
                posTransaction.CustomerID = 2;
                posTransaction.Cost = txtCost.Text;
                posTransaction.CreateTimeStamp = DateTime.Now;
                posTransaction.SIDR = txtSIDR.Text;
                //edit
                if (_posTransactionID > 0)
                {
                    await _posTransactionService.Edit(_posTransactionID, posTransaction);
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
            txtProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            var productNames = await _productService.GetAll();
            foreach (var item in productNames)
            {
                txtProductName.AutoCompleteCustomSource.Add(item.Name);
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

        private async void AddProductOnTransaction()
        {
            try
            {
                if (_posTransactionID > 0)
                {
                    //get the product id according to its name
                    var productID = _productService.GetProductID(txtProductName.Text);
                    var transactionProductModel = new TransactionProductModel();
                    transactionProductModel.ProductID = productID;
                    transactionProductModel.IsPaid = false;
                    transactionProductModel.IsToPay = true;
                    transactionProductModel.POSTransactionID = _posTransactionID;
                    transactionProductModel.Quantity = 1;
                    transactionProductModel.UpdateTimeStamp = DateTime.Now;
                    await _transactionProductService.AddNewTransactionProductAsync(transactionProductModel);
                    await LoadProductsOnTransaction();
                    await SetTransactionData();
                }
                else
                {
                    MetroMessageBox.Show(this, "No Point of Sale Transaction Found!", "Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            catch (RecordNotFoundException ex)
            {
                MetroMessageBox.Show(this, string.Format("{0} for {1}", ex.Message, txtProductName.Text), "Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (LimitMustNotReachException ex)
            {
                MetroMessageBox.Show(this, ex.Message);
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
                var productsOnTransaction = await _transactionProductService.GetProductsByTransactionID(_posTransactionID);

                int rowIndex = 0; // index of rows
                int checkboxColumnIndex = 1;
                gridList.Rows.Clear();
                decimal total = 0;
                int count = 0;
                foreach (var item in productsOnTransaction)
                {
                    count++;
                    gridList.Rows.Add(new object[] {item.TransactionProductID.ToString(),item.IsToPay,
                          count.ToString(),
                          //IsReplace and IsCancel = true then show productName [replace] [cancelled]
                            item.IsReplace && item.IsCancel ? item.ProductName + " [replaced] [cancelled]"
                             //IsCancel = true then show productName [cancelled]
                           :item.IsCancel ? item.ProductName + " [cancelled] "
                            //IsReplace = true then show productName [replace]
                            :  item.IsReplace ?  item.ProductName + " [replaced] "
                            //show product name only
                             : item.ProductName,
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



                //select all check box state must be update to avoid confusion on current state of list
                UpdateSelecAllCheckboxState();


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (_transactionProductID > 0)
                {
                    if (!_isFinishedPosTransaction)
                    {


                        var dialogResult = MetroMessageBox.Show(this, "Do you want to remove this product?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            var transactionProduct = await _transactionProductService.Get(_transactionProductID);
                            if (!transactionProduct.IsPaid)
                            {

                                await _transactionProductService.RemoveTransactionProductAsync(_transactionProductID);
                                _transactionProductID = 0;
                            }
                            else
                            {
                                MetroMessageBox.Show(this, "Product is already paid. You cannot remove the product!", "Remove Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        await SetTransactionData();
                        await LoadProductsOnTransaction();

                    }
                    else
                    {
                        MetroMessageBox.Show(this, "You cannot delete products with finished Point of Sale Transaction!", "Remove Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

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

            _transactionProductID = 0;
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
            txtTotal.Text = _posTransactionService.GetTotalAmount(_posTransactionID).ToString();
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
                _transactionProductID = int.Parse(grid.SelectedRows[0].Cells[0].Value.ToString());

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
                    if (_transactionProductID > 0)
                    {
                        var rows = gridList.SelectedRows[0];
                        var chkValue = bool.Parse(rows.Cells[checkboxColumnIndex].Value.ToString());
                        _transactionProductService.EditIsToPay(_transactionProductID, chkValue);
                        txtTotal.Text = _posTransactionService.GetTotalAmount(_posTransactionID).ToString("N");
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
                    _posTransactionID = posTransaction.POSTransactionID;
                    txtCost.Text = posTransaction.Cost;
                    txtCustomerName.Text = posTransaction.CustomerFullName;
                    customerID = posTransaction.CustomerID;
                    txtReceivable.Text = posTransaction.Receivable.ToString();
                    _isFinishedPosTransaction = posTransaction.IsFinished;
                    _isFullyPaid = posTransaction.IsFullyPaid;
                    txtTotal.Text = posTransaction.TotalAmount.ToString("N"); // currency format no symbol
                    txtPayment.Text = posTransaction.TotalPayment.ToString();
                    txtCancelAmount.Text = posTransaction.CancelAmount.ToString();
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
                MetroMessageBox.Show(this, "No Record Found on SI/DR!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gridList.Rows.Clear();
                txtCost.Text = "";
                txtCustomerName.Text = "";
                txtTotal.Text = "0.00";
                _isFinishedPosTransaction = false;
                _isFullyPaid = false;
                _posTransactionID = 0;

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

        private async void txtProductName_ButtonClick(object sender, EventArgs e)
        {
            FormHandler.OpenPointOfSaleQuantityEditForm(_posTransactionID).ShowDialog();
            await LoadProductsOnTransaction();
            await SetTransactionData();
        }

        private async void btnNewTransaction_Click(object sender, EventArgs e)
        {
            await AddNewPOSTransaction();
        }

        private async Task AddNewPOSTransaction()
        {
            try
            {
                if (_posTransactionID == 0)
                {


                    if (ValidatePOSTransactionFields())
                    {
                        var newPOSTransaction = new POSTransactionModel();
                        newPOSTransaction.Cost = txtCost.Text;
                        newPOSTransaction.CreateTimeStamp = DateTime.Now;
                        newPOSTransaction.CustomerID = customerID;
                        newPOSTransaction.SIDR = txtSIDR.Text;
                        newPOSTransaction = await _posTransactionService.AddNew(newPOSTransaction);
                        _posTransactionID = newPOSTransaction.POSTransactionID;
                        MetroMessageBox.Show(this, "New Point of Sale Transaction has been generated!", "New Point of Sale Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    DialogResult d = MetroMessageBox.Show(this, "A Transaction is currently loaded. Do you want to reload unfinished Point of Sale Transaction?", "New Point of Sale Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (d == DialogResult.Yes)
                    {
                        await GenerateNewOrLoadUnFinishedPOSTransaction();
                    }
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

            return true;
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
            catch (RecordNotFoundException ex)
            {

                MetroMessageBox.Show(this, string.Format("{0} for {1}", ex.Message, txtCustomerName.Text), "Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Text = "";
                txtCustomerName.Focus();
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
                if (_posTransactionID > 0)
                {
                    if (!_isFinishedPosTransaction)
                    {


                        if (ValidatePOSTransactionFields())
                        {
                            var posTransaction = await _posTransactionService.Get(_posTransactionID);
                            posTransaction.Cost = txtCost.Text;
                            posTransaction.CustomerID = customerID;
                            posTransaction.SIDR = txtSIDR.Text;
                            await _posTransactionService.Edit(_posTransactionID, posTransaction);
                            MetroMessageBox.Show(this, "Point of Sale Details has been updated", "Update Point of Sale Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "You cannot update a finished Point of Sale Transaction!", "Update Point of Sale Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (_posTransactionID > 0)
                {
                    var total = _posTransactionService.GetTotalAmount(_posTransactionID);
                    var receivableAmout = _posTransactionService.GetReceivableAmount(_posTransactionID);
                    if (total > 0 || receivableAmout > 0)
                    {
                        FormHandler.OpenPointOfSalePaymentForm(_posTransactionID).ShowDialog();

                        // this means that a pos transaction is loaded and if payment commited, it will reload the computation
                        // and update the interface
                        await SetTransactionData();

                        if (_isFullyPaid)
                        {
                            await GenerateNewOrLoadUnFinishedPOSTransaction();
                        }




                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Total Amount or Receivable must be greater than 0!", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MetroMessageBox.Show(this, "No Point of Sale Transaction is loaded!", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }

        }

        private void tmrControlState(object sender, EventArgs e)
        {
            ManageControlState();
        }

        private void ManageControlState()
        {

            if (_posTransactionID == 0 || _isFinishedPosTransaction)
            {
                btnRemove.Enabled = false;
                btnUpdatePOSTransactionDetails.Enabled = false;
                txtProductName.Enabled = false;

            }
            else
            {
                btnRemove.Enabled = true;
                btnUpdatePOSTransactionDetails.Enabled = true;
                txtProductName.Enabled = true;
                txtReceivable.Visible = true;

            }
            // when transaction is finish
            if (!_isFinishedPosTransaction)
            {
                pnlSummary.Visible = false;
                btnCancelReplace.Enabled = false;
            }
            else
            {
                pnlSummary.Visible = true;
                btnCancelReplace.Enabled = true;
            }
            // when transaction is fully paid or when the grid list has no product
            if (_isFullyPaid || gridList.Rows.Count == 0)
            {
                btnPayment.Enabled = false;

            }
            else
            {
                btnPayment.Enabled = true;
            }

        }

        private async void btnCancelReplace_Click(object sender, EventArgs e)
        {
            if (_isFinishedPosTransaction)
            {
                FormHandler.OpenSalesReplaceCancelForm(_transactionProductID).ShowDialog();
                await SetTransactionData();
            }

        }
    }
}
