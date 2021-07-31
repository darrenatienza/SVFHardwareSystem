using SVFHardwareSystem.Services;
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
        public static frmEditPointOfSaleDate OpenEditPointOfSaleDateForm(int saleID)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmEditPointOfSaleDate>(new InjectionConstructor(new object[] { new SaleService(), saleID }))
                .Resolve<frmEditPointOfSaleDate>();

        }
        public static frmSIDRListingByProduct OpenSIDRListingByProduct(int selProductID)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmSIDRListingByProduct>(new InjectionConstructor(new object[] { new ProductService(), new SalesService(),  selProductID }))
                .Resolve<frmSIDRListingByProduct>();

        }
     
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

        public static frmLogin OpenLogin() => UnityConfig
                     .Register().Resolve<frmLogin>();
        public static frmProductSale OpenProductSaleMonthlyInventoryForm() => UnityConfig
                  .Register().Resolve<frmProductSale>();
        public static frmSalesMonthlyReport OpenSaleMonthlyReportForm() => UnityConfig
                   .Register().Resolve<frmSalesMonthlyReport>();

        public static frmDailySales OpenSalesReport() => UnityConfig
                   .Register().Resolve<frmDailySales>();
        public static frmProductInventory OpenProductInventory() => UnityConfig
                   .Register().Resolve<frmProductInventory>();
        internal static frmProductInventoryReport OpenProductMonthlyReport() => UnityConfig
                   .Register().Resolve<frmProductInventoryReport>();
        internal static frmUserForm OpenUserForm() => UnityConfig
                        .Register().Resolve<frmUserForm>();
        internal static frmInitialProductQuantity OpenInitialProductQuantity() => UnityConfig
                        .Register().Resolve<frmInitialProductQuantity>();
        public static frmSupplierForm OpenSupplierForm(int supplierID)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmSupplierForm>(new InjectionConstructor(new object[] { new SupplierService(), supplierID }))
                .Resolve<frmSupplierForm>();

        }

        public static frmPointOfSaleDiscountForm OpenProductDiscountForm(int saleProductID)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmPointOfSaleDiscountForm>(new InjectionConstructor(new object[] { new SaleProductService(), saleProductID }))
                .Resolve<frmPointOfSaleDiscountForm>();

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
        public static frmPurchasePayments OpenPurchasePayments(int purchaseID, DateTime purchaseDate)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmPurchasePayments>(new InjectionConstructor(new object[] { new PurchaseService(), new PaymentMethodService(), purchaseID,purchaseDate }))
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
                .RegisterType<frmPointofSaleQuantityEdit>(new InjectionConstructor(new object[] { new ProductService(), new SaleProductService(), posTransactionID }))
                .Resolve<frmPointofSaleQuantityEdit>();

        }

        public static frmPointOfSalePayment OpenPointOfSalePaymentForm(int posTransactionID, DateTime saleDate)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmPointOfSalePayment>(new InjectionConstructor(new object[] { new SalePaymentService(), new SaleService(), posTransactionID, saleDate }))
                .Resolve<frmPointOfSalePayment>();

        }
        public static frmPointOfSalesReplaceCancel OpenSalesReplaceCancelForm(int posTransactionID)
        {
            return UnityConfig
                .Register()
                .RegisterType<frmPointOfSalesReplaceCancel>(new InjectionConstructor(new object[] { new SaleProductService(), posTransactionID }))
                .Resolve<frmPointOfSalesReplaceCancel>();

        }

        internal static frmProductForm OpenProductForm(int productID) => UnityConfig
                .Register()
                .RegisterType<frmProductForm>(new InjectionConstructor(new object[] { new ProductService(), new CategoryService(), new SupplierService(), productID }))
                .Resolve<frmProductForm>();

        public static frmProductForm OpenProductForm() => UnityConfig
                         .Register().Resolve<frmProductForm>();


    }
}
