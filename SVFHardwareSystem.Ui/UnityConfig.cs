﻿using SVFHardwareSystem.Services;
using SVFHardwareSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SVFHardwareSystem.Ui
{
    internal static class UnityConfig
    {
        public static UnityContainer Register()
        {
            var container = new UnityContainer();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<ISaleService, SaleService>();
            container.RegisterType<ISaleProductService, TransactionProductService>();
            container.RegisterType<ISalesService, SalesService>();
            container.RegisterType<ISupplierService, SupplierService>();
            container.RegisterType<IPurchaseService, PurchaseService>();
            container.RegisterType<IPurchaseSaleInventoryService, PurchaseSaleInventoryService>();
        
            return container;
        }
    }
}
