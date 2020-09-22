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
    public class TransactionProductService : Service<TransactionProductModel,TransactionProduct>, ITransactionProductService
    {
        public TransactionProductService() { }

        public void EditIsToPay(int id, bool isToPay)
        {
            using (var db = new DataContext())
            {
                var productOnTransaction = db.TransactionProducts.Find(id);
                productOnTransaction.IsToPay = isToPay;
                db.Entry(productOnTransaction).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public async Task<IList<TransactionProductModel>> GetProductsByTransactionID(int id)
        {
            using (var db = new DataContext())
            {
                var productsOnTransactions = await db.TransactionProducts.Where(x => x.POSTransactionID == id).OrderByDescending(x => x.TransactionProductID).ToListAsync();
                var models = Mapping.Mapper.Map<List<TransactionProductModel>>(productsOnTransactions);
                return models;
            }
        }
    }
}
