using MetroFramework;
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
    public partial class frmProducts : MetroForm
    {
        public frmProducts()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
        }

        private void metroTextBox1_ButtonClick(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Click");
        }
    }
}
