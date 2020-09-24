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
    public class TransactionProductService : Service<TransactionProductModel,TransactionProduct>, ITransactionProductService
    {
        public TransactionProductService() { }

        public async Task AddNewTransactionProductAsync(TransactionProductModel model)
        {

            using (var db = new DataContext())
            {

                var transactionProduct = Mapping.Mapper.Map<TransactionProduct>(model);

                var product = db.Products.Find(model.ProductID);
                if (product != null)
                {
                    // ramaining quantity must not less than or equal to limit.
                    var remainingQuantity = product.Quantity - model.Quantity;
                    if (remainingQuantity <= product.Limit)
                    {
                        throw new LimitMustNoReachException(product.Limit);
                    }
                    product.Quantity = remainingQuantity;
                    db.Entry(product).State = EntityState.Modified;

                    db.TransactionProducts.Add(transactionProduct);

                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new RecordNotFoundException();
                }
                
            }
        }

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

        public async Task RemoveTransactionProductAsync(int transactionProductID)
        {
            using (var db = new DataContext())
            {
                var transactionProduct = db.TransactionProducts.Find(transactionProductID);
                var product = db.Products.Find(transactionProduct.ProductID);

                var addedQuantity = product.Quantity + transactionProduct.Quantity;
                product.Quantity = addedQuantity;
                db.Entry(product).State = EntityState.Modified;
                db.TransactionProducts.Remove(transactionProduct);
                await db.SaveChangesAsync();
            }
        }
    }
}
