using SVFHardwareSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL
{
    public interface IDataContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<SaleProduct> SaleProducts { get; set; }
    }
}
