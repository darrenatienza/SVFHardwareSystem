using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class PurchaseProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; internal set; }
        public int Quantity { get; set; }
        public string ProductUnit { get; internal set; }
        [Obsolete("Delears Price cannot be set on product", true)]
        public decimal ProductDealersPrice { get; internal set; }
        public decimal Total { get { return Price * Quantity; } }
        public bool IsQuantityUploaded { get; set; }
        public int PurchaseProductID { get; set; }
        public int ProductCategoryID { get; set; }
        /// <summary>
        /// Dealers Price
        /// </summary>
        public decimal Price { get; set; }
    }
}
