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
    public partial class frmSaleProductMonthlyInventory : MetroForm
    {
        private int _year;
        private int _month;
        private int _day;
        private IProductInventoryService _productInventoryService;

        public frmSaleProductMonthlyInventory(IProductInventoryService productInventoryService)
        {
            InitializeComponent();
            _productInventoryService = productInventoryService;
        }

        private async void frmSaleProductMonthlyInventory_Load(object sender, EventArgs e)
        {
            _year = dtDate.Value.Year;
            _month = dtDate.Value.Month;
            _day = dtDate.Value.Day;
            await LoadProductMonthlyReport();

        }

        private async Task LoadProductMonthlyReport()
        {
            try
            {

                var monthlyProducts = await _productInventoryService.GetSaleProductInventories(_year, _month);

                int count = 0;
                var ds = new reports();
                DataTable t = ds.Tables["Purchases"];
                DataRow r;
                foreach (var item in monthlyProducts)
                {
                    count++;
                    r = t.NewRow();
                    //r["Id"] = count.ToString();
                    r["Category"] = item.CategoryName;
                    r["Description"] = item.Name;
                    r["Unit"] = item.Unit;
                    r["Qty"] = item.Quantity;
                    r["UCost"] = item.Price.ToCurrencyFormat();
                    r["Amount"] = item.TotalAmount.ToCurrencyFormat();

                    t.Rows.Add(r);
                }
                var amount = await _productInventoryService.GetSaleProductTotalAmount(_month,_year);
                // for total of cash and purchases
                r = t.NewRow();
                r["Description"] = "Total";
                r["Amount"] = amount.ToCurrencyFormat();


                t.Rows.Add(r);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportEmbeddedResource = "SVFHardwareSystem.Ui.Reports.PurchaseReport.rdlc";
                var __totalPayablePayment = new ReportParameter("MonthYear", string.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(_month),_year));
                var __isYearlyTotalAmount = new ReportParameter("IsYearlyTotalAmount", "false");
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { __totalPayablePayment, __isYearlyTotalAmount });

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
            //chkTotal.Text = string.Format("Show Total for Year {0}", _year);
            await LoadProductMonthlyReport();
        }

       
        private async Task LoadSaleProductYearlyInventory()
        {
            try
            {

                var productInventories = await _productInventoryService.GetSaleProductInventories(_year);

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

                    r["Qty"] = item.Quantity;
                    r["UCost"] = item.Price.ToCurrencyFormat();
                    r["Amount"] = item.TotalAmount.ToCurrencyFormat();

                    t.Rows.Add(r);
                }

                var finalAmount = await _productInventoryService.GetSaleProductTotalAmount(_year);
                // for total of cash and purchases
                r = t.NewRow();
                r["Description"] = "Total";
                r["Amount"] = finalAmount.ToCurrencyFormat();


                t.Rows.Add(r);
                reportViewer1.LocalReport.DataSources.Clear();

                var __totalPayablePayment = new ReportParameter("Year", string.Format("{0}", _year));


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

        private void radioDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDaily.Checked)
            {
                dtDate.Format = DateTimePickerFormat.Custom;
                dtDate.CustomFormat = "MMMM dd, yyyy";
            }
          
        }

        private void radioMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMonth.Checked)
            {
                dtDate.Format = DateTimePickerFormat.Custom;
                dtDate.CustomFormat = "MMMM, yyyy";
            }
          
        }

        private void radioYear_CheckedChanged(object sender, EventArgs e)
        {
            if (radioYear.Checked)
            {
                dtDate.Format = DateTimePickerFormat.Custom;
                dtDate.CustomFormat = "yyyy";
            }
          
        }
    }
}
