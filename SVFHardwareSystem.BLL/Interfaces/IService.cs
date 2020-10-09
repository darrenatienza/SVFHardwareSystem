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
        Task<T> GetAsync(int id);
        Task <IList<T>> GetAllAsync();
        Task AddAsync(T model);
        Task<T> AddNewAsync(T model);
        /// <summary>
        /// Edit the record
        /// </summary>
        /// <param name="id">primary key of the record</param>
        /// <param name="model">object that contains the record</param>
        /// <returns>Async void</returns>
        /// <exception cref="Exceptions.CustomBaseException">Application logic exceptions</exception>
        Task EditAsync(int id, T model);
        Task RemoveAsync(int id);
    }
}
