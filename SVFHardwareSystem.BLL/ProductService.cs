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

        public void DeductQuantityOnProduct(int productID, decimal quantityToBuy)
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
                var products = db.Products
                    .Where(x => x.Category.Name.Contains(category) && x.Name.Contains(criteria))
                    .OrderBy(x => x.Category.Name)
                    .ThenBy(x => x.Name)
                    .ToList();
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

        public decimal GetQuantityByProductName(string productName)
        {
            using (var db = new DataContext())
            {
                var product = db.Products.FirstOrDefault(x => x.Name == productName);
                return product == null ? 0 : product.Quantity;
            }
        }

        public decimal GetRemainingQuantity(int productID, decimal quantityToBuy)
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

        public override Task AddAsync(ProductModel model)
        {

            ValidateModel(model);

            return base.AddAsync(model);
        }
        private void ValidateModel(ProductModel model)
        {
            //validation ignores updating quantity, product inventory service handle this
            //if (model.SupplierID == 0)
            //{
            //    throw new RecordNotFoundException("Supplier");
            //}
            if (model.CategoryID == 0)
            {
                throw new RecordNotFoundException("Category");
            }
            //if (model.DealersPrice == 0)
            //{
            //    throw new InvalidFieldException("Dealers Price");
            //}
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
        public override Task EditAsync(int id, ProductModel model)
        {
            ValidateModel(model);
            return base.EditAsync(id, model);
        }

        public async Task<IList<ProductModel>> GetAllByCategoryID(int categoryID)
        {
            using (var db = new DataContext())
            {
                var products = await db.Products.Where(x => x.CategoryID == categoryID).OrderBy(x => x.Name).ToListAsync();
                var models = Mapping.Mapper.Map<IList<ProductModel>>(products);
                return models;
            }
        }

        public async Task<Dictionary<int,string>> GetProductNamesAsync(string criteria)
        {
            using (var db = new DataContext())
            {
                var names = await db.Products.Where(x => x.Name.Contains(criteria)).Select(x => new { x.ProductID, x.Name }).ToListAsync();
                var dictionaries = new Dictionary<int, string>();
                foreach (var item in names)
                {
                    dictionaries.Add(item.ProductID, item.Name);
                }
                return dictionaries;
            }
        }

        public ProductModel GetProduct(int productID)
        {
            
            using (var db = new DataContext())
            {
                var entity = db.Products.Find(productID);
                var model = Mapping.Mapper.Map<ProductModel>(entity) ?? throw new RecordNotFoundException();
                //get the last purchase price from supplier of particular product
                var purchases = db.PurchaseProducts.Where(x => x.ProductID == productID);
                var lastPurchase = purchases.OrderByDescending(x => x.PurchaseProductID).FirstOrDefault();
                if (lastPurchase != null)
                {
                    model.PreviousPurchasePrice = lastPurchase.Price;
                }
                
                return model;

            }
        }
    }
}
