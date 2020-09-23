using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    public class Product
    {
        public Product() { }
        public int ProductID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Limit { get; set; }

    }
}
