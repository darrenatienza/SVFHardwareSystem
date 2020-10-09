using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    [Serializable]
    public class PurchaseProductUploadAlreadyException : CustomBaseException
    {
        public PurchaseProductUploadAlreadyException() : base(String.Format("Purchase Product Quantity was already uploaded!")) { }

        
    }
}
