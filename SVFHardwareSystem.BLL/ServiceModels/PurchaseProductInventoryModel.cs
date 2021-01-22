using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    /// <summary>
    /// Report for Monthly Purchases of a product
    /// </summary>
    public class PurchaseProductInventoryModel
    {
        public int ProductID { get; internal set; }
        public string CategoryName { get; internal set; }
        /// <summary>
        /// Description
        /// </summary>
        public string  Name { get; internal set; }
        public string Unit { get; internal set; }
        /// <summary>
        /// Ref
        /// </summary>
        public string SIDR { get; internal set; }
       
        public decimal Quantity { get; internal set; }
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
        /// <summary>
        /// Purchase Dates
        /// </summary>
        public string Date { get; internal set; }
    }
}
