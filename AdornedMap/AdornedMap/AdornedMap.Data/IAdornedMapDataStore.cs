using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdornedMap.Models;

namespace AdornedMap.AdornedMap.Data
{
    public interface IAdornedMapDataStore
    {
        Task<String> AddAddressAsync(Address address);
        Task<bool> UpdateAddressAsync(Address address);
        Task<Address> GetAddressAsync(String id);
        Task<IList<Address>> GetAddressesAsync();
    }
}