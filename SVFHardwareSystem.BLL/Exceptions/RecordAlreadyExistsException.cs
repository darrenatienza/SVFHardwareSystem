using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    public class RecordAlreadyExistsException : Exception
    {
        public RecordAlreadyExistsException() { }

        public RecordAlreadyExistsException(string recordIdentifier) : base(String.Format("Record Already exists for {0}", recordIdentifier))
        {
        }
    }
}
