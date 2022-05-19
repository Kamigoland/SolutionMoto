using AppMobileMoto.Models;
using AppMobileMoto.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileMoto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewClientPage : ContentPage
    {
        public Client Item { get; set; }

        public NewClientPage()
        {
            InitializeComponent();
            BindingContext = new NewClientViewModel();
        }

    }
}