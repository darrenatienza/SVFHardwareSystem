using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface ISalePaymentService : IService<SalePaymentModel>
    {
        /// <summary>
        /// Adds new record of payment for current pos transaction.
        /// Set isPaid = true of  transactions products where isToPay = true.
        /// Set isFinish = true of current pos transaction.
        /// </summary>
        /// <param name="posTransactionID"></param>
        /// <param name="change"></param>
        [Obsolete("This method has been move to PaymentService")]
        void Pay(int posTransactionID, decimal amountTendered, decimal total);
        Task<decimal> GetReceivablePaymentAmount(DateTime date);
    }
}
