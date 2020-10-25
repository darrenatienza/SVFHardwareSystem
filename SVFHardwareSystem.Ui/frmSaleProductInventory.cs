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
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVFHardwareSystem.Ui
{
    public partial class frmSaleProductInventory : MetroForm
    {
  
        private ISaleProductInventoryService _productInventoryService;
       

        public frmSaleProductInventory(ISaleProductInventoryService productInventoryService)
        {
            InitializeComponent();
            _productInventoryService = productInventoryService;
        }

        private async void frmSaleProductMonthlyInventory_Load(object sender, EventArgs e)
        {

            var year = dtDate.Value.Year;
            var month = dtDate.Value.Month;
            var day = dtDate.Value.Day;
            await LoadSaleProductDailyReport(year,month,day);

        }

        private async Task LoadSaleProductMonthlyReport(int year,int month)
        {
            try
            {
                if (radioMonth.Checked)
                {
                   
                    var monthlyProducts = await _productInventoryService.GetSaleProductInventories(year, month);
                    var finalAmount = await _productInventoryService.GetSaleProductTotalAmount(month, year);
                    var duration = string.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), year);
                    LoadReport(duration, finalAmount, monthlyProducts);
                }
                

                
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

            var day = dtDate.Value.Day;
            var month = dtDate.Value.Month;
            var year = dtDate.Value.Year;
            await LoadSaleProductMonthlyReport(year,month);
            await LoadSaleProductDailyReport(year,month,day);
            await LoadSaleProductYearlyInventory(year);
        }

       
        private async Task LoadSaleProductYearlyInventory(int year)
        {
            try
            {
                if (radioYear.Checked)
                {
                    
                    var productInventories = await _productInventoryService.GetSaleProductInventories(year);
                    var finalAmount = await _productInventoryService.GetSaleProductTotalAmount(year);
                    var duration = year.ToString();
                    LoadReport(duration,finalAmount,productInventories);
                }
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

        private void LoadReport(string duration, decimal finalAmount, IList<SaleProductInventoryModel> productInventories)
        {
            try
            {
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


                // for total of cash and purchases
                r = t.NewRow();
                r["Description"] = "Total";
                r["Amount"] = finalAmount.ToCurrencyFormat();


                t.Rows.Add(r);
                reportViewer1.LocalReport.DataSources.Clear();

                var __duration = new ReportParameter("Duration", duration);


                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { __duration });

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
        private async void radioDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDaily.Checked)
            {
                dtDate.Format = DateTimePickerFormat.Custom;
                dtDate.CustomFormat = "MMMM dd, yyyy";

                var day = dtDate.Value.Day;
                var month = dtDate.Value.Month;
                var year = dtDate.Value.Year;

                await LoadSaleProductDailyReport(year,month,day);
            }
          
        }

        private async Task LoadSaleProductDailyReport(int year, int month, int day)
        {
            try
            {
                if (radioDaily.Checked)
                {
                    
                    var productInventories = await _productInventoryService.GetSaleProductInventories(year,month,day);
                    var finalAmount = await _productInventoryService.GetSaleProductTotalAmount(year,month,day);
                    var duration = string.Format("{0} {1}, {2}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month),day, year);
                    LoadReport(duration, finalAmount, productInventories);
                }
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
                dtDate.CustomFormat = "MMMM, yyyy";
                var month = dtDate.Value.Month;
                var year = dtDate.Value.Year;

                await LoadSaleProductMonthlyReport(year, month);
            }
          
        }

        private async void radioYear_CheckedChanged(object sender, EventArgs e)
        {
            if (radioYear.Checked)
            {
                dtDate.Format = DateTimePickerFormat.Custom;
                dtDate.CustomFormat = "yyyy";
                var year = dtDate.Value.Year;
                await LoadSaleProductYearlyInventory(year);
            }
          
        }
    }
}
