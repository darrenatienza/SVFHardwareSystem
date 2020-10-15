using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class SupplierPayablesModel
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
        public decimal TotalCashPayment { get; set; }
        /// <summary>
        /// Balance
        /// </summary>
        public decimal TotalPayableAmount { get; set; }

    }
}
