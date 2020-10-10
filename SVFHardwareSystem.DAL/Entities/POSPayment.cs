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
    public class POSPayment
    {
        public POSPayment() { }
        public int POSPaymentID { get; set; }
        public int POSTransactionID { get; set; }
        public virtual POSTransaction POSTransaction { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsReceivablePayment { get; set; }


    }
}
