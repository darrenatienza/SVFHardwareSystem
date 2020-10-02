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
    public class ProductService : Service<ProductModel, Product>, IProductService
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
                    throw new LimitMustNotReachException(product.Limit);
                }
                product.Quantity = remainingQuantity;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IList<ProductModel> GetAll(string category, string criteria)
        {
            using (var db = new DataContext())
            {
                var products = db.Products.Where(x => x.Category.Name.Contains(category) && x.Name.Contains(criteria)).ToList();
                var models = Mapping.Mapper.Map<IList<ProductModel>>(products);
                return models;

            }
        }

        public ProductModel GetByProductName(string productName)
        {
            using (var db = new DataContext())
            {
                var product = db.Products.FirstOrDefault(x => x.Name == productName);
                var model = product != null ? Mapping.Mapper.Map<ProductModel>(product) : throw new RecordNotFoundException();
                return model;
            }
        }

        public int GetProductID(string productName)
        {
            using (var db = new DataContext())
            {
                var product = db.Products.FirstOrDefault(x => x.Name == productName);
                return product == null ? throw new RecordNotFoundException() : product.ProductID;
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
                    throw new LimitMustNotReachException(product.Limit);
                }
                return product == null ? 0 : remainingQuantity;
            }
        }

        public override  Task Add(ProductModel model)
        {
            
            using (var db = new DataContext())
            {
                var supplier = db.Suppliers.FirstOrDefault(x => x.Name == model.SupplierName);
                var category = db.Categories.FirstOrDefault(x => x.Name == model.CategoryName);
                model.SupplierID = supplier == null ? throw new RecordNotFoundException("Supplier") :  supplier.SupplierID;
                model.CategoryID = category == null ? throw new RecordNotFoundException("Category") : category.CategoryID;
            }

            
            return  base.Add(model);
        }
    }
}
