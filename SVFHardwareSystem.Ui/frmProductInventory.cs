using MetroFramework;
using MetroFramework.Controls;
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
    public partial class frmProductInventory : MetroForm
    {
        private IProductInventoryService _productInventoryService;

        public frmProductInventory(IProductInventoryService productInventoryService)
        {
            InitializeComponent();
            _productInventoryService = productInventoryService;
            radioBeginning.CheckedChanged += RadioBeginning_CheckedChanged;
        }

        private void RadioBeginning_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (MetroRadioButton)sender;
            int year = dtDate.Value.Year;
            if (radio.Name == radioEnding.Name)
            {
                btnSave.Visible = radioEnding.Checked ? true : false;
            }
            
        }

        private void frmProductInventory_Load(object sender, EventArgs e)
        {

          
        }

        private void radioEnding_CheckedChanged(object sender, EventArgs e)
        {

           
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        private async Task LoadBeginningInventories(int year)
        {
            try
            {
                var productInventories = await _productInventoryService.GetBeginningInventories((int)year);
                var reportTitle = "Beginning";
                
                var finalAmount = await _productInventoryService.GetBeginningInventories((int)year);
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

        private void LoadReport(string duration, decimal finalAmount, IList<ProductInventoryModel> productInventories, string reportTitle)
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
                    r["Category"] = item.ProductCategoryName;
                    r["Description"] = item.ProductName;
                    r["Unit"] = item.Unit;
                    r["Qty"] = item.Quantity;
                    r["UCost"] = item.UnitPrice.ToCurrencyFormat();
                    r["Amount"] = item.TotalAmount.ToCurrencyFormat();

                    t.Rows.Add(r);
                }
                // for total of cash and purchases
                r = t.NewRow();
                r["Description"] = "Total";
                r["Amount"] = finalAmount.ToCurrencyFormat();


                t.Rows.Add(r);
                reportViewer1.LocalReport.DataSources.Clear();
                var __year = new ReportParameter("Duration", duration);
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
