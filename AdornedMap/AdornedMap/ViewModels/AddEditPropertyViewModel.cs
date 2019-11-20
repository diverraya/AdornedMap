using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;
using AdornedMap.Models;
using AdornedMap.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AdornedMap.ViewModels
{
    public class AddEditPropertyViewModel : BaseViewModel
    {
        public AddEditPropertyViewModel()
        {
            Property = new Property();
        }
        
        public ICommand AddPropertyCommand => new Command(AddPropertyAsync);
        public ICommand CancelCommand => new Command(CancelAsync);
        public ICommand GetLocationCommand => new Command(GetLocationAsync);
        public ICommand GeocodeCommand => new Command(GeocodeAsync);

        private async void GeocodeAsync()
        {
//            if (string.IsNullOrWhiteSpace($"{Property.Address} {Property.Unit} {Property.City} {Property.State} {Property.Zip}"))
//            {
//                string message = "Must enter an address";
//                return;
//            }
            var address = $"{Property.Address} {Property.City} {Property.State} {Property.Zip}";
            var locations = await Geocoding.GetLocationsAsync(address);
            var location = locations.FirstOrDefault();
            if (location != null)
            {
                Property.Latitude = location.Latitude;
                Property.Longitude = location.Longitude;
                OnPropertyChanged(nameof(Property));
            }
        }

        private void CancelAsync(object obj)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

        private void AddPropertyAsync() 
        {
            Application.Current.MainPage = new NavigationPage(new AddEditPropertyPage(new AddEditPropertyViewModel()));
        }

        private async void GetLocationAsync()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = await Geolocation.GetLocationAsync(request);

            Property.Latitude = location.Latitude; 
            Property.Longitude = location.Longitude;

            var addresses = await Geocoding.GetPlacemarksAsync(location);
            var address = addresses.FirstOrDefault();
            if (address != null)
            {
                Property.Address = $"{address.SubThoroughfare} {address.Thoroughfare}";
                Property.City = $"{address.Locality}";
                Property.State = $"{address.AdminArea}";
                Property.Zip = $"{address.PostalCode}";
            }
            
            OnPropertyChanged(nameof(Property));
        }
        
        private Property _property;
        
        public Property Property
        {
            get => _property;
            set => SetProperty(ref _property, value);
        }
    }
}