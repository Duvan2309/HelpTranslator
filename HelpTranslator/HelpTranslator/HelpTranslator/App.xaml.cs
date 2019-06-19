using HelpTranslator.Paginas;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelpTranslator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                //BarBackgroundColor = Color.FromHex("#cc33ff")
            };
        }

        public static async void NavigationPage(Page name)
        {
            Application.Current.MainPage = new NavigationPage(new MenuPage());
            await name.Navigation.PushAsync(new MenuPage());
        }

        internal static async Task NavigationPageAsync(Page name)
        {
            Application.Current.MainPage = new NavigationPage(new MenuPage());
            await name.Navigation.PushAsync(new MenuPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
