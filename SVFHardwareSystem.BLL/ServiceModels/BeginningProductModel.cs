using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class BeginningProductModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        /// <summary>
        /// Selling Amount to Customers
        /// </summary>
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
