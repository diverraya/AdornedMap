using System;
using AdornedMap.Models;
using AdornedMap.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdornedMap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressDetailPage : ContentPage

    {
        private readonly AddressDetailViewModel _viewModel;
        public Address Address { get; set; }  

        public AddressDetailPage(AddressDetailViewModel viewModel)
        {
            InitializeComponent();
            InitializeData();
            
            _viewModel = viewModel;
            BindingContext = Address;
            
        }

        private void InitializeData()
        {
            Address = new Address {Id = Guid.NewGuid(), StreetAddress = "", Unit = "", City = "", State = "", Zip = "", 
                Latitude = Convert.ToDouble(""), Longitude = Convert.ToDouble("")};
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            _viewModel.Address = "222222";
            DisplayAlert($"The saved info is {_viewModel.Address}", "", "Button 2");
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void GetLocation_Clicked(object sender, EventArgs e)
        {
            GetLocationAsync();
        }
        
        private static async void GetLocationAsync()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = Geolocation.GetLocationAsync(request);

            Address.Latitude = location.Latitude;
            Address.Longitude = location.Longitude;
            
            OnPropertyChanged(nameof(Address));
        }
    }
}