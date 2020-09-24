using SVFHardwareSystem.DAL.Entities;
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
    public class POSPaymentService : Service<POSPaymentModel, POSPayment>, IPOSPaymentService
    {
        public POSPaymentService() { }

        public void Pay(int posTransactionID, decimal amountTendered,decimal total)
        {
            using (var db = new DataContext())
            {
                // amount tendered must be greater than or equal to total
                //if (amountTendered = total)
                //{


                    // add new pospayment
                    var posPayment = new POSPayment();
                    posPayment.Amount = amountTendered;
                    posPayment.PaymentDate = DateTime.Now;
                    posPayment.POSTransactionID = posTransactionID;
                    db.POSPayments.Add(posPayment);

                    // update isFinish of Pos Transaction
                    var posTransaction = db.POSTransactions.Find(posTransactionID);
                    posTransaction.IsFinished = true;
                    db.Entry(posTransaction).State = EntityState.Modified;

                    // update isPaid of products on transaction products
                    var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == posTransactionID && x.IsToPay == true && x.IsPaid == false);
                    foreach (var item in transactionProducts)
                    {
                        item.IsPaid = true;

                        db.Entry(item).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                //}
                //else
                //{
                //    throw new AmountTenderMustBeGreaterThanOrEqualException();
                //}
            }
        }
    }
}
