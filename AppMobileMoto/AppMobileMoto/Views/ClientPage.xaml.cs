using AppMoblieMoto.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileMoto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientPage : ContentPage
    {
        ClientViewModel _viewModel;

        public ClientPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ClientViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }

}