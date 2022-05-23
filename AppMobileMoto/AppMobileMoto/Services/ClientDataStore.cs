using AppMobileMoto.Models;
using ServiceReferenceMoto;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileMoto.Services
{
    public class ClientDataStore : AbstractDataStore<Client>
    {
        public ClientDataStore()
            : base()
        {
            //items = MotoService.GetUsers(new GetUsersRequest()).GetUsersResult.Select(u => new Client(u)).ToList();
            Refresh();
        }
        public void Refresh()
        {
            items = MotoService.GetUsers(new GetUsersRequest()).GetUsersResult.Select(u => new Client(u)).ToList();
        }
        public override Client Find(Client item)
        {
            return items.Where((Client arg) => arg.IdUser == item.IdUser).FirstOrDefault();
        }
        public override Client Find(int id)
        {
            return items.Where((Client arg) => arg.IdUser == id).FirstOrDefault();
        }

        public override async Task<bool> AddItemAsync(Client item)
        {
            var passed = MotoService.AddOrUpdateUser(new AddOrUpdateUserRequest(item)).AddOrUpdateUserResult;
            if (!passed)
            {
                return await Task.FromResult(false);
            }
            else
            {
                Refresh();
                return await Task.FromResult(true);
            }
        }
    }
}

