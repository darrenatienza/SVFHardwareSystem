using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class PurchaseModel
    {
        public PurchaseModel() { }
        public int PurchaseID { get; set; }
        public DateTime CreateTimeStamp { get; set; } = DateTime.Now;

        public DateTime DatePurchase { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Remarks { get; set; }
    }
}
