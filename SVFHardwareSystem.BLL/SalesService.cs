using AutoMap;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Exceptions;
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
        private ISaleService _saleService;

        public SalesService()
        {
            
        }

        public SalesService(ISaleService saleService)
        {
            _saleService = saleService;
        }

        public IList<SalesModel> GetSales(DateTime from, DateTime to, string criteria)
        {
            using (var db = new DataContext())
            {


                var postransactions = db.Sales.Include(x => x.SaleProducts).Where(x => DbFunctions.TruncateTime(x.SaleDate) >= DbFunctions.TruncateTime(from)
                && DbFunctions.TruncateTime(x.SaleDate) <= DbFunctions.TruncateTime(to)
                && (x.Cost.Contains(criteria) || x.SIDR.Contains(criteria))
                && (x.IsFinished)).ToList();

                var sales = new List<SalesModel>();
                foreach (var item in postransactions)
                {
                    var sale = Mapping.Mapper.Map<SalesModel>(item);




                    // this is the total amout of payment and being subtracted for every product on this transaction
                    var amountPaidOnCash = _saleService.GetTotalCashOnlyAmount(item.SaleID);

                    // this is the total amout of payment and being subtracted for every product on this transaction
                    var amountCashOnly = _saleService.GetTotalCashOnlyAmount(item.SaleID);


                    var receivablePayment = _saleService.GetTotalReceivablePayment(item.SaleID);

                    var _salesProducts = Mapping.Mapper.Map<List<SalesProductModel>>(item.SaleProducts);
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

                var customers = db.Customers.Where(x => x.Sales.Where(y => y.IsFullyPaid == false).ToList().Count() > 0).ToList();
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
                var transactionProducts = db.SaleProducts.Where(x => x.SaleID == posTransactionID).ToList();
                // here quantity to cancel must subtract to actual quantity purchase because they are quantities that the
                // customers was not pay.
                return transactionProducts.Sum(y => (y.Quantity - y.QuantityToCancel) * y.Price);
            }
        }
        private decimal GetTotalPaymentAmount(int posTransactionID)
        {
            using (var db = new DataContext())
            {
                var posPayments = db.SalePayments.Where(x => x.SaleID == posTransactionID); ;
                //compute for  total amount of cash payments
                var cash = posPayments.Count() > 0 ? posPayments.Sum(y => y.Amount) : 0;
                return cash;
            }

        }
        

        public async Task<SalesMonthlyTotalModel> GetSalesMonthlyTotal(int month, int year)
        {
            using (var db = new DataContext())
            {
                var daysInMonth = DateTime.DaysInMonth(year, month);
                var salesMonthlyTotalModel = new SalesMonthlyTotalModel();
                salesMonthlyTotalModel.Month = month;
                salesMonthlyTotalModel.Year = year;

                for (int day = 1; day <= daysInMonth; day++)
                {
                    var totalDailyCashPayment = await GetTotalCashOnlyPayment(month, year, day);
                    var totalSalesAmount = await GetTotalSalesAmount(month, year, day);

                    var salesDailyTotalModel = new SalesDailyTotalModel();
                    salesDailyTotalModel.Date = new DateTime(year, month, day);
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
                var posPayments = await db.SalePayments.Where(x => x.Sale.SaleDate.Month == month
                    && x.Sale.SaleDate.Year == year && x.Sale.SaleDate.Day == day
                    && x.IsReceivablePayment == false && x.Sale.IsSaleCancel == false && x.Sale.HasReceivablePayment == true).ToListAsync();

                return posPayments.Count() > 0 ? posPayments.Sum(y => y.Amount) : 0;
            }


        }

        private async Task<decimal> GetTotalSalesAmount(int month, int year, int day)
        {
            using (var db = new DataContext())
            {
                var sales = await db.Sales.Include(x => x.SaleProducts).Where(x => x.SaleDate.Month == month
                    && x.SaleDate.Year == year && x.SaleDate.Day == day && x.HasReceivablePayment == true).ToListAsync();

                return sales.Count() > 0 ? sales.Sum(y => y.SaleProducts.Sum(z => (z.Quantity - z.QuantityToCancel) * z.Price)) : 0;
            }


        }

        public async Task<List<SaleProductInventoryModel>> GetAllProductSaleInventoryByMonthYear(int month, int year)
        {
            using (var db = new DataContext())
            {
                year = year == 0 ? throw new InvalidFieldException("Year") : year;
                month = month == 0 ? throw new InvalidFieldException("Month") : month;
                //query the product 
                var products = await db.Products
                    .Where(x => x.SaleProducts
                    .Where(y => y.Sale.CreateTimeStamp.Year == year)
                    .Count() > 0).ToListAsync();


                var models = new List<SaleProductInventoryModel>();
                // set values to the purchase products
                foreach (var product in products)
                {

                    // map equal properties
                    var model = Mapping.Mapper.Map<SaleProductInventoryModel>(product);
                    // query product purchase using year month and product id
                    var saleProduct = await db.SaleProducts
                        .Where(x =>
                            x.Sale.SaleDate.Year == year
                            && x.ProductID == product.ProductID).ToListAsync();
                    //set values
                    model.Quantity = saleProduct.Sum(x => x.Quantity);
                    model.TotalAmount = saleProduct.Sum(x => x.Quantity * x.Price);

                    // add to model purchase products
                    models.Add(model);
                }

                return models;
            }
        }

        public async Task<IList<SalesModel>> GetSales(DateTime date, string criteria)
        {
            using (var db = new DataContext())
            {


                var postransactions = await db.Sales.Include(x => x.SaleProducts).Where(x => DbFunctions.TruncateTime(x.SaleDate) == DbFunctions.TruncateTime(date)
              
                && (x.Cost.Contains(criteria) || x.SIDR.Contains(criteria))
                && (x.IsFinished)).ToListAsync();

                var sales = new List<SalesModel>();
                foreach (var item in postransactions)
                {
                    var sale = Mapping.Mapper.Map<SalesModel>(item);
                    // this is the total amout of payment and being subtracted for every product on this transaction
                    var amountPaidOnCash = _saleService.GetTotalCashOnlyAmount(item.SaleID);

                    // this is the total amout of payment and being subtracted for every product on this transaction
                    var amountCashOnly = _saleService.GetTotalCashOnlyAmount(item.SaleID);


                    var receivablePayment = _saleService.GetTotalReceivablePayment(item.SaleID);

                    var _salesProducts = Mapping.Mapper.Map<List<SalesProductModel>>(item.SaleProducts);
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
                            decimal newReceivablePayment = 0;
                            //then subtract the amount paid on receivables
                            newReceivablePayment = receivablePayment - Math.Abs(amountPaidOnCash);
                             if (newReceivablePayment >= 0)
                                {
                                    salesProduct.ReceivablesCredit = Math.Abs(amountPaidOnCash);
                              
                                    salesProduct.CashDebit = remainingQuantityAmount - salesProduct.ReceivablesCredit;
                                    
                                }
                                else
                                {
                                    //if negative credit, convert the negative to positive, put this as receivable credit
                                    salesProduct.ReceivableDebit = Math.Abs(newReceivablePayment);
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

        public List<string> GetAllSIDRByProduct(int selProductID)
        {
            List<string> sidrList = new List<string>();
            using (var db = new DataContext())
            {
                var salesProductList = db.SaleProducts.Include(x => x.Sale).Where(x => x.ProductID == selProductID).Select(x => x.Sale);
                foreach (var salesProduct in  salesProductList)
                {
                    
                    sidrList.Add(salesProduct.SIDR);
                }
                return sidrList;
            }
        }
    }
}
