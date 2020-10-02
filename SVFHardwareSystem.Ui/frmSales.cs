using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Interfaces;
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
    public partial class frmSales : MetroForm
    {
        private ISalesService _salesService;

        public frmSales(ISalesService salesService)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            _salesService = salesService;
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            LoadSales();
        }

        private void LoadSales()
        {
            try
            {
                var from = dtFrom.Value;
                var to = dtTo.Value;
                var criteria = txtCriteria.Text;
                var sales = _salesService.GetSales(from, to, criteria);


                gridList.Rows.Clear();
                
                foreach (var sale in sales)
                {
                    int count = 0;
                    count++;

                    gridList.Rows.Add(new object[] {"",
                          count.ToString(),

                    sale.CreateTimeStamp.ToShortDateString(),
                    sale.Cost,
                    sale.SIDR,
                   "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                        "",sale.CustomerFullName});

                    foreach (var item in sale.SalesProducts)
                    {
                        gridList.Rows.Add(new object[] {"",
                        
                            "",
                    "",
                    "",
                    "",
                    item.Quantity + " "+ item.ProductUnit,
                   //IsReplace and IsCancel = true then show productName [replace] [cancelled]
                            
                             //IsCancel = true then show productName [cancelled]
                           item.IsCancel ?string.Format("{0} [{1} {2}]", item.ProductName ,item.QuantityToCancel.ToString(),"cancelled")

                            //show product name only
                             : item.ProductName,


                    item.SaleDebit,
                    item.SaleCredit,
                    item.CashDebit,
                    item.CashCredit,
                    item.ReceivableDebit,
                    item.ReceivablesCredit}) ;
                    }

                    // footer total
                    gridList.Rows.Add(new object[] {"",
                          "",
"",
                   "",
                    "",
                    "",
                   "Total",
                    sale.TotalSaleDebit,
                    sale.TotalSaleCredit,
                    sale.TotalCashDebit,
                    sale.TotalCashCredit,
                    sale.TotalReceivableDebit,
                    sale.TotalReceivableCredit});



                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtCriteria_ButtonClick(object sender, EventArgs e)
        {
            LoadSales();
        }
    }
}
