using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class PurchaseSaleInventoryProductModel
    {
        public string  CategoryName { get; set; }

        public int ProductID { get; set; }
        /// <summary>
        /// Name of the Product
        /// </summary>
        public string Name{ get; set; }
        public string  Unit { get; set; }

        public int Year { get; set; }

        public int BeginningQuantity { get; set; } = 0;
        public decimal BeginningUnitCost { get; set; } = 0;
        public decimal BeginningAmount { get { return Math.Round(BeginningQuantity * BeginningUnitCost,2); } }

        public int PurchaseQuantity { get; set; } = 0;
        public decimal PurchaseUnitCost { get; set; } = 0;
        public decimal PurchaseAmount { get { return Math.Round(PurchaseQuantity * PurchaseUnitCost,2); } }

        public int SalesQuantity { get; set; } = 0;
        public decimal SalesUnitCost { get; set; } = 0;
        public decimal SalesAmount { get { return Math.Round(SalesQuantity * SalesUnitCost,2); } }


        public int EndingQuantity { get { return (BeginningQuantity + PurchaseQuantity) - SalesQuantity; } }
        public decimal EndingUnitCost { get { return EndingAmount == 0 ? 0 :Math.Round(EndingAmount /EndingQuantity,2); } }
        public decimal EndingAmount { get { return (BeginningAmount + PurchaseAmount) - SalesAmount; } }

        public int ProductSaleInventoryID { get; set; }
        public string ProductUnit { get; set; }
    }
}
