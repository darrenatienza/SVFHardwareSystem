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
    public class PurchaseProductMonthlyReportModel
    {
        public string CategoryName { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string  ProductName { get; set; }
        public string Unit { get; set; }
        /// <summary>
        /// Ref
        /// </summary>
        public int SIDR { get; set; }
       
        public int Quantity { get; set; }
        /// <summary>
        /// Unit Cost
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Amount
        /// </summary>
        public decimal TotalAmount { get => Price * Quantity; }
    }
}
