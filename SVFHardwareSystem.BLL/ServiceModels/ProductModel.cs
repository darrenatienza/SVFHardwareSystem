using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class ProductModel
    {


        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        /// <summary>
        /// Selling Amount to Customers
        /// </summary>
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public int ProductID { get; set; }
        public string CategoryName { get; set; }
        public int Limit { get; set; }
        
       
       
        public int CategoryID { get; set; }
        /// <summary>
        /// Cost of product purchase
        /// </summary>
        public decimal UnitCost { get; set; }
    }
}
