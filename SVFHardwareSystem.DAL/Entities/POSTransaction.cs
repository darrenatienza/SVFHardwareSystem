using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    /// <summary>
    /// Point of Sale Transactions
    /// </summary>
    public class POSTransaction
    {
        public POSTransaction() { }
        
        public int POSTransactionID { get; set; }
        public DateTime CreateTimeStamp { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public string Cost { get; set; }
        public string SIDR { get; set; }
        public bool IsFinished { get; set; }
        public ICollection<POSPayment> POSPayments { get; set; } = new HashSet<POSPayment>();
        public ICollection<TransactionProduct> TransactionProducts { get; set; } = new HashSet<TransactionProduct>();
        
    }
}
