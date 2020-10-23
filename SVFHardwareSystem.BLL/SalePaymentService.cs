﻿using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    public class SalePaymentService : Service<SalePaymentModel, SalePayment>, ISalePaymentService
    {
        public SalePaymentService() { }

        public void Pay(int posTransactionID, decimal amountTendered, decimal total)
        {
            using (var db = new DataContext())
            {



                // add new pospayment
                var posPayment = new SalePayment();
                posPayment.Amount = amountTendered;
                posPayment.PaymentDate = DateTime.Now;
                posPayment.SaleID = posTransactionID;
                db.POSPayments.Add(posPayment);

                // update isFinish of Pos Transaction
                var posTransaction = db.POSTransactions.Find(posTransactionID);
                posTransaction.IsFinished = true;
                posTransaction.DateFinished = DateTime.Now;
                db.Entry(posTransaction).State = EntityState.Modified;

                // update isPaid of products on transaction products
                var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == posTransactionID && x.IsToPay == true && x.IsPaid == false);
                foreach (var item in transactionProducts)
                {
                    item.IsPaid = true;

                    db.Entry(item).State = EntityState.Modified;
                }
                db.SaveChanges();

            }
        }
    }
}