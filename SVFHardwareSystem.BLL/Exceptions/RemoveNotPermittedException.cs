using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    [Serializable]
    public class RemoveNotPermittedException : CustomBaseException
    {
        public RemoveNotPermittedException() { }

        public RemoveNotPermittedException(string message) : base(message) { Code = "210"; }
    }
}
