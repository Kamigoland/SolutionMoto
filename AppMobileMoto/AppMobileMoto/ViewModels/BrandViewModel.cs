using AppMobileMoto.Models;
using AppMobileMoto.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AppMobileMoto.ViewModels
{
    class BrandViewModel : AItemsViewModel<Brand>
    {
        public BrandViewModel():base("Brands")
        {
        }

        public override void GoToAddPage()
        {
            return;
        }
    }
}
