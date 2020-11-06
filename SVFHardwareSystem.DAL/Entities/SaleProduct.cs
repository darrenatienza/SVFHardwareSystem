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
    public class SaleProduct
    {
        public SaleProduct() { }
        public int SaleProductID { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int SaleID { get; set; }
        public virtual Sale Sale { get; set; }
        public int Quantity { get; set; }
        /// <summary>
        /// Indicates the product that is paid by customer
        /// </summary>
        public bool IsPaid { get; set; }
        /// <summary>
        /// Indicates the product that will be paid in the future
        /// </summary>
        public bool IsToPay { get; set; }

        public bool IsReplace { get; set; }
        public DateTime ReplaceDate { get; set; } = DateTime.Now;
        public string ReplaceReason { get; set; }
        public bool IsCancel { get; set; }
        public DateTime CancelDate { get; set; } = DateTime.Now;
        public string CancelReason { get; set; }
        /// <summary>
        /// This indicates if the quantity of the replace or cancel product is added to current product inventory 
        /// </summary>
        public bool IsQuantityAddedToInventoryAfterReplaceOrCancel { get; set; }
        public bool IsForReturnToSupplierAfterReplace { get; set; }
        public bool IsForReturnToSupplierAfterCancel { get; set; }
        /// <summary>
        /// Number of Quantity that is replace
        /// </summary>
        public int QuantityToReplace { get; set; }
        /// <summary>
        /// Number of Quantity that is Cancel
        /// </summary>
        public int QuantityToCancel { get; set; }
        public DateTime CreateTimeStamp { get; set; } = DateTime.Now;
        /// <summary>
        /// Amount of Item paid.
        /// Not relying on product price
        /// Change of product price may affect the daily sales if relying on Product Price
        /// </summary>
        public decimal Price { get; set; }
    }
}
