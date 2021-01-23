using SVFHardwareSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class YearlyProductInventoryModel
    {
        public int YearlyProductInventoryID { get; set; }
        
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Unit { get; set; }
        public int Year { get; set; }
        public decimal Quantity { get; set; }
        /// <summary>
        /// Total
        /// </summary>
        public decimal Price { get; set; }
        public decimal TotalAmount { get
            {
                return Price * Quantity;
            } }

        public DateTime CreateTimeStamp { get; set; }
    }
}
