using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class PurchaseMonthlyReportModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public IList<PurchaseProductMonthlyReportModel> PurchaseProductMonthlyReports { get; set; } = new List<PurchaseProductMonthlyReportModel>();
        public decimal TotalMonthlyAmount { get => PurchaseProductMonthlyReports.Sum(x => x.TotalAmount); }
    }
}
