using AutoMap;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Exceptions;
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
    public class PurchaseService : Service<PurchaseModel, Purchase>, IPurchaseService
    {
        public override async Task AddAsync(PurchaseModel model)
        {

            if (model.SupplierID == 0)
            {
                throw new InvalidFieldException("Supplier");
            }
            using (var db = new DataContext())
            {
                var purchase = db.Purchases.FirstOrDefault(x => DbFunctions.TruncateTime(x.DatePurchase) == DbFunctions.TruncateTime(model.DatePurchase) && x.SupplierID == model.SupplierID);
                if (purchase != null)
                {
                    var identifier = string.Format("the date of {0}", model.DatePurchase.ToShortDateString());
                    throw new RecordAlreadyExistsException(identifier);
                }
            }
            await base.AddAsync(model);
        }

        public override Task EditAsync(int id, PurchaseModel model)
        {
            if (model.PurchaseID == 0)
            {
                throw new InvalidFieldException("Purchase");
            }
            if (model.SupplierID == 0)
            {
                throw new InvalidFieldException("Supplier");
            }
            return base.EditAsync(id, model);
        }


        public async Task<IList<PurchaseModel>> GetAllAsync(int supplierID)
        {
            using (var db = new DataContext())
            {
                var objs = await db.Purchases.Where(x => x.Supplier.SupplierID == supplierID).ToListAsync();
                var models = Mapping.Mapper.Map<List<PurchaseModel>>(objs);
                return models;
            }
        }
    }
}
