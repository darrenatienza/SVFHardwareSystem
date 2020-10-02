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

        public override Task Add(ProductModel model)
        {

            ValidateModel(model);
            return base.Add(model);
        }
        private void ValidateModel(ProductModel model)
        {
            //validation ignores updating quantity, product inventory service handle this
            if (model.SupplierID == 0)
            {
                throw new RecordNotFoundException("Supplier");
            }
            if (model.CategoryID == 0)
            {
                throw new RecordNotFoundException("Category");
            }
            if (model.DealersPrice == 0)
            {
                throw new InvalidFieldException("Dealers Price");
            }
            if (model.Limit == 0)
            {
                throw new InvalidFieldException("Limit");
            }
            if (model.Price == 0)
            {
                throw new InvalidFieldException("Price");
            }

            if (model.Name == "")
            {
                throw new InvalidFieldException("Product Name");
            }
        }
        public override Task Edit(int id, ProductModel model)
        {
            ValidateModel(model);
            return base.Edit(id, model);
        }
    }
}
