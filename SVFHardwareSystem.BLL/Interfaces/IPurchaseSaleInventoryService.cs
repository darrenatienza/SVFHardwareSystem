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
        IList<PurchaseSaleInventoryModel> GetYearlyInventory(int year);

        void Save(int year);
    }
}
