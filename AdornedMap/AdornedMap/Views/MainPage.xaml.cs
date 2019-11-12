using System;
using AdornedMap.ViewModels;
using Xamarin.Forms;

namespace AdornedMap.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        { 
            InitializeComponent();
        }
        
        public async void Search_Clicked(object sender, EventArgs eventArgs)
        {
            //DisplayAlert("Search option", "Search was selected", "Button 2", "Button 1");
            await Navigation.PushAsync(new AddressDetailPage(new AddressDetailViewModel()));
        }
    }
}