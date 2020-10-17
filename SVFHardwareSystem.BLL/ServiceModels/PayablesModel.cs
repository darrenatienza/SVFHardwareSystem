using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class PayablesModel
    {
        public int SupplierID { get; set; }
        public DateTime DatePurchase { get; set; }

        public string SupplierName { get; set; }
        public string SIDR { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal TotalCash { get; set; }
        public decimal TotalPayable { get; set; }
        
    }
}
