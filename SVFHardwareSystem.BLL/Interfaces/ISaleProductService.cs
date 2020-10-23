﻿using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface ISaleProductService : IService<SaleProductModel>
    {
        Task<IList<SaleProductModel>> GetProductsBySaleID(int saleID);
        /// <summary>
        /// Edit the IsToPay Column of the transaction products
        /// </summary>
        /// <param name="id">The Product on Transaction ID</param>
        /// <param name="isToPay">The value of isToPay</param>
        void EditIsToPay(int id, bool isToPay);
        /// <summary>
        /// Remove the product on TransactionProducts then add the quantity of transaction product to product of removed
        /// </summary>
        /// <param name="transactionProductID"></param>
        /// <returns></returns>
        Task RemoveTransactionProductAsync(int transactionProductID);
        /// <summary>
        /// Add new Product on transaction then deduct the quantity purchase on product table quantity column
        /// </summary>
        /// <param name="transactionProduct"></param>
        /// <returns></returns>
        Task AddNewTransactionProductAsync(SaleProductModel transactionProduct);
        /// <summary>
        /// Replace product
        /// </summary>
        /// <param name="transactionProductID">Transaction Product ID of record</param>
        /// <param name="reason">Reason for Replacement</param>
        /// <param name="isForReturnToSupplier">Is the purchase product needs to return to supplier</param>
        /// <param name="quantityToReplace">Number of product that will be replace</param>
        void ReplaceProduct(int transactionProductID, string reason, bool isForReturnToSupplier, int quantityToReplace);
        void CancelProduct(int transactionProductID, string reason, bool isAddQuantity, bool isForReturnToSupplier, int quantityToCancel);
    }
}