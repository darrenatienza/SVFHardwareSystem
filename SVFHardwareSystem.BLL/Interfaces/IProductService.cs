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
        decimal GetQuantityByProductName(string productName);
        ProductModel GetByProductName(string productName);
        decimal GetRemainingQuantity(int productID, decimal quantityToBuy);
        void DeductQuantityOnProduct(int productID, decimal quantityToBuy);
        IList<ProductModel> GetAll(string category, string criteria);
        Task<IList<ProductModel>> GetAllByCategoryID(int categoryID);
        Task<Dictionary<int,string>> GetProductNamesAsync(string criteria);
        ProductModel GetProduct(int productID);
        Task<IList<ProductModel>> GetAllWithZeroBeginningQuantityByCategoryID(int categoryID);
        BeginningProductModel GetBeginningInventory(int productID);
        void EditBeginningInventoryQuantity(int productID, decimal quantity,decimal price);
        void EditProductQuantity(int productID, decimal quantity,decimal price);
    }
}
