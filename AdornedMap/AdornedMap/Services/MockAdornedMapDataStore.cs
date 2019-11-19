using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdornedMap.Models;

namespace AdornedMap.Services 
{
    public class MockAdornedMapDataStore : IAdornedMapDataStore
    {
        private static readonly List<Property> mockProperties;
        private static int nextPropertyId;

        static MockAdornedMapDataStore()
        {
            mockProperties = new List<Property>
            {
               new Property{Id = "Id", Address = "12726 W Lowden Rd", City = "Peoria", State = "AZ", Zip = "85383"},
               new Property{Id = "Id", Address = "12782 W Lowden Rd", City = "Peoria", State = "AZ", Zip = "85383"},
            };

            nextPropertyId = mockProperties.Count;
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

        public async Task<String> AddPropertyAsync(Property mockProperty)
        {
            lock (this)
            {
                mockProperty.Id = nextPropertyId.ToString();
                mockProperties.Add(mockProperty);
                nextPropertyId++;
            }
            return await Task.FromResult(mockProperty.Id);
        }

        public async Task<bool> UpdatePropertyAsync(Property mockProperty)
        {
            var propertyIndex = mockProperties.FindIndex((Property arg) => arg.Id == mockProperty.Id);
            var propertyFound = propertyIndex != -1;
            if (propertyFound)
            {
                mockProperties[propertyIndex].Address = mockProperty.Address;
                mockProperties[propertyIndex].City = mockProperty.City;
                mockProperties[propertyIndex].State = mockProperty.State;
                mockProperties[propertyIndex].Zip = mockProperty.Zip;
            }
            return await Task.FromResult(propertyFound);
        }

        public async Task<Property> GetPropertyAsync(string id)
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
            var result = mockProperties.FirstOrDefault(mockProperty => mockProperty.Id == id);

            // Make a copy of the property to simulate reading from an external datastore
            var returnProperty = CopyProperty(result);
            return await Task.FromResult(returnProperty);
        }

        public async Task<IList<Property>> GetPropertiesAsync()
        {
            // Make a copy of the properties to simulate reading from and external datastore
            var returnProperties = new List<Property>();
            foreach (var property in mockProperties)
                returnProperties.Add(CopyProperty(property));
            return await Task.FromResult(returnProperties);
        }

        private static Property CopyProperty(Property property)
        {
            return new Property { Id = property.Id, Address = property.Address, City = property.City, State = property.State, Zip = property.Zip};
        }
    }
}