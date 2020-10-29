using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface ICustomerReceivableService
    {
        Task<IList<CustomerReceivableModel>> GetCustomerReceivables(int customerID);

        Task<Dictionary<int, string>> GetCustomerNameWithReceivables();
    }
}
