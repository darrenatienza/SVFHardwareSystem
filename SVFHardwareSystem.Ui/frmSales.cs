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
                var sales = _salesService.GetSales(from, to,criteria);

              
                gridList.Rows.Clear();
                int count = 0;
                foreach (var item in sales)
                {
                    count++;
                    gridList.Rows.Add(new object[] {"",
                          count.ToString(),

                    item.CreateTimeStamp.ToShortDateString(),
                    item.Quantity + " "+ item.ProductUnit,
                    item.ProductName.ToString(),
                    item.POSTransactionCost,
                    item.POSTransactionSIDR }); ;
                   
                   
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
