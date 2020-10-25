using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface ISaleProductInventoryService
    {
        Task<IList<SaleProductInventoryModel>> GetSaleProductInventories(int year, int month);
        Task<decimal> GetSaleProductTotalAmount(int year);
        Task<decimal> GetSaleProductTotalAmount(int month, int year);
        Task<IList<SaleProductInventoryModel>> GetSaleProductInventories(int year);
        Task<IList<SaleProductInventoryModel>> GetSaleProductInventories(int year, int month, int day);
        Task<decimal>  GetSaleProductTotalAmount(int year, int month, int day);
    }
}
