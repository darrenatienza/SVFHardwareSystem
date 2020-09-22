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
    }
}
