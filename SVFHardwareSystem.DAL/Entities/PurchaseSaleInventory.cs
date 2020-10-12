using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    public class PurchaseSaleInventory
    {
        public int PurchaseSaleInventoryID { get; set; }

        public int Year { get; set; }
        public DateTime CreateTimeStamp { get; set; } = DateTime.Now;
    }
}
