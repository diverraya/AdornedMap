using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdornedMap.Models;

namespace AdornedMap.AdornedMap.Data
{
    public class MockAdornedMapDataStore : IAdornedMapDataStore
    {
        private static readonly List<Address> mockAddresses;
        private static int nextAddressId;

        static MockAdornedMapDataStore()
        {
            mockAddresses = new List<Address>
            {
               new Address{Id = Guid.NewGuid(), StreetAddress = "12726 W Lowden Rd", City = "Peoria", State = "AZ", Zip = "85383"},
               new Address{Id = Guid.NewGuid(), StreetAddress = "12782 W Lowden Rd", City = "Peoria", State = "AZ", Zip = "85383"},
            };

            nextAddressId = mockAddresses.Count;
        }

        public MockAdornedMapDataStore()
        {
            //var xamformsintro = new Course { Id = "xamformsintro", Name = "Introduction to Xamarin.Forms" };
            //var androidkotlin = new Course { Id = "androidkotlin", Name = "Android Apps with Kotlin: First App" };
            //var xamarincross = new Course { Id = "xamarincross", Name = "Cross-platform with Xamarin" };
            //mockCourses = new List<Course>
            //{
            //    xamformsintro,
            //    androidkotlin,
            //    xamarincross,
            //};


        }

        public async Task<String> AddAddressAsync(Address address)
        {
            lock (this)
            {
                address.Id = new Guid(nextAddressId.ToString());
                mockAddresses.Add(address);
                nextAddressId++;
            }
            return await Task.FromResult(address.Id.ToString());
        }

        public async Task<bool> UpdateAddressAsync(Address address)
        {
            var addressIndex = mockAddresses.FindIndex((Address arg) => arg.Id == address.Id);
            var addressFound = addressIndex != -1;
            if (addressFound)
            {
                mockAddresses[addressIndex].StreetAddress = address.StreetAddress;
                mockAddresses[addressIndex].City = address.City;
                mockAddresses[addressIndex].State = address.State;
                mockAddresses[addressIndex].Zip = address.Zip;
            }
            return await Task.FromResult(addressFound);
        }

        public async Task<Address> GetAddressAsync(string id)
        {
            //Note testNote = null;
            //foreach(var loopNote in mockNotes)
            //{
            //    if (loopNote.Id == id)
            //    {
            //        testNote = loopNote;
            //        break;
            //    }
            //}
            //int i = 0;
            var result = mockAddresses.FirstOrDefault(address => address.Id.ToString() == id);

            // Make a copy of the note to simulate reading from an external datastore
            var returnAddress = CopyAddress(result);
            return await Task.FromResult(returnAddress);
        }

        public async Task<IList<Address>> GetAddressesAsync()
        {
            var returnAddresses = new List<Address>();
            foreach (var address in mockAddresses)
                returnAddresses.Add(CopyAddress(address));
            return await Task.FromResult(returnAddresses);
        }

        private static Address CopyAddress(Address address)
        {
            return new Address { Id = address.Id, StreetAddress = address.StreetAddress, City = address.City, State = address.State, Zip = address.Zip};
        }
    }
}