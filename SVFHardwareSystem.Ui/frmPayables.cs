using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
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

        public frmPayables(IPurchaseService purchaseService)
        {
            InitializeComponent();
            _purchaseService = purchaseService;
        }

       

        private void LoadReport()
        {
            int count = 0;
            var showAll = chkAll.Checked;
            _purchases = Task.Run(() => _purchaseService.GetAllPurchasePayablesAsync(showAll)).Result;
            var ds = new reports();
            DataTable t = ds.Tables["Purchases"];
            DataRow r;
            foreach (var item in _purchases)
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
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("Purchases", t);





            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
        }

        private void frmPayables_Load(object sender, EventArgs e)
        {
            LoadReport();
            LoadSuppliers();



        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadReport();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            var _groupedSuppliers = _purchases.GroupBy(x => x.SupplierName).Select(x => new { Name = x.Key }).ToList();
            cboSuppliers.Items.Clear();
            _groupedSuppliers.ForEach(x => cboSuppliers.Items.Add(x.Name));
        }
    }
}
