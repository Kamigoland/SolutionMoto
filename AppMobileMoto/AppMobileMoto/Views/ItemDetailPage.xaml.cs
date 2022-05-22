using AppMobileMoto.ViewModels;
using Xamarin.Forms;

namespace AppMobileMoto.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}