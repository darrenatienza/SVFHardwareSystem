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
                decimal total = 0;
                decimal cash = 0;
                
                var entity = await db.POSTransactions.FirstOrDefaultAsync(x => x.SIDR == code && x.IsFinished == true) ;
                var model = entity != null ? Mapping.Mapper.Map<POSTransactionModel>(entity) : throw new KeyNotFoundException();
                var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == entity.POSTransactionID);
                var posPayments = db.POSPayments.Where(x => x.POSTransactionID == entity.POSTransactionID);
                if (transactionProducts.Count() > 0 && posPayments.Count() > 0)
                {
                    total = transactionProducts.Sum(y => y.Quantity * y.Product.Price);
                    cash = posPayments.Sum(y => y.Amount);
                    model.Receivable = total - cash;
                }
               
                return model;
            }

        }

        public decimal GetReceivableAmount(int posTransactionID)
        {
            using (var db = new DataContext())
            {
                decimal total = 0;
                decimal cash = 0;
                decimal receivable = 0;
                var entity = db.POSTransactions.FirstOrDefault(x => x.POSTransactionID == posTransactionID && x.IsFinished == true);
                if (entity != null)
                {
                    var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == entity.POSTransactionID);
                    var posPayments = db.POSPayments.Where(x => x.POSTransactionID == entity.POSTransactionID);
                    if (transactionProducts.Count() > 0 && posPayments.Count() > 0)
                    {
                        total = transactionProducts.Sum(y => y.Quantity * y.Product.Price);
                        cash = posPayments.Sum(y => y.Amount);
                        receivable = total - cash;
                    }
                }
                
                return receivable;
            }
        }

        public decimal GetTotalAmount(int posTransactionID)
        {
            using (var db = new DataContext())
            {
                decimal total = 0;
                var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == posTransactionID && x.IsToPay == true && !x.IsPaid);
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
