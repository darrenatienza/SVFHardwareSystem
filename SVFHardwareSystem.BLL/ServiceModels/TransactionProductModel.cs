using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class TransactionProductModel
    {
        public TransactionProductModel() { }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public bool IsPaid { get; set; }
        public bool IsToPay { get; set; }
        /// <summary>
        /// Indicates the time when the product transaction updated
        /// </summary>
        public DateTime UpdateTimeStamp { get; set; }
        public int POSTransactionID { get; set; }
        public decimal Total { get { return Quantity * ProductPrice; } }

        public decimal ProductPrice { get; set; }
        public int TransactionProductID { get; set; }
    }
}
