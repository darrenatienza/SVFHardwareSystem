using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> Get(int id);
        Task <IList<T>> GetAll();
        Task<int> Add(T model);
        Task<int> Edit(int id, T model);
        Task Remove(int id);
    }
}
