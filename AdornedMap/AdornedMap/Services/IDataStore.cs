using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdornedMap.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddAddressAsync(T address);
        Task<bool> UpdateAddressAsync(T address);
        Task<bool> DeleteAddressAsync(string id);
        Task<T> GetAddressAsync(string id);
    }
}