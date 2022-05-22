using AppMobileMoto.Models;
using AppMobileMoto.ViewModels;
using Xamarin.Forms;

namespace AppMobileMoto.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}