using SlijterijXamarin.Data;
using SlijterijXamarin.Interfaces;
using SlijterijXamarin.Services;
using SlijterijXamarin.ViewModels.Base;
using SlijterijXamarin.Views;
using System;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SlijterijXamarin
{
    public partial class App : Application
    {
        //public static ProductManager ProdManager { get; private set; }
        //public static LoginManager LoginManager { get; private set; }

        public App()
        {
            InitializeComponent();
            
            //ProdManager = new ProductManager(new RestService(Client.Get));
            //LoginManager = new LoginManager(new LoginService(Client.Get));
            //MainPage = new NavigationPage(new LoginPage());
        }

        protected override async void OnStart()
        {
            await InitNavigation();
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
