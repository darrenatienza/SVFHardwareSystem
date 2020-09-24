using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class POSTransactionModel
    {
        public DateTime CreateTimeStamp { get; set; }
        public string CustomerFullName { get; set; }
        public string Cost { get; set; }
        public string SIDR { get; set; }
        public int CustomerID { get; set; }
        public int POSTransactionID { get; set; }
        public decimal Receivable { get; set; }
        public bool IsFinished { get; set; }
    }
}
