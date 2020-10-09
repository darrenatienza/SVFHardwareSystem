using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    public abstract class CustomBaseException : Exception
    {
        public string Code = "";
        public CustomBaseException() { }
        public CustomBaseException(string message) : base(message) { }
    }
}
