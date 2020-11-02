using SVFHardwareSystem.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class PurchaseModel
    {
        private string _sidr;

        public PurchaseModel() { }
        public int PurchaseID { get; set; }
        public DateTime CreateTimeStamp { get; set; } = DateTime.Now;
        public bool IsFullyPaid { get; set; }
        public DateTime DatePurchase { get; set; }
        public int SupplierID { get; set; }
        public string SIDR
        {
            get { return _sidr; }
            set
            {
                if (value == "" || value == null)
                {
                    throw new InvalidFieldException("SIDR");
                }
                _sidr = value;
            } }
        public string SupplierName { get; set; }
        public string Remarks { get; set; }
        public decimal TotalPurchaseAmount { get { return PurchaseProducts.Sum(x => x.Total); } }

        public IList<PurchaseProductModel> PurchaseProducts { get; set; } = new List<PurchaseProductModel>();

        public IList<PurchasePaymentModel> PurchasePayments { get; set; } = new List<PurchasePaymentModel>();

        public decimal TotalCashAmount
        {
            get
            {
                return PurchasePayments.Where(x => x.PaymentMethodName == "Cash").Sum(x => x.Amount);
            }
        }

        public decimal TotalPayableAmount
        {
            get
            {
                return TotalPurchaseAmount - TotalCashAmount;
            }
        }

        public decimal TotalCheckAmount
        {
            get
            {
                var checks = PurchasePayments.Where(x => x.PaymentMethodName == "Check");
                return checks.Sum(x => x.Amount);


            }
        }
        public decimal TotalPayment
        {
            get { return PurchasePayments.Sum(x => x.Amount); }
        }
        public decimal Balance { get { return TotalPurchaseAmount - TotalPayment; } }

        public string CheckDate
        {
            get
            {
                var value = "";
                var checks = PurchasePayments.Where(x => x.PaymentMethodName == "Check");
                if (checks.Count() > 0)
                {
                    foreach (var item in checks)
                    {
                        value += "[" + item.PaymentDate.ToShortDateString() + "]";
                    }

                }
                if (TotalCashAmount == TotalPurchaseAmount)
                {
                    value=  "PD";
                }
                
                return value;
            }
        }
        public string CheckNumber
        {
            get
            {
                var value = "";
                var checks = PurchasePayments.Where(x => x.PaymentMethodName == "Check");
                if (checks.Count() > 0)
                {
                    foreach (var item in checks)
                    {
                        value += "[" + item.CheckNumber + "]";
                    }

                }
                if (TotalCashAmount == TotalPurchaseAmount)
                {
                    value = "no check";
                }
                
                return value;
            }
        }
    }
}
