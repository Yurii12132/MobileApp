using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeninetsApp.Services
{
    public interface IDataStore<T>
    {
        Task AddAsync(T item);
        Task<bool> UpdatemAsync(T item);
        Task<bool> DeleteAsync(string id);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(bool forceRefresh = false);
    }
}
