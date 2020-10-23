using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface ISalesService
    {
        IList<SalesModel> GetSales(DateTime from, DateTime to, string criteria);
        decimal GetTotalAmount(string sidr);
        IList<CustomerReceivableModel> GetCustomersWithReceivables(int year);
        CustomerReceivableModel GetCustomerWithReceivables(int customerID);

        Task<SalesMonthlyTotalModel> GetSalesMonthlyTotal(int month, int year);

        Task<List<ProductInventoryModel>> GetAllProductSaleInventoryByMonthYear(int month, int year);
    }
}
