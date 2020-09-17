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
                var customers = await _customerService.GetAll();
                int count = 0;
                lvCustomers.Items.Clear();
                foreach (var item in customers)
                {
                    count++;
                    var lvi = new ListViewItem(count.ToString());
                    lvi.SubItems.Add(item.FullName);
                    lvi.SubItems.Add(item.Address);
                    lvi.SubItems.Add(item.ContactNumber);
                    lvi.Tag = item.CustomerID;
                    lvCustomers.Items.Add(lvi);
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
                lvCustomers.Items.Clear();
                foreach (var item in categories)
                {
                    count++;
                    var lvi = new ListViewItem(count.ToString());
                    lvi.SubItems.Add(item.FullName);
                    lvi.SubItems.Add(item.Address);
                    lvi.SubItems.Add(item.ContactNumber);
                    lvi.Tag = item.CustomerID;
                    lvCustomers.Items.Add(lvi);
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
                        await _customerService.Remove(id);
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

        private async void lvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                id = lvCustomers.SelectedItems.Count > 0 ? int.Parse(lvCustomers.SelectedItems[0].Tag.ToString()) : 0;
                if (id > 0)
                {
                    var category = await _customerService.Get(id);
                    
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
    }
}
