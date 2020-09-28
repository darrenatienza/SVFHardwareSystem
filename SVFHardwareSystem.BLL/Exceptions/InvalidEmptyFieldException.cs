using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    [Serializable]
    public class InvalidEmptyFieldException : Exception
    {
        public InvalidEmptyFieldException() { }

        public InvalidEmptyFieldException(string fieldName) :base(String.Format("Field {0} must containt value!", fieldName)){  
        }
    }
}
