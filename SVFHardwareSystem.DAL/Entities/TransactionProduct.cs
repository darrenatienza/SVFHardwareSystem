using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    /// <summary>
    /// Products for every transactions
    /// </summary>
    public class TransactionProduct
    {
        public TransactionProduct() { }
        public int TransactionProductID { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int POSTransactionID { get; set; }
        public virtual POSTransaction POSTransaction{get; set;}
        public int Quantity { get; set; }
        public bool IsPaid { get; set; }
        /// <summary>
        /// Indicates the time when the product transaction updated
        /// </summary>
        public DateTime UpdateTimeStamp { get; set; }
    }
}
