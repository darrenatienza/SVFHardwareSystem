﻿using SVFHardwareSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Queries
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext")
        {
            Configuration.LazyLoadingEnabled = true;
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<POSPayment> POSPayments { get; set; }
        public virtual DbSet<POSTransaction> POSTransactions { get; set; }
        public virtual DbSet<TransactionProduct> TransactionProducts { get; set; }


    }
}
