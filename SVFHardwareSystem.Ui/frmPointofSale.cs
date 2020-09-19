using MetroFramework.Forms;
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
        public frmPointofSale()
        {

            InitializeComponent();
            metroTextBox2.CustomButton.Click += CustomButton_Click;
        }

        private void frmPointofSale_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveTransaction_Click(object sender, EventArgs e)
        {
           
        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
