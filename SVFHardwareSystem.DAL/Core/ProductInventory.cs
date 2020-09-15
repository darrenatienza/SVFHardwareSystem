using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Core
{
    public class ProductInventory
    {
        public ProductInventory() { }
        public int ProductInventoryID { get; set; }
        public DateTime CreateTimeStamp { get; set; }
        public int ProductID { get; set; }

    }
}
