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
    public class Sale
    {
        public Sale() { }

        public int SaleID { get; set; }
        public DateTime CreateTimeStamp { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public string Cost { get; set; }
        public string SIDR { get; set; }
        public bool IsFinished { get; set; }
        public ICollection<SalePayment> SalePayments { get; set; } = new HashSet<SalePayment>();
        public ICollection<SaleProduct> TransactionProducts { get; set; } = new HashSet<SaleProduct>();
        /// <summary>
        /// Date when the sale finished
        /// </summary>
        public DateTime DateFinished { get; set; }
        public bool IsFullyPaid { get; set; }
        /// <summary>
        /// Date when the transaction happens
        /// </summary>
        public DateTime SalesTransactionDate { get; set; }
    }
}
