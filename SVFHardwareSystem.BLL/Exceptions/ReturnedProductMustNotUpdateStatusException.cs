using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Exceptions
{
    [Serializable]
    public class ReturnedProductMustNotUpdateStatusException : Exception
    {
        public ReturnedProductMustNotUpdateStatusException() : base(String.Format("Product with replaced or cancel status must not be updated")) { }

        


    }
}
