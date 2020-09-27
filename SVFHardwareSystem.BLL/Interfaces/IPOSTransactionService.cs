
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


    }
}
