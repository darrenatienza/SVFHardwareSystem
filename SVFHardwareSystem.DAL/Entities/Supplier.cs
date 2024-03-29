﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    public class Supplier
    {
        public Supplier() { }
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
    }
}
