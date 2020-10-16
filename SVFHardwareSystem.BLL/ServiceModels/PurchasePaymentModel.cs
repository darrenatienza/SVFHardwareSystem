using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class PurchasePaymentModel
    {
        public PurchasePaymentModel() { }
        public int PurchasePaymentID { get; set; }
        public int PurchaseID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; }
        public int CheckNumber { get; set; }

    }
}
