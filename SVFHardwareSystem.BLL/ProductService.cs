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
    public class ProductService : Service<ProductModel,Product>, IProductService
    {

        public ProductService()
        {
           
        }

        public void DeductQuantityOnProduct(int productID, int quantityToBuy)
        {
            using (var db = new DataContext())
            {
                var product = db.Products.Find(productID);
                var remainingQuantity = product.Quantity - quantityToBuy;
                if (remainingQuantity < product.Limit)
                {
                    throw new LimitMustNoReachException(product.Limit);
                }
                product.Quantity = remainingQuantity;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public ProductModel GetByProductName(string productName)
        {
            using (var db = new DataContext())
            {
                var product = db.Products.FirstOrDefault(x => x.Name == productName);
                var model = product != null ? Mapping.Mapper.Map<ProductModel>(product) : throw new KeyNotFoundException();
                return model;
            }
        }

        public int GetProductID(string productName)
        {
            using (var db = new DataContext())
            {
                var product = db.Products.FirstOrDefault(x => x.Name == productName);
                return product == null ? 0 : product.ProductID;
            }
        }

        public int GetQuantityByProductName(string productName)
        {
            using (var db = new DataContext())
            {
                var product = db.Products.FirstOrDefault(x => x.Name == productName);
                return product == null ? 0 : product.Quantity;
            }
        }

        public int GetRemainingQuantity(int productID, int quantityToBuy)
        {
            using (var db = new DataContext())
            {
                var product = db.Products.Find(productID);
                var remainingQuantity = product.Quantity - quantityToBuy;
                if (remainingQuantity < product.Limit)
                {
                    throw new LimitMustNoReachException(product.Limit);
                }
                return product == null ? 0 : remainingQuantity;
            }
        }
    }
}
