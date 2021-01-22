using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    public class ProductInventory
    {
        public ProductInventory() { }
        public int ProductInventoryID { get; set; }
        public DateTime CreateTimeStamp { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Year { get; set; }
        public decimal Quantity { get; set; }
        /// <summary>
        /// Total
        /// </summary>
        public decimal TotalAmount { get; set; }

    }
}
