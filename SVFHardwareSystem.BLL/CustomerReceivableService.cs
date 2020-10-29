using AutoMap;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    public class CustomerReceivableService : ICustomerReceivableService
    {
        public async Task<Dictionary<int, string>> GetCustomerNameWithReceivables()
        {
            using (var db = new DataContext())
            {
                var customers = db.Customers.Where(x => x.)
            }
        }

        public Task<IList<CustomerReceivableModel>> GetCustomerReceivables(int customerID)
        {
            throw new NotImplementedException();
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
