using AutoMap;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    public class CustomerService : Service<CustomerModel,Customer>, ICustomerService
    {
       

        public async Task<IList<CustomerModel>> GetAll(string criteria)
        {
            using (var db = new DataContext())
            {
                List<Customer> objs = await db.Customers.Where(x => x.FullName.Contains(criteria)).ToListAsync();
                var models = Mapping.Mapper.Map<List<CustomerModel>>(objs);
                return models;
            }
        }
    }
}
