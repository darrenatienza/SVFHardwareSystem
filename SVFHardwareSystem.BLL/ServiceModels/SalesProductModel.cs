using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class SalesProductModel
    {
        public DateTime CreateTimeStamp { get; set; }
        public string ProductName { get; set; }
        public string SaleCost { get; set; }
        public string SaleSIDR { get; set; }
        public decimal Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductUnit { get; set; }
        /// <summary>
        /// Amount of returned product
        /// </summary>
        public decimal SaleDebit { get; set; }
        /// <summary>
        /// Amount of product
        /// </summary>
        public decimal SaleCredit
        {
            get
            {
                return Quantity * Price;
            }
        }
        public decimal CashDebit { get; set; }
        public decimal CashCredit { get; set; }
        public decimal ReceivablesCredit { get; set; }
        public decimal ReceivableDebit { get; set; }
        public int TransactionProductID { get; internal set; }
        /// <summary>
        /// Number of Quantity that is Cancel
        /// </summary>
        public decimal QuantityToCancel { get; set; }
        public bool IsCancel { get; internal set; }
        public bool IsPaid { get; internal set; }
        public int SaleID { get; internal set; }
        public bool IsReplace { get; set; }
        /// <summary>
        /// Amount of Product after being purchase
        /// </summary>
        public decimal Price { get; set; }
    }
}
