using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class CustomerSalesReceivableModel
    {

        public DateTime SalesTransactionDate { get; set; }
        public string SI { get; set; }
        /// <summary>
        /// Total Amount Paid by Customers
        /// </summary>
        public decimal Debit { get; set; }
        /// <summary>
        /// Total Amount of sales transaction
        /// </summary>
        public decimal Credit { get; set; }
        /// <summary>
        /// Balance of Customers
        /// </summary>
        public decimal Balance { get { return Credit - Debit; } }
    }
}
