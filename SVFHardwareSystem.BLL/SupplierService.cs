using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    public class SupplierService : Service<SupplierModel, Supplier>, ISupplierService
    {
    }
}
