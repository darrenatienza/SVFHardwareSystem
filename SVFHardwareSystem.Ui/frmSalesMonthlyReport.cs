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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVFHardwareSystem.Ui
{
    public partial class frmSalesMonthlyReport : MetroForm
    {
        private ISalesService _salesService;

        public frmSalesMonthlyReport(ISalesService salesService)
        {
            InitializeComponent();
            _salesService = salesService;
        }


        private async Task LoadSalesMonthlyReport()
        {
            try
            {
                var month = dtDate.Value.Month;
                var year = dtDate.Value.Year;
                var salesMonthlyTotal = await _salesService.GetSalesMonthlyTotal(month, year);

                int count = 0;
                var ds = new reports();
                DataTable t = ds.Tables["MonthlyTotalSales"];
                DataRow r;
                foreach (var item in salesMonthlyTotal.SalesDailyTotals)
                {
                    count++;
                    r = t.NewRow();
                    //r["Id"] = count.ToString();
                    r["Date"] = item.Date.ToShortDateString();
                    r["TotalDailyCashPayment"] = item.TotalDailyCashPayment.ToCurrencyFormat();
                    r["TotalDailyReceivablesAmount"] = item.TotalDailyReceivablesAmount.ToCurrencyFormat();
                    r["TotalDailySalesAmount"] = item.TotalDailySalesAmount.ToCurrencyFormat();
                    
                    t.Rows.Add(r);
                }
                // for total of cash and purchases
                r = t.NewRow();
                r["Description"] = "Total";
                r["TotalDailyCashPayment"] = salesMonthlyTotal.TotalCashMonthlyPayment.ToCurrencyFormat();
                r["TotalDailyReceivablesAmount"] = salesMonthlyTotal.TotalMonthlyReceivablesAmount.ToCurrencyFormat();
                r["TotalDailySalesAmount"] = salesMonthlyTotal.TotalMonthlySalesAmount.ToCurrencyFormat();

                t.Rows.Add(r);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("MonthlyTotalSales", t);

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

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void frmSalesMonthlyReport_Load(object sender, EventArgs e)
        {
            
            await LoadSalesMonthlyReport();
        }
    }
}
