using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Ui.Extensions;
using SVFHardwareSystem.Ui.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVFHardwareSystem.Ui
{
    public partial class frmProductInventoryReport : MetroForm
    {
        private IPurchaseService _purchaseService;
        private int _year;
        private int _month;

        public frmProductInventoryReport(IPurchaseService purchaseService)
        {
            InitializeComponent();
            _purchaseService = purchaseService;
        }

        private async void frmProductMonthlyReport_Load(object sender, EventArgs e)
        {
            _year = dtDate.Value.Year;
            _month = dtDate.Value.Month;
            chkTotal.Text = string.Format("Show Total for Year {0}", _year);
            await LoadProductMonthlyReport();

        }

        private async Task LoadProductMonthlyReport()
        {
            try
            {
                
                var monthlyProducts = await _purchaseService.GetPurchaseMonthlyReport(_year, _month);

                int count = 0;
                var ds = new reports();
                DataTable t = ds.Tables["Purchases"];
                DataRow r;
                foreach (var item in monthlyProducts.PurchaseProductMonthlyReports)
                {
                    count++;
                    r = t.NewRow();
                    //r["Id"] = count.ToString();
                    r["Category"] = item.CategoryName;
                    r["Description"] = item.Name;
                    r["Unit"] = item.Unit;
                    r["Date"] = item.Date;
                    r["Ref"] = item.SIDR;
                    r["Qty"] = item.Quantity;
                    r["UCost"] = item.Price.ToCurrencyFormat();
                    r["Amount"] = item.TotalAmount.ToCurrencyFormat();

                    t.Rows.Add(r);
                }
                // for total of cash and purchases
                r = t.NewRow();
                r["Description"] = "Total";
                r["Amount"] = monthlyProducts.TotalMonthlyAmount.ToCurrencyFormat();
               

                t.Rows.Add(r);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportEmbeddedResource = "SVFHardwareSystem.Ui.Reports.PurchaseReport.rdlc";
                var __totalPayablePayment = new ReportParameter("MonthYear", string.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthlyProducts.Month), monthlyProducts.Year));
                var __isYearlyTotalAmount = new ReportParameter("IsYearlyTotalAmount", "false");
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { __totalPayablePayment,__isYearlyTotalAmount });

                ReportDataSource rds = new ReportDataSource("Purchases", t);

                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                this.reportViewer1.RefreshReport();

            }
            catch (CustomBaseException ex)
            {

                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dtDate_ValueChanged(object sender, EventArgs e)
        {
            _year = dtDate.Value.Year;
            _month = dtDate.Value.Month;
            chkTotal.Text = string.Format("Show Total for Year {0}", _year);
            await LoadProductMonthlyReport();
        }

        private async void chkTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTotal.Checked == true)
            {
                dtDate.Enabled = false;
                await LoadPurchaseProductYearlyInventories();
            }
            else
            {
                dtDate.Enabled = true;
                await LoadProductMonthlyReport();
            }
        }

        private async Task LoadPurchaseProductYearlyInventories()
        {
            try
            {

                var productInventories = await _purchaseService.GetPurchaseProductYearlyInventories(_year);

                int count = 0;
                var ds = new reports();
                DataTable t = ds.Tables["ProductInventory"];
                DataRow r;
                foreach (var item in productInventories)
                {
                    count++;
                    r = t.NewRow();
                    //r["Id"] = count.ToString();
                    r["Category"] = item.CategoryName;
                    r["Description"] = item.Name;
                    r["Unit"] = item.Unit;
                    r["Date"] = item.Date;
                    r["Ref"] = item.SIDR;
                    r["Qty"] = item.Quantity;
                    r["UCost"] = item.Price.ToCurrencyFormat();
                    r["Amount"] = item.TotalAmount.ToCurrencyFormat();

                    t.Rows.Add(r);
                }
               
                var finalAmount = await _purchaseService.GetPurchaseProductYearlyFinalTotalAmount(_year);
                // for total of cash and purchases
                r = t.NewRow();
                r["Description"] = "Total";
                r["Amount"] = finalAmount.ToCurrencyFormat();


                t.Rows.Add(r);
                reportViewer1.LocalReport.DataSources.Clear();

                var __totalPayablePayment = new ReportParameter("Year", string.Format("{0}",  _year));
                

                reportViewer1.LocalReport.ReportEmbeddedResource = "SVFHardwareSystem.Ui.Reports.PurchaseProductInventoryYearlyReport.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { __totalPayablePayment });

                ReportDataSource rds = new ReportDataSource("ProductInventory", t);

                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                this.reportViewer1.RefreshReport();

            }
            catch (CustomBaseException ex)
            {

                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    }
}
