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
        public string Cost { get; set; }
        public string SIDR { get; set; }
        public decimal TotalSaleDebit { get { return SalesProducts.Sum(x => x.SaleDebit); } }
        public decimal TotalSaleCredit { get { return SalesProducts.Sum(x => x.SaleCredit); } }
        public decimal TotalCashDebit { get { return SalesProducts.Sum(x => x.CashDebit); } }
        public decimal TotalCashCredit { get { return SalesProducts.Sum(x => x.CashCredit); } }
        public decimal TotalReceivableDebit { get { return SalesProducts.Sum(x => x.ReceivableDebit); } }
        public decimal TotalReceivableCredit { get { return SalesProducts.Sum(x => x.ReceivablesCredit); } }

        public IList<SalesProductModel> SalesProducts { get; set; } = new List<SalesProductModel>();
        public object CustomerFullName { get; set; }
    }
}
