using AutoMap;
using SVFHardwareSystem.DAL;
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
    public class PurchaseProductInventoryService : IPurchaseProductInventoryService
    {
        public async Task<IList<PurchaseProductInventoryModel>> GetPurchaseProductInventories(int year, int month)
        {
            using (var db = new DataContext())
            {
                year = year == 0 ? throw new InvalidFieldException("Year") : year;
                month = month == 0 ? throw new InvalidFieldException("Month") : month;

                //query the product 
                var products = await GetProducts(db, year, month);

                var models = new List<PurchaseProductInventoryModel>();

                // set values to the purchase products
                foreach (var product in products)
                {
                    // map equal properties
                    var model = Mapping.Mapper.Map<PurchaseProductInventoryModel>(product);

                    // query using year month and product id
                    var purchaseProducts = await GetPurchaseProducts(db,year, month,product.ProductID);

                    //set values
                    model.Quantity = purchaseProducts.Sum(x => x.Quantity);
                    model.TotalAmount = purchaseProducts.Sum(x => x.Quantity * x.Price);
                    //fill property
                    foreach (var item in purchaseProducts)
                    {
                        model.SIDR += string.Format("[{0}]", item.Purchase.SIDR);
                    }
                    foreach (var  item in purchaseProducts)
                    {
                        model.Date += string.Format("[{0}]", item.Purchase.DatePurchase.ToShortDateString());
                    }
                 
                    // add to model purchase products
                    models.Add(model);
                }

                return models;

            }


        }

       

        public async Task<IList<PurchaseProductInventoryModel>> GetPurchaseProductInventories(int year)
        {
            using (var db = new DataContext())
            {
                year = year == 0 ? throw new InvalidFieldException("Year") : year;
                //query the product 
                var products = await GetProducts(db, year);


                var models = new List<PurchaseProductInventoryModel>();
                // set values to the purchase products
                foreach (var product in products)
                {

                    // map equal properties
                    var model = Mapping.Mapper.Map<PurchaseProductInventoryModel>(product);
                    // query product purchase using year month and product id
                    var purchaseProducts = await GetPurchaseProducts(db, year, product.ProductID);
                    //set values
                    model.Quantity = purchaseProducts.Sum(x => x.Quantity);
                    model.TotalAmount = purchaseProducts.Sum(x => x.Quantity * x.Price);
                    //fill property
                    foreach (var item in purchaseProducts)
                    {
                        model.SIDR += string.Format("[{0}]", item.Purchase.SIDR);
                    }
                    foreach (var item in purchaseProducts)
                    {
                        model.Date += string.Format("[{0}]", item.Purchase.DatePurchase.ToShortDateString());
                    }
                    // add to model purchase products
                    models.Add(model);
                }

                return models;
            }
        }

        

        public async Task<decimal> GetPurchaseProductYearlyFinalTotalAmount(int year)
        {
            using (var db = new DataContext())
            {
                year = year == 0 ? throw new InvalidFieldException("Year") : year;
                // query product purchase using year
                var purchaseProducts = await db.PurchaseProducts
                    .Where(x =>
                        x.Purchase.DatePurchase.Year == year
                      ).Select(x => new { x.Quantity, x.Price }).ToListAsync();
                return purchaseProducts.Sum(x => x.Quantity * x.Price);
            }

        }
        private async Task<IList<Product>> GetProducts(IDataContext db, int year, int month)
        {
            return await db.Products
                    .Where(x => x.PurchaseProducts
                    .Where(y => y.Purchase.DatePurchase.Year == year && y.Purchase.DatePurchase.Month == month)
                    .Count() > 0).ToListAsync();
        }

        private async Task<IList<PurchaseProduct>> GetPurchaseProducts(IDataContext db, int year, int month, int productID)
        {
            return await db.PurchaseProducts
                         .Where(x =>
                             x.Purchase.DatePurchase.Year == year
                             && x.Purchase.DatePurchase.Month == month
                             && x.ProductID == productID).ToListAsync();
        }

        public async Task<decimal> GetPurchaseProductTotal(int year, int month)
        {
            using (var db = new DataContext())
            {
                year = year == 0 ? throw new InvalidFieldException("Year") : year;
                month = month == 0 ? throw new InvalidFieldException("Month") : month;

                // query using year
                // just select quantity and price
                var saleProducts = await db.PurchaseProducts
                    .Where(x =>
                        x.Purchase.DatePurchase.Year == year && x.Purchase.DatePurchase.Month == month 
                      ).Select(x => new { x.Quantity, x.Price }).ToListAsync();
                return saleProducts.Sum(x => x.Quantity * x.Price);
            }
        }
        public async Task<decimal> GetPurchaseProductTotal(int year)
        {
            using (var db = new DataContext())
            {
                year = year == 0 ? throw new InvalidFieldException("Year") : year;

                // query using year
                // just select quantity and price
                var saleProducts = await db.PurchaseProducts
                    .Where(x =>
                        x.Purchase.DatePurchase.Year == year
                      ).Select(x => new { x.Quantity, x.Price }).ToListAsync();
                return saleProducts.Sum(x => x.Quantity * x.Price);
            }
        }
        private async Task<IList<PurchaseProduct>> GetPurchaseProducts(IDataContext db, int year, int productID)
        {
            return await db.PurchaseProducts
                         .Where(x =>
                             x.Purchase.DatePurchase.Year == year
                             && x.ProductID == productID).ToListAsync();
        }

        private async Task<IList<Product>> GetProducts(IDataContext db, int year)
        {
            return await db.Products
                    .Where(x => x.PurchaseProducts
                    .Where(y => y.Purchase.DatePurchase.Year == year)

                    .Count() > 0).ToListAsync();
        }
        
    }
}
