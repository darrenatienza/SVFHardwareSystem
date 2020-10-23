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
        public int? SupplierID { get; set; }
        //public virtual Supplier Supplier { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public decimal? DealersPrice { get; set; }

        public ICollection<PurchaseProduct> PurchaseProducts { get; set; }

        public ICollection<SaleProduct> SaleProducts { get; set; }

    }
}
