using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
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
        private IPurchaseProductInventoryService _purchaseProductInventoryService;


        public frmProductInventoryReport(IPurchaseProductInventoryService purchaseProductInventoryService)
        {
            InitializeComponent();
            _purchaseProductInventoryService = purchaseProductInventoryService;
        }

        private async void frmProductMonthlyReport_Load(object sender, EventArgs e)
        {

            var month = dtDate.Value.Month;
            var year = dtDate.Value.Year;
            await LoadPurchaseProductInventories(year,month);

        }

       

        private void LoadReport(string duration, decimal finalAmount, IList<PurchaseProductInventoryModel> purchaseProducts, string reportType)
            {
                try { 
                int count = 0;
                var ds = new reports();
                DataTable t = ds.Tables["ProductInventory"];
                DataRow r;
                foreach (var item in purchaseProducts)
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
                r["Amount"] =finalAmount.ToCurrencyFormat();


                t.Rows.Add(r);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportEmbeddedResource = reportType;
                var __totalPayablePayment = new ReportParameter("Duration", duration);

                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { __totalPayablePayment });

                ReportDataSource rds = new ReportDataSource("ProductInventory", t);

                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                this.reportViewer1.RefreshReport();

            }
           
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dtDate_ValueChanged(object sender, EventArgs e)
        {
            var year = dtDate.Value.Year;
            var month = dtDate.Value.Month;

            if (radioMonth.Checked)
            {
                await LoadPurchaseProductInventories(year,month);
            }
            if (radioYear.Checked)
            {
                await LoadPurchaseProductInventories(year);
            }
            
        }
        private async Task LoadPurchaseProductInventories(int year, int month)
        {
            try
            {

                var monthlyProducts = await _purchaseProductInventoryService.GetPurchaseProductInventories(year, month);
                var reportType = "SVFHardwareSystem.Ui.Reports.PurchaseProductInverntoryMonth.rdlc";
                var duration = string.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), year);
                var finalAmount = await _purchaseProductInventoryService.GetPurchaseProductTotal(year, month);
                LoadReport(duration, finalAmount, monthlyProducts, reportType);
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
        private async Task LoadPurchaseProductInventories(int year)
        {
            try
            {
                var productInventories = await _purchaseProductInventoryService.GetPurchaseProductInventories(year);
                var reportType = "SVFHardwareSystem.Ui.Reports.PurchaseProductInventoryYear.rdlc";
                var duration =  year.ToString();
                var finalAmount = await _purchaseProductInventoryService.GetPurchaseProductTotal(year);
                LoadReport(duration, finalAmount, productInventories, reportType);
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

        private async void radioMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMonth.Checked)
            {
                dtDate.Format = DateTimePickerFormat.Custom;
                dtDate.CustomFormat = "MMMM yyyy";

                var month = dtDate.Value.Month;
                var year = dtDate.Value.Year;

                await LoadPurchaseProductInventories(year,month);
            }
        }

        private async void radioYear_CheckedChanged(object sender, EventArgs e)
        {
            if (radioYear.Checked)
            {
                dtDate.Format = DateTimePickerFormat.Custom;
                dtDate.CustomFormat = "yyyy";

                var month = dtDate.Value.Month;
                var year = dtDate.Value.Year;

                await LoadPurchaseProductInventories(year);
            }
        }
    }
}
