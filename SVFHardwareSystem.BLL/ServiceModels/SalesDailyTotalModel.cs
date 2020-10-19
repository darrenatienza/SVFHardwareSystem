using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class SalesDailyTotalModel
    {
        public DateTime Date { get; set; }
        public decimal TotalDailyCashPayment { get; internal set; }
        public decimal TotalDailyReceivablesAmount { get { return  TotalDailySalesAmount -TotalDailyCashPayment; } }
        public decimal TotalDailySalesAmount { get; internal set; }
    }
}
