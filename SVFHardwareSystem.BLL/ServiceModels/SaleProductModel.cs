using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class SaleProductModel
    {
        public SaleProductModel() { }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public bool IsPaid { get; set; }
        public bool IsToPay { get; set; }
        /// <summary>
        /// Indicates the time when the product transaction updated
        /// </summary>
        public DateTime UpdateTimeStamp { get; set; }
        public int SaleID { get; set; }
        public decimal Total { get { return Quantity * Price; } }

        public decimal ProductPrice { get; set; }
        public int SaleProductID { get; set; }
        public bool IsCancel { get; set; }
        public bool IsReplace { get; set; }
        public bool IsForReturnToSupplierAfterReplace { get; set; }
        public bool IsForReturnToSupplierAfterCancel { get; set; }
        public int QuantityToCancel { get; set; }
        public int QuantityToReplace { get; set; }
        public decimal Price { get; set; }
    }
}
