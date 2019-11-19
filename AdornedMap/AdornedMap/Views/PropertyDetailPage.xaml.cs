using System;
using AdornedMap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdornedMap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyDetailPage : ContentPage

    {
        PropertyDetailViewModel _viewModel;

        public PropertyDetailPage(PropertyDetailViewModel viewModel)
        {
            InitializeComponent();
            
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        public PropertyDetailPage()
        {
            InitializeComponent();
            
            _viewModel = new PropertyDetailViewModel();
            BindingContext = _viewModel;
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            
        }

       

//        private void GetLocation_Clicked(object sender, EventArgs e)
//        {
//            DisplayAlert("Get Location clicked", "Get Location button was clicked", "Button 2");
//        }
        
       
    }
}