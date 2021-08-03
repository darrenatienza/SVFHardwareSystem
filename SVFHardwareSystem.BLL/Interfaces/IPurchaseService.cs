using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVFHardwareSystem.Services.Exceptions;
namespace SVFHardwareSystem.Services.Interfaces
{
    public interface IPurchaseService : IService<PurchaseModel>
    {

        Task<IList<PurchaseModel>> GetAllAsync(int supplierID);
        Task<IList<PurchaseModel>> GetAllPurchasePayablesAsync(int year, bool isFullyPaid);

        Task<IList<PurchaseProductModel>> GetPurchaseProductsAsync(int purchaseID);
        /// <summary>
        /// Edit the Purchase Product
        /// </summary>
        /// <param name="purchaseProduct"></param>
        /// <returns></returns>
        /// <exception cref="EditNotPermittedException">Thrown when purchase product upload quantity is true.</exception>
        /// <exception cref="InvalidFieldException">Thrown when product id and quantity is zero.</exception>
        Task EditPurchaseProduct(PurchaseProductModel purchaseProduct);
        Task AddPurchaseProductAsync(int purchaseID, PurchaseProductModel purchaseProduct);
        Task<PurchaseProductModel> GetPurchaseProduct(int purchaseID, int productID);
        IList<PurchaseModel> GetPurchaseListByProductID(int selProductID);
        Task<IList<PurchaseModel>> GetAllPurchasePayablesAsync(int year, int month, string supplierName);

        /// <summary>
        /// Removes the Purchase Product
        /// </summary>
        /// <param name="purchaseProductID">ID of the Purchase Product</param>
        /// <exception cref="CustomBaseException">Thrown when a purchase products quantity was uploaded to the product inventory</exception>
        void DeletePurchaseProduct(int purchaseProductID);
        Task<IList<PurchasePaymentModel>> GetAllPurchasePaymentsAsync(int purchaseID);

        /// <summary>
        /// Uploads the quantity of the product purchase
        /// </summary>
        /// <param name="purchaseProductID">Id of the purchase product</param>
        /// <exception cref="CustomBaseException">Thrown when an invalid logic occurs</exception>
        void UploadPurchaseQuantity(int purchaseProductID);
        Task<int> GeneratedNewPurchaseID(int supplierID);

        /// <summary>
        /// Add new Purchase payment on phone
        /// </summary>
        /// <param name="purchasePayment"></param>
        void AddPurchasePayment(PurchasePaymentModel purchasePayment);
        Task<PurchasesPerSupplierModel> GetPurchasesPerSupplier(int year, int supplierID,bool fullyPaid);

        

    }
}
