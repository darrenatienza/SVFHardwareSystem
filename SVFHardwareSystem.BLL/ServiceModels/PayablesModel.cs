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
        public string SIDR { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal Cash { get; set; }
        public decimal Payable { get; set; }
        public DateTime DateOfCheck { get; set; }
        public int CheckNumber { get; set; }
        public decimal CheckAmount { get; set; }
    }
}
