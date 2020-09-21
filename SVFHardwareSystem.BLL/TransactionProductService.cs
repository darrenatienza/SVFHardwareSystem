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

        public async Task<IList<TransactionProductModel>> GetProductsByTransactionID(int id)
        {
            using (var db = new DataContext())
            {
                var productsOnTransactions = await db.TransactionProducts.Where(x => x.POSTransactionID == id).ToListAsync();
                var models = Mapping.Mapper.Map<List<TransactionProductModel>>(productsOnTransactions);
                return models;
            }
        }
    }
}
