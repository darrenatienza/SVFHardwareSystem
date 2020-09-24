using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class POSPaymentModel
    {
        public POSPaymentModel() { }
        public int POSPaymentID { get; set; }
        public int POSTransactionID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }
}
