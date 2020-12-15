using AutoMap;
using AutoMapper;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Extensions;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    public class PurchaseService : Service<PurchaseModel, Purchase>, IPurchaseService
    {
        public override async Task AddAsync(PurchaseModel model)
        {
            using (var db = new DataContext())
            {
                if (model.SupplierID == 0)
            {
                throw new InvalidFieldException("Supplier");
            }
            
                var existingPurchase = await db.Purchases.FirstOrDefaultAsync(x => x.SupplierID == model.SupplierID && x.SIDR == model.SIDR);

                model.SIDR = existingPurchase != null ? throw new RecordAlreadyExistsException("SIDR") : model.SIDR;

                var purchase = db.Purchases.FirstOrDefault(x => DbFunctions.TruncateTime(x.DatePurchase) == DbFunctions.TruncateTime(model.DatePurchase) && x.SupplierID == model.SupplierID);
                if (purchase != null)
                {
                    var identifier = string.Format("the date of {0}", model.DatePurchase.ToShortDateString());
                    throw new RecordAlreadyExistsException(identifier);
                }
            }
            await base.AddAsync(model);
        }



        public async Task AddPurchaseProductAsync(int purchaseID, PurchaseProductModel model)
        {
            using (var db = new DataContext())
            {
                ValidatePurchaseProduct(model.ProductID, model.Quantity);
                var existProductOnPurchase = db.PurchaseProducts.FirstOrDefault(x => x.ProductID == model.ProductID && x.PurchaseID == purchaseID);
                if (existProductOnPurchase != null)
                {
                    //no duplicate products for every purchases
                    throw new RecordAlreadyExistsException(string.Format("Product {0}", existProductOnPurchase.Product.Name));
                }
                var product = db.Products.Find(model.ProductID);
                if (model.IsQuantityUploaded)
                {
                    // add the quantity to current product quantity if isquantityuploaded is true
                    
                    product.Quantity += model.Quantity;
                    db.Entry(product).State = EntityState.Modified;
                }
                
                if (model.Price >= product.Price)
                {
                    throw new InvalidFieldException2(string.Format("Purchase Unit Price {1} must be less than product price {0}.", 
                        product.Price.ToCurrencyFormat(), model.Price.ToString()));
                }
                var purchaseProduct = Mapping.Mapper.Map<PurchaseProduct>(model);
                
                purchaseProduct.PurchaseID = purchaseID;
                db.PurchaseProducts.Add(purchaseProduct);

                // set is fully paid to false when adding new purchase product
                var purchase = db.Purchases.Find(purchaseID);
                purchase.IsFullyPaid = false;
                db.Entry(purchase).State = EntityState.Modified;

                await db.SaveChangesAsync();

            }
        }

        public override Task EditAsync(int id, PurchaseModel model)
        {
            if (model.PurchaseID == 0)
            {
                throw new InvalidFieldException("Purchase");
            }
            if (model.SupplierID == 0)
            {
                throw new InvalidFieldException("Supplier");
            }
            if (model.SIDR == "")
            {
                throw new InvalidFieldException("SIDR");
            }
            using (var db = new DataContext())
            {
                var purchase = db.Purchases.FirstOrDefault(r => DbFunctions.TruncateTime(r.DatePurchase) == DbFunctions.TruncateTime(model.DatePurchase));
                // thrown an error only for changing purchase date but already exists
                if (purchase != null && purchase.DatePurchase != model.DatePurchase)
                {
                    throw new RecordAlreadyExistsException(string.Format("the date of {0}", model.DatePurchase.ToShortDateString()));
                }
            }
            return base.EditAsync(id, model);
        }

        public async Task EditPurchaseProduct(PurchaseProductModel model)
        {
            using (var db = new DataContext())
            {


                ValidatePurchaseProduct(model.ProductID, model.Quantity);

                var purchaseProduct = db.PurchaseProducts.Find(model.PurchaseProductID);
                if (purchaseProduct.IsQuantityUploaded)
                {
                    //purchases where uploaded quantity is true must not available for edit
                    throw new EditNotPermittedException();
                }
                var newPurchaseProduct = Mapping.Mapper.Map(model, purchaseProduct);
                db.Entry(newPurchaseProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();

            }
        }

        private void ValidatePurchaseProduct(int productID, int quantity)
        {
            if (productID == 0)
            {
                throw new InvalidFieldException("Product");
            }
            if (quantity == 0)
            {
                throw new InvalidFieldException("Quantity");
            }
        }

        public async Task<IList<PurchaseModel>> GetAllAsync(int supplierID)
        {
            using (var db = new DataContext())
            {
                var objs = await db.Purchases.Include(x => x.PurchaseProducts).Include(x => x.PurchasePayments).Where(x => x.Supplier.SupplierID == supplierID).ToListAsync();
                var models = Mapping.Mapper.Map<List<PurchaseModel>>(objs);
                return models;
            }
        }

        public async Task<IList<PurchaseProductModel>> GetPurchaseProductsAsync(int purchaseID)
        {
            using (var db = new DataContext())
            {
                var objs = await db.PurchaseProducts.Where(x => x.PurchaseID == purchaseID).ToListAsync();
                var models = Mapping.Mapper.Map<List<PurchaseProductModel>>(objs);
                return models;
            }
        }
        public IList<PurchaseProductModel> GetPurchaseProducts(int purchaseID)
        {
            using (var db = new DataContext())
            {
                var objs = db.PurchaseProducts.Where(x => x.PurchaseID == purchaseID).ToList();
                var models = Mapping.Mapper.Map<List<PurchaseProductModel>>(objs);
                return models;
            }
        }
        public async Task<PurchaseProductModel> GetPurchaseProduct(int purchaseID, int productID)
        {
            using (var db = new DataContext())
            {
                
                var obj = await db.PurchaseProducts.FirstOrDefaultAsync(x => x.PurchaseID == purchaseID && x.ProductID == productID);
                var model = Mapping.Mapper.Map<PurchaseProductModel>(obj);
                return model;
            }
        }

        public void DeletePurchaseProduct(int purchaseProductID)
        {
            using (var db = new DataContext())
            {
                var purchaseProduct = db.PurchaseProducts.Find(purchaseProductID);
                if (purchaseProduct == null)
                {
                    throw new RecordNotFoundException("Purchase Product");
                }
                if (purchaseProduct.IsQuantityUploaded)
                {
                    throw new RemoveNotPermittedException("Remove is not permitted for Purchase Products where the quantity was uploaded to the Product Inventory.");

                }
                db.PurchaseProducts.Remove(purchaseProduct);
                db.SaveChanges();

            }
        }

        public void UploadPurchaseQuantity(int purchaseProductID)
        {
            using (var db = new DataContext())
            {
                var purchasePRoduct = db.PurchaseProducts.Find(purchaseProductID);
                if (purchasePRoduct == null)
                {
                    throw new RecordNotFoundException("Purchase Product");
                }
                var product = db.Products.Find(purchasePRoduct.ProductID);
                if (product == null)
                {
                    throw new RecordNotFoundException("Product");
                }
                if (purchasePRoduct.IsQuantityUploaded)
                {
                    throw new PurchaseProductUploadAlreadyException();
                }
                product.Quantity += purchasePRoduct.Quantity;
                purchasePRoduct.IsQuantityUploaded = true;
                db.Entry(product).State = EntityState.Modified;
                db.Entry(purchasePRoduct).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public override PurchaseModel Get(int id)
        {
            using (var db = new DataContext())
            {
                var purchase = db.Purchases.Include(x => x.PurchasePayments).Include(x => x.PurchaseProducts).FirstOrDefault(x => x.PurchaseID == id);
                var model = Mapping.Mapper.Map<PurchaseModel>(purchase);
                return model;
            }


        }

        public void AddPurchasePayment(PurchasePaymentModel model)
        {
            using (var db = new DataContext())
            {
                var purchase = db.Purchases.Find(model.PurchaseID);

                CheckDecimalIfLessThanOrEqual(model.Amount, 0, "Amount");
                //payment date must be greater than purchase date.
                if (model.PaymentDate.Date < purchase.DatePurchase.Date)
                {
                    throw new InvalidFieldException2("Payment Date must be greater than Purchase Date");
                }

                var paymentMethod = db.PaymentMethods.FirstOrDefault(x => x.PaymentMethodID == model.PaymentMethodID);

                // check payment logic
                CheckObjectIfExists(paymentMethod, "Payment Method");
                if (model.PaymentMethodID == 2 && model.CheckNumber == 0)
                {
                    throw new InvalidFieldException("Check Number");
                }

                var total = GetPurchaseProducts(model.PurchaseID).Sum(r => r.Total);
                var totalPayment = GetAllPurchasePayments(model.PurchaseID).Sum(r => r.Amount);
                var balance = total - totalPayment - model.Amount;
                if (balance < 0)
                {
                    throw new OverPaymentException("Payment for Purchase Product Exceeded to total amount!");
                }
                // for fully paid set isfullypaid to true
                if (balance == 0)
                {
                    

                    purchase.IsFullyPaid = true;
                    db.Entry(purchase).State = EntityState.Modified;
                }
                var purchasePayment = Mapping.Mapper.Map<PurchasePayment>(model);
                db.PurchasePayments.Add(purchasePayment);
                db.SaveChanges();
            }
        }
        private void CheckDecimalIfLessThanOrEqual(decimal value, decimal lessThanOrEqualTo, string fieldName)
        {
            if (value <= lessThanOrEqualTo)
            {
                throw new InvalidFieldException(fieldName);
            }
        }
        private void CheckObjectIfAlreadyExists(object value, string fieldName)
        {
            if (value != null)
            {
                throw new RecordAlreadyExistsException(fieldName);
            }
        }

        private void CheckObjectIfExists(object value, string fieldName)
        {
            if (value == null)
            {
                throw new RecordNotFoundException(fieldName);
            }
        }

        public async Task<IList<PurchasePaymentModel>> GetAllPurchasePaymentsAsync(int purchaseID)
        {
            using (var db = new DataContext())
            {
                var purchasePayments = await db.PurchasePayments.Where(x => x.PurchaseID == purchaseID).ToListAsync();
                var models = Mapping.Mapper.Map<IList<PurchasePaymentModel>>(purchasePayments);
                return models;
            }
        }
        public IList<PurchasePaymentModel> GetAllPurchasePayments(int purchaseID)
        {
            using (var db = new DataContext())
            {
                var purchasePayments = db.PurchasePayments.Where(x => x.PurchaseID == purchaseID).ToList();
                var models = Mapping.Mapper.Map<IList<PurchasePaymentModel>>(purchasePayments);
                return models;
            }
        }

        public async Task<IList<PurchaseModel>> GetAllPurchasePayablesAsync(int year, bool isFullyPaid)
        {
            using (var db = new DataContext())
            {
                year = year == 0 ? throw new InvalidFieldException("Year") : year;

                var purchases = await db.Purchases
                    .Include(x => x.PurchasePayments)
                    .Include(x => x.PurchaseProducts)
                    .Where(x => x.IsFullyPaid == isFullyPaid && x.DatePurchase.Year == year).ToListAsync();

                var purchaseModels = Mapping.Mapper.Map<List<PurchaseModel>>(purchases);

                return purchaseModels;



            }
        }

       

        public async Task<PurchasesPerSupplierModel> GetPurchasesPerSupplier(int year, int supplierID, bool isFullyPaid)
        {
            using (var db = new DataContext())
            {
                 year = year == 0 ? throw new InvalidFieldException("Year") : year;
                supplierID = supplierID == 0 ? throw new InvalidFieldException("Supplier") : supplierID;

                var supplier = await db.Suppliers
                    .Include(x => x.Purchases.Select(y => y.PurchasePayments))
                    .Include(x => x.Purchases.Select(y => y.PurchaseProducts))
                    .FirstOrDefaultAsync(x => x.SupplierID == supplierID && x.Purchases.Where( y => y.DatePurchase.Year == year).Count() > 0);
                    var model = Mapping.Mapper.Map<PurchasesPerSupplierModel>(supplier);

                model.Purchases = model.Purchases.Where(x => x.IsFullyPaid == isFullyPaid).ToList();

                return model;
                  



               
            }
        }

        public async Task<IList<PurchaseModel>> GetAllPurchasePayablesAsync(int year, int month,string supplierName)
        {
            using (var db = new DataContext())
            {
                year = year == 0 ? throw new InvalidFieldException("Year") : year;
                month = month == 0 ? throw new InvalidFieldException("Month") : month;
                supplierName = supplierName.Contains("Select") ? "" : supplierName;
                var purchases = await db.Purchases
                    .Include(x => x.PurchasePayments)
                    .Include(x => x.PurchaseProducts)
                    .Where(x => x.DatePurchase.Year == year && x.DatePurchase.Month == month && x.Supplier.Name.Contains(supplierName)).ToListAsync();

                var purchaseModels = Mapping.Mapper.Map<List<PurchaseModel>>(purchases);

                return purchaseModels;



            }
        }

        public async Task<int> GeneratedNewPurchaseID(int supplierID)
        {
            using (var db = new DataContext())
            {
                var purchase = new Purchase();
                purchase.CreateTimeStamp = DateTime.Now;
                purchase.DatePurchase = DateTime.Now;
                purchase.IsFullyPaid = false;
                purchase.Remarks = "";
                purchase.SIDR = "";
                purchase.SupplierID = supplierID;
                db.Purchases.Add(purchase);
                await db.SaveChangesAsync();
                return purchase.PurchaseID;
            }
        }
    }
}
