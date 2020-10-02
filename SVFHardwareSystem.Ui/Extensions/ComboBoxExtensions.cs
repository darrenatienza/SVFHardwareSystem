using SVFHardwareSystem.Ui.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.ComboBox;

namespace SVFHardwareSystem.Ui.Extensions
{
    public static class ComboBoxExtensions
    {
        /// <summary>
        /// Extension to get item using id
        /// This requires ItemX Dependecies
        /// </summary>
        /// <param name="collection">Combo box Items</param>
        /// <param name="id">ID of record</param>
        /// <returns>ItemX Object</returns>
        public static ItemX SelectItemByID(this ObjectCollection collection, int id)
        {

            return collection.OfType<ItemX>().FirstOrDefault(r => r.Value == id.ToString());
        }
    }
}
