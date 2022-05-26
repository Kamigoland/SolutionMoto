using AppMobileMoto.Services;
using Xamarin.Forms;

namespace AppMobileMoto
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<BrandDataStore>();
            DependencyService.Register<MessagesDataStore>();
            DependencyService.Register<BillDataStore>();
            DependencyService.Register<ItemDataStore>();
            DependencyService.Register<ClientDataStore>();
            DependencyService.Register<ServiceReferenceMoto.MotoServiceClient>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
