using AutoMap;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace SVFHardwareSystem.Services
{
    public class POSTransactionService : Service<POSTransactionModel,POSTransaction>, IPOSTransactionService
    {
        public POSTransactionService() { }

        public void EditCustomerIDOnCurrentPOSTransaction(int posTransactionID, int customerID)
        {
            using (var db = new DataContext())
            {
                var entity = db.POSTransactions.Find(posTransactionID);
                entity.CustomerID = customerID;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public async Task<POSTransactionModel> Get(string code)
        {
            using (var db = new DataContext())
            {
                var entity = await db.POSTransactions.FirstOrDefaultAsync(x => x.SIDR == code);
                var model = entity != null ? Mapping.Mapper.Map<POSTransactionModel>(entity) : throw new KeyNotFoundException();
                return model;
            }

        }

        public decimal GetTotalAmount(int posTransactionID)
        {
            using (var db = new DataContext())
            {
                decimal total = 0;
                var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == posTransactionID && x.IsToPay == true);
                if (transactionProducts.Count() > 0)
                {
                    total = transactionProducts.Sum(y => y.Quantity * y.Product.Price);
                   
                }
                return total;


            }
        }

        public POSTransactionModel GetUnFinishedTransaction()
        {
            using (var db = new DataContext())
            {
                var entity = db.POSTransactions.FirstOrDefault(x => x.IsFinished == false);
                var model = entity != null ? Mapping.Mapper.Map<POSTransactionModel>(entity) : throw new KeyNotFoundException();
                return model;
  
            }
        }
    }
}
