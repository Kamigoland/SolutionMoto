using AppMobileMoto.Models;
using AppMobileMoto.Services;
using AppMobileMoto.Views;
using Xamarin.Forms;

namespace AppMobileMoto.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public IDataStore<Client> DataStore => DependencyService.Get<IDataStore<Client>>();

        private static int id;
        private static string username;
        private string password;
        private bool isactive;
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        public int ID
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public static int SessionId
        {
            get => id;
        }
        public string UserNameC
        {
            get => username;
            set => SetProperty(ref username, value);
        }
        public static string SessionUserName { 
            get=>username;
            }
        public string PasswordC
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public bool IsActive
        {
            get => isactive;
            set => SetProperty(ref isactive, value);
        }
        private async void OnLoginClicked(object obj)
        {
            var items = await DataStore.GetItemsAsync(true);
            bool check = false;
            foreach (var item in items)
            {
                if (item.Username == UserNameC)
                {
                    if (item.Password == PasswordC)
                    {
                        if (item.IsActive)
                        {
                            ID = item.IdUser;
                            UserNameC = item.Username;
                            check = true;
                            
                        }
                    }
                }
                //Items.Add(item);
            }
            if (check)
            {
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        }
    }
}
