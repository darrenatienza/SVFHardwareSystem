using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Exceptions;
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
    public partial class frmPointOfSalePayment : MetroForm
    {
        private IPOSPaymentService _posPaymentService;
        private IPOSTransactionService _pOSTransactionService;
        private int _posTransactionID;
        private decimal _total;
        private decimal _receivable;
        private decimal _change;
        private decimal _amount;

        public frmPointOfSalePayment(IPOSPaymentService posPaymentService, IPOSTransactionService pOSTransactionService, int transactionID)
        {
            InitializeComponent();
            _posPaymentService = posPaymentService;
            _pOSTransactionService = pOSTransactionService;
            _posTransactionID = transactionID;
        }

        private void frmPointOfSalePayment_Load(object sender, EventArgs e)
        {
            _total = _pOSTransactionService.GetTotalAmount(_posTransactionID);
            txtTotal.Text = _total.ToString();

            _receivable = _pOSTransactionService.GetReceivableAmount(_posTransactionID);
            txtReceivable.Text = _receivable.ToString();




        }

        private void txtAmountTendered_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtAmountTendered_TextChanged(object sender, EventArgs e)
        {
            txtChange.Text = "";
            var strAmount = txtAmountTendered.Text;

            // if recievable has value more than zero
            // it means that the payment is for balance
            // if not, the payment is for a new point of sale transaction
            if (_receivable > 0)
            {
                if (decimal.TryParse(strAmount, out _amount))
                {
                    _change = _amount - _receivable;
                    txtChange.Text = _change.ToString();
                }
            }
            else
            {
                if (decimal.TryParse(strAmount, out _amount))
                {
                    _change = _amount - _total;
                    txtChange.Text = _change.ToString();
                }
            }


        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                _pOSTransactionService.Pay(_posTransactionID, _amount, _total);
                this.Close();
            }
            catch (AmountTenderMustBeGreaterThanOrEqualException ex)
            {
                MetroMessageBox.Show(this, ex.Message);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void tmrControlState_Tick(object sender, EventArgs e)
        {
            // set visibilty of txtTotal and txtReceivable according to value of  _receivable variables
            //if _receivable is more than 0 txtTotal is not visible
            //if _receivable is 0 txtReceivable is not visible and total is visible

            if (_receivable > 0)
            {
                //this means it is paying balances
                txtTotal.Visible = false;
                txtReceivable.Visible = true;
                lblReceivable.Visible = true;
                lblTotal.Visible = false;
            }
            else
            {
                txtTotal.Visible = true;
                txtReceivable.Visible = false;
                lblReceivable.Visible = false;
                lblTotal.Visible = true;
            }
        }
    }
}
