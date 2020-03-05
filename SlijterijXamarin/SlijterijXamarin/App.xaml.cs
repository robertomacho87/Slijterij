using SlijterijXamarin.Data;
using SlijterijXamarin.Views;
using System;
using System.Net;
using TodoREST;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SlijterijXamarin
{
    public partial class App : Application
    {
        public static ProductManager ProdManager { get; private set; }
        public App()
        {
        
            //InitializeComponent();
            ProdManager = new ProductManager(new RestService());
            MainPage = new NavigationPage(new ProductView());
            
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
