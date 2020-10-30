using AutoMap;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Exceptions;
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

        public int GetCustomerID(string customerName)
        {
            using (var db = new DataContext())
            {
                var customer = db.Customers.FirstOrDefault(x => x.FullName == customerName);
                return customer == null ? throw new RecordNotFoundException() : customer.CustomerID;
            }
        }

        public async Task<Dictionary<int, string>> GetCustomerNamesAsync(string criteria)
        {
            using (var db = new DataContext())
            {
                var names = await db.Customers.Where(x => x.FullName.Contains(criteria)).Select(x => new { x.CustomerID, x.FullName }).ToListAsync();
                var dictionaries = new Dictionary<int, string>();
                foreach (var item in names)
                {
                    dictionaries.Add(item.CustomerID, item.FullName);
                }
                return dictionaries;
            }
        }
    }
}
