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

namespace SVFHardwareSystem.Services
{
    public class POSTransactionService : IPOSTransactionService
    {
        public POSTransactionService() { }

        public async Task<int> Add(POSTransactionModel model)
        {
            using (var db = new DataContext())
            {
                var postransaction = Mapping.Mapper.Map<POSTransaction>(model);
                db.POSTransactions.Add(postransaction);
                await db.SaveChangesAsync();
                return postransaction.POSTransactionID;
            }
        }

        public async Task<int> Edit(int id, POSTransactionModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<POSTransactionModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<POSTransactionModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
