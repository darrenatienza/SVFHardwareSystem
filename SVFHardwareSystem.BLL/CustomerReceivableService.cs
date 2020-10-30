using AutoMap;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    public class CustomerReceivableService : ICustomerReceivableService
    {
      

        public CustomerReceivableService()
        {
           
        }

       
        public async Task<IList<CustomerReceivableModel>> GetAllCustomersReceivables(int month, int year)
        {
            using (var db = new DataContext())
            {
                var customerSaleWithReceivables = await db.Sales
                       .Where(x => x.IsFullyPaid == false && x.SaleDate.Year == year && x.SaleDate.Month == month)
                       .Select(x =>
                        new CustomerReceivableModel
                        {
                            Date = x.SaleDate,
                            CustomerID = x.CustomerID,
                            Debit = x.SalePayments.Count() > 0 ?x.SalePayments.Sum(sp => sp.Amount) : 0,
                            Credit = x.SaleProducts.Count() > 0? x.SaleProducts.Sum(spr => spr.Price * (spr.Quantity - spr.QuantityToCancel)) : 0,
                            SI = x.SIDR,
                            FullName = x.Customer.FullName
                        })
                        .ToListAsync();

                return customerSaleWithReceivables;
            }
        }

        public async Task<Dictionary<int, string>> GetCustomerNamesWithReceivables()
        {
            using (var db = new DataContext())
            {
                var customers = await db.Customers.Where(x => x.Sales.Where(y => y.IsFullyPaid == false).Count() > 0).ToListAsync();
                var custormersDictionaries = new Dictionary<int, string>();
                foreach (var item in customers)
                {
                    custormersDictionaries.Add(item.CustomerID, item.FullName);
                }
                return custormersDictionaries;
            }
        }

        public async Task<IList<CustomerReceivableModel>> GetCustomerReceivables(int customerID)
        {
            using (var db = new DataContext())
            {
                var customerSaleWithReceivables = await db.Sales
                       .Where(x => x.CustomerID == customerID && x.IsFullyPaid == false)
                       .Select(x =>
                        new CustomerReceivableModel { 
                            Date = x.SaleDate,
                            CustomerID = x.CustomerID, 
                            Debit = x.SalePayments.Count() > 0 ? x.SalePayments.Sum(sp => sp.Amount) : 0, 
                            Credit = x.SaleProducts.Count() > 0 ?x.SaleProducts.Sum(spr => spr.Price * (spr.Quantity - spr.QuantityToCancel)) : 0, 
                            SI = x.SIDR, FullName = x.Customer.FullName })
                        .ToListAsync();

                return customerSaleWithReceivables;
            }
        }

      

        //public CustomerReceivableModel GetCustomerWithReceivables(int customerID)
        //{
        //    using (var db = new DataContext())
        //    {
        //        var customer = db.Customers.Find(customerID);
        //        var customerReceivableModel = Mapping.Mapper.Map<CustomerReceivableModel>(customer);

        //        var salesTransctions = db.Sales.Where(x => x.CustomerID == customerID && x.IsFullyPaid == false).ToList();

        //        foreach (var item in salesTransctions)
        //        {
        //            var totalPurchaseAmount = GetTotalPurchaseAmount(item.SaleID);
        //            var totalPaymentAmount = GetTotalPaymentAmount(item.SaleID);

        //            var model = new CustomerSalesReceivableModel();
        //            model.Credit = totalPurchaseAmount;
        //            model.SalesTransactionDate = item.SaleDate;
        //            model.Debit = totalPaymentAmount;
        //            model.SI = item.SIDR;
        //            customerReceivableModel.SalesReceivables.Add(model);
        //        }
        //        return customerReceivableModel;

        //    }



        //}
    }
}
