using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class SalesModel
    {
        public SalesModel() { }

        public DateTime CreateTimeStamp { get; set; }
        public string ProductName { get; set; }
        public string POSTransactionCost { get; set; }
        public string POSTransactionSIDR { get; set; }
        public int Quantity { get; set; }
        public string ProductUnit { get; set; }
        public decimal SaleDebit { get; set; }
        public decimal SaleCredit { get; set; }
        public decimal CashDebit { get; set; }
        public decimal CashCredit { get; set; }
        public decimal ReceivablesCredit { get; set; }
        public decimal ReceivableDebit { get; set; }

    }
}
