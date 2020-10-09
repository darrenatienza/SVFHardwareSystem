using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    [Serializable]
    public class RecordNotFoundException : CustomBaseException
    {
        
        public RecordNotFoundException() : base(String.Format("Record not found")) { Code = "100"; }

        public RecordNotFoundException(string field) : base(String.Format("Record not found for " + field)) { }


    }
}
