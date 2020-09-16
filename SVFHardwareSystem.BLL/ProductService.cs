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
    public class ProductService : IProductService
    {

        public ProductService()
        {
           
        }
        public async Task<int> Add(ProductModel obj)
        {
            using (var db = new DataContext())
            {
                var product = Mapping.Mapper.Map<Product>(obj);
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return product.ProductID;
            }

        }

       

        public int Edit(int id, ProductModel obj)
        {
            throw new NotImplementedException();
        }

        public ProductModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProductModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
