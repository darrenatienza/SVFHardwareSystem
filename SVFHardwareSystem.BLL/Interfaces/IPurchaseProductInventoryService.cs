using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface IPurchaseProductInventoryService
    {
        Task<IList<PurchaseProductInventoryModel>> GetPurchaseProductInventories(int year, int month);

        Task<IList<PurchaseProductInventoryModel>> GetPurchaseProductInventories(int year);
        Task<decimal> GetPurchaseProductYearlyFinalTotalAmount(int year);
        Task<decimal> GetPurchaseProductTotal(int year, int month);
        Task<decimal> GetPurchaseProductTotal(int year);
    }
}
