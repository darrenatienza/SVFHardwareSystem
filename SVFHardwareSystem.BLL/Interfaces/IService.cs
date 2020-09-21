using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services.Interfaces
{
    /// <summary>
    /// Base Services Interface
    /// </summary>
    /// <typeparam name="T">T is model</typeparam>
    public interface IService<T> where T : class
    {
        Task<T> Get(int id);
        Task <IList<T>> GetAll();
        Task Add(T model);
        Task Edit(int id, T model);
        Task Remove(int id);
    }
}
