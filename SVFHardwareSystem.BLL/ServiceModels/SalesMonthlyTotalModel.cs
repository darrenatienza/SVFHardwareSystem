using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class SalesMonthlyTotalModel
    {
        public int Year { get; set; }
        public int Month { get; set; }


        public decimal TotalCashMonthlyPayment { get { return SalesDailyTotals.Sum(x => x.TotalDailyCashPayment); } }

        public decimal TotalMonthlyReceivablesAmount{ get { return SalesDailyTotals.Sum(x => x.TotalDailyReceivablesAmount); } }

        public decimal TotalMonthlySalesAmount { get { return SalesDailyTotals.Sum(x => x.TotalDailySalesAmount); } }
        public IList<SalesDailyTotalModel> SalesDailyTotals { get; set; } = new List<SalesDailyTotalModel>();
    
        
    }
}
