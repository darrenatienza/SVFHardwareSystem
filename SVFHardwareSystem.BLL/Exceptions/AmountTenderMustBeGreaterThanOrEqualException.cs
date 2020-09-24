using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    [Serializable]
    public class AmountTenderMustBeGreaterThanOrEqualException :Exception
    {
        public AmountTenderMustBeGreaterThanOrEqualException() : base(String.Format("Amount Tender must be greater than or equal to the payable amount!")) { }

        
    }
}
