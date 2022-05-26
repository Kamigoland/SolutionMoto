using AppMobileMoto.Models;
using AppMobileMoto.Services;

namespace AppMobileMoto.ViewModels
{
    public class BillViewModel : AItemsViewModel<Bill>
    {
        public BillViewModel() : base("Bills")
        {

        }

        public override void GoToAddPage()
        {
            return;
        }
    }
}

