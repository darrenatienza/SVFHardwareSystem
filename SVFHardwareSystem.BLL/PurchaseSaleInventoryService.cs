using AutoMap;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    public class PurchaseSaleInventoryService : IPurchaseSaleInventoryService
    {
        public async Task<IList<PurchaseSaleInventoryProductModel>> GetYearlyInventory(int year)
        {
            using (var db = new DataContext())
            {
                //validation
                if (year == 0)
                {
                    throw new InvalidFieldException("Year");
                }

                var products = await db.Products.ToListAsync();

                var purchaseSales = Mapping.Mapper.Map<List<PurchaseSaleInventoryProductModel>>(products);
                var newPurchaseSaleInventories = new List<PurchaseSaleInventoryProductModel>();
                foreach (var purchaseSaleInventory in purchaseSales)
                {
                    var previousYear = year - 1;
                    purchaseSaleInventory.Year = year;
                    // last previous inventory of the product from db;
                    var previousPurchaseSaleInventory = db.PurchaseSaleInventoryProducts.FirstOrDefault(x => x.ProductID == purchaseSaleInventory.ProductID && x.Year == previousYear);
                    var previousPurchaseSaleInventoryModel = Mapping.Mapper.Map<PurchaseSaleInventoryProductModel>(previousPurchaseSaleInventory);
                    if (previousPurchaseSaleInventory != null)
                    {


                        purchaseSaleInventory.BeginningQuantity = previousPurchaseSaleInventoryModel.EndingQuantity;
                        purchaseSaleInventory.BeginningUnitCost = previousPurchaseSaleInventoryModel.EndingUnitCost;
                    }

                    var purchases = await db.PurchaseProducts.Where(x => x.Purchase.DatePurchase.Year == year && x.ProductID == purchaseSaleInventory.ProductID).ToListAsync();
                    //get total purchase quantity according to the year
                    var totalQuantityPurchase = purchases.Sum(x => x.Quantity);

                    //get total purchase amount purchase according to the year
                    var totalAmountPurchase = purchases.Sum(x => x.Price * x.Quantity);

                    if (totalQuantityPurchase > 0 && totalAmountPurchase > 0)
                    {
                        purchaseSaleInventory.PurchaseQuantity = totalQuantityPurchase;
                        purchaseSaleInventory.PurchaseUnitCost = Math.Round(totalAmountPurchase / totalQuantityPurchase, 2);
                    }

                    var sales = await db.TransactionProducts.Where(x => x.CreateTimeStamp.Year == year && x.ProductID == purchaseSaleInventory.ProductID).ToListAsync();
                    //get total sale quantity according to the year
                    var totalSalesQuantity = sales.Count() > 0 ? sales.Sum(x => x.Quantity) - sales.Sum(x => x.QuantityToCancel) : 0;

                    //get total sale amount purchase according to the year
                    var totalAmountSale = sales.Count() > 0 ? sales.Sum(x => x.Price * totalSalesQuantity) : 0;
                    if (totalSalesQuantity > 0 && totalAmountSale > 0)
                    {
                        purchaseSaleInventory.SalesQuantity = totalSalesQuantity;
                        purchaseSaleInventory.SalesUnitCost = Math.Round(totalAmountSale / totalSalesQuantity, 2);
                    }

                    newPurchaseSaleInventories.Add(purchaseSaleInventory);

                }
                return newPurchaseSaleInventories;
            }
        }

        public async Task SaveAsync(int year)
        {
            using (var db = new DataContext())
            {
                var startYear = year;
                var endYear = year;

                // validation
                if (year == 0)
                {
                    throw new InvalidFieldException("Year");
                }


                var latest = db.PurchaseSaleInventories.OrderByDescending(x => x.PurchaseSaleInventoryID).FirstOrDefault();
                if (latest != null)
                {
                    endYear = latest.Year > startYear ? latest.Year : startYear;
                }

                for (int __year = startYear; __year <= endYear; __year++)
                {
                    var inventories = db.PurchaseSaleInventoryProducts.Where(x => x.PurchaseSaleInventory.Year == __year);

                    if (inventories.Count() > 0)
                    {
                        db.PurchaseSaleInventoryProducts.RemoveRange(inventories);
                    }
                    var models = await GetYearlyInventory(year);
                    var inventoryproducts = Mapping.Mapper.Map<List<PurchaseSaleInventoryProduct>>(models);

                    var inventory = db.PurchaseSaleInventories.FirstOrDefault(x => x.Year == __year);

                    if (inventory == null)
                    {
                        var purchaseSaleInventory = new PurchaseSaleInventory();
                        purchaseSaleInventory.Year = year;
                        db.PurchaseSaleInventories.Add(purchaseSaleInventory);
                    }
                    else
                    {
                        inventoryproducts.ForEach(x => x.PurchaseSaleInventoryID = inventory.PurchaseSaleInventoryID);
                    }
                    db.PurchaseSaleInventoryProducts.AddRange(inventoryproducts);
                    await db.SaveChangesAsync();
                }




            }
        }
    }
}
