using System.Windows.Input;
using AdornedMap.Models;
using AdornedMap.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AdornedMap.ViewModels
{
    public class AddEditPropertyViewModel : BaseViewModel
    {
        public AddEditPropertyViewModel()
        {
            Property = new Property();
        }
        
        public ICommand AddPropertyCommand => new Command(AddPropertyAsync);

        private async void AddPropertyAsync()
        {
            Application.Current.MainPage = new AddEditPropertyPage(new AddEditPropertyViewModel());
        }

        public ICommand GetLocationCommand => new Command(GetLocationAsync);
        
        private async void GetLocationAsync()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = await Geolocation.GetLocationAsync(request);

            Property.Latitude = location.Latitude; 
            Property.Longitude = location.Longitude;
            
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