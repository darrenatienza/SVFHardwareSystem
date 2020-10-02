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
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public string CategoryName { get; set; }
        public int Limit { get; set; }
        public decimal DealersPrice { get; set; }
        public string SupplierName { get; set; }
        public int SupplierID { get; internal set; }
        public int CategoryID { get; internal set; }
    }
}
