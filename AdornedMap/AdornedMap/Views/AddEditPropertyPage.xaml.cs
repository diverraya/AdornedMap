using System;
using AdornedMap.Models;
using AdornedMap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdornedMap.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditPropertyPage : ContentPage
    {
        public Property Property { get; set; }
        public AddEditPropertyPage(AddEditPropertyViewModel viewModel)
        {
            InitializeComponent();
            InitializeData();

            BindingContext = viewModel; 
        }

        void InitializeData()
        {
            Property = new Property
            {
                Id = "Test id", Address = "Test Address", City = "Test City", State = "Test State", 
                Zip = "Test Zip"
            };
        }
    }
}