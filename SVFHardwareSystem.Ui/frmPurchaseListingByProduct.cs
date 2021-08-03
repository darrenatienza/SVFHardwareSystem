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
    public partial class frmPurchaseListingByProduct : MetroForm
    {
        private ICategoryService _categoryService;
        private IProductService _productService;
        private IPurchaseService _purchaseService;
        private int _selProductID;

        public frmPurchaseListingByProduct(IProductService productService,IPurchaseService purchaseService, int selProductID)
        {
            InitializeComponent();
       
            _productService = productService;
            _purchaseService = purchaseService;
            _selProductID = selProductID;
        }

        private void frmSIDRListingByProduct_Load(object sender, EventArgs e)
        {
            try
            {

                lblProductName.Text = _productService.Get(_selProductID).Name;

                var sidrList = _purchaseService.GetPurchaseListByProductID(_selProductID);
                int count = 0;
                gridSIDRList.Rows.Clear();
                foreach (var item in sidrList)
                {
                    count++;
                    gridSIDRList.Rows.Add(new object[] {
                            "",
                            item.SupplierName,
                            item.DatePurchase.ToShortDateString()});
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
