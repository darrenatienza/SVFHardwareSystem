using MetroFramework;
using MetroFramework.Controls;
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
    public partial class frmProductInventory : MetroForm
    {
        private IProductInventoryService _productInventoryService;

        public frmProductInventory(IProductInventoryService productInventoryService)
        {
            InitializeComponent();
            //useful centering circular progressbar
            this.WindowState = FormWindowState.Maximized;

            _productInventoryService = productInventoryService;
            radioBeginning.CheckedChanged += RadioBeginning_CheckedChanged;
            radioSale.CheckedChanged += RadioBeginning_CheckedChanged;
            radioPurchase.CheckedChanged += RadioBeginning_CheckedChanged;
            radioEnding.CheckedChanged += RadioBeginning_CheckedChanged;
        }

        private async void RadioBeginning_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (MetroRadioButton)sender;
            
            spinnerLoading.Visible = true;
            btnSave.Visible = false;
            if (radio.Checked)
            {
                int year = dtDate.Value.Year;
                await Task.Delay(500);
                if (radio.Name == radioBeginning.Name)
                {
                    await LoadBeginningInventories(year);
                }
                if (radio.Name == radioSale.Name)
                {
                    await LoadSaleInventories(year);
                }
                if (radio.Name == radioPurchase.Name)
                {
                    await LoadPurchaseInventoriesAsync(year);
                }
                if (radio.Name == radioEnding.Name)
                {
                    btnSave.Visible = radioEnding.Checked ? true : false;
                    await LoadEndingInventories(year);
                }
            }

            spinnerLoading.Visible = false;
        }

        private async void frmProductInventory_Load(object sender, EventArgs e)
        {
            var year = dtDate.Value.Year;
            spinnerLoading.Visible = true;
            await Task.Delay(100);
            await LoadBeginningInventories(year);
            spinnerLoading.Visible = false;
        }

        private void radioEnding_CheckedChanged(object sender, EventArgs e)
        {

           
            
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var year = dtDate.Value.Year;
                await _productInventoryService.SaveEndingInventoryAsync(year);
                MetroMessageBox.Show(this, "New Purchase and Sales of Products have been saved!", "Purchase and Sales Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private async Task LoadBeginningInventories(int year)
        {
            try
            {
                var productInventories = await _productInventoryService.GetBeginningInventories(year);
                var reportTitle = "Beginning Inventory";
                var finalAmount = await _productInventoryService.GetBeginningInventoryAmount(year);
                LoadReport(year, finalAmount, productInventories, reportTitle);
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
        private async Task LoadSaleInventories(int year)
        {
            try
            {
                var productInventories = await _productInventoryService.GetSaleInventories(year);
                var reportTitle = "Sale Inventory";
                var finalAmount = await _productInventoryService.GetSaleInventoryAmount(year);
                LoadReport(year, finalAmount, productInventories, reportTitle);
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
        private async Task LoadEndingInventories(int year)
        {
            try
            {
                var productInventories = await _productInventoryService.GetEndingInventories(year);
                var reportTitle = "Ending Inventory";
                var finalAmount = await _productInventoryService.GetEndingInventoryAmount(year);
                LoadReport(year, finalAmount, productInventories, reportTitle);
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
        private async Task LoadPurchaseInventoriesAsync(int year)
        {
            try
            {
                var productInventories = await _productInventoryService.GetPurchaseInventories(year);
                var reportTitle = "Purchase Inventory";
                var finalAmount = await _productInventoryService.GetPurchaseInventoryAmount(year);
                LoadReport(year, finalAmount, productInventories, reportTitle);
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

        private void LoadReport(int year, decimal finalAmount, IList<ProductInventoryModel> productInventories, string reportTitle)
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
                    r["Qty"] = item.Qty;
                    r["UCost"] = item.UnitPrice.ToCurrencyFormat();
                    r["Amount"] = item.TotalAmount.ToCurrencyFormat();

                    t.Rows.Add(r);
                }
                // for total 
                r = t.NewRow();
                r["Description"] = "Total";
                r["Amount"] = finalAmount.ToCurrencyFormat();


                t.Rows.Add(r);
                reportViewer1.LocalReport.DataSources.Clear();
                var __year = new ReportParameter("Year", year.ToString());
                var __reportTitle = new ReportParameter("ReportTitle", reportTitle);
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { __year, __reportTitle });

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
    }
}
