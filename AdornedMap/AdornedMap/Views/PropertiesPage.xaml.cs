using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdornedMap.Models;
using AdornedMap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdornedMap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertiesPage : ContentPage
    {
        private PropertiesViewModel _viewModel;
        
        public PropertiesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PropertiesViewModel();
        }

        async void OnPrpertySelected(object sender, SelectedItemChangedEventArgs args)
        {
            var property = args.SelectedItem as Property;
            if (property == null)
                return;

            await Navigation.PushModalAsync(new PropertyDetailPage(new PropertyDetailViewModel(property)));
        }
    }
}