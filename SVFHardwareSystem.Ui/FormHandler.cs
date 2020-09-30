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
        public static frmCustomers OpenCustomersForm() => UnityConfig
                            .Register().Resolve<frmCustomers>();


        public static frmSales OpenSalesForm() => UnityConfig
                           .Register().Resolve<frmSales>();
        public static frmPointofSale OpenPointofSaleForm() => UnityConfig
                          .Register().Resolve<frmPointofSale>();
        /// <summary>
        /// Dependency Inject with parameter on frmPointofSaleQuantityEdit
        /// </summary>
        /// <param name="posTransactionID"></param>
        /// <returns></returns>
        public static frmPointofSaleQuantityEdit OpenPointOfSaleQuantityEditForm(int posTransactionID) {
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

    }
}
