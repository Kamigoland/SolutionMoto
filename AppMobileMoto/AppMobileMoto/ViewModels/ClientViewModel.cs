using AppMobileMoto.Models;
using AppMobileMoto.Services;
using AppMobileMoto.ViewModels;
using AppMobileMoto.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMoblieMoto.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        public IDataStore<Client> DataStore => DependencyService.Get<IDataStore<Client>>();
        private Client _selectedItem;
        public ObservableCollection<Client> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Client> ItemTapped { get; }

        public ClientViewModel()
        {
            Title = "Clients";
            Items = new ObservableCollection<Client>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<Client>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Client SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
             await Shell.Current.GoToAsync(nameof(NewClientPage));
        }

        async void OnItemSelected(Client item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.IdClient}");
        }
    }
}
