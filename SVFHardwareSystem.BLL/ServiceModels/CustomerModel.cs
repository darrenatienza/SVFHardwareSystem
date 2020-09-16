using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.ServiceModels
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
    }
}
