using SVFHardwareSystem.DAL.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    public class PurchasePayment
    {
        public PurchasePayment() { }

        public int PurchasePaymentID { get; set; }
        public int PurchaseID { get; set; }
        public virtual Purchase Purchase { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
