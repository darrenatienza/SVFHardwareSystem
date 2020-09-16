using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        T Get(int id);
        IList<T> GetAll();
        Task<int> Add(T obj);
        int Edit(int id, T obj);
        int Remove(int id);
    }
}
