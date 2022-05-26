
using AppMobileMoto.Services;
using AppMobileMoto.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileMoto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillPage : ContentPage
    {
        BillViewModel _viewModel;
        public BillPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new BillViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}