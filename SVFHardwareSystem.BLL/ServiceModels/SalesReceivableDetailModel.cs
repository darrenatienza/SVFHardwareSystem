﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class SalesReceivableDetailModel
    {

        public string FullName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        /// <summary>
        /// Total Amount of Balance for all Invoices
        /// </summary>
        public decimal TotalBalance { get { return SalesReceivables.Sum(x => x.Balance); } }

        public IList<SalesReceivableModel> SalesReceivables { get; set; } = new List<SalesReceivableModel>();
        public object CustomerID { get; set; }
    }
}
