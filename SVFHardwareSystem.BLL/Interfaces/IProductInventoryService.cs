using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface IProductInventoryService
    {
        Task<IList<ProductInventoryModel>> GetBeginningInventories(int year);
        Task<IList<ProductInventoryModel>> GetPurchaseInventories(int year);

        Task<IList<ProductInventoryModel>> GetSaleInventories(int year);
        Task<IList<ProductInventoryModel>> GetEndingInventories(int year);
    }
}
