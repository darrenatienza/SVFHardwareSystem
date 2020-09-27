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
using System.Runtime.CompilerServices;

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
                decimal receivable = 0;
                decimal cancel = 0;
                var entity = await db.POSTransactions.FirstOrDefaultAsync(x => x.SIDR == code);
                var model = entity != null ? Mapping.Mapper.Map<POSTransactionModel>(entity) : throw new KeyNotFoundException();
                //get total and receivables list
                var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == entity.POSTransactionID && !x.IsCancel);
                var posPayments = db.POSPayments.Where(x => x.POSTransactionID == entity.POSTransactionID);
                // compute for total amount of products
                total = transactionProducts.Count() > 0 ? transactionProducts.Sum(y => y.Quantity * y.Product.Price) : 0;
                //compute for  total amount of cash payments
                cash = posPayments.Count() > 0 ? posPayments.Sum(y => y.Amount) : 0;
                // cancel items are computed where is cancel is true and is paid is true
                var cancelItems = transactionProducts.Where(a => a.IsCancel && a.IsPaid);
                cancel = cancelItems.Count() > 0 ? cancelItems.Sum(z => z.Quantity * z.Product.Price) : 0;
                // peform operation && set values
               receivable = total - cash;
                model.IsFullyPaid = receivable == 0 ? true : false;
                model.TotalAmount = total;
                model.TotalPayment = cash;
                model.Receivable = receivable;
                model.CancelAmount = cancel;
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
                var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == posTransactionID);
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
                decimal total = 0;
                decimal cash = 0;
                var entity = db.POSTransactions.FirstOrDefault(x => x.IsFinished == false);
                var model = entity != null ? Mapping.Mapper.Map<POSTransactionModel>(entity) : throw new KeyNotFoundException();
                var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == entity.POSTransactionID);
                var posPayments = db.POSPayments.Where(x => x.POSTransactionID == entity.POSTransactionID);
               
                if (transactionProducts.Count() > 0)
                {
                    total = transactionProducts.Sum(y => y.Quantity * y.Product.Price);
                    model.TotalAmount = total;
                }
                return model;
  
            }
        }
    }
}
