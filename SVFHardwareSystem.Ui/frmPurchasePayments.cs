using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Extensions;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using SVFHardwareSystem.Ui.Extensions;
using SVFHardwareSystem.Ui.Misc;
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
    public partial class frmPurchasePayments : MetroForm
    {
        private IPurchaseService _purchaseService;
        private int _purchaseID;
        private IPaymentMethodService _paymentMethodService;
        private int _paymentMethodID;

        public frmPurchasePayments(IPurchaseService purchaseService,IPaymentMethodService paymentMethodService, int purchaseID)
        {
            InitializeComponent();
            _purchaseService = purchaseService;
            _purchaseID = purchaseID;
            _paymentMethodService = paymentMethodService;
        }

        private void frmPurchasePayments_Load(object sender, EventArgs e)
        {
            SetPurchaseData();
            LoadPaymentMethods();
            LoadPurchasePayments();
        }

        private async void LoadPurchasePayments()
        {
            try
            {
                var purchasePayments = await _purchaseService.GetAllPurchasePaymentsAsync(_purchaseID);
                var grid = gridPurchasePayment;
                int count = 0;
                grid.Rows.Clear();
                foreach (var item in purchasePayments.OrderByDescending(x => x.PaymentDate))
                {
                    count++;
                    grid.Rows.Add(new object[] {
                            item.PurchaseID.ToString(),
                            count.ToString(),
                            item.PaymentDate,
                            item.PaymentMethodName,
                            item.PaymentMethodName == "Check" ? item.CheckNumber.ToString() : "n/a",
                            item.Amount
                    });
                }


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void LoadPaymentMethods()
        {
            try
            {
                var paymentMethods = _paymentMethodService.GetAll();
                cboPaymentMethod.Items.Clear();
                cboPaymentMethod.Items.Add("-Select Payment Method-");
                foreach (var item in paymentMethods)
                {
                    cboPaymentMethod.Items.Add(new ItemX(item.Name, item.PaymentMethodID.ToString()));
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetPurchaseData()
        {
            try
            {
                var purchase = _purchaseService.Get(_purchaseID);
                if (purchase != null)
                {
                    txtTotalPurchase.Text = purchase.TotalPurchaseAmount.ToString();
                    txtTotalPayment.Text = purchase.TotalPayment.ToString();
                    txtBalance.Text = purchase.Balance.ToString();
                }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            try
            {
                var purchasePayment = new PurchasePaymentModel();
                purchasePayment.CheckNumber = txtCheckNumber.Text.ToInt();
                purchasePayment.Amount = txtAmount.Text.ToDecimal();
                purchasePayment.PaymentDate = dtPaymentDate.Value;
                purchasePayment.PurchaseID = _purchaseID;
                purchasePayment.PaymentMethodID = _paymentMethodID;
                _purchaseService.AddPurchasePayment(purchasePayment);
                ResetInputs();
                LoadPurchasePayments();
                SetPurchaseData();
                MetroMessageBox.Show(this, "New Purchase Payment has been saved!", "New Purchase Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ResetInputs()
        {
            txtCheckNumber.Text = "";
            cboPaymentMethod.SelectedIndex = 0;
        }

        private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            _paymentMethodID = cboPaymentMethod.SelectedIndex == 0 ? cboPaymentMethod.SelectedIndex = 0: ((ItemX)cboPaymentMethod.SelectedItem).Key.ToInt();
        }
    }
}
