using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Extensions;
using SVFHardwareSystem.Services.Interfaces;
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
    public partial class frmPointOfSalesReplaceCancel : MetroForm
    {
        private ISaleProductService _transactionProductService;
        private int _transactionProductID;

        public frmPointOfSalesReplaceCancel(ISaleProductService transactionProductService, int transactionProductID)
        {
            InitializeComponent();
            _transactionProductService = transactionProductService;
            _transactionProductID = transactionProductID;
        }

        private async void frmSalesReturned_Load(object sender, EventArgs e)
        {
            await SetTransactionProductData();


        }

        private async Task SetTransactionProductData()
        {
            try
            {
                var transactionProduct = await _transactionProductService.GetAsync(_transactionProductID);
                lblProductName.Text = "Product Name: " + transactionProduct.ProductName;
                lblQuantity.Text = "Quantity: " + transactionProduct.Quantity;
                lblOfQuantityOnCancel.Text = "of " + transactionProduct.Quantity;
                lblOfQuantityOnReplace.Text = "of " + transactionProduct.Quantity;
                txtQuantityToCancel.Text = transactionProduct.Quantity.ToString();
                txtQuantityToReplace.Text = transactionProduct.Quantity.ToString();
            }
            catch (RecordNotFoundException ex)
            {
                MetroMessageBox.Show(this, "No product selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnApplyReplace_Click(object sender, EventArgs e)
        {
            try
            {
                int quantityToReplace = txtQuantityToReplace.Text.ToInt();
                var reason = txtReplaceReason.Text;
                var isForReturnToSupplier = chkReturnToSupplierAfterReplace.Checked;
                
                _transactionProductService.ReplaceProduct(_transactionProductID, reason, isForReturnToSupplier,quantityToReplace);
                this.Close();

            }
            catch (ReturnedProductMustNotUpdateStatusException ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (RecordNotFoundException ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApplyCancel_Click(object sender, EventArgs e)
        {
            try
            {
                int quantityToCancel = txtQuantityToCancel.Text.ToInt();
                var reason = txtCancelReason.Text;
                var isAddQuantity = chkAddQuantity.Checked;
                var isForReturnToSupplier = chkReturnToSupplierAfterReplace.Checked;
               
                _transactionProductService.CancelProduct(_transactionProductID, reason, isAddQuantity, isForReturnToSupplier,quantityToCancel);
                this.Close();

            }
            catch (ReturnedProductMustNotUpdateStatusException ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (RecordNotFoundException ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
