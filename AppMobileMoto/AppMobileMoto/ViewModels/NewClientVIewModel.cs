using AppMobileMoto.Models;
using System;


namespace AppMobileMoto.ViewModels
{
    public class NewClientViewModel : ANewItemViewModel<Client>
    {
        private string name;
        private string adres;
        private bool phoneNumber;
        public NewClientViewModel()
            : base()
        {
        }
        public override bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name);
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Adres
        {
            get => adres;
            set => SetProperty(ref adres, value);
        }
        public bool PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }
        public override Client SetItem()
        {
            Client newItem = new Client()
            {
                IdUser = 0,
                Username = Name,
                Password = adres,
                IsActive = PhoneNumber
            };
            return newItem;
        }
    }
}
