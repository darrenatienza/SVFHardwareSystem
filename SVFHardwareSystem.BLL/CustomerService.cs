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
    public class CustomerService : ICustomerService
    {
        public async Task<int> Add(CustomerModel model)
        {
            using (var db = new DataContext())
            {
                var customer = Mapping.Mapper.Map<Customer>(model);
                db.Customers.Add(customer);
                await db.SaveChangesAsync();
                return customer.CustomerID;
            }
        }

        public async Task<int> Edit(int id, CustomerModel model)
        {
            using (var db = new DataContext())
            {
                var entity = db.Customers.Find(id);
                // mapping on existing entity from model
                var customer = Mapping.Mapper.Map(model, entity);
                db.Entry(customer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return customer.CustomerID;
            }
        }

        public async Task<CustomerModel> Get(int id)
        {
            using (var db = new DataContext())
            {
                var obj = db.Customers.Find(id);
                var model = obj != null ? Mapping.Mapper.Map<CustomerModel>(obj) : throw new KeyNotFoundException();
                return model;
            }
        }

        public async Task<IList<CustomerModel>> GetAll()
        {
            using (var db = new DataContext())
            {
                List<Customer> objs = await db.Customers.ToListAsync();
                var models = Mapping.Mapper.Map<List<CustomerModel>>(objs);
                return models;
            }
        }

        public async Task<IList<CustomerModel>> GetAll(string criteria)
        {
            using (var db = new DataContext())
            {
                List<Customer> objs = await db.Customers.Where(x => x.FullName.Contains(criteria)).ToListAsync();
                var models = Mapping.Mapper.Map<List<CustomerModel>>(objs);
                return models;
            }
        }

        public async Task Remove(int id)
        {
            using (var db = new DataContext())
            {
                var entity = db.Customers.Find(id);
                db.Customers.Remove(entity);
                await db.SaveChangesAsync();
            }
        }
    }
}
