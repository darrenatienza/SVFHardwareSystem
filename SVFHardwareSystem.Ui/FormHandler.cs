using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SVFHardwareSystem.Ui
{
    public static class FormHandler
    {
        public static frmCustomers OpenCustomersForm() => UnityConfig
                            .Register().Resolve<frmCustomers>();
    }
}
