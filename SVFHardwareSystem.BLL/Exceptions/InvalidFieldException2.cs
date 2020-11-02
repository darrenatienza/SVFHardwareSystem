using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    [Serializable]
    public class InvalidFieldException2 : CustomBaseException
    {
        public InvalidFieldException2() { }

        public InvalidFieldException2(string message) : base(message)
        {
        }
    }
}
