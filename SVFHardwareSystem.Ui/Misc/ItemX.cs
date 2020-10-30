using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Ui.Misc
{
    public class ItemX
    {
        public string Value;
        public string Key;
        public ItemX(string value, string key)
        {
            Value = value; Key = key;
        }
        public override string ToString()
        {
            // Generates the text shown in the combo box
            return Value;
        }
    }
}
