using AppMobileMoto.Models;
using ServiceReferenceMoto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileMoto.Services
{
    public abstract class AbstractDataStore<T> : IDataStore<T>
    {
        public List<T> items;
        public List<T> Items
        {
            get
            {
                //if (items == null || !items.Any())
                //{
                //    Refresh();
                //}
                return items;
            }
        }
        public IMotoService MotoService;

        public AbstractDataStore()
        {
            MotoService = DependencyService.Get<IMotoService>();
        }
        public virtual async Task<bool> AddItemAsync(T item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }
        public abstract T Find(T item);
        public abstract T Find(int id);

        public async Task<bool> UpdateItemAsync(T item)
        {
            var oldItem = Find(item);
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Find(id);
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await Task.FromResult(Find(id));
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
