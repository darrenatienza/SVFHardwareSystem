using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    public class PaymentMethod
    {
        public PaymentMethod() { }
        public int PaymentMethodID { get; set; }
        public string Name { get; set; }
    }
}
