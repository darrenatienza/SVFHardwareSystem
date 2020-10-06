using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    public class SupplierProductToReturn
    {
        public SupplierProductToReturn() { }
        public int SupplierProductToReturnID { get; set; }
        /// <summary>
        /// This indicates the identity of the product item that needs to return
        /// </summary>
        public string Code { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        /// <summary>
        /// Reason of product needs to return
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// Indicates if product its came from cancel or return of point of sale
        /// </summary>
        public bool IsProductFromCancelReplace { get; set; }
        public DateTime CreateTimeStamp { get; set; }
    }
}
