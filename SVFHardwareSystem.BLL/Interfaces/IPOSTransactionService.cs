
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface IPOSTransactionService : IService<POSTransactionModel>
    {
        Task<POSTransactionModel> Get(string code);
        POSTransactionModel GetUnFinishedTransaction();
        void EditCustomerIDOnCurrentPOSTransaction(int posTransactionID, int customerID);
        /// <summary>
        /// Get total amount of current POS Transaction where IsToPay = true and IsPaid = false.
        /// </summary>
        /// <param name="posTransactionID"></param>
        /// <returns></returns>
        decimal GetTotalAmount(int posTransactionID);
        decimal GetReceivableAmount(int posTransactionID);
        decimal GetCashAmount(int postransactionID);
        /// <summary>
        /// Returns Total Cash Payment of a transaction where payments with receivables definition are ignores.
        /// </summary>
        /// <param name="postransactionID">Primary key id of the sales transaction</param>
        /// <returns>Total cash payment of a particular sales transaction</returns>
        decimal GetTotalCashOnlyAmount(int postransactionID);
        decimal GetTotalReceivablePayment(int posTransactionID);

        /// <summary>
        /// Adds new record of payment for current pos transaction.
        /// Set isPaid = true of  transactions products where isToPay = true.
        /// Set isFinish = true of current pos transaction.
        /// Set isFullyPaid = true of sales if the receivable = 0
        /// </summary>
        /// <param name="posTransactionID"></param>
        /// <param name="change"></param>
        void Pay(int posTransactionID, decimal amountTendered, decimal total);
        
        void CheckAndUpdateIfPosTransactionIsFullyPaid(int posTransactionID);
    }
}
