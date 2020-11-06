using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Ui.Extensions;
using SVFHardwareSystem.Ui.Reports;
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
    public partial class frmDailySales : MetroForm
    {
        private ISalesService _salesService;
        private ISalePaymentService _salePaymentService;

        public frmDailySales(ISalesService salesService,ISalePaymentService salePaymentService)
        {
            InitializeComponent();
            
            _salesService = salesService;
            _salePaymentService = salePaymentService;
        }

        private async void frmSales_Load(object sender, EventArgs e)
        {
            await LoadSales();
        }

        private async Task LoadSales()
        {
            try
            {
                // delay to load the ui
                await Task.Delay(100);

                var date = dtDate.Value;
               
                var criteria = txtCriteria.Text;
                var sales = await _salesService.GetSales(date,criteria);

                var recievablePaymentAmount = await _salePaymentService.GetReceivablePaymentAmount(date.Date);
                var ds = new reports();
                DataTable t = ds.Tables["SalesReport"];
                DataRow r;
                int count = 0;
                foreach (var sale in sales)
                {
                    count++;
                    r = t.NewRow();
                    r["Date"] =             sale.SaleDate.ToShortDateString();
                    r["Cost"] =             sale.Cost;
                    r["SIDR"] =             sale.SIDR;
                    r["Quantity"] =         "";
                    r["ProductName"] =      "";
                    r["SalesDebit"] =       "";
                    r["SalesCredit"] =      "";
                    r["CashDebit"] =        "";
                    r["CashCredit"] =       "";
                    r["ReceivablesDebit"] = "";
                    r["ReceivablesCredit"] = "";

                    r["Customer"] = sale.CustomerFullName;
                    t.Rows.Add(r);


                    foreach (var item in sale.SalesProducts)
                    {

                        r = t.NewRow();
                        r["Date"] = "";
                        r["Cost"] = "";
                        r["SIDR"] = "";
                        r["Quantity"] = item.Quantity + " " + item.ProductUnit;
                        r["ProductName"] =
                           //IsReplace and IsCancel = true then show productName [replace] [cancelled]
                           //IsCancel = true then show productName [cancelled]
                           item.IsCancel ? string.Format("{0} [{1} {2}]", item.ProductName, item.QuantityToCancel.ToString(), "cancelled")
                             //show product name only
                             : item.ProductName;
                        r["SalesDebit"] = item.SaleDebit.ToCurrencyFormat();
                        r["SalesCredit"] = item.SaleCredit.ToCurrencyFormat();
                        r["CashDebit"] = item.CashDebit.ToCurrencyFormat();
                        r["CashCredit"] = item.CashCredit.ToCurrencyFormat();
                        r["ReceivablesDebit"] = item.ReceivableDebit.ToCurrencyFormat();
                        r["ReceivablesCredit"] = item.ReceivablesCredit.ToCurrencyFormat();
                        r["Customer"] = "";
                        t.Rows.Add(r);


                    }

                    //total

                    r = t.NewRow();
                    r["Date"] = "";
                    r["Cost"] = "";
                    r["SIDR"] = "";
                    r["Quantity"] = "";
                    r["ProductName"] =
                       "Total";
                    r["SalesDebit"] = sale.TotalSaleDebit.ToCurrencyFormat();
                    r["SalesCredit"] = sale.TotalSaleCredit.ToCurrencyFormat();
                    r["CashDebit"] = sale.TotalCashDebit.ToCurrencyFormat();
                    r["CashCredit"] = sale.TotalCashCredit.ToCurrencyFormat();
                    r["ReceivablesDebit"] = sale.TotalReceivableDebit.ToCurrencyFormat();
                    r["ReceivablesCredit"] = sale.TotalReceivableCredit.ToCurrencyFormat();
                    r["Customer"] = "";
                    t.Rows.Add(r);
                }

                var cashAmount = sales.Sum(x => x.TotalCashDebit);
                var saleAmount = sales.Sum(x => x.TotalSaleCredit);
                var recievableSale = sales.Sum(x => x.TotalReceivableDebit);
                var totalCash = (recievablePaymentAmount + cashAmount);
                var totalSale = totalCash + recievableSale;
                var __dateRange = new ReportParameter("DateRange", string.Format("Date: {0}", date.ToString("MMMM dd,yyyy")));
                // total purchase by customer per day
                var __totalPurchaseSale = new ReportParameter("TotalPurchaseSale", saleAmount.ToCurrencyFormat());
                // total cash payment paid bay customer per day
                var __cash = new ReportParameter("CashPayment", cashAmount.ToCurrencyFormat());
                // total receivable payment by customer by that day
                var __receivablePayment = new ReportParameter("ReceivablePayment",recievablePaymentAmount.ToCurrencyFormat());
                // cash + receivablePayment
                var __totalCash = new ReportParameter("TotalCash", totalCash.ToCurrencyFormat());
                // unpaid by customer
                var __receivable = new ReportParameter("ReceivableSale", recievableSale.ToCurrencyFormat());
                // totalcash + receivable sale
                var __totalSale = new ReportParameter("TotalSale", totalSale.ToCurrencyFormat() );
                
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { __dateRange,
                    __totalPurchaseSale,
                    __cash,
                    __receivablePayment,
                    
                    __receivable,
                    __totalSale});
                reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rds = new ReportDataSource("SalesReport", t);

                    reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = ZoomMode.PageWidth;
                    this.reportViewer1.RefreshReport();











                }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void txtCriteria_ButtonClick(object sender, EventArgs e)
        {
            LoadSales();
        }

        private void btnCustomersWithReceivables_Click(object sender, EventArgs e)
        {
            FormHandler.OpenCustomerReceivableForm().ShowDialog();
        }
    }
}
