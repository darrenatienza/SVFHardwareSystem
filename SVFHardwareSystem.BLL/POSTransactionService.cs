using AutoMap;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace SVFHardwareSystem.Services
{
    public class POSTransactionService : Service<POSTransactionModel, POSTransaction>, IPOSTransactionService
    {
        public POSTransactionService() { }

        public void EditCustomerIDOnCurrentPOSTransaction(int posTransactionID, int customerID)
        {
            using (var db = new DataContext())
            {
                var entity = db.POSTransactions.Find(posTransactionID);
                entity.CustomerID = customerID;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public async Task<POSTransactionModel> Get(string code)
        {
            using (var db = new DataContext())
            {
                //decimal total = 0;
                //decimal cash = 0;
                //decimal receivable = 0;
                //decimal cancel = 0;
                var entity = await db.POSTransactions.FirstOrDefaultAsync(x => x.SIDR == code);
                var model = entity != null ? Mapping.Mapper.Map<POSTransactionModel>(entity) : throw new KeyNotFoundException();
                ////get total and receivables list
                //var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == entity.POSTransactionID);
                //var posPayments = db.POSPayments.Where(x => x.POSTransactionID == entity.POSTransactionID);
                //// compute for total amount of products
                //total = transactionProducts.Count() > 0 ? transactionProducts.Sum(y => y.Quantity * y.Product.Price) : 0;
                ////compute for  total amount of cash payments
                //cash = posPayments.Count() > 0 ? posPayments.Sum(y => y.Amount) : 0;
                //// cancel items are computed where is cancel is true and is paid is true
                //var cancelItems = transactionProducts.Where(a => a.IsCancel == true && a.IsPaid == true);
                //cancel = cancelItems.Count() > 0 ? cancelItems.Sum(z => z.Quantity * z.Product.Price) : 0;
                // peform operation && set values
                //receivable = total - cash - cancel;
                var total = this.GetTotalAmount(db, model.POSTransactionID);
                var cash = this.GetCashAmount(db, model.POSTransactionID);
                var cancel = this.GetCancelAmount(db, model.POSTransactionID);
                var receivable = this.GetReceivableAmount(model.POSTransactionID);
                model.IsFullyPaid = receivable <= 0 && entity.IsFinished ? true : false;
                model.TotalAmount = total;
                model.TotalPayment = cash;
                model.Receivable = receivable;
                model.CancelAmount = cancel;
                return model;
            }

        }

        private decimal GetCancelAmount(DataContext db, int pOSTransactionID)
        {
            decimal cancel = 0;

            var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == pOSTransactionID);
            // cancel items are computed where is cancel is true and is paid is true
            var cancelItems = transactionProducts.Where(a => a.IsCancel == true && a.IsPaid == true);
            cancel = cancelItems.Count() > 0 ? cancelItems.Sum(z => z.QuantityToCancel * z.Price) : 0;

            return cancel;
        }

        public decimal GetReceivableAmount(int posTransactionID)
        {
            decimal recievable = 0;
            using (var db = new DataContext())
            {
                var isFinished = db.POSTransactions.Find(posTransactionID).IsFinished;
                if (isFinished)
                {
                    var total = this.GetTotalAmount(db, posTransactionID);
                    var cash = this.GetCashAmount(db, posTransactionID);
                    var cancel = this.GetCancelAmount(db, posTransactionID);
                    recievable = total - cash;
                }
                return recievable;
            }
        }

        public decimal GetTotalAmount(int posTransactionID)
        {
            using (var db = new DataContext())
            {

                return this.GetTotalAmount(db, posTransactionID);


            }
        }

        private decimal GetTotalAmount(DataContext db, int posTransactionID)
        {
            decimal total = 0;

            var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == posTransactionID);
            if (transactionProducts.Count() > 0)
            {
                //subtract the quantity cancelled to purchase quantity then multiply the result on product price to get
                // the total amount
                // all cancelled quantity must not included to computation
                total = transactionProducts.Sum(y => (y.Quantity - y.QuantityToCancel) * y.Price);

            }
            return total;
        }

        public POSTransactionModel GetUnFinishedTransaction()
        {
            using (var db = new DataContext())
            {
                decimal total = 0;
                decimal cash = 0;
                var entity = db.POSTransactions.FirstOrDefault(x => x.IsFinished == false);
                var model = entity != null ? Mapping.Mapper.Map<POSTransactionModel>(entity) : throw new KeyNotFoundException();
                var transactionProducts = db.TransactionProducts.Where(x => x.POSTransactionID == entity.POSTransactionID);
                var posPayments = db.POSPayments.Where(x => x.POSTransactionID == entity.POSTransactionID);

                if (transactionProducts.Count() > 0)
                {
                    total = transactionProducts.Sum(y => y.Quantity * y.Product.Price);
                    model.TotalAmount = total;
                }
                return model;

            }
        }

        public decimal GetCashAmount(int postransactionID)
        {
            using (var db = new DataContext())
            {
                return this.GetCashAmount(db, postransactionID);
            }
        }

        public decimal GetTotalReceivablePayment(int posTransactionID)
        {
            using (var db = new DataContext())
            {
                var posPayments = db.POSPayments.Where(x => x.POSTransactionID == posTransactionID && x.IsReceivablePayment == true).ToList();
                return ComputeTotalPaymentAmount(posPayments);
            }
        }

        private decimal GetCashAmount(DataContext db, int postransactionID)
        {
            var posPayments = db.POSPayments.Where(x => x.POSTransactionID == postransactionID); ;
            //compute for  total amount of cash payments
            var cash = posPayments.Count() > 0 ? posPayments.Sum(y => y.Amount) : 0;
            return cash;
        }
        private decimal ComputeTotalPaymentAmount(IList<POSPayment> posPayments)
        {
            //compute for  total amount of cash payments
            var cash = posPayments.Count() > 0 ? posPayments.Sum(y => y.Amount) : 0;
            return cash;
        }
        public void Pay(int posTransactionID, decimal amountTendered, decimal total)
        {
            using (var db = new DataContext())
            {

                var receivable = GetReceivableAmount(posTransactionID);

                // add new pospayment
                var posPayment = new POSPayment();
                posPayment.Amount = amountTendered;
                posPayment.PaymentDate = DateTime.Now;
                posPayment.POSTransactionID = posTransactionID;
                posPayment.IsReceivablePayment = receivable > 0 ? true : false;
                db.POSPayments.Add(posPayment);

                if (receivable == 0)
                {
                    // update isFinish of Pos Transaction for first payment
                    var posTransaction = db.POSTransactions.Find(posTransactionID);
                    posTransaction.IsFinished = true;
                    posTransaction.DateFinished = DateTime.Now;

                    db.Entry(posTransaction).State = EntityState.Modified;
                }
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

        public decimal GetTotalCashOnlyAmount(int postransactionID)
        {
            using (var db = new DataContext())
            {
                var posPayments = db.POSPayments.Where(x => x.POSTransactionID == postransactionID && x.IsReceivablePayment == false).ToList();
                return ComputeTotalPaymentAmount(posPayments);
            }


        }

        public void CheckAndUpdateIfPosTransactionIsFullyPaid(int posTransactionID)
        {
            using (var db = new DataContext())
            {
                var receivable = GetReceivableAmount(posTransactionID);
                var posTransaction = db.POSTransactions.Find(posTransactionID);

                posTransaction.IsFullyPaid = receivable == 0 ? true : false;
                db.Entry(posTransaction).State = EntityState.Modified;
                db.SaveChanges();

            }
        }
    }
}
