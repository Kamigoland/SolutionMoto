using AppMobileMoto.Models;
using AppMobileMoto.Services;
using AppMobileMoto.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace AppMobileMoto.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        private int itemId;
        private string text;
        private string description;
        private string username;
        private string brandname;
        private string modelname;
        private string colorname;
        private int price;
        private string negotiable;
        private int? prodate;
        private int? mileage;
        private int? strokecapacity;
        private int? power;
        public int Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string UserName { get => username; set => SetProperty(ref username, value); }
        public string BrandName { get=>brandname; set=>SetProperty(ref brandname, value); }
        public string ModelName { get=>modelname; set=>SetProperty(ref modelname, value); }
        public string ColorName { get=>colorname; set=>SetProperty(ref colorname, value); }
        public string Title { get=>text; set=>SetProperty(ref text, value); }
        //public string Description { get; set; }
        public int Price { get=>price; set=>SetProperty(ref price, value); }
        public string Negotiable { get=>negotiable; set=>SetProperty(ref negotiable, value); }
        public int? ProDate { get => prodate; set => SetProperty(ref prodate, value); }
        public int? Mileage { get => mileage; set=>SetProperty(ref mileage, value); }
        public int? StrokeCapacity { get=>strokecapacity; set=>SetProperty(ref strokecapacity, value); }
        public int? Power { get=>power; set=>SetProperty(ref power, value); }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }
        public Command MsgSeller { get; }
        public ItemDetailViewModel()
        {
            MsgSeller = new Command(MsgSellers);
        }
        private async void MsgSellers()
        {
            await Shell.Current.GoToAsync($"{nameof(MessageDetailPage)}?{nameof(MessageDetailViewModel.ItemId)}={ItemId}");
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.IdAnnouncement;
                Text = item.Title;
                Description = item.Description;
                UserName = item.UserName;
                Title = item.Title;
                BrandName = item.BrandName;
                ModelName = item.ModelName;
                ColorName = item.ColorName;
                Price = item.Price;
                if (item.Negotiable)
                {
                    Negotiable = "Negotiable";
                }
                else
                {
                    Negotiable = "Not negotiable";
                }
                ProDate = item.ProDate;
                Mileage = item.Mileage;
                StrokeCapacity = item.StrokeCapacity;
                Power = item.Power;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
