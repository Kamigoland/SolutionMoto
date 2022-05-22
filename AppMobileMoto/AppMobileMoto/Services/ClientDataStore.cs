using AppMobileMoto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMobileMoto.Services
{
    public class ClientDataStore : IDataStore<Client>
    {
        readonly List<Client> items;

        public ClientDataStore()
        {
            items = new List<Client>()
            {
                new Client { IdClient = 1, Name = "Clientt 11", Adres="New Sącz 1",PhoneNumber="1" },
                new Client { IdClient = 2, Name = "Cliennt 22", Adres="New Sącz 2",PhoneNumber="2" },
                new Client { IdClient = 3, Name = "Clieent 33", Adres="New Sącz 3",PhoneNumber="3" }
            };
        }

        public async Task<bool> AddItemAsync(Client item)
        {
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Client item)
        {
            var oldItem = items.Where((Client arg) => arg.IdClient == item.IdClient).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Client arg) => arg.IdClient == id).FirstOrDefault();
            items.Remove(oldItem);
            return await Task.FromResult(true);
        }

        public async Task<Client> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.IdClient == id));
        }

        public async Task<IEnumerable<Client>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}

