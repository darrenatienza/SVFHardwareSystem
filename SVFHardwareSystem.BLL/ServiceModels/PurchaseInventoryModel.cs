using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class PurchaseInventoryModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public IList<PurchaseProductInventoryModel> PurchaseProductMonthlyReports { get; set; } = new List<PurchaseProductInventoryModel>();
        public decimal TotalMonthlyAmount { get => PurchaseProductMonthlyReports.Sum(x => x.TotalAmount); }
    }
}
