using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface IProductService : IService<ProductModel>
    {
        int GetProductID(string productName);
        int GetQuantityByProductName(string productName);
        ProductModel GetByProductName(string productName);
        int GetRemainingQuantity(int productID, int quantityToBuy);
        void DeductQuantityOnProduct(int productID, int quantityToBuy);
        IList<ProductModel> GetAll(string category, string criteria);
        Task<IList<ProductModel>> GetAllByCategoryID(int categoryID);
        Task<Dictionary<int,string>> GetProductNamesAsync(string criteria);
    }
}
