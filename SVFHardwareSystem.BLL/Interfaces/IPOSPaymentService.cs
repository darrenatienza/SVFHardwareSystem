﻿using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface IPOSPaymentService : IService<POSPaymentModel>
    {
        /// <summary>
        /// Adds new record of payment for current pos transaction.
        /// Set isPaid = true of  transactions products where isToPay = true.
        /// Set isFinish = true of current pos transaction.
        /// </summary>
        /// <param name="posTransactionID"></param>
        /// <param name="change"></param>
        void Pay(int posTransactionID, decimal amountTendered, decimal total);
    }
}