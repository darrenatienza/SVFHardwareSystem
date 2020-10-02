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
using Unity;

namespace SVFHardwareSystem.Ui
{
    public partial class frmSuppliers : MetroForm
    {
        ISupplierService _supplierService;
        private int _supplierID;
        public frmSuppliers(ISupplierService supplierService)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            _supplierService = supplierService;
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            LoadSuppliers();

        }
        private async void LoadSuppliers()
        {
            try
            {
                var customers = await _supplierService.GetAll();
                int count = 0;
                gridSupplier.Rows.Clear();
                foreach (var item in customers)
                {
                    count++;
                    gridSupplier.Rows.Add(new string[] {
                            item.SupplierID.ToString(),
                            count.ToString(),
                            item.Name,
                            item.Address,

                    item.ContactNumber});
                }


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var criteria = txtSearch.Text;
                var categories = await _supplierService.GetAll(criteria);
                int count = 0;
                gridSupplier.Rows.Clear();
                foreach (var item in categories)
                {
                    count++;
                    gridSupplier.Rows.Add(new string[] {
                            item.SupplierID.ToString(),
                            count.ToString(),
                            item.Name,
                            item.Address,
                    item.ContactNumber});
                }




            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormHandler.OpenSupplierForm().ShowDialog();
            LoadSuppliers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSupplier();
        }

        private async void DeleteSupplier()
        {
            try
            {
                if (_supplierID > 0)
                {
                    var dialogResult = MetroMessageBox.Show(this, "Do you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        await _supplierService.Remove(_supplierID);
                        _supplierID = 0;
                    }
                    LoadSuppliers();

                }
                else
                {
                    MetroMessageBox.Show(this, "No record selected to remove", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormHandler.OpenSupplierForm(_supplierID).ShowDialog();
            LoadSuppliers();
        }

        private void gridCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = gridSupplier;

            if (grid.SelectedRows.Count > 0)
            {
                _supplierID = int.Parse(grid.SelectedRows[0].Cells[0].Value.ToString());

            }
        }
    }
}
