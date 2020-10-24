using SVFHardwareSystem.DAL;
using SVFHardwareSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Queries
{
    public class DataContext :DbContext ,IDataContext
    {
        public DataContext() : base("name=DataContext")
        {
            Configuration.LazyLoadingEnabled = true;
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SalePayment> POSPayments { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleProduct> SaleProducts { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<WarrantyProduct> WarrantyProducts { get; set; }

        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseProduct> PurchaseProducts { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

        public virtual DbSet<PurchasePayment> PurchasePayments { get; set; }

        public virtual DbSet<PurchaseSaleInventoryProduct> PurchaseSaleInventoryProducts { get; set; }
        public virtual DbSet<PurchaseSaleInventory> PurchaseSaleInventories { get; set; }

        public virtual DbSet<ProductInventory> ProductInventories { get; set; }

    }
}
