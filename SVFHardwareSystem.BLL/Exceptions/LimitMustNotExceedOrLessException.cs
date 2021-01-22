using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    [Serializable]
    public class LimitMustNotExceedOrLessException : Exception
    {
        public LimitMustNotExceedOrLessException() { }

        public LimitMustNotExceedOrLessException(decimal max, int min) :base(string.Format("Quantity must not exceed to the limit of {0} but not less than {1}", max, min)){  
        }
    }
}
