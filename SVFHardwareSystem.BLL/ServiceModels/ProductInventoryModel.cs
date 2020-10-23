using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class ProductInventoryModel
    {
        public int ProductID { get; internal set; }
        public string CategoryName { get; internal set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Name { get; internal set; }
        public string Unit { get; internal set; }
        public int Quantity { get; internal set; }
        /// <summary>
        /// Unit Cost
        /// Total Amount / Quantity
        /// Need the avarage price
        /// Prices of every product purchase may change
        /// </summary>
        public decimal Price { get => TotalAmount / Quantity; }
        /// <summary>
        /// Amount
        /// </summary>
        public decimal TotalAmount { get; internal set; }
    }
}
