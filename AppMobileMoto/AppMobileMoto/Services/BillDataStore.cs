using AppMobileMoto.Models;
using AppMobileMoto.ViewModels;
using ServiceReferenceMoto;
using System.Linq;
using System.Threading.Tasks;

namespace AppMobileMoto.Services
{
    class BillDataStore : AbstractDataStore<Bill>
    {
        public BillDataStore() : base()
        {
            //items = MotoService.GetUserBills(new GetUserBillsRequest(LoginViewModel.SessionId)).GetUserBillsResult.Select(b => new Bill(b)).ToList();
            //items = MotoService.GetBills(new GetBillsRequest()).GetBillsResult.Select(b => new Bill(b)).ToList();
            Refresh();
        }
        public void Refresh()
        {
            items = MotoService.GetUserBills(new GetUserBillsRequest(LoginViewModel.SessionId)).GetUserBillsResult.Select(b => new Bill(b)).ToList();
        }
        public override Bill Find(Bill item)
        {
            return items.Where((Bill arg) => arg.IdBill == item.IdBill).FirstOrDefault();
        }

        public override Bill Find(int id)
        {
            return items.Where((Bill arg) => arg.IdBill == id).FirstOrDefault();
        }
        public override async Task<bool> AddItemAsync(Bill bill)
        {
            var passed = MotoService.AddBill(new AddBillRequest(bill.IdService, bill.IdAnnouncement,
                bill.IdUser, bill.FinalValue)).AddBillResult;
            if (!passed)
            {
                return await Task.FromResult(false);
            }
            else
            {
                Refresh();
                new ItemDataStore().Refresh();
                return await Task.FromResult(true);
            }
        }
    }
}
