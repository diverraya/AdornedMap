using System.Windows.Input;
using AdornedMap.Views;
using Xamarin.Forms;

namespace AdornedMap.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand AddPropertyCommand => new Command(AddPropertyAsync);

        private void AddPropertyAsync()
        { 
            Application.Current.MainPage = new AddEditPropertyPage(new AddEditPropertyViewModel());
        }
    }
}