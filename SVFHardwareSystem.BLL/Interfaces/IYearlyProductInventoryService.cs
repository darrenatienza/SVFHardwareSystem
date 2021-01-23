using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface IYearlyProductInventoryService : IService<YearlyProductInventoryModel>
    {
        /// <summary>
        /// Get the Yearly Product Inventory
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        Task<IList<YearlyProductInventoryModel>> GetBeginningYearlyProductInventories(int year);
        /// <summary>
        /// Ending yearly inventory is the current product table contents
        /// </summary>
        /// <returns></returns>
        Task<IList<YearlyProductInventoryModel>> GetEndingYearlyProductInventories();

        /// <summary>
        /// Ending yearly inventory is the current product table contents
        /// </summary>
        /// <returns></returns>
        Task SaveYearlyProductInventory();
    }
}
