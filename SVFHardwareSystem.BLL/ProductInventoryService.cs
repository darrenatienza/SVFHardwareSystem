using AutoMap;
using SVFHardwareSystem.DAL;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    public class ProductInventoryService : IProductInventoryService
    {
        public async Task<IList<ProductInventoryModel>> GetBeginningInventories(int year)
        {
            using (var db = new DataContext())
            {
                var products = await GetProductsExistsOnProductInventoryPurchasesAndSales(db, year);
                var models = new List<ProductInventoryModel>();
                foreach (var product in products)
                {
                    // get last product as beginning
                    var productOnInventory = db.ProductInventories.LastOrDefault(x => x.ProductID == product.ProductID);
                    // map similar properties
                    var model = Mapping.Mapper.Map<ProductInventoryModel>(productOnInventory);
                    models.Add(model);
                }
                return models;
            }
        }

        public async Task<IList<ProductInventoryModel>> GetEndingInventories(int year)
        {
            using (var db = new DataContext())
            {
                var products = await GetProductsExistsOnProductInventoryPurchasesAndSales(db, year);
                var models = new List<ProductInventoryModel>();
                foreach (var product in products)
                {
                    // map similar properties
                    var model = Mapping.Mapper.Map<ProductInventoryModel>(product);

                    // get last product as beginning
                    var productOnInventory = db.ProductInventories.LastOrDefault(x => x.ProductID == product.ProductID);

                    // get purchase product for the year
                    var productOnPurchase = (await GetPurchaseInventories(db, year)).FirstOrDefault(x => x.ProductID == product.ProductID);

                    // get sale product for the year
                    var productOnSale = (await GetSaleInventories(db, year)).FirstOrDefault(x => x.ProductID == product.ProductID);
                    
                    //compute total quantity (ending quantity)
                    model.Quantity = (productOnInventory.Quantity + productOnPurchase.Quantity) - productOnSale.Quantity;
                    
                    //compute total amount (ending amount)
                    model.TotalAmount = (productOnInventory.TotalAmount + productOnPurchase.TotalAmount) - productOnSale.TotalAmount;
                    
                    models.Add(model);
                }
                return models;
            }
        }

        public async Task<IList<ProductInventoryModel>> GetPurchaseInventories(int year)
        {
            using (var db= new DataContext())
            {
                return await GetPurchaseInventories(db, year);
            }
        }

        public async Task<IList<ProductInventoryModel>> GetSaleInventories(int year)
        {
            using (var db = new DataContext())
            {
                return await GetSaleInventories(db, year);
            }
        }

        /// <summary>
        /// Get Products with selected year purchases and has product inventory record
        /// </summary>
        /// <param name="db">DataContext</param>
        /// <param name="year">Select Year</param>
        /// <returns>List of Products</returns>
        private async Task<IList<Product>> GetProductsExistsOnProductInventoryPurchasesAndSales(IDataContext db, int year)
        {
            return await db.Products
                    .Where(x => x.PurchaseProducts.Where(y => y.Purchase.DatePurchase.Year == year).Count() > 0 
                    || x.SaleProducts.Where( y => y.Sale.SaleDate.Year == year).Count() > 0
                    || x.ProductInventories.Where(z => z.ProductID == x.ProductID).Count() > 0)
                    .Select(z => new Product { Name = z.Name, Unit = z.Unit, ProductID = z.ProductID }).ToListAsync();
        }
        public async Task<IList<ProductInventoryModel>> GetBeginningInventories(IDataContext db, int year)
        {

            var products = await GetProductsExistsOnProductInventoryPurchasesAndSales(db, year);
            var models = new List<ProductInventoryModel>();
            foreach (var product in products)
            {
                // get last product as beginning
                var productOnInventory = db.ProductInventories.LastOrDefault(x => x.ProductID == product.ProductID);
                // map similar properties
                var model = Mapping.Mapper.Map<ProductInventoryModel>(productOnInventory);
                models.Add(model);
            }
            return models;

        }
        public async Task<IList<ProductInventoryModel>> GetPurchaseInventories(IDataContext db, int year)
        {

            var products = await GetProductsExistsOnProductInventoryPurchasesAndSales(db, year);
            var models = new List<ProductInventoryModel>();
            foreach (var product in products)
            {
                // map similar properties
                var model = Mapping.Mapper.Map<ProductInventoryModel>(product);
                // get last product as beginning
                var productOnPurchases = await db.PurchaseProducts.Where(x => x.ProductID == product.ProductID).ToListAsync();
                // set computed properties
                model.Quantity = productOnPurchases.Sum(x => x.Quantity);
                model.TotalAmount = productOnPurchases.Sum(x => x.Price * x.Quantity);
                model.Year = year;
                models.Add(model);
            }
            return models;

        }
        public async Task<IList<ProductInventoryModel>> GetSaleInventories(IDataContext db, int year)
        {

            var products = await GetProductsExistsOnProductInventoryPurchasesAndSales(db, year);
            var models = new List<ProductInventoryModel>();
            foreach (var product in products)
            {
                // map similar properties
                var model = Mapping.Mapper.Map<ProductInventoryModel>(product);
                // get last product as beginning
                var productOnSales = await db.SaleProducts.Where(x => x.ProductID == product.ProductID).ToListAsync();
                // set computed properties
                model.Quantity = productOnSales.Sum(x => x.Quantity);
                model.TotalAmount = productOnSales.Sum(x => x.Price * (x.Quantity - x.QuantityToCancel));
                model.Year = year;
                models.Add(model);
            }
            return models;

        }

    }
}
