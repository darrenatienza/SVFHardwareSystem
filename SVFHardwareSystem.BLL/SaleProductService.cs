﻿using AutoMap;
using SVFHardwareSystem.DAL;
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
    public class SaleProductService : Service<SaleProductModel, SaleProduct>, ISaleProductService
    {
        public SaleProductService() { }

        public async Task AddNewTransactionProductAsync(SaleProductModel model)
        {

            using (var db = new DataContext())
            {

                var transactionProduct = Mapping.Mapper.Map<SaleProduct>(model);

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
                    db.SaleProducts.Add(transactionProduct);

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
                var transactionProduct = db.SaleProducts.Find(transactionProductID);
                // use sale id to retrive the  sale record of product
                var saleID = transactionProduct.SaleID;
                var sale = db.Sales.Find(saleID);
                //total of sale quantity
                var totalSaleProductQuantity = db.SaleProducts.Where(x => x.SaleID == saleID).Sum(x => x.Quantity);
                //total of cancel quantity
                var totalSaleProductQuantityToCancel = db.SaleProducts.Where(x => x.SaleID == saleID).Sum(x => x.QuantityToCancel);

                var product = db.Products.Find(transactionProduct.ProductID);
                // product where isCancel is true must not update the status because it was already cancelled
                if (transactionProduct.IsCancel)
                {
                    throw new ReturnedProductMustNotUpdateStatusException();
                }
                // quantity of product to cancel must not exceed to the product on sale or not less than 0
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

                totalSaleProductQuantityToCancel += quantityToCancel;
                
                // cancel the sale if the total quantity of cancel per product is equal to total quantity  purchase
                sale.IsSaleCancel = totalSaleProductQuantity == totalSaleProductQuantityToCancel ? true : false;

                db.Entry(sale).State = EntityState.Modified;
                

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
                var productOnTransaction = db.SaleProducts.Find(id);
                productOnTransaction.IsToPay = isToPay;
                db.Entry(productOnTransaction).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public async Task<IList<SaleProductModel>> GetProductsBySaleID(int id)
        {
            using (var db = new DataContext())
            {
                var productsOnTransactions = await db.SaleProducts.Where(x => x.SaleID == id).OrderByDescending(x => x.SaleProductID).ToListAsync();
                var models = Mapping.Mapper.Map<List<SaleProductModel>>(productsOnTransactions);
                return models;
            }
        }

        public async Task RemoveTransactionProductAsync(int transactionProductID)
        {
            using (var db = new DataContext())
            {
                var transactionProduct = db.SaleProducts.Find(transactionProductID);
                var product = db.Products.Find(transactionProduct.ProductID);

                var addedQuantity = product.Quantity + transactionProduct.Quantity;
                product.Quantity = addedQuantity;
                db.Entry(product).State = EntityState.Modified;
                db.SaleProducts.Remove(transactionProduct);
                await db.SaveChangesAsync();
            }
        }

        public void ReplaceProduct(int transactionProductID, string reason, bool isForReturnToSupplier, int quantityToReplace)
        {
            using (var db = new DataContext())
            {



                var transactionProduct = db.SaleProducts.Find(transactionProductID);
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

        private void AddSupplierProductToReturnOnReplaceCancel(IDataContext db, int productID, int quantityToCancelReplace, string reason)
        {
            var supplierProductToReturn = new WarrantyProduct();
            supplierProductToReturn.Code = ""; // temporary put empty string
            supplierProductToReturn.IsProductFromCancelReplace = true;
            supplierProductToReturn.ProductID = productID;
            supplierProductToReturn.Quantity = quantityToCancelReplace;
            supplierProductToReturn.Reason = reason;
            db.WarrantyProducts.Add(supplierProductToReturn);
        }
    }
}