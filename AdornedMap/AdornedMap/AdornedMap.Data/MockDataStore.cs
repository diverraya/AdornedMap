using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdornedMap.Models;

namespace AdornedMap.AdornedMap.Data
{
    public class MockDataStore : IDataStore<Address>
    {
        List<Address> addresses;

        public MockDataStore()
        {
            addresses = new List<Address>();
            var mockAddresses = new List<Address>
            {
                new Address { Id = Guid.NewGuid(), StreetAddress = "12726 W Lowden Rd", City= "Peoria", State = "AZ", Zip = "85383"},
                new Address { Id = Guid.NewGuid(), StreetAddress = "12782 W Lowden Rd", City= "Peoria", State = "AZ", Zip = "85383"}
            };

            foreach (var address in mockAddresses)
            {
                addresses.Add(address);
            }
        }

        public async Task<bool> AddAddressAsync(Address address)
        {
            addresses.Add(address);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAddressAsync(Address address)
        {
            var oldItem = addresses.Where((Address arg) => arg.Id == address.Id).FirstOrDefault();
            addresses.Remove(oldItem);
            addresses.Add(address);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAddressAsync(string id)
        {
            var oldItem = addresses.Where((Address arg) => arg.Id.ToString() == id).FirstOrDefault();
            addresses.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Address> GetAddressAsync(string id)
        {
            return await Task.FromResult(addresses.FirstOrDefault(s => s.Id.ToString() == id));
        }

    }
}