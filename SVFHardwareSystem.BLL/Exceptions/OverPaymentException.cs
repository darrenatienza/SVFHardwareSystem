using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    [Serializable]
    public class OverPaymentException : CustomBaseException
    {
        public OverPaymentException(string message) : base(message) { }

        
    }
}
