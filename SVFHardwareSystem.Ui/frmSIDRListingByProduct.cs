using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Ui.Misc;
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
    public partial class frmSIDRListingByProduct : MetroForm
    {
        private ICategoryService _categoryService;
        private IProductService _productService;
        private ISalesService _sales;
        private int _selProductID;

        public frmSIDRListingByProduct(IProductService productService,ISalesService sales, int selProductID)
        {
            InitializeComponent();
       
            _productService = productService;
            _sales = sales;
            _selProductID = selProductID;
        }

        private void frmSIDRListingByProduct_Load(object sender, EventArgs e)
        {
            try
            {

                lblProductName.Text = _productService.Get(_selProductID).Name;

                var sidrList = _sales.GetAllSIDRByProduct(_selProductID);
                int count = 0;
                gridSIDRList.Rows.Clear();
                foreach (var item in sidrList)
                {
                    count++;
                    gridSIDRList.Rows.Add(new object[] {
                            "",
                            item});
                }


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }
        
        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
