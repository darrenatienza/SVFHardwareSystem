﻿using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface ICustomerService : IService<CustomerModel>
    {
        Task<IList<CustomerModel>> GetAll(string criteria);
        int GetCustomerID(string customerName);
        Task<Dictionary<int, string>> GetCustomerNamesAsync(string criteria);
    }
}
