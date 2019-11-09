using System;
using System.Security.Principal;

namespace AdornedMap.ViewModels
{
    public class SearchDetailViewModel  
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}