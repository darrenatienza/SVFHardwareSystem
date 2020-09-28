using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    [Serializable]
    public class LimitMustNotReachException :Exception
    {
        public LimitMustNotReachException() { }

        public LimitMustNotReachException(int limit) :base(String.Format("Quantity  must not reach the limit of {0}", limit)){  
        }
    }
}
