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
        private int _customerID;

        public frmCustomerReceivable(ISalesService saleService)
        {
            InitializeComponent();
            _saleService = saleService;
        }

        private void CustomerReceivable_Load(object sender, EventArgs e)
        {

            
            LoadCustomersWithReceivables();
            this.reportViewer1.RefreshReport();
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
                var customerReceivable = _saleService.GetCustomerWithReceivables(_customerID);
                int count = 0;

                var ds = new reports();
                DataTable t = ds.Tables["CustomerReceivable"];
                DataRow r;
                foreach (var item in customerReceivable.SalesReceivables)
                {
                    count++;
                    r = t.NewRow();
                    r["Id"] = count.ToString();
                    r["Date"] = item.SalesTransactionDate;
                    r["SI"] = item.SI;
                    r["Debit"] = item.Debit;
                    r["Credit"] = item.Credit;
                    r["Balance"] = item.Balance;

                    t.Rows.Add(r);
                }
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("CustomerReceivable", t);

                var __customerName = new ReportParameter("CustomerName", customerReceivable.FullName);
                var __contactNumber = new ReportParameter("ContactNumber", customerReceivable.ContactNumber);
                var __address = new ReportParameter("Address", customerReceivable.Address);
                var __totalBalance = new ReportParameter("TotalBalance", customerReceivable.TotalBalance.ToString());

                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { __customerName, __contactNumber,__address,__totalBalance });

                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void gridCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = gridCustomers;

            if (grid.SelectedRows.Count > 0)
            {
                _customerID = int.Parse(grid.SelectedRows[0].Cells[0].Value.ToString());
                LoadReport();
            }
        }
    }
}
