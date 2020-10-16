using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    public class Purchase
    {
        public Purchase() { }
        public int PurchaseID { get; set; }
        public DateTime CreateTimeStamp { get; set; } = DateTime.Now;

        public DateTime DatePurchase { get; set; }

        public string SIDR { get; set; }
        public int SupplierID { get; set; }
        public virtual Supplier Supplier { get; set; }

        public string Remarks { get; set; }

        public ICollection<PurchaseProduct> PurchaseProducts { get; set; } = new HashSet<PurchaseProduct>();

    }
}
