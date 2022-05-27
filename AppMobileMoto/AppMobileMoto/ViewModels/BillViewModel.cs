using AppMobileMoto.Models;
using AppMobileMoto.Services;
using AppMobileMoto.Views;
using Xamarin.Forms;

namespace AppMobileMoto.ViewModels
{
    public class BillViewModel : AItemsViewModel<Bill>
    {
        public BillViewModel() : base("Bills")
        {

        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewBillsPage));
        }
    }
}

