using System;
using System.Windows.Input;
using AdornedMap.ViewModels;
using Xamarin.Forms;

namespace AdornedMap.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        { 
            InitializeComponent();
            BindingContext = new AddEditPropertyViewModel();
        }
    }
}