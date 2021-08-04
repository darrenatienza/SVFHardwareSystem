
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface ISaleService : IService<SaleModel>
    {
        Task<SaleModel> Get(string code);
        SaleModel GetUnFinishedTransaction();
        void EditCustomerIDOnCurrentSale(int posTransactionID, int customerID);
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
        /// Adds new payment for sale
        /// </summary>
        /// <param name="saleID">ID of the sale</param>
        /// <param name="amountTendered">Amount paid by customer</param>
        /// <param name="paymentDate">Date when Payment is done</param>
        void Pay(int saleID, decimal amountTendered, DateTime paymentDate);
        
        void CheckAndUpdateIfSaleIsFullyPaid(int posTransactionID);
        void RemoveTransaction(int saleID);
        bool HasProductOnSale(int purchaseProductID);
        
    }
}
