using AutoMap;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    public class PurchaseSaleInventoryService : IPurchaseSaleInventoryService
    {
        public IList<PurchaseSaleInventoryProductModel> GetYearlyInventory(int year)
        {
            using (var db = new DataContext())
            {
                var products = db.Products.ToList();

                var purchaseSales = Mapping.Mapper.Map<List<PurchaseSaleInventoryProductModel>>(products);
                var newPurchaseSaleInventories = new List<PurchaseSaleInventoryProductModel>();
                foreach (var purchaseSaleInventory in purchaseSales)
                {
                    var previousYear = year - 1;
                    purchaseSaleInventory.Year = year;
                    // last previous inventory of the product;
                    var previousPurchaseSaleInventory = db.PurchaseSaleInventoryProducts.FirstOrDefault(x => x.ProductID == purchaseSaleInventory.ProductID && x.Year == previousYear);
                    var previousPurchaseSaleInventoryModel = Mapping.Mapper.Map<PurchaseSaleInventoryProductModel>(previousPurchaseSaleInventory);
                    if (previousPurchaseSaleInventory != null)
                    {


                        purchaseSaleInventory.BeginningQuantity = previousPurchaseSaleInventoryModel.EndingQuantity;
                        purchaseSaleInventory.BeginningUnitCost = previousPurchaseSaleInventoryModel.EndingUnitCost;
                    }

                    var purchases = db.PurchaseProducts.Where(x => x.Purchase.DatePurchase.Year == year && x.ProductID == purchaseSaleInventory.ProductID).ToList();
                    //get total purchase quantity according to the year
                    var totalQuantityPurchase = purchases.Sum(x => x.Quantity);

                    //get total purchase amount purchase according to the year
                    var totalAmountPurchase = purchases.Sum(x => x.Price * x.Quantity);

                    if (totalQuantityPurchase > 0 && totalAmountPurchase > 0)
                    {
                        purchaseSaleInventory.PurchaseQuantity = totalQuantityPurchase;
                        purchaseSaleInventory.PurchaseUnitCost = Math.Round(totalAmountPurchase / totalQuantityPurchase, 2);
                    }

                    var sales = db.TransactionProducts.Where(x => x.CreateTimeStamp.Year == year && x.IsCancel == false && x.ProductID == purchaseSaleInventory.ProductID).ToList();
                    //get total purchase quantity according to the year
                    var totalSalesQuantity = sales.Count() > 0 ? sales.Sum(x => x.Quantity) : 0;

                    //get total purchase amount purchase according to the year
                    var totalAmountSale = sales.Count() > 0 ? sales.Sum(x => x.Price) : 0;
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

        public void Save(int year)
        {
            using (var db = new DataContext())
            {
                var models = GetYearlyInventory(year);
                var inventoryproducts = Mapping.Mapper.Map<List<PurchaseSaleInventoryProduct>>(models);

                var purchaseSaleInventory = new PurchaseSaleInventory();
                purchaseSaleInventory.Year = year;
                db.PurchaseSaleInventories.Add(purchaseSaleInventory);

                db.PurchaseSaleInventoryProducts.AddRange(inventoryproducts);
                db.SaveChanges();
            }
        }
    }
}
