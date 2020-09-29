using AutoMap;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace SVFHardwareSystem.Services
{
    public class SalesService : ISalesService
    {
        private IPOSTransactionService _pOSTransactionService;

        public SalesService(IPOSTransactionService pOSTransactionService)
        {
            _pOSTransactionService = pOSTransactionService;
        }

        public IList<SalesModel> GetSales(DateTime from, DateTime to, string criteria)
        {
            using (var db = new DataContext())
            {
                // get products on transactions from date to date
                var transactionProducts = db.TransactionProducts.Where(x => (DbFunctions.TruncateTime(x.CreateTimeStamp) >= DbFunctions.TruncateTime(from)
                && DbFunctions.TruncateTime(x.CreateTimeStamp) <= DbFunctions.TruncateTime(to))
                && (x.POSTransaction.Cost.Contains(criteria) || x.POSTransaction.SIDR.Contains(criteria))).ToList();
                var models = Mapping.Mapper.Map<List<SalesModel>>(transactionProducts);

                foreach (var item in models)
                {

                    item.SaleDebit = item.IsCancel ? item.SaleCredit : 0;
                    //cash credit = amount paid - total amount

                    foreach (var tProd in transactionProducts.Where(x => x.POSTransactionID == item.POSTransactionID))
                    {
                        // this is the total amout of transaction and being subtracted every transaction product
                        var currentAmountPaid = _pOSTransactionService.GetTotalAmount(item.POSTransactionID);
                        if (tProd.TransactionProductID != item.TransactionProductID)
                        {

                            currentAmountPaid = currentAmountPaid - item.SaleCredit;
                        }
                        else
                        {
                            var credit = currentAmountPaid - item.SaleCredit;
                            if (credit > 0)
                            {
                                item.CashCredit = credit;
                            }
                            else
                            {
                                //if negative number convert the negative to positive
                                item.ReceivableDebit = Math.Abs(credit);
                                currentAmountPaid = 0; // set to zero to avoid wrong computation for later amount
                            }

                        }
                    }
                    //item.CashCredit = item.IsPaid ? item.SaleCredit : 0;
                    //item.CashDebit = item.IsCancel ? 0 : item.SaleCredit;
                    //item.ReceivableDebit = item.IsPaid ? 0 : item.SaleCredit;
                    //item.ReceivablesCredit = item.IsCancel ? item.SaleCredit : 0;
                }
                return models;
            }
        }

        public decimal GetTotalAmount(string sidr)
        {
            throw new NotImplementedException();
        }
    }
}
