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
    public partial class frmSalesReport : MetroForm
    {
        private ISalesService _salesService;

        public frmSalesReport(ISalesService salesService)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            _salesService = salesService;
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            LoadSales();
        }

        private void LoadSales()
        {
            try
            {
                var from = dtFrom.Value;
                var to = dtTo.Value;
                var criteria = txtCriteria.Text;
                var sales = _salesService.GetSales(from, to, criteria);


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


                var __dateRange = new ReportParameter("DateRange", string.Format("{0} to {1}", from.ToString("MMMM dd,yyyy"),to.ToString("MMMM dd,yyyy")));

                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { __dateRange });
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
