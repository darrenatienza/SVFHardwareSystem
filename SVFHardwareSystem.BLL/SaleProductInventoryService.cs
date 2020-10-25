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
    public class SaleProductInventoryService : ISaleProductInventoryService
    {
        public async Task<IList<SaleProductInventoryModel>> GetSaleProductInventories(int year, int month)
        {
            using (var db = new DataContext())
            {
                year = year == 0 ? throw new InvalidFieldException("Year") : year;
                month = month == 0 ? throw new InvalidFieldException("Month") : month;

                //query the product 
                var products = await GetProducts(db,year, month);


                var models = new List<SaleProductInventoryModel>();

                foreach (var product in products)
                {
                    // map equal properties
                    var model = Mapping.Mapper.Map<SaleProductInventoryModel>(product);

                    // query using year month and product id
                    var saleProducts = await GetSaleProducts(db, year, month,product.ProductID);
                    //set values
                    model.Quantity = saleProducts.Sum(x => x.Quantity);
                    model.TotalAmount = saleProducts.Sum(x => x.Quantity * x.Price);
                    
                    // add to models
                    models.Add(model);
                }

                return models;

            }
        }

        public async Task<IList<SaleProductInventoryModel>> GetSaleProductInventories(int year)
        {
            using (var db = new DataContext())
            {
                year = year == 0 ? throw new InvalidFieldException("Year") : year;
               

                //query the product 
                var products = await GetProducts(db, year);


                var models = new List<SaleProductInventoryModel>();

                foreach (var product in products)
                {
                    // map equal properties
                    var model = Mapping.Mapper.Map<SaleProductInventoryModel>(product);

                    // query using year month and product id
                    var saleProducts = await GetSaleProducts(db, year, product.ProductID);
                    //set values
                    model.Quantity = saleProducts.Sum(x => x.Quantity);
                    model.TotalAmount = saleProducts.Sum(x => x.Quantity * x.Price);

                    // add to models
                    models.Add(model);
                }

                return models;

            }
        }

        public async Task<decimal> GetSaleProductTotalAmount(int year)
        {
           
                using (var db = new DataContext())
                {
                    year = year == 0 ? throw new InvalidFieldException("Year") : year;
                    // query using year
                    var saleProducts = await db.SaleProducts
                        .Where(x =>
                            x.Sale.SaleDate.Year == year
                          ).Select(x => new { x.Quantity, x.Price }).ToListAsync();
                    return saleProducts.Sum(x => x.Quantity * x.Price);
                }
            
        }

        public async Task<decimal> GetSaleProductTotalAmount(int month, int year)
        {
            using (var db = new DataContext())
            {
                year = year == 0 ? throw new InvalidFieldException("Year") : year;
                month =     month== 0 ? throw new InvalidFieldException("Month") : month;
                // query using year
                // just select quantity and price
                var saleProducts = await db.SaleProducts
                    .Where(x =>
                        x.Sale.SaleDate.Year == year && x.Sale.SaleDate.Month == month
                      ).Select(x => new { x.Quantity, x.Price }).ToListAsync();
                return saleProducts.Sum(x => x.Quantity * x.Price);
            }
        }

        public async Task<IList<SaleProductInventoryModel>> GetSaleProductInventories(int year, int month, int day)
        {
            using (var db = new DataContext())
            {
                year = year == 0 ? throw new InvalidFieldException("Year") : year;
               month = month == 0 ? throw new InvalidFieldException("Month") : month;
                day= day == 0 ? throw new InvalidFieldException("Day") : day;
                //query the product 
                var products = await GetProducts(db, year, month,day);


                var models = new List<SaleProductInventoryModel>();

                foreach (var product in products)
                {
                    // map equal properties
                    var model = Mapping.Mapper.Map<SaleProductInventoryModel>(product);

                    // query using year month and product id
                    var saleProducts = await GetSaleProducts(db, year, month, day, product.ProductID);
                    //set values
                    model.Quantity = saleProducts.Sum(x => x.Quantity);
                    model.TotalAmount = saleProducts.Sum(x => x.Quantity * x.Price);

                    // add to models
                    models.Add(model);
                }

                return models;

            }
        }

        public async Task<decimal> GetSaleProductTotalAmount(int year, int month, int day)
        {
            using (var db = new DataContext())
            {
                year = year == 0 ? throw new InvalidFieldException("Year") : year;
                month = month == 0 ? throw new InvalidFieldException("Month") : month;
                day = day == 0 ? throw new InvalidFieldException("Day") : day;
                // query using year
                // just select quantity and price
                var saleProducts = await db.SaleProducts
                    .Where(x =>
                        x.Sale.SaleDate.Year == year && x.Sale.SaleDate.Month == month && x.Sale.SaleDate.Day == day
                      ).Select(x => new { x.Quantity, x.Price }).ToListAsync();
                return saleProducts.Sum(x => x.Quantity * x.Price);
            }
        }
        private async Task<IList<Product>> GetProducts(IDataContext db, int year, int month, int day)
        {
            return await db.Products
                    .Where(x => x.SaleProducts
                    .Where(y => y.Sale.SaleDate.Year == year)
                    .Where(y => y.Sale.SaleDate.Month == month)
                    .Where(y => y.Sale.SaleDate.Day == day)
                    .Count() > 0).ToListAsync();
        }
        private async Task<IList<Product>> GetProducts(IDataContext db, int year, int month)
        {
            return await db.Products
                .Where(x => x.SaleProducts
                .Where(y => y.Sale.SaleDate.Year == year && y.Sale.SaleDate.Month == month)
                .Count() > 0).ToListAsync();
        }
        private async Task<IList<SaleProduct>> GetSaleProducts(IDataContext db, int year, int month, int productID)
        {
            return await db.SaleProducts
                        .Where(x =>
                            x.Sale.SaleDate.Year == year
                            && x.Sale.SaleDate.Month == month
                            && x.ProductID == productID).ToListAsync();
        }
        private async Task<IList<SaleProduct>> GetSaleProducts(IDataContext db, int year, int month, int day, int productID)
        {
            return await db.SaleProducts
                        .Where(x =>
                            x.Sale.SaleDate.Year == year
                            && x.Sale.SaleDate.Month == month
                            && x.Sale.SaleDate.Day == day
                            && x.ProductID == productID).ToListAsync();
        }
        private async Task<IList<SaleProduct>> GetSaleProducts(IDataContext db, int year, int productID)
        {
            return await db.SaleProducts
                        .Where(x =>
                            x.Sale.SaleDate.Year == year
                            && x.ProductID == productID).ToListAsync();
        }

        private async Task<IList<Product>> GetProducts(IDataContext db, int year)
        {
            return await db.Products
                    .Where(x => x.SaleProducts
                    .Where(y => y.Sale.SaleDate.Year == year)
                    .Count() > 0).ToListAsync();
        }
    }
}
