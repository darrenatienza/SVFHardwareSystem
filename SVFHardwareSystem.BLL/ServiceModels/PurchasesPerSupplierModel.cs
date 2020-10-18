using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class PurchasesPerSupplierModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public decimal TotalPurchaseAmount { get { return Purchases.Sum(x => x.TotalPurchaseAmount); } }
        public decimal TotalCashPayment { get { return Purchases.Sum(x => x.TotalCashAmount); } }
        public decimal TotalPayablePayment { get { return Purchases.Sum(x => x.TotalPayableAmount); } }
        public IList<PurchaseModel> Purchases { get; set; } = new List<PurchaseModel>();
    }
}
