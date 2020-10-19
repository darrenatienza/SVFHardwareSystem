namespace SVFHardwareSystem.DAL.Migrations
{
    using SVFHardwareSystem.DAL.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SVFHardwareSystem.Queries.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SVFHardwareSystem.Queries.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            #region Add Categories
            var categories= new Dictionary<string, Category>
            {
                //Users Lookup
                {"1", new Category {CategoryID= 1, Name = "Category 1", }},
                {"2", new Category {CategoryID= 2, Name = "Category 2", }},
                {"3", new Category {CategoryID= 3, Name = "Category 3", }},

            };
            foreach (var item in categories.Values)
                context.Categories.AddOrUpdate(t => t.CategoryID, item);
            #endregion

            #region Add Supplier
            var suppliers = new Dictionary<string, Supplier>
            {
                //Users Lookup
                {"1", new Supplier {SupplierID = 1, Name = "Supplier 1", Address = "Address 1", ContactNumber="Contact Number 1",}},
                {"2", new Supplier {SupplierID = 2, Name = "Supplier 2", Address = "Address 2", ContactNumber="Contact Number 2", }},
                {"3", new Supplier {SupplierID = 3, Name = "Supplier 3", Address = "Address 3", ContactNumber="Contact Number 3", }},

            };
            foreach (var supplier in suppliers.Values)
                context.Suppliers.AddOrUpdate(t => t.SupplierID, supplier);
            #endregion



            #region Add Customers
            var customers = new Dictionary<string, Customer>
            {
                //Users Lookup
                {"1", new Customer {CustomerID = 1, FullName = "Customer", Address = "Address 1", ContactNumber="Contact Number 1"}},
                
                

            };
            foreach (var item in customers.Values)
                context.Customers.AddOrUpdate(t => t.CustomerID, item);
            #endregion

            #region Add Payment Methods
            var paymentMethods = new Dictionary<string, PaymentMethod>
            {
                //Users Lookup
                {"1", new PaymentMethod {PaymentMethodID= 1, Name = "Cash"}},
                {"2", new PaymentMethod {PaymentMethodID= 2, Name = "Check"}},
                

            };
            foreach (var item in paymentMethods.Values)
                context.PaymentMethods.AddOrUpdate(t => t.PaymentMethodID, item);
            #endregion



           

            #region Add Products
            var products = new Dictionary<string, Product>
            {
                //Users Lookup
                {"1", new Product {ProductID = 1, Name = "Product 1", CategoryID = 1, Code="1", Limit = 1, Price = 20, Quantity= 1000, Unit= "pc"}},
                {"2", new Product {ProductID = 2, Name = "Product 2", CategoryID = 1, Code="2", Limit = 1, Price = 5, Quantity= 1000, Unit= "pc"}},
                {"3", new Product {ProductID = 3, Name = "Product 3", CategoryID = 1, Code="3", Limit = 1, Price = 14, Quantity= 1000, Unit= "pc"}},

            };
            foreach (var product in products.Values)
                context.Products.AddOrUpdate(t => t.ProductID, product);
            #endregion
        }
    }
}
