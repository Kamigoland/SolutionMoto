using AppMobileMoto.Models;
using AppMobileMoto.Views;
using Xamarin.Forms;

namespace AppMobileMoto.ViewModels
{
    public class ItemsViewModel : AItemsViewModel<Item>
    {
        public ItemsViewModel()
            : base("Items")
        {

        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewItemPage));
        }
    }

}