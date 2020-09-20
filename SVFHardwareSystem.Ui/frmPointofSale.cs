using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
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
    public partial class frmPointofSale : MetroForm
    {
        private int id;
        private IPOSTransactionService _posTransactionService;

        public frmPointofSale(IPOSTransactionService posTransactionService)
        {

            InitializeComponent();
            txtProductName.CustomButton.Click += CustomButton_Click;
            _posTransactionService = posTransactionService;
        }

        private void frmPointofSale_Load(object sender, EventArgs e)
        {

        }

        private async void btnSaveTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                var posTransaction = new POSTransactionModel();
                posTransaction.CustomerID = 6;
                posTransaction.Cost = txtCost.Text;
                posTransaction.CreateTimeStamp = DateTime.Now;
                posTransaction.SIDR = txtSIDR.Text;
                //edit
                if (id > 0)
                {
                    await _posTransactionService.Edit(id, posTransaction);
                }
                else
                {
                    //add
                    await _posTransactionService.Add(posTransaction);
                }

               // await LoadCategories();
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
