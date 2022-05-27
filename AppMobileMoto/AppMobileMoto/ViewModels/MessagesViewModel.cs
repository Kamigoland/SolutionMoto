using AppMobileMoto.Models;
using AppMobileMoto.Services;
using AppMobileMoto.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileMoto.ViewModels
{
    class MessagesViewModel : BaseViewModel
    {
        public IDataStore<Messages> DataStore => DependencyService.Get<IDataStore<Messages>>();
        private Messages _selectedItem;

        public ObservableCollection<Messages> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Messages> ItemTapped { get; }

        public MessagesViewModel()
        {
            Title = "Messages";
            Items = new ObservableCollection<Messages>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Messages>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);

                int[] check = new int[1000];
                for (int i = 0; i < 1000; i++)
                {
                    check[i] = 0;
                }
                foreach (var item in items)
                {
                    if (check[item.IdAnnouncement] == 0)
                    {
                        Items.Add(item);
                        check[item.IdAnnouncement] = 1;
                    }

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

        public Messages SelectedItem
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
            //await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Messages item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(MessageDetailPage)}?{nameof(MessageDetailViewModel.ItemId)}={item.IdAnnouncement}");
        }
    }
}
