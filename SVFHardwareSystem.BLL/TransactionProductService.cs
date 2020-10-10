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
    public class TransactionProductService : Service<TransactionProductModel, TransactionProduct>, ITransactionProductService
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
                        throw new LimitMustNotReachException(product.Limit);
                    }
                    product.Quantity = remainingQuantity;
                    db.Entry(product).State = EntityState.Modified;
                    transactionProduct.Price = product.Price;
                    db.TransactionProducts.Add(transactionProduct);

                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new RecordNotFoundException();
                }

            }
        }

        public void CancelProduct(int transactionProductID, string reason, bool isAddQuantity, bool isForReturnToSupplier, int quantityToCancel)
        {
            using (var db = new DataContext())
            {
                var transactionProduct = db.TransactionProducts.Find(transactionProductID);
                var product = db.Products.Find(transactionProduct.ProductID);
                // product where isCancel is true must not update the status because it was returned
                if (transactionProduct.IsCancel)
                {
                    throw new ReturnedProductMustNotUpdateStatusException();
                }
                if (quantityToCancel <= 0 || quantityToCancel > transactionProduct.Quantity)
                {
                    throw new LimitMustNotExceedOrLessException(transactionProduct.Quantity, 1);
                }
                if (reason == string.Empty)
                {
                    throw new InvalidFieldException("Reason");
                }
                //if isAddQuantity is true, add the quantity of transaction product to the current quantity of the product
                if (isAddQuantity)
                {
                    product.Quantity += quantityToCancel;
                    transactionProduct.IsQuantityAddedToInventoryAfterReplaceOrCancel = true;
                }
                // add to SupplierProductsToReturn
                if (isForReturnToSupplier)
                {
                    AddSupplierProductToReturnOnReplaceCancel(db, product.ProductID, quantityToCancel, reason);
                }

                //Notes: No need to subtract quantity on product inventory after adding it to the supplier product to return because the
                // product is purchased.
                db.Entry(product).State = EntityState.Modified;

                transactionProduct.IsForReturnToSupplierAfterCancel = isForReturnToSupplier;
                transactionProduct.IsCancel = true;
                transactionProduct.CancelReason = reason;
                transactionProduct.CancelDate = DateTime.Now;
                transactionProduct.QuantityToCancel = quantityToCancel;
                db.Entry(transactionProduct).State = EntityState.Modified;
                db.SaveChanges();

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

        public void ReplaceProduct(int transactionProductID, string reason, bool isForReturnToSupplier, int quantityToReplace)
        {
            using (var db = new DataContext())
            {



                var transactionProduct = db.TransactionProducts.Find(transactionProductID);
                var product = db.Products.Find(transactionProduct.ProductID);
                // if isReplace or iscancel is true, record must not update the status because it was replace
                if (transactionProduct.IsReplace || transactionProduct.IsCancel)
                {
                    throw new ReturnedProductMustNotUpdateStatusException();
                }
                if (reason == string.Empty)
                {
                    throw new InvalidFieldException("Reason");
                }

                // check limit of quantity to replace
                if (quantityToReplace <= 0 || quantityToReplace > transactionProduct.Quantity)
                {
                    throw new LimitMustNotExceedOrLessException(transactionProduct.Quantity, 1);
                }
                // add to SupplierProductsToReturn
                if (isForReturnToSupplier)
                {
                    AddSupplierProductToReturnOnReplaceCancel(db, product.ProductID, quantityToReplace, reason);

                }

                //product inventory quantity must subtract the quantity that will be replace because this will be given back to 
                //customer
                product.Quantity -= quantityToReplace;
                db.Entry(product).State = EntityState.Modified;

                //Mark the product as return to supplier
                transactionProduct.IsForReturnToSupplierAfterReplace = isForReturnToSupplier;
                //indicates the product is already replace
                transactionProduct.IsReplace = true;

                transactionProduct.ReplaceReason = reason;
                transactionProduct.ReplaceDate = DateTime.Now;
                transactionProduct.QuantityToReplace = quantityToReplace;
                db.Entry(transactionProduct).State = EntityState.Modified;
                db.SaveChanges();

            }
        }

        private void AddSupplierProductToReturnOnReplaceCancel(DataContext db, int productID, int quantityToCancelReplace, string reason)
        {
            var supplierProductToReturn = new SupplierProductToReturn();
            supplierProductToReturn.Code = ""; // temporary put empty string
            supplierProductToReturn.IsProductFromCancelReplace = true;
            supplierProductToReturn.ProductID = productID;
            supplierProductToReturn.Quantity = quantityToCancelReplace;
            supplierProductToReturn.Reason = reason;
            db.SupplierProductsToReturn.Add(supplierProductToReturn);
        }
    }
}
