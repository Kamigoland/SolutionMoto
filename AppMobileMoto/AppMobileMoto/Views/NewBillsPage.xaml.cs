using AppMobileMoto.Models;
using AppMobileMoto.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileMoto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBillsPage : ContentPage
    {
        public Bill Item { get; set; }
        public NewBillsPage()
        {
            InitializeComponent();
            BindingContext = new NewBillViewModel();
        }
    }
}