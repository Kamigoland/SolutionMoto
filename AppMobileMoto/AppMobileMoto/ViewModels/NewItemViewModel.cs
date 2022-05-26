using AppMobileMoto.Models;
using AppMobileMoto.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AppMobileMoto.ViewModels
{
    public class NewItemViewModel : ANewItemViewModel<Item>
    {
        private string title;
        private string description;
        private int price;
        private bool negotiable;
        private int proDate;
        private int mileage;
        private int strokeCapacity;
        private int power;
        private int idbrand;
        private int idModel;
        private int idBodyType;
        private int idColor;
        public NewItemViewModel()
            : base()
        {
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(description);
        }
        //public List<Brand> Brands
        //{
        //    get
        //    {
        //        return DependencyService.Get<IDataStore<Brand>>().Items;
        //    }
        //}
        //public Brand SelectedBrand
        //{
        //    get => selectedBrand;
        //    set => SetProperty(ref selectedBrand, value);
        //}
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public int Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
        public int IdModel
        {
            get => idModel;
            set => SetProperty(ref idModel, value);
        }
        public int IdBrand
        {
            get => idbrand;
            set => SetProperty(ref idbrand, value);
        }
        public int IdColor
        {
            get => idColor;
            set => SetProperty(ref idColor, value);
        }
        public int IdBodyType
        {
            get => idBodyType;
            set => SetProperty(ref idBodyType, value);
        }
        public bool Negotiable
        {
            get => negotiable;
            set => SetProperty(ref negotiable, value);
        }
        public int ProDate
        {
            get => proDate;
            set => SetProperty(ref proDate, value);
        }
        public int Mileage
        {
            get => mileage;
            set => SetProperty(ref mileage, value);
        }
        public int StrokeCapacity
        {
            get => strokeCapacity;
            set => SetProperty(ref strokeCapacity, value);
        }
        public int Power
        {
            get => power;
            set => SetProperty(ref power, value);
        }
        public override Item SetItem()
        {
            Item newItem = new Item()
            {
                IdAnnouncement = 0,
                IdUser = LoginViewModel.SessionId,
                IdBrand = IdBodyType,
                IdModel = IdModel,
                IdBodyType = IdBodyType,
                IdColor = idColor,
                Title = Title,
                Description = Description,
                Price = Price,
                Negotiable = Negotiable,
                ProDate = ProDate,
                Mileage = Mileage,
                StrokeCapacity = StrokeCapacity,
                Power = Power,
                IsActive = true

            };
            return newItem;
        }
    }

}
