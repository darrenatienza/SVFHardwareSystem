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

namespace SVFHardwareSystem.Services
{
    public class SalesService : ISalesService
    {
        public SalesService() { }

        public IList<SalesModel> GetSales(DateTime from, DateTime to, string criteria)
        {
            using (var db = new DataContext())
            {
                // get products on transactions from date to date
                var transactionProducts = db.TransactionProducts.Where(x => (DbFunctions.TruncateTime(x.CreateTimeStamp) >= DbFunctions.TruncateTime(from) 
                && DbFunctions.TruncateTime(x.CreateTimeStamp) <= DbFunctions.TruncateTime(to)) 
                && (x.POSTransaction.Cost.Contains(criteria) || x.POSTransaction.SIDR.Contains(criteria))).ToList();
                var models = Mapping.Mapper.Map<List<SalesModel>>(transactionProducts);
                return models;
            }
        }

        public decimal GetTotalAmount(string sidr)
        {
            throw new NotImplementedException();
        }
    }
}
