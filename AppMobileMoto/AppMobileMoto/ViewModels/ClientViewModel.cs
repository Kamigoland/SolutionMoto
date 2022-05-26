using AppMobileMoto.Models;
using AppMobileMoto.ViewModels;
using AppMobileMoto.Views;
using Xamarin.Forms;

namespace AppMobileMoto.ViewModels
{
    public class ClientViewModel : AItemsViewModel<Client>
    {
        public ClientViewModel()
            : base("Users")
        {
        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewClientPage));
        }

    }

}
