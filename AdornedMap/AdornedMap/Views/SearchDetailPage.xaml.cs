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
        public Search Search { get; set; }

        public SearchDetailPage(SearchDetailViewModel viewModel)
        {
            InitializeComponent();
            InitializeData();

            BindingContext = Search;
        }

        void InitializeData()
        {
            Search = new Search {Address = "Address", City = "City", State = "ST", Zip = "85555"};
        }
    }
}