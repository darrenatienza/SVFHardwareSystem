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
    public class SalePaymentService : Service<SalePaymentModel, SalePayment>, ISalePaymentService
    {
        public SalePaymentService() { }

        public async Task<decimal> GetReceivablePaymentAmount(DateTime date)
        {
            using (var db = new DataContext())
            {
                var payments = await db.SalePayments.Where(x => x.IsReceivablePayment == true && DbFunctions.TruncateTime(x.PaymentDate) == DbFunctions.TruncateTime(date)).ToListAsync();
                return payments.Count > 0 ? payments.Sum(x => x.Amount) : 0;
            }
        }

        public void Pay(int posTransactionID, decimal amountTendered, decimal total)
        {
            using (var db = new DataContext())
            {



                // add new pospayment
                var posPayment = new SalePayment();
                posPayment.Amount = amountTendered;
                posPayment.PaymentDate = DateTime.Now;
                posPayment.SaleID = posTransactionID;
                db.SalePayments.Add(posPayment);

                // update isFinish of Pos Transaction
                var posTransaction = db.Sales.Find(posTransactionID);
                posTransaction.IsFinished = true;
                //posTransaction.DateFinished = DateTime.Now;
                db.Entry(posTransaction).State = EntityState.Modified;

                // update isPaid of products on transaction products
                var transactionProducts = db.SaleProducts.Where(x => x.SaleID == posTransactionID && x.IsToPay == true && x.IsPaid == false);
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
