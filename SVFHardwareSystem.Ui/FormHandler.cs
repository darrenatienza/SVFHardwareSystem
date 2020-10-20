﻿using SVFHardwareSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace SVFHardwareSystem.Ui
{
    public static class FormHandler
    {
        public static frmCustomers OpenCustomersForm() => UnityConfig
                            .Register().Resolve<frmCustomers>();


        public static frmSales OpenSalesForm() => UnityConfig
                           .Register().Resolve<frmSales>();
        public static frmCategory OpenCategoriesForm() => UnityConfig
                           .Register().Resolve<frmCategory>();


        public static frmProducts OpenProductsForm() => UnityConfig
                          .Register().Resolve<frmProducts>();

        public static frmPointofSale OpenPointofSaleForm() => UnityConfig
                          .Register().Resolve<frmPointofSale>();
        public static frmSuppliers OpenSuppliersForm() => UnityConfig
                         .Register().Resolve<frmSuppliers>();
        public static frmSupplierForm OpenSupplierForm() => UnityConfig
                       .Register().Resolve<frmSupplierForm>();
        public static frmPurchases OpenPurchasesForm() => UnityConfig
                      .Register().Resolve<frmPurchases>();

        public static frmPurchaseSaleInventories OpenPurchaseSaleInventoriesForm() => UnityConfig
                     .Register().Resolve<frmPurchaseSaleInventories>();

        public static frmCustomerReceivable OpenCustomerReceivableForm() => UnityConfig
                     .Register().Resolve<frmCustomerReceivable>();

        public static frmPayables OpenPayablesForm() => UnityConfig
                     .Register().Resolve<frmPayables>();

        public static frmSalesMonthlyReport OpenSaleMonthlyReportForm() => UnityConfig
                   .Register().Resolve<frmSalesMonthlyReport>();

        public static frmSalesReport OpenSalesReport() => UnityConfig
                   .Register().Resolve<frmSalesReport>();
        public static frmSupplierForm OpenSupplierForm(int supplierID)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmSupplierForm>(new InjectionConstructor(new object[] { new SupplierService(), supplierID }))
                .Resolve<frmSupplierForm>();

        }
        public static frmPurchaseProductForm OpenPurchaseProductForm(int purchaseID)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmPurchaseProductForm>(new InjectionConstructor(new object[] { new ProductService(), new CategoryService(), new PurchaseService(), purchaseID }))
                .Resolve<frmPurchaseProductForm>();

        }
        public static frmPurchaseProductForm OpenPurchaseProductForm(int purchaseID, int productID)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmPurchaseProductForm>(new InjectionConstructor(new object[] { new ProductService(), new CategoryService(), new PurchaseService(), purchaseID, productID }))
                .Resolve<frmPurchaseProductForm>();

        }
        public static frmPurchasePayments OpenPurchasePayments(int purchaseID)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmPurchasePayments>(new InjectionConstructor(new object[] { new PurchaseService(), new PaymentMethodService(), purchaseID }))
                .Resolve<frmPurchasePayments>();

        }
        /// <summary>
        /// Dependency Inject with parameter on frmPointofSaleQuantityEdit
        /// </summary>
        /// <param name="posTransactionID"></param>
        /// <returns></returns>
        public static frmPointofSaleQuantityEdit OpenPointOfSaleQuantityEditForm(int posTransactionID)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmPointofSaleQuantityEdit>(new InjectionConstructor(new object[] { new ProductService(), new TransactionProductService(), posTransactionID }))
                .Resolve<frmPointofSaleQuantityEdit>();

        }

        public static frmPointOfSalePayment OpenPointOfSalePaymentForm(int posTransactionID)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmPointOfSalePayment>(new InjectionConstructor(new object[] { new POSPaymentService(), new POSTransactionService(), posTransactionID }))
                .Resolve<frmPointOfSalePayment>();

        }
        public static frmSalesReplaceCancel OpenSalesReplaceCancelForm(int posTransactionID)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmSalesReplaceCancel>(new InjectionConstructor(new object[] { new TransactionProductService(), posTransactionID }))
                .Resolve<frmSalesReplaceCancel>();

        }

        internal static frmProductForm OpenProductForm(int productID) => UnityConfig
                .Register()
                .RegisterType<frmProductForm>(new InjectionConstructor(new object[] { new ProductService(), new CategoryService(), new SupplierService(), productID }))
                .Resolve<frmProductForm>();

        public static frmProductForm OpenProductForm() => UnityConfig
                         .Register().Resolve<frmProductForm>();


    }
}
