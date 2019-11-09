using System;
using AdornedMap.Models;
using AdornedMap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdornedMap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchDetailPage : ContentPage

    {
        SearchDetailViewModel viewModel;
        private SearchDetailViewModel _viewModel;
        public Address Search { get; set; }

        public SearchDetailPage(SearchDetailViewModel viewModel)
        {
            InitializeComponent();
            InitializeData();
            
            _viewModel = viewModel;
            BindingContext = _viewModel;
            
        }

        void InitializeData()
        {
            Search = new Address {StreetAddress = "Address", City = "City", State = "ST", Zip = "85555"};
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
 
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}