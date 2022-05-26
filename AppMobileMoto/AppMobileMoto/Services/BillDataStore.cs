using AppMobileMoto.Models;
using AppMobileMoto.ViewModels;
using ServiceReferenceMoto;
using System.Linq;

namespace AppMobileMoto.Services
{
    class BillDataStore : AbstractDataStore<Bill>
    {
        public BillDataStore() : base()
        {
            items = MotoService.GetUserBills(new GetUserBillsRequest(LoginViewModel.SessionId)).GetUserBillsResult.Select(b => new Bill(b)).ToList();
            //items = MotoService.GetBills(new GetBillsRequest()).GetBillsResult.Select(b => new Bill(b)).ToList();
        }
        public override Bill Find(Bill item)
        {
            return items.Where((Bill arg) => arg.IdBill == item.IdBill).FirstOrDefault();
        }

        public override Bill Find(int id)
        {
            return items.Where((Bill arg) => arg.IdBill == id).FirstOrDefault();
        }
    }
}
