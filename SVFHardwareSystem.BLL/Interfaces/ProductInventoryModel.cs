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
        public string  Name { get; set; }
        public string Unit { get; set; }
        public int Year { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice
        {
            get => TotalAmount > 0 && Quantity > 0 ? TotalAmount / Quantity : 0;
        }
        /// <summary>
        /// Total
        /// </summary>
        public decimal TotalAmount { get; set; }
        public string CategoryName { get; set; }
    }
}
