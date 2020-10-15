using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    public class PurchaseSaleInventoryProduct
    {
        public int PurchaseSaleInventoryProductID { get; set; }

        public int PurchaseSaleInventoryID { get; set; }
        public virtual PurchaseSaleInventory PurchaseSaleInventory { get; set; }
        public int ProductID { get; set; }
       public virtual Product Product { get; set; }
        public int Year { get; set; }
        /// <summary>
        /// Base on Previous Ending Quantity 
        /// </summary>
        public int BeginningQuantity { get; set; }
        /// <summary>
        /// Base on Previous Ending Cost
        /// </summary>
        public decimal BeginningUnitCost { get; set; }



        /// <summary>
        /// Total purchase quantity of Product for current Year
        /// </summary>
        public int PurchaseQuantity { get; set; }
        /// <summary>
        /// Total purchase unit cost of Product for current Year
        /// </summary>
        public decimal PurchaseUnitCost { get; set; }

        public int SalesQuantity { get; set; }
        public decimal SalesUnitCost { get; set; }
    }
}
