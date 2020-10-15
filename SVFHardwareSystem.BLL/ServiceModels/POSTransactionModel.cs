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
        public decimal Receivable { get; internal set; }
        public bool IsFinished { get; set; }
        public bool IsFullyPaid { get; internal set; }
        /// <summary>
        /// Total Amount of all Purchase Products
        /// </summary>
        public decimal TotalAmount { get; internal set; }
        public decimal TotalPayment { get; set; }
        public decimal CancelAmount { get; internal set; }
        public decimal Price { get; set; }
        public DateTime SalesTransactionDate { get; set; }
    }
}
