﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    public class PurchaseProduct
    {
        public PurchaseProduct() { }
        public int PurchaseProductID { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int PurchaseID { get; set; }
        public virtual Purchase Purchase { get; set; }
        public decimal Quantity { get; set; }
        public bool IsQuantityUploaded { get; set; }
        /// <summary>
        /// Price of the Product after Purchases
        /// </summary>
        public decimal Price { get; set; }
    }
}
