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
            try
            {
                using (var db = new DataContext())
                {
                    var customer = Mapping.Mapper.Map<Customer>(obj);
                    db.Customers.Add(customer);
                    await db.SaveChangesAsync();
                    return customer.CustomerID;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        public int Edit(int id, CustomerModel obj)
        {
            throw new NotImplementedException();
        }

        public CustomerModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<CustomerModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
