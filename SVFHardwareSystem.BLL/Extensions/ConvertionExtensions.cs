using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Extensions
{
    public static class ConvertionExtensions
    {
        public static decimal ToDecimal(this String str)
        {
            decimal result = 0;
            return !decimal.TryParse(str, out result) ? 0 : result;
        }
        public static int ToInt(this String str)
        {
            int result = 0;
            return !int.TryParse(str, out result) ? 0 : result;
        }
    }
}
