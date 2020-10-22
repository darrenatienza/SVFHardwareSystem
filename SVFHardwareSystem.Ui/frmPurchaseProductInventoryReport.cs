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

        public frmProductInventoryReport(IPurchaseService purchaseService)
        {
            InitializeComponent();
            _purchaseService = purchaseService;
        }

        private async void frmProductMonthlyReport_Load(object sender, EventArgs e)
        {
            await LoadProductMonthlyReport();

        }

        private async Task LoadProductMonthlyReport()
        {
            try
            {
                var month = dtDate.Value.Month;
                var year = dtDate.Value.Year;
                var monthlyProducts = await _purchaseService.GetPurchaseMonthlyReport(year, month);

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
                r["Amount"] = monthlyProducts.TotalMonthlyAmount;
               

                t.Rows.Add(r);
                reportViewer1.LocalReport.DataSources.Clear();

                var __totalPayablePayment = new ReportParameter("MonthYear", string.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthlyProducts.Month), monthlyProducts.Year));

                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { __totalPayablePayment });

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
            await LoadProductMonthlyReport();
        }
    }
}
