using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using SVFHardwareSystem.Services.Extensions;
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
        private int _saleID;
        private ISaleService _saleService;
        private IProductService _productService;
        private ISaleProductService _transactionProductService;
        private ICustomerService _customerService;
        private int _transactionProductID;
        private int customerID;
        private bool _isFinishedSale;
        private bool _isFullyPaid;

        public frmPointofSale(ISaleService saleService,
            IProductService productService, ISaleProductService saleProductService,
            ICustomerService customerService)
        {

            InitializeComponent();
            _saleService = saleService;
            _productService = productService;
            _transactionProductService = saleProductService;
            _customerService = customerService;
            gridList.CellValueChanged += GridList_CellValueChanged;
            txtCustomerName.GotFocus += TxtCustomerName_GotFocus;
        }

        

     

        private async void frmPointofSale_Load(object sender, EventArgs e)

        {


            await GenerateNewOrLoadUnFinishedSale();






        }

        private async Task GenerateNewOrLoadUnFinishedSale()
        {
            try
            {
                var previousPOSTransaction = _saleService.GetUnFinishedTransaction();
                dtSalesTransactionDate.Value = previousPOSTransaction.SaleDate;
                txtCost.Text = previousPOSTransaction.Cost;
                txtCustomerName.Text = previousPOSTransaction.CustomerFullName;
                customerID = previousPOSTransaction.CustomerID;
                txtSIDR.Text = previousPOSTransaction.SIDR;
                _saleID = previousPOSTransaction.SaleID;
                txtReceivable.Text = "0.00"; // all unfinished transactions have 0.00 value
                _isFinishedSale = previousPOSTransaction.IsFinished;
                _isFullyPaid = previousPOSTransaction.IsFullyPaid;
                txtTotal.Text = previousPOSTransaction.TotalAmount.ToCurrencyFormat();
                await LoadProductsOnTransaction();
            }
            catch (KeyNotFoundException ex)
            {

                txtCost.Text = "";
                txtCustomerName.Text = "";
                customerID = 0;
                txtSIDR.Text = "";
                _saleID = 0;
                _isFinishedSale = false;
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

        

        

        private async Task AddProductOnTransaction()
        {
            try
            {
                if (_saleID > 0)
                {
                    //get the product id according to its name
                    var productID = _productService.GetProductID(txtProductName.Text);
                    var transactionProductModel = new SaleProductModel();
                    transactionProductModel.ProductID = productID;
                    transactionProductModel.IsPaid = false;
                    transactionProductModel.IsToPay = true;
                    transactionProductModel.SaleID = _saleID;
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
                var productsOnTransaction = await _transactionProductService.GetProductsBySaleID(_saleID);

                int rowIndex = 0; // index of rows
                int checkboxColumnIndex = 1;
                gridList.Rows.Clear();
                decimal total = 0;
                int count = 0;
                foreach (var item in productsOnTransaction)
                {
                    count++;
                    gridList.Rows.Add(new object[] {item.SaleProductID.ToString(),item.IsToPay,
                          count.ToString(),
                          //IsReplace and IsCancel = true then show productName [replace] [cancelled]
                            item.IsReplace && item.IsCancel ? string.Format("{0} [{1} {2}, {3} {4}]", item.ProductName ,item.QuantityToReplace.ToString(),"replaced", item.QuantityToCancel.ToString(),"cancelled")
                             //IsCancel = true then show productName [cancelled]
                           :item.IsCancel ?string.Format("{0} [{1} {2}]", item.ProductName ,item.QuantityToCancel.ToString(),"cancelled")
                            //IsReplace = true then show productName [replace]
                            :  item.IsReplace ?  string.Format("{0} [{1} {2}]", item.ProductName ,item.QuantityToReplace.ToString(),"replaced")
                            //show product name only
                             : item.ProductName,
                            item.Price.ToCurrencyFormat(),
                    item.Quantity.ToCurrencyFormat(),
                    item.Total.ToCurrencyFormat()});
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
                    if (!_isFinishedSale)
                    {


                        var dialogResult = MetroMessageBox.Show(this, "Do you want to remove this product?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            var transactionProduct = await _transactionProductService.GetAsync(_transactionProductID);
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
            txtTotal.Text = _saleService.GetTotalAmount(_saleID).ToString();
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
                        txtTotal.Text = _saleService.GetTotalAmount(_saleID).ToString("N");
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
                    var posTransaction = await _saleService.Get(code);
                    SetSaleData(posTransaction);
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
                _isFinishedSale = false;
                _isFullyPaid = false;
                _saleID = 0;

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }
        public void SetSaleData(SaleModel model)
        {
            _saleID = model.SaleID;
            txtCost.Text = model.Cost;
            txtCustomerName.Text = model.CustomerFullName;
            customerID = model.CustomerID;
            txtReceivable.Text = model.Receivable.ToCurrencyFormat();
            _isFinishedSale = model.IsFinished;
            _isFullyPaid = model.IsFullyPaid;
            txtTotal.Text = model.TotalAmount.ToCurrencyFormat();
            txtPayment.Text = model.TotalPayment.ToCurrencyFormat();
            txtCancelAmount.Text = model.CancelAmount.ToCurrencyFormat();
            dtSalesTransactionDate.Value = model.SaleDate;
            //close customer search list
            lbCustomer.Visible = false;
        }
        
        private async void txtProductName_ButtonClick(object sender, EventArgs e)
        {
            FormHandler.OpenPointOfSaleQuantityEditForm(_saleID).ShowDialog();
            await LoadProductsOnTransaction();
            await SetTransactionData();
        }

        private async void btnNewTransaction_Click(object sender, EventArgs e)
        {
            await AddNewSale();
            this.Focus();
        }

        private async Task AddNewSale()
        {
            try
            {
                if (_saleID == 0)
                {


                    if (VAlidateFields())
                    {
                        var newPOSTransaction = new SaleModel();
                        newPOSTransaction.SaleDate = dtSalesTransactionDate.Value;
                        newPOSTransaction.Cost = txtCost.Text;
                        newPOSTransaction.CreateTimeStamp = DateTime.Now;
                        newPOSTransaction.CustomerID = customerID;
                        newPOSTransaction.SIDR = txtSIDR.Text;
                        newPOSTransaction = await _saleService.AddNewAsync(newPOSTransaction);
                        _saleID = newPOSTransaction.SaleID;
                        MetroMessageBox.Show(this, "New Point of Sale Transaction has been generated!", "New Point of Sale Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    DialogResult d = MetroMessageBox.Show(this, "A Transaction is currently loaded. Do you want to reload unfinished Point of Sale Transaction?", "New Point of Sale Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (d == DialogResult.Yes)
                    {
                        await GenerateNewOrLoadUnFinishedSale();
                    }
                }
                


            }
            catch (CustomBaseException ex)
            {

                MetroMessageBox.Show(this, ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VAlidateFields()
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

        }

        private async void btnUpdateSaleDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (_saleID > 0)
                {
                    if (!_isFinishedSale)
                    {


                        if (VAlidateFields())
                        {
                            var posTransaction = await _saleService.GetAsync(_saleID);
                            posTransaction.Cost = txtCost.Text;
                            posTransaction.CustomerID = customerID;
                            posTransaction.SIDR = txtSIDR.Text;
                            posTransaction.SaleDate = dtSalesTransactionDate.Value;
                            await _saleService.EditAsync(_saleID, posTransaction);
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
                if (_saleID > 0)
                {
                    var total = _saleService.GetTotalAmount(_saleID);
                    var receivableAmout = _saleService.GetReceivableAmount(_saleID);
                    var saleDate = dtSalesTransactionDate.Value;
                    if (total > 0 || receivableAmout > 0)
                    {
                        FormHandler.OpenPointOfSalePaymentForm(_saleID,saleDate).ShowDialog();

                        // this means that a pos transaction is loaded and if payment commited, it will reload the computation
                        // and update the interface
                        await SetTransactionData();

                        if (_isFullyPaid)
                        {
                            await GenerateNewOrLoadUnFinishedSale();
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

            if (_saleID == 0 || _isFinishedSale)
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
            if (!_isFinishedSale)
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
            if (_isFinishedSale)
            {
                FormHandler.OpenSalesReplaceCancelForm(_transactionProductID).ShowDialog();
                await SetTransactionData();
            }

        }

      
       
        protected override  bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
            if (keyData == (Keys.Control | Keys.P))
            {
                txtProductName.Focus();
                return true;
            }
            if (keyData == (Keys.Control | Keys.N))
            {
                btnNewTransaction_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }



        #region Customer Name List Box Implementations
        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetCustomerIDField();
                lbCustomer.Visible = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                lbCustomer.Focus();
            }
           
        }
        private void lbCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (lbCustomer.SelectedIndex == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    txtCustomerName.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            
            {
                
                txtCustomerName.Text = lbCustomer.Text;
                SetCustomerIDField();
                txtCustomerName.Focus();
                lbCustomer.Visible = false;


            }
        }
        private async void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var criteria = txtCustomerName.Text;
                await LoadCustomerSearchList(criteria);
            }
            catch (CustomBaseException ex)
            {

                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task LoadCustomerSearchList(string criteria)
        {
            Dictionary<int, string> productNames = new Dictionary<int, string>();
            if (criteria != "")
            {
                productNames = await _customerService.GetCustomerNamesAsync(criteria);
            }
            UpdateCustomerSearchList(productNames);
        }

        private void UpdateCustomerSearchList(Dictionary<int, string> customerNames)
        {
            lbCustomer.Visible = false;
            if (customerNames.Count > 0)
            {
                lbCustomer.Visible = true;
                lbCustomer.Items.Clear();
                foreach (var item in customerNames)
                {
                    lbCustomer.Items.Add(item.Value);
                }
            }


        }
        #endregion

        #region Product Name List Box Implementations

        /// <summary>
        /// Occurs when a keyboard key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await AddProductOnTransaction();
                lbProducts.Visible = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                lbProducts.Focus();
            }

        }

        /// <summary>
        /// Occurs when a keyboard key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void lbProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lbProducts.SelectedIndex == 0)
                {
                    txtProductName.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (lbProducts.SelectedIndex >= 0)
                {
                    txtProductName.Text = lbProducts.Text;
                    await AddProductOnTransaction();
                    txtProductName.Focus();
                    lbProducts.Visible = false;
                }
            }
        }

        /// <summary>
        /// Occurs when a text changed happen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var criteria = txtProductName.Text;
                await LoadProductSearchList(criteria);
            }
            catch (CustomBaseException ex)
            {

                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadProductSearchList(string criteria)
        {
            Dictionary<int, string> productNames = new Dictionary<int, string>();
            if (criteria != "")
            {
                productNames = await _productService.GetProductNamesAsync(criteria);
            }
            UpdateProductSearchList(productNames);
        }

        private void UpdateProductSearchList(Dictionary<int, string> productNames)
        {
            lbProducts.Visible = false;
            if (productNames.Count > 0)
            {
                lbProducts.Visible = true;
                lbProducts.Items.Clear();
                foreach (var item in productNames)
                {
                    lbProducts.Items.Add(item.Value);
                }
            }


        }

        private void TxtCustomerName_GotFocus(object sender, EventArgs e)
        {
            txtCustomerName.TextChanged += txtCustomerName_TextChanged;
        }
        private async void txtSIDR_ButtonClick(object sender, EventArgs e)
        {
            txtCustomerName.TextChanged -= txtCustomerName_TextChanged;
            await SetTransactionData();
        }

        #endregion

        private void txtCustomerName_Click(object sender, EventArgs e)
        {
            
        }

        private async void btnDiscount_Click(object sender, EventArgs e)
        {
            if(_transactionProductID > 0)
            {
                FormHandler.OpenProductDiscountForm(_transactionProductID).ShowDialog();
                await LoadProductsOnTransaction();
                await SetTransactionData();

            }
            else
            {
                MetroMessageBox.Show(this, "Please select the product you want to discount!", "Point Of Sale", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private  void btnEditDate_Click(object sender, EventArgs e)
        {
            if(_saleID > 0)
            {
                var form = FormHandler.OpenEditPointOfSaleDateForm(_saleID);
                form.OnDateUpdated += Form_OnDateUpdated;
                form.ShowDialog();
            }
            else
            {
                MetroMessageBox.Show(this, "No Record selected!");
            }
           

        }

        private void Form_OnDateUpdated(object sender, EventArgs e)
        {

            var form = (frmEditPointOfSaleDate)sender;
                    dtSalesTransactionDate.Value = form.NewDate;
            
        }
    }
}
