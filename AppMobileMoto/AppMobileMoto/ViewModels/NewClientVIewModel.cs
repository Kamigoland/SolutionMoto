using System;
using AppMobileMoto.Models;
using AppMobileMoto.Services;
using Xamarin.Forms;


namespace AppMobileMoto.ViewModels
{
    public class NewClientViewModel : BaseViewModel
    {
        public IDataStore<Client> DataStore => DependencyService.Get<IDataStore<Client>>();
        private int idClient;
        private string name;
        private string adres;
        private string phoneNumber;
        public NewClientViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        private bool ValidateSave()
        {
            return IdClient > 0
                && !String.IsNullOrWhiteSpace(Name);
        }
        public int IdClient
        {
            get => idClient;
            set => SetProperty(ref idClient, value);
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
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
        private async void OnSave()
        {
            Client newItem = new Client()
            {
                IdClient = IdClient,
                Name = Name,
                Adres = Adres,
                PhoneNumber = PhoneNumber
            };
            await DataStore.AddItemAsync(newItem);
            await Shell.Current.GoToAsync("..");
        }
    }

}
