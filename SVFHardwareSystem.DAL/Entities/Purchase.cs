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
        public DateTime CreateTimeStamp { get; set; }

        public DateTime DatePurchase { get; set; }
        public int PurchaseID { get; set; }
        public string Code { get; set; }
        public string Remarks { get; set; }

    }
}
