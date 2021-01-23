using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
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
    public class YearlyProductInventoryService : Service<YearlyProductInventoryModel, YearlyProductInventory>, IYearlyProductInventoryService
    {
        public async Task<IList<YearlyProductInventoryModel>> GetBeginningYearlyProductInventories(int year)
        {
            using (var db = new DataContext())
            {
                var products = await db.Products.Include(x => x.Category).ToListAsync();
                var previousYear = year - 1;
                var models = new List<YearlyProductInventoryModel>();
                foreach (var product in products)
                {
                    var model = new YearlyProductInventoryModel();

                    // get last product as beginning
                    var productOnInventory = await db.YearlyProductInventories.FirstOrDefaultAsync(x => x.ProductID == product.ProductID && x.Year == previousYear);
                    
                    model.ProductID = product.ProductID;
                    model.ProductName = product.Name;
                    model.Unit = product.Unit;
                    model.CategoryName = product.Category.Name;
                    if (productOnInventory != null)
                    {
                       
                        model.YearlyProductInventoryID = productOnInventory.YearlyProductInventoryID;
                        model.Quantity = productOnInventory.Quantity;
                        model.Price = productOnInventory.Price;
                        model.Year = productOnInventory.Year;
                        model.CreateTimeStamp = productOnInventory.CreateTimeStamp;
                    }
                    else
                    {
                       // newly added products that not included on previous yearly inventory
                        // no yearly product inventory id since it does not exists on yearly product inventory table
                        model.Quantity = 0;
                        model.Price = product.Price;
                        model.Year = previousYear;
                        model.CreateTimeStamp = DateTime.Now;
                    }

                    models.Add(model);
                }
                return models;
            }
            
        }

        public async Task<IList<YearlyProductInventoryModel>> GetEndingYearlyProductInventories()
        {
            using (var db = new DataContext())
            {
                var products = await db.Products.Include(x => x.Category).ToListAsync();
               
                var models = new List<YearlyProductInventoryModel>();
                foreach (var product in products)
                {
                    var model = new YearlyProductInventoryModel();

                    model.ProductID = product.ProductID;
                    model.ProductName = product.Name;
                    model.Unit = product.Unit;
                    model.CategoryName = product.Category.Name;
                    
                    // not yet exists on yearly product inventory table
                    model.YearlyProductInventoryID = 0;
                    model.Quantity = product.Quantity;
                    model.Price = product.Price;
                    model.Year = DateTime.Now.Year;
                    model.CreateTimeStamp = DateTime.Now;
                    models.Add(model);
                }
                return models;
            }
        }

        public async Task SaveYearlyProductInventory()
        {
            using (var db = new DataContext())
            {
                var products = await db.Products.Include(x => x.Category).ToListAsync();

                
                foreach (var product in products)
                {
                    var model = new YearlyProductInventory();

                    model.ProductID = product.ProductID;
                    model.Quantity = product.Quantity;
                    model.Price = product.Price;
                    model.Year = DateTime.Now.Year;
                    model.CreateTimeStamp = DateTime.Now;
                    db.YearlyProductInventories.Add(model);
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
