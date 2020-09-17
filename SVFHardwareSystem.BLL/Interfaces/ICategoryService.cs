using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface ICategoryService : IService<CategoryModel>
    {
        Task<IList<CategoryModel>> GetAll(string criteria);
    }
}
