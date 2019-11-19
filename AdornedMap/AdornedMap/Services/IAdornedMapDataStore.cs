using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdornedMap.Models;

namespace AdornedMap.Services
{
    public interface IAdornedMapDataStore
    {
        Task<string> AddPropertyAsync(Property mockPropery);
        Task<bool> UpdatePropertyAsync(Property property);
        Task<Property> GetPropertyAsync(string id);
        Task<IList<Property>> GetPropertiesAsync();
    }
}