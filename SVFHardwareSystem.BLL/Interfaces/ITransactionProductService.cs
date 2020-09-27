using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface ITransactionProductService : IService<TransactionProductModel>
    {
        Task<IList<TransactionProductModel>> GetProductsByTransactionID(int id);
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
        Task AddNewTransactionProductAsync(TransactionProductModel transactionProduct);
        void ReplaceProduct(int transactionProductID, string reason);
        void CancelProduct(int transactionProductID, string reason, bool isAddQuantity);
    }
}
