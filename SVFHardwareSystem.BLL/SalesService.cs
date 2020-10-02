using AutoMap;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace SVFHardwareSystem.Services
{
    public class SalesService : ISalesService
    {
        private IPOSTransactionService _posTransaction;

        public SalesService(IPOSTransactionService posTransaction)
        {
            _posTransaction = posTransaction;
        }

        public IList<SalesModel> GetSales(DateTime from, DateTime to, string criteria)
        {
            using (var db = new DataContext())
            {


                var postransactions = db.POSTransactions.Include(x => x.TransactionProducts).Where(x => DbFunctions.TruncateTime(x.DateFinished) >= DbFunctions.TruncateTime(from)
                && DbFunctions.TruncateTime(x.DateFinished) <= DbFunctions.TruncateTime(to)
                && (x.Cost.Contains(criteria) || x.SIDR.Contains(criteria))
                && (x.IsFinished)).ToList();

                var sales = new List<SalesModel>();
                foreach (var item in postransactions)
                {
                    var sale = Mapping.Mapper.Map<SalesModel>(item);
                    



                    // this is the total amout of payment and being subtracted for every product on this transaction
                    var amountPaid = _posTransaction.GetCashAmount(item.POSTransactionID);
                    var _salesProducts = Mapping.Mapper.Map<List<SalesProductModel>>(item.TransactionProducts);
                    // cash debit and receivable debit computation
                    foreach (var salesProduct in _salesProducts)
                    {
                        //sales debit and cash credit computation

                        // compute the remaining quantity by subtracting total quantity purchase and quantity cancel
                        // get the remaining quantity amount by subtracting the product price and the remaining quantity
                        // get the cancel amount by subtracting product price to quantity cancel
                        // the cancel amount will be the SALE Debit And CASH Debit because these are the amount that will be
                        // given back to the customer
                        var remainingQuantity = salesProduct.Quantity - salesProduct.QuantityToCancel;
                        decimal remainingQuantityAmount = salesProduct.ProductPrice * remainingQuantity;
                        decimal cancelAmount = salesProduct.ProductPrice * salesProduct.QuantityToCancel;
                        salesProduct.SaleDebit = cancelAmount;
                        salesProduct.CashCredit = cancelAmount;
                        amountPaid -= remainingQuantityAmount;
                        if (amountPaid >= 0)
                        {
                            salesProduct.CashDebit = remainingQuantityAmount;
                        }
                        else
                        {
                            //if negative credit, convert the negative to positive, put this as receivable credit
                            salesProduct.ReceivableDebit = Math.Abs(amountPaid);
                            //get portion of cash debit paid
                            salesProduct.CashDebit = remainingQuantityAmount - salesProduct.ReceivableDebit;
                            amountPaid = 0; // set to zero to avoid wrong computation for later amount
                        }
                        sale.SalesProducts.Add(salesProduct);
                    }
                    sales.Add(sale);
                }
                // order sales according on update time
                return sales;
            }
        }

        public decimal GetTotalAmount(string sidr)
        {
            throw new NotImplementedException();
        }
    }
}
