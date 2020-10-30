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
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVFHardwareSystem.Ui
{
    public partial class frmCustomerReceivable : MetroForm
    {
        private ICustomerReceivableService _customerReceivableService;
        private ICustomerService _customerService;
        private int _customerID;

        public frmCustomerReceivable(ICustomerReceivableService customerReceivableService, ICustomerService customerService)
        {
            InitializeComponent();
            _customerReceivableService = customerReceivableService;
            _customerService = customerService;
        }

        private async void CustomerReceivable_Load(object sender, EventArgs e)
        {

            
            await LoadCustomerNamesWithReceivables();
           
        }

        private async Task LoadCustomerReceivables(int customerID)
        {

                var customerReceivables = await _customerReceivableService.GetCustomerReceivables(customerID);
                var customerName = _customerService.Get(customerID).FullName;
                var title = string.Format("All Receivables of {0}", customerName);
                UpdateReport(customerReceivables,title);
           
           
        }

       
        private void UpdateReport(IList<CustomerReceivableModel> customerReceivables, string title)
        {
            try
            {
                var reportTable = "CustomerReceivable";
                var dataTable = GetDataTable(customerReceivables, reportTable);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource(reportTable, dataTable);
                var __duration = new ReportParameter("Title", title);
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { __duration});
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

        private DataTable GetDataTable(IList<CustomerReceivableModel> customerReceivables, string reportTable)
        {
            var ds = new reports();
            DataTable t = ds.Tables[reportTable];
            DataRow r;
            foreach (var item in customerReceivables)
            {
                r = t.NewRow();
                r["Date"] = item.Date.ToShortDateString();
                r["FullName"] = item.FullName;
                r["SI"] = item.SI;
                r["Debit"] = item.Debit;
                r["Credit"] = item.Credit;
                r["Balance"] = item.Balance;

                t.Rows.Add(r);
            }
            r = t.NewRow();
            r["SI"] = "Total";
            r["Debit"] = customerReceivables.Sum(x => x.Debit);
            r["Credit"] = customerReceivables.Sum(x => x.Credit);
            r["Balance"] = customerReceivables.Sum(x => x.Balance);
            t.Rows.Add(r);
            return t;
        }

        private async Task LoadCustomerNamesWithReceivables()
        {
            var customersNamesDictionary = await _customerReceivableService.GetCustomerNamesWithReceivables();
            UpdateCustomersComboBox(customersNamesDictionary);
        }

        private void UpdateCustomersComboBox(Dictionary<int, string> customersNamesDictionary)
        {
            if (cboCustomers.Items.Count > 0)
            {

                cboCustomers.Items.Clear();
                cboCustomers.Items.Add("All");
                foreach (var customer in customersNamesDictionary)
                {
                    cboCustomers.Items.Add(new ItemX(customer.Value, customer.Key.ToString()));
                }
            }
            
        }

        private async void cboCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pnlDate.Visible = false;

                var customerID = cboCustomers.SelectedIndex <= 0 ? cboCustomers.SelectedIndex = 0: ((ItemX)cboCustomers.SelectedItem).Key.ToInt();
                if (customerID > 0)
                {
                    await LoadCustomerReceivables(customerID);
                }
                else
                {
                    pnlDate.Visible = true;
                    var year = dtDate.Value.Year;
                    var month = dtDate.Value.Month;
                    
                    await LoadAllReceivables(month, year);
                }
              
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

        private async Task LoadAllReceivables(int month, int year)
        {
            var customerReceivables = await _customerReceivableService.GetAllCustomersReceivables(month,year);
            // month year as title
            var title = string.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), year);
            UpdateReport(customerReceivables,title);
        }

        private async void dtDate_ValueChanged(object sender, EventArgs e)
        {
            var year = dtDate.Value.Year;
            var month = dtDate.Value.Month;
            await LoadAllReceivables(month, year);
        }

        
    }
}
