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
        /// <summary>
        /// Date when the record created
        /// </summary>
        public DateTime CreateTimeStamp { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public string Cost { get; set; }
        public string SIDR { get; set; }
        public bool IsFinished { get; set; }
        public ICollection<SalePayment> SalePayments { get; set; } = new HashSet<SalePayment>();
        public ICollection<SaleProduct> SaleProducts { get; set; } = new HashSet<SaleProduct>();
        [Obsolete("Not applicable on current point of sale setup")]
        /// <summary>
        /// Date when the sale finished
        /// </summary>
        public DateTime DateFinished { get; set; } = DateTime.Now;
        public bool IsFullyPaid { get; set; }
        /// <summary>
        /// Date when the transaction happens
        /// </summary>
        public DateTime SaleDate { get; set; }
        /// <summary>
        /// Indicates if the Sale is cancelled
        /// This means that all products are cancelled to
        /// </summary>
        public bool IsSaleCancel { get; set; }
        public bool HasReceivablePayment { get; set; }
    }
}
