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
                IList<SalesModel> saleModels = new List<SalesModel>();
                foreach (var item in postransactions)
                {
                    // this is the total amout of payment and being subtracted for every product of this transaction
                    var amountPaid = _posTransaction.GetCashAmount(item.POSTransactionID);
                    var _saleModels = Mapping.Mapper.Map<List<SalesModel>>(item.TransactionProducts);
                    // cash debit and receivable debit computation
                    foreach (var saleModel in _saleModels)
                    {
                        //sales debit and cash credit computation
                        //get all cancelled products
                        if (saleModel.IsCancel)
                        {
                            // compute base on how many item is cancelled
                            var remainingQuantity = saleModel.Quantity - saleModel.QuantityToCancel;
                            decimal remainingQuantityAmount = saleModel.ProductPrice * remainingQuantity;
                            saleModel.SaleDebit = remainingQuantityAmount;
                            saleModel.CashCredit = remainingQuantityAmount;
                            //testing -- wrong output
                            amountPaid -= saleModel.SaleCredit;

                            if (amountPaid >= 0)
                            {
                                saleModel.CashDebit = saleModel.SaleCredit;
                            }
                            else
                            {
                                //if negative credit, convert the negative to positive, put this as receivable credit
                                saleModel.ReceivableDebit = Math.Abs(amountPaid);
                                //get portion of cash debit paid
                                saleModel.CashDebit = saleModel.SaleCredit - saleModel.ReceivableDebit;
                                amountPaid = 0; // set to zero to avoid wrong computation for later amount
                            }
                        }
                        else
                        {
                            amountPaid -= saleModel.SaleCredit;

                            if (amountPaid >= 0)
                            {
                                saleModel.CashDebit = saleModel.SaleCredit;
                            }
                            else
                            {
                                //if negative credit, convert the negative to positive, put this as receivable credit
                                saleModel.ReceivableDebit = Math.Abs(amountPaid);
                                //get portion of cash debit paid
                                saleModel.CashDebit = saleModel.SaleCredit - saleModel.ReceivableDebit;
                                amountPaid = 0; // set to zero to avoid wrong computation for later amount
                            }
                        }
                        //subtract amount paid to sale credit

                        saleModels.Add(saleModel);
                    }
                }
                // order sales according on update time
                var orderedSaleModels = saleModels;
                return saleModels;
            }
        }

        public decimal GetTotalAmount(string sidr)
        {
            throw new NotImplementedException();
        }
    }
}
