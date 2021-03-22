using SVFHardwareSystem.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class PurchaseProductModel
    {
        private int _productID;
        private decimal _quantity;

        public int ProductID
        {
            get { return _productID; }
            set
            {
                if (value == 0)
                {
                    throw new InvalidFieldException("Product");
                }
                _productID = value;
            } 
        }
        public string ProductName { get; internal set; }
        public decimal Quantity {
            get { return _quantity; }
            set
            {
                if (value == 0)
                {
                    throw new InvalidFieldException("Product");
                }
                _quantity = value;
            }
        }
        public string ProductUnit { get; internal set; }
        [Obsolete("Delears Price cannot be set on product", true)]
        public decimal ProductDealersPrice { get; internal set; }
        public decimal Total { get { return UnitCost * Quantity; } }
        public bool IsQuantityUploaded { get; set; }
        public int PurchaseProductID { get; set; }
        public int ProductCategoryID { get; set; }
        /// <summary>
        /// Dealers Price
        /// </summary>
        public decimal UnitCost { get; set; }
    }
}
