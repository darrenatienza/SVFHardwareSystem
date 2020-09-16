using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    /// <summary>
    /// Categories of Product
    /// </summary>
    public class Category
    {
        public Category() { }

        public int CategoryID {get; set;}
        public string Name { get; set; }
    }
}
