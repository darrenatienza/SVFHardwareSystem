using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;
using SVFHardwareSystem.Services.Interfaces;
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
    public partial class frmCustomerReceivable : MetroForm
    {
        private ISalesService _saleService;

        public frmCustomerReceivable(ISalesService saleService)
        {
            InitializeComponent();
            _saleService = saleService;
        }

        private void CustomerReceivable_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            LoadCustomersWithReceivables();
        }

        private void LoadCustomersWithReceivables()
        {
            try
            {
                var customers = _saleService.GetCustomersWithReceivables(2020);
                int count = 0;
                gridCustomers.Rows.Clear();
                foreach (var item in customers)
                {
                    count++;
                    gridCustomers.Rows.Add(new string[] {
                            item.CustomerID.ToString(),
                            count.ToString(),
                            item.FullName,
                            });
                }


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        public void LoadReport()
        {
            try
            {
                var year = DateTime.Now.Year;
                //var salesReceivableDetail = _saleService.GetSalesReceivables(year);
                //int count = 0;

                //var ds = new reports();
                //DataTable t = ds.Tables["dtPosTransaction"];
                //DataRow r;
                //foreach (var item in salesReceivableDetail.SalesReceivables)
                //{
                //    count++;
                //    r = t.NewRow();
                //    r["i"] = count.ToString();
                //    r["Date"] = item.Date;
                //    r["TransactionCode"] = item.TransactionCode;
                //    r["Quantity"] = item.Quantity;
                //    r["AmountTendered"] = item.AmountTendered;
                //    r["Total"] = item.Total;

                //    t.Rows.Add(r);
                //}
                //reportViewer1.LocalReport.DataSources.Clear();
                //ReportDataSource rds = new ReportDataSource("dsPosTransaction", t);

                //var p_datefrom = new ReportParameter("DateFrom", dateFrom.ToShortDateString());
                //var p_dateTo = new ReportParameter("DateTo", dateTo.ToShortDateString());

                //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p_datefrom, p_dateTo });

                //reportViewer1.LocalReport.DataSources.Add(rds);
                //reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                //reportViewer1.ZoomMode = ZoomMode.PageWidth;
                //this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
