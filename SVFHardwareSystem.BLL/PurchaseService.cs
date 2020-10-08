using AutoMap;
using AutoMapper;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public async Task AddPurchaseProductAsync(int purchaseID, PurchaseProductModel model)
        {
            using (var db = new DataContext())
            {
                ValidatePurchaseProduct(model.ProductID, model.Quantity);
                var existProductOnPurchase = db.PurchaseProducts.FirstOrDefault(x => x.ProductID == model.ProductID && x.PurchaseID == purchaseID);
                if (existProductOnPurchase != null)
                {
                    //no duplicate products for every purchases
                    throw new RecordAlreadyExistsException(string.Format("Product {0}", existProductOnPurchase.Product.Name));
                }
                if (model.IsQuantityUploaded)
                {
                    // add the quantity to current product quantity if isquantityuploaded is true
                    var product = db.Products.Find(model.ProductID);
                    product.Quantity += model.Quantity;
                    db.Entry(product).State = EntityState.Modified;
                }
                var purchaseProduct = Mapping.Mapper.Map<PurchaseProduct>(model);
                purchaseProduct.PurchaseID = purchaseID;
                db.PurchaseProducts.Add(purchaseProduct);
                await db.SaveChangesAsync();

            }
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

        public async Task EditPurchaseProduct(PurchaseProductModel model)
        {
            using (var db = new DataContext())
            {


                ValidatePurchaseProduct(model.ProductID, model.Quantity);
                
                var purchaseProduct = db.PurchaseProducts.Find(model.PurchaseProductID);
                if (purchaseProduct.IsQuantityUploaded)
                {
                    //purchases where uploaded quantity is true must not available for edit
                    throw new EditNotPermittedException();
                }
                var newPurchaseProduct = Mapping.Mapper.Map(model, purchaseProduct);
                db.Entry(newPurchaseProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();

            }
        }

        private void ValidatePurchaseProduct(int productID, int quantity)
        {
            if (productID == 0)
            {
                throw new InvalidFieldException("Product");
            }
            if (quantity == 0)
            {
                throw new InvalidFieldException("Quantity");
            }
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

        public async Task<IList<PurchaseProductModel>> GetPurchaseProducts(int purchaseID)
        {
            using (var db = new DataContext())
            {
                var objs = await db.PurchaseProducts.Where(x => x.PurchaseID == purchaseID).ToListAsync();
                var models = Mapping.Mapper.Map<List<PurchaseProductModel>>(objs);
                return models;
            }
        }

        public async Task<PurchaseProductModel> GetPurchaseProduct(int purchaseID, int productID)
        {
            using (var db = new DataContext())
            {
                var obj =  await db.PurchaseProducts.FirstOrDefaultAsync(x => x.PurchaseID == purchaseID && x.ProductID == productID);
                var model = Mapping.Mapper.Map<PurchaseProductModel>(obj);
                return model;
            }
        }
    }
}
