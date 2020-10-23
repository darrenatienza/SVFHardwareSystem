using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    /// <summary>
    /// Payments for every Transactions
    /// </summary>
    public class SalePayment
    {
        public SalePayment() { }
        public int SalePaymentID { get; set; }
        public int SaleID { get; set; }
        public virtual Sale Sale { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsReceivablePayment { get; set; }


    }
}
