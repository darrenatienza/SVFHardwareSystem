using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    public interface IPurchaseSaleInventoryService
    {
        IList<PurchaseSaleInventoryProductModel> GetYearlyInventory(int year);
        /// <summary>
        /// Saves new Purchase and Sale Inventory
        /// </summary>
        /// <param name="year">Year of the inventory to save</param>
        void Save(int year);
    }
}
