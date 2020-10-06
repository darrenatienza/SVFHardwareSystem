using MetroFramework;
using MetroFramework.Forms;
using SVFHardwareSystem.Services;
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
using Unity.Injection;

namespace SVFHardwareSystem.Ui
{
    public partial class frmCustomers : MetroForm
    {
        ICustomerService _customerService;
        private int id;
        public frmCustomers(ICustomerService customerService)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Resizable = false;
            _customerService = customerService;
        }

        private async void frmCustomers_Load(object sender, EventArgs e)
        {
            await LoadCustomers();

        }
        private async Task LoadCustomers()
        {
            try
            {
                var customers = await _customerService.GetAllAsync();
                int count = 0;
                gridCustomers.Rows.Clear();
                foreach (var item in customers)
                {
                    count++;
                    gridCustomers.Rows.Add(new string[] {
                            item.CustomerID.ToString(),
                            count.ToString(),
                            item.FullName,
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
                
                var categories = await _customerService.GetAll(txtSearch.Text);
                int count = 0;
                gridCustomers.Rows.Clear();
                foreach (var item in categories)
                {
                    count++;
                    gridCustomers.Rows.Add(new string[] {
                            item.CustomerID.ToString(),
                            count.ToString(),
                            item.FullName,
                            item.Address,
                    item.ContactNumber});
                }
               
               


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.ToString());
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var form = UnityConfig
               .Register().Resolve<frmCustomerForm>();
            form.ShowDialog();
            await LoadCustomers();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {
                    var dialogResult = MetroMessageBox.Show(this, "Do you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        await _customerService.RemoveAsync(id);
                        id = 0;
                    }
                    await LoadCustomers();

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

       

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var form = UnityConfig
               .Register().RegisterType<frmCustomerForm>(new InjectionConstructor(new object[] { new CustomerService(), id })).Resolve<frmCustomerForm>();
            form.ShowDialog();
            await LoadCustomers();
        }

        private void gridCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = gridCustomers;

            if (grid.SelectedRows.Count > 0)
            {
                id = int.Parse(grid.SelectedRows[0].Cells[0].Value.ToString());
                


            }
        }
    }
}
