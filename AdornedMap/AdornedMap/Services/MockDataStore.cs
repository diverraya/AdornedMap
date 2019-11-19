using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdornedMap.Models;

namespace AdornedMap.Services
{
    public class MockDataStore : IDataStore<Property>
    {
        List<Property> properties;

        public MockDataStore()
        {
            properties = new List<Property>();
            var mockProperties = new List<Property>
            {
                new Property { Id = "Id", Address = "12726 W Lowden Rd", City= "Peoria", State = "AZ", Zip = "85383"},
                new Property { Id = "Id", Address = "12782 W Lowden Rd", City= "Peoria", State = "AZ", Zip = "85383"}
            };

            foreach (var property in mockProperties)
            {
                properties.Add(property);
            }
        }

        public async Task<bool> AddAddressAsync(Property property)
        {
            properties.Add(property);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAddressAsync(Property property)
        {
            var oldItem = properties.Where((Property arg) => arg.Id == property.Id).FirstOrDefault();
            properties.Remove(oldItem);
            properties.Add(property);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAddressAsync(string id)
        {
            var oldItem = properties.Where((Property arg) => arg.Id.ToString() == id).FirstOrDefault();
            properties.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Property> GetAddressAsync(string id)
        {
            return await Task.FromResult(properties.FirstOrDefault(s => s.Id.ToString() == id));
        }

    }
}