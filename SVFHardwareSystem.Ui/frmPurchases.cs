using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Extensions;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using SVFHardwareSystem.Ui.Extensions;
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
    public partial class frmPurchases : MetroForm
    {
        private ISupplierService _supplierService;
        private IPurchaseService _purchaseService;
        private int _supplierID;
        private int _purchaseID;
        private int _purchaseProductID;

        public frmPurchases(ISupplierService supplierService, IPurchaseService purchaseService)
        {
            InitializeComponent();
            _supplierService = supplierService;
            _purchaseService = purchaseService;
           
        }

        private void frmPurchases_Load(object sender, EventArgs e)
        {
            LoadSuppliers();

        }
        private async void LoadSuppliers()
        {

            var suppliers = await _supplierService.GetAllAsync();
            foreach (var item in suppliers)
            {
                cboSupplier.Items.Add(new ItemX(item.Name, item.SupplierID.ToString()));

            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            _purchaseID = 0;
            _purchaseProductID = 0;
            txtSIDR.Text = "";
            dtDatePurchase.Value = DateTime.Now;
            txtRemarks.Text = "";
        }

        private async Task GenerateNewPurchaseID()
        {
            _purchaseID = await _purchaseService.GeneratedNewPurchaseID(_supplierID);
        }

        private async Task DeletePurchaseIDGeneration()
        {
            await _purchaseService.RemoveAsync(_purchaseID);
        }

        private async void GenerateNewPurchase()
        {
            try
            {
                DialogResult d = MetroMessageBox.Show(this, "Do you want to generate new purchase?", "Generate New Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    var purchaseModel = new PurchaseModel();
                    purchaseModel.SIDR = txtSIDR.Text;
                    purchaseModel.DatePurchase = dtDatePurchase.Value;
                    purchaseModel.SupplierID = _supplierID;
                    await _purchaseService.AddAsync(purchaseModel);
                    LoadPurchaseDates();
                    MetroMessageBox.Show(this, "New Purchase has been generated.", "New Purchase", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePurchase();
        }

        private async void SavePurchase()
        {
            try
            {
                var purchaseModel = new PurchaseModel();
                purchaseModel.PurchaseID = _purchaseID;
                purchaseModel.DatePurchase = dtDatePurchase.Value;
                purchaseModel.Remarks = txtRemarks.Text;
                purchaseModel.SIDR = txtSIDR.Text;
                purchaseModel.SupplierID = _supplierID;
                if (_purchaseID == 0)
                {
                    await _purchaseService.AddAsync(purchaseModel);
                }
                else
                {
                    await _purchaseService.EditAsync(_purchaseID, purchaseModel);
                }
                
                MetroMessageBox.Show(this, "Changes has been saved.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadPurchaseDates();
                await LoadPurchaseProducts();

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

        private void btnPayments_Click(object sender, EventArgs e)
        {
            ViewPayments();
        }

        private void ViewPayments()
        {
            var purchaseDate = dtDatePurchase.Value;
            FormHandler.OpenPurchasePayments(_purchaseID,purchaseDate).ShowDialog();
        }

        private void dtDatePurchase_ValueChanged(object sender, EventArgs e)
        {

        }

        private async void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            _supplierID = ((ItemX)cboSupplier.SelectedItem).Key.ToInt();
           await LoadPurchaseDates();
            gridPurchaseProduct.Rows.Clear();

        }

        private async void SetPurchaseData()
        {
            try
            {
                var purchase = await _purchaseService.GetAsync(_purchaseID);
                txtSIDR.Text = purchase.SIDR;
                txtRemarks.Text = purchase.Remarks;
                dtDatePurchase.Value = purchase.DatePurchase;
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridPurchaseDate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        protected override async void OnFormClosed(FormClosedEventArgs e)
        {

            base.OnFormClosed(e);
        }
        private async Task LoadPurchaseProducts()
        {
            try
            {
                var purchases = await _purchaseService.GetPurchaseProductsAsync(_purchaseID);
                var grid = gridPurchaseProduct;
                int count = 0;
                int rowIndex = 0;
                int checkboxColumnIndex = 2; // index of isquantityuploaded on grid
                grid.Rows.Clear();
                foreach (var item in purchases)
                {
                    count++;
                    grid.Rows.Add(new object[] {
                            item.PurchaseProductID.ToString(),
                            count.ToString(),
                            item.IsQuantityUploaded,
                            item.Quantity,
                            item.ProductUnit,
                            item.ProductName,
                            item.Price,
                            item.Total,

                    });


                    DataGridViewCheckBoxCell chk = grid.Rows[rowIndex].Cells[checkboxColumnIndex] as DataGridViewCheckBoxCell;
                    chk.ReadOnly = true;
                    
                    if (item.IsQuantityUploaded)
                    {

                        chk.ToolTipText = "This product quantity was uploaded to the product inventory!";
                    }
                    else
                    {
                        chk.ToolTipText = "This product quantity is not yet uploaded to the product inventory!";
                    }
                    rowIndex++; // increment for proceeding to new row;
                }

                lblTotal.Text = purchases.Sum(x => x.Total).ToCurrencyFormat();

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetPurchaseID()
        {
            var grid = gridPurchaseDate;

            if (grid.SelectedRows.Count > 0)
            {
                _purchaseID = int.Parse(grid.SelectedRows[0].Cells[0].Value.ToString());



            }
        }
        private async Task LoadPurchaseDates()
        {
            try
            {
                var purchases = await _purchaseService.GetAllAsync(_supplierID);
                var grid = gridPurchaseDate;
                int count = 0;
                grid.Rows.Clear();
                foreach (var item in purchases.OrderByDescending(x => x.DatePurchase))
                {
                    count++;
                    grid.Rows.Add(new object[] {
                            item.PurchaseID.ToString(),
                            count.ToString(),
                            item.Balance <= 0  && item.TotalPayment > 0 ? string.Format("{0} {1}",item.DatePurchase.ToShortDateString(), "[paid]") : item.DatePurchase.ToShortDateString()
                    });
                }


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_purchaseID == 0)
            {
                MetroMessageBox.Show(this, "Please select Purchase on list before adding!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FormHandler.OpenPurchaseProductForm(_purchaseID).ShowDialog();
                LoadPurchaseProducts();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_purchaseID == 0 || _purchaseProductID == 0)
            {
                MetroMessageBox.Show(this, "Please select Purchase and Product on list before editing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FormHandler.OpenPurchaseProductForm(_purchaseID, _purchaseProductID).ShowDialog();
            }



        }

        private void gridPurchaseProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SetProductID();
        }

        private void SetProductID()
        {
            var grid = gridPurchaseProduct;

            if (grid.SelectedRows.Count > 0)
            {
                _purchaseProductID = int.Parse(grid.SelectedRows[0].Cells[0].Value.ToString());



            }
        }

        private void gridPurchaseProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetProductID();
        }

        private void gridPurchaseDate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetPurchaseID();
            SetPurchaseData();
            LoadPurchaseProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MetroMessageBox.Show(this, "Are you sure you want to delete this purchase product?", "Delete Purchase Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    _purchaseService.DeletePurchaseProduct(_purchaseProductID);
                    LoadPurchaseProducts();
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

        private async void btnUploadQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MetroMessageBox.Show(this, "Are you sure you want to upload purchase product quantity to product inventory? \n" +
                    "If Yes, the purchase product quantity will be added to the current product inventry quantity \n" +
                    "Removing the uploaded purchase product quantity will not be permitted in the future.", "Upload Purchase Product Quantity", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    _purchaseService.UploadPurchaseQuantity(_purchaseProductID);
                    await LoadPurchaseProducts();
                }
            }
            catch (CustomBaseException ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // other exceptions
                MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
