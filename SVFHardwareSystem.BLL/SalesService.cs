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
                    var amountPaidOnCash = _posTransaction.GetTotalCashOnlyAmount(item.POSTransactionID);

                    // this is the total amout of payment and being subtracted for every product on this transaction
                    var amountCashOnly = _posTransaction.GetTotalCashOnlyAmount(item.POSTransactionID);


                    var receivablePayment = _posTransaction.GetTotalReceivablePayment(item.POSTransactionID);

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
                        decimal remainingQuantityAmount = salesProduct.Price * remainingQuantity;
                        decimal cancelAmount = salesProduct.Price * salesProduct.QuantityToCancel;
                        salesProduct.SaleDebit = cancelAmount;
                        salesProduct.CashCredit = cancelAmount;
                        //subtract first the amount paid on cash (first payment)
                        amountPaidOnCash -= remainingQuantityAmount;
                        if (amountPaidOnCash >= 0)
                        {
                            salesProduct.CashDebit = remainingQuantityAmount;
                        }

                        else
                        {
                            //then subtract the amount paid on receivables
                            receivablePayment -= Math.Abs(amountPaidOnCash);
                            if (receivablePayment >= 0)
                            {
                                salesProduct.ReceivablesCredit = Math.Abs(amountPaidOnCash);
                                salesProduct.CashDebit = remainingQuantityAmount - salesProduct.ReceivablesCredit;
                            }
                            else
                            {
                                //if negative credit, convert the negative to positive, put this as receivable credit
                                salesProduct.ReceivableDebit = Math.Abs(receivablePayment);
                                //get portion of cash debit paid
                                salesProduct.CashDebit = remainingQuantityAmount - salesProduct.ReceivableDebit;
                            }

                            amountPaidOnCash = 0; // set to zero to avoid wrong computation for later amount



                        }
                        sale.SalesProducts.Add(salesProduct);
                    }
                    sales.Add(sale);
                }
                // order sales according on update time
                return sales;
            }
        }

        public IList<CustomerReceivableModel> GetCustomersWithReceivables(int year)
        {
            using (var db = new DataContext())
            {
                // all sales transaction where isfullypaid = false is a receivable sales

                var customers = db.Customers.Where(x => x.PosTransactions.Where(y => y.IsFullyPaid == false).ToList().Count() >  0).ToList();
                var models = Mapping.Mapper.Map<List<CustomerReceivableModel>>(customers);
                return models;

            }
        }

        public decimal GetTotalAmount(string sidr)
        {
            throw new NotImplementedException();
        }
        private decimal GetTotalPurchaseAmount(int posTransactionID)
        {
            using (var db = new DataContext())
            {
                var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == posTransactionID).ToList();
                // here quantity to cancel must subtract to actual quantity purchase because they are quantities that the
                // customers was not pay.
                return transactionProducts.Sum(y => (y.Quantity - y.QuantityToCancel) * y.Price);
            }
        }
        private decimal GetTotalPaymentAmount(int posTransactionID)
        {
            using (var db = new DataContext())
            {
                var posPayments = db.POSPayments.Where(x => x.POSTransactionID == posTransactionID); ;
                //compute for  total amount of cash payments
                var cash = posPayments.Count() > 0 ? posPayments.Sum(y => y.Amount) : 0;
                return cash;
            }
           
        }
        public CustomerReceivableModel GetCustomerWithReceivables(int customerID)
        {
            using (var db = new DataContext())
            {
                var customer = db.Customers.Find(customerID);
                var customerReceivableModel = Mapping.Mapper.Map<CustomerReceivableModel>(customer);

                var salesTransctions = db.POSTransactions.Where(x => x.CustomerID == customerID && x.IsFullyPaid == false).ToList();

                foreach (var item in salesTransctions)
                {
                    var totalPurchaseAmount = GetTotalPurchaseAmount(item.POSTransactionID);
                    var totalPaymentAmount = GetTotalPaymentAmount(item.POSTransactionID);

                    var model = new CustomerSalesReceivableModel();
                    model.Credit = totalPurchaseAmount;
                    model.SalesTransactionDate = item.SalesTransactionDate;
                    model.Debit = totalPaymentAmount;
                    model.SI = item.SIDR;
                    customerReceivableModel.SalesReceivables.Add(model);
                }
                return customerReceivableModel;
               
            }
            


        }

        public async Task<SalesMonthlyTotalModel> GetSalesMonthlyTotal(int month, int year)
        {
            using (var db = new DataContext())
            {
                var daysInMonth = DateTime.DaysInMonth(year, month);
                var salesMonthlyTotalModel = new SalesMonthlyTotalModel();

                
                for (int day = 1; day <= daysInMonth; day++)
                {
                    var totalDailyCashPayment = await GetTotalCashOnlyPayment(month, year, day);
                    var totalSalesAmount = await GetTotalSalesAmount(month, year, day);

                    var salesDailyTotalModel = new SalesDailyTotalModel();
                    salesDailyTotalModel.Date =  new DateTime(year, month, day);
                    salesDailyTotalModel.TotalDailyCashPayment = totalDailyCashPayment;
                    salesDailyTotalModel.TotalDailySalesAmount = totalSalesAmount;
                    salesMonthlyTotalModel.SalesDailyTotals.Add(salesDailyTotalModel);
                }
                return salesMonthlyTotalModel;
            }
        }

        public async Task<decimal> GetTotalCashOnlyPayment(int month, int year, int day)
        {
            using (var db = new DataContext())
            {
                var posPayments = await db.POSPayments.Where(x => x.PaymentDate.Month == month 
                    && x.PaymentDate.Year == year && x.PaymentDate.Day == day 
                    && x.IsReceivablePayment == false).ToListAsync();

                return posPayments.Count() > 0 ? posPayments.Sum(y => y.Amount) : 0;
            }


        }

        public async Task<decimal> GetTotalSalesAmount(int month, int year, int day)
        {
            using (var db = new DataContext())
            {
                var sales = await db.POSTransactions.Include(x => x.TransactionProducts).Where(x => x.SalesTransactionDate.Month == month
                    && x.SalesTransactionDate.Year == year && x.SalesTransactionDate.Day == day ).ToListAsync();
                
                return sales.Count() > 0 ? sales.Sum(y => y.TransactionProducts.Sum(z => (z.Quantity - z.QuantityToCancel) * z.Price)) : 0;
            }


        }
    }
}
