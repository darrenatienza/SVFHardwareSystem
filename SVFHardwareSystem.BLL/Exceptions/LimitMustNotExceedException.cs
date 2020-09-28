using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    [Serializable]
    public class LimitMustNotExceedException : Exception
    {
        public LimitMustNotExceedException() { }

        public LimitMustNotExceedException(int limit) :base(String.Format("Quantity  must not exceed the limit of {0}", limit)){  
        }
    }
}
