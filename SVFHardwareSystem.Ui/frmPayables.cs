using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Extensions;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using SVFHardwareSystem.Ui.Misc;
using SVFHardwareSystem.Ui.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer.Utilities;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVFHardwareSystem.Ui
{
    public partial class frmPayables : MetroForm
    {
        private IPurchaseService _purchaseService;
        private IList<PurchaseModel> _purchases;
        private int _supplierID;

        public frmPayables(IPurchaseService purchaseService)
        {
            InitializeComponent();
            _purchaseService = purchaseService;
            _purchases = new List<PurchaseModel>();
        }

       

        private async Task LoadReport()
        {

            try
            {
                int count = 0;
                
                var fullyPaid = chkFullyPaid.Checked;
                var year = dtDate.Value.Year;
                var month = dtDate.Value.Month;
                var supplierName = cboSuppliers.Text;
                _purchases = await _purchaseService.GetAllPurchasePayablesAsync(year, month,supplierName);


                var ds = new reports();
                DataTable t = ds.Tables["Payables"];
                DataRow r;
                foreach (var item in _purchases)
                {

                    
                    count++;
                    r = t.NewRow();
                    //r["Id"] = count.ToString();
                    r["Date"] = item.DatePurchase.ToShortDateString();
                    r["SupplierName"] = item.SupplierName;
                    r["SIDR"] = item.SIDR;
                    r["TotalPurchaseAmount"] = item.TotalPurchaseAmount.ToCurrencyFormat();
                    r["TotalCashAmount"] = item.TotalCashAmount.ToCurrencyFormat();
                    r["TotalPayableAmount"] = item.TotalPayableAmount.ToCurrencyFormat();
                    r["CheckDate"] =  item.CheckDate;
                    r["CheckNumber"] = item.CheckNumber;
                    r["TotalCheckAmount"] = item.TotalCheckAmount.ToCurrencyFormat();
                    t.Rows.Add(r);
                }
                // for total of cash and purchases
                r = t.NewRow();
                r["SupplierName"] = "Total";
                r["TotalPurchaseAmount"] = _purchases.Sum(x => x.TotalPurchaseAmount).ToCurrencyFormat();
                r["TotalCashAmount"] = _purchases.Sum(x => x.TotalCashAmount).ToCurrencyFormat();
                r["TotalPayableAmount"] = _purchases.Sum(x => x.TotalPayableAmount).ToCurrencyFormat();
                t.Rows.Add(r);

                var __dateRange = new ReportParameter("MonthYear", string.Format("{0}", dtDate.Value.ToString("MMMM yyyy")));

                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { __dateRange });
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("Payables", t);

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

        /**private async Task LoadPurchasesPerSupplierReport()
        {

            try
            {
                int count = 0;

                var fullyPaid = chkFullyPaid.Checked;
                var year = cboYear.Text.ToInt();
                var purchasesPerSupplier = await _purchaseService.GetPurchasesPerSupplier(year, _supplierID, fullyPaid);
                var ds = new reports();
                DataTable t = ds.Tables["Purchases"];
                DataRow r;
                foreach (var item in purchasesPerSupplier.Purchases)
                {
                    count++;
                    r = t.NewRow();
                    r["Id"] = count.ToString();
                    r["Date"] = item.DatePurchase.ToShortDateString();
                    r["SupplierName"] = item.SupplierName;
                    r["SIDR"] = item.SIDR;
                    r["TotalPurchaseAmount"] = item.TotalPurchaseAmount;
                    r["TotalCashAmount"] = item.TotalCashAmount;
                    r["TotalPayableAmount"] = item.TotalPayableAmount;
                    r["CheckDate"] = item.CheckDate;
                    r["CheckNumber"] = item.CheckNumber;
                    r["TotalCheckAmount"] = item.TotalCheckAmount;
                    t.Rows.Add(r);
                }
                // for total of cash and purchases
                r = t.NewRow();
                r["TotalPurchaseAmount"] = purchasesPerSupplier.TotalPurchaseAmount;
                r["TotalCashAmount"] = purchasesPerSupplier.TotalCashPayment;

                t.Rows.Add(r);

                reportViewer1.LocalReport.ReportEmbeddedResource = "SVFHardwareSystem.Ui.Reports.PurchasePerSupplier.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("Purchases", t);

                var __supplierName = new ReportParameter("SupplierName", purchasesPerSupplier.Name);
                var __address = new ReportParameter("Address", purchasesPerSupplier.Address);
                var __contactNumber = new ReportParameter("ContactNumber", purchasesPerSupplier.ContactNumber);
                var __totalPurchase = new ReportParameter("TotalPurchaseAmount", purchasesPerSupplier.TotalPurchaseAmount.ToString());
                var __totalCashPayment = new ReportParameter("TotalCashPayment", purchasesPerSupplier.TotalCashPayment.ToString());
                var __totalPayablePayment = new ReportParameter("TotalPayablePayment", purchasesPerSupplier.TotalPayablePayment.ToString());

                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { __supplierName, __address, __contactNumber, __totalPurchase,__totalCashPayment,__totalPayablePayment});

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

        } */
        private async void frmPayables_Load(object sender, EventArgs e)
        {
            //cboYear.SelectedIndex = 0;
            await LoadReport();
            LoadSuppliers();



        }

        private async void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            _supplierID = 0;
            await LoadReport();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
           
            cboSuppliers.Items.Clear();
            cboSuppliers.Items.Add("--Select Supplier--");
            if (_purchases.Count() > 0)
            {
                var _groupedSuppliers = _purchases.GroupBy(x => x.SupplierName).Select(x => new { Name = x.Key, ID = x.FirstOrDefault().SupplierID }).ToList();
              
                _groupedSuppliers.ForEach(x => cboSuppliers.Items.Add(new ItemX(x.Name,x.ID.ToString())));
            }
           
        }

        private async void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadReport();
            LoadSuppliers();
        }

        private async void cboSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_supplierID = ((ItemX)cboSuppliers.SelectedItem).Value.ToInt();
            await LoadReport();
            
        }

        private async void dtDate_ValueChanged(object sender, EventArgs e)
        {
            await LoadReport();
        }
    }
}
