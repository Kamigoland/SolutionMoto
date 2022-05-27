using AppMobileMoto.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileMoto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageDetailPage : ContentPage
    {
        public MessageDetailPage()
        {
            InitializeComponent();
            BindingContext = new MessageDetailViewModel();
        }
    }
}