using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Ui.Interfaces
{
    public interface IAuthenticationService
    {
        string EncodePasswordToBase64(string password);
        string DecodeFrom64(string encodedData);
        
    }
}
