using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Extensions
{
    public static class FormatExtensions
    {
        public static String ToCurrencyFormat(this decimal value)
        {

            return string.Format("{0:n}", value);
        }
    }
}
