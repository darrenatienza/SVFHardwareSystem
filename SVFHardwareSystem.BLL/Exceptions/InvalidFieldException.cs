using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    [Serializable]
    public class InvalidFieldException : CustomBaseException
    {
        public InvalidFieldException() { }

        public InvalidFieldException(string fieldName) : base(String.Format("Field {0} has invalid value!", fieldName))
        {
        }
    }
}
