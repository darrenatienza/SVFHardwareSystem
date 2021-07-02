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
    public partial class frmEditPointOfSaleDate : MetroForm
    {
        private ISaleService _saleService;
        private int _saleID;
        public event EventHandler OnDateUpdated;
        public DateTime NewDate { get; set; }
        public frmEditPointOfSaleDate()
        {
            InitializeComponent();
        }
        public void DateUpdated()
        {
            var handler = OnDateUpdated;
            if (handler != null)
            {
                handler.Invoke(this, null);
            }
        }
        public frmEditPointOfSaleDate(ISaleService saleService, int saleID)
        {
            _saleService = saleService;
            _saleID = saleID;
            InitializeComponent();
        }

        private void frmEditPointOfSaleDate_Load(object sender, EventArgs e)
        {
            LoadSaleData();
        }

        private void LoadSaleData()
        {
            try
            {
                var sale = _saleService.Get(_saleID);
                lblSIDR.Text = sale.SIDR;
                lblPrevDate.Text = sale.SaleDate.ToShortDateString();
              
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.Message, "Error");
            }
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var sale = _saleService.Get(_saleID);
                sale.SaleDate = dtNewDate.Value;
                _saleService.EditAsync(_saleID, sale);
                NewDate = dtNewDate.Value;
                DateUpdated();
                this.Close();
                
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error");
            }
        }
    }
}
