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
        Task<IList<PurchaseProductModel>>  GetPurchaseProducts(int purchaseID);
        /// <summary>
        /// Edit the Purchase Product
        /// </summary>
        /// <param name="purchaseProduct"></param>
        /// <returns></returns>
        /// <exception cref="EditNotPermittedException">Thrown when purchase product upload quantity is true.</exception>
        /// <exception cref="InvalidFieldException">Thrown when product id and quantity is zero.</exception>
        Task EditPurchaseProduct(PurchaseProductModel purchaseProduct);
        Task AddPurchaseProductAsync(int purchaseID,PurchaseProductModel purchaseProduct);
        Task<PurchaseProductModel> GetPurchaseProduct(int purchaseID, int productID);
    }
}
