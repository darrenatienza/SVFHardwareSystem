using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    /// <summary>
    /// General Inventory for Product aka yearly
    /// </summary>
    public class ProductInventoryModel
    {

        public int ProductInventoryID { get; set; }
        public DateTime CreateTimeStamp { get; set; }
        public int ProductID { get; set; }
        public string  ProductName { get; set; }
        public string Unit { get; set; }
        public int Year { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice
        {
            get => TotalAmount / Quantity;
        }
        /// <summary>
        /// Total
        /// </summary>
        public decimal TotalAmount { get; set; }
        public string ProductCategoryName { get; set; }
    }
}
