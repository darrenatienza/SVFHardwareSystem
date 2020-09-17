using AutoMap;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    public class CustomerService : ICustomerService
    {
        public async Task<int> Add(CustomerModel obj)
        {
           
                using (var db = new DataContext())
                {
                    var customer = Mapping.Mapper.Map<Customer>(obj);
                    db.Customers.Add(customer);
                    await db.SaveChangesAsync();
                    return customer.CustomerID;
                }
           
            
        }

        public async Task<int> Edit(int id, CustomerModel obj)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CustomerModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
