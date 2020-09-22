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

        public async Task<POSTransactionModel> Get(string code)
        {
            using (var db = new DataContext())
            {
                var entity = await db.POSTransactions.FirstOrDefaultAsync(x => x.SIDR == code);
                var model = entity != null ? Mapping.Mapper.Map<POSTransactionModel>(entity) : throw new KeyNotFoundException();
                return model;
            }

        }

        public POSTransactionModel GetUnFinishedTransaction()
        {
            using (var db = new DataContext())
            {
                var entity = db.POSTransactions.FirstOrDefault(x => x.IsFinish == false);
                var model = entity != null ? Mapping.Mapper.Map<POSTransactionModel>(entity) : throw new KeyNotFoundException();
                return model;
            }
        }
    }
}
