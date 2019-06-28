using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelpTranslator.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }

        public async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            bool salir = await DisplayAlert("Salir", "Quieres salir?", "Si", "No");
            if (salir)
            {
                Application.Current.Quit();
                await Navigation.PushAsync(new MainPage());
            }
        }

        private async void BtnTraductor_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new TraductorPage());
        }

        private async void BtnVideos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideosPage());
        }

        private async void BtnLenguajes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LenguajesPage());
        }

        private async void BtnApps_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppsPage());
        }

        private async void BtnEmail_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmailPage());
        }

        private async void BtnUbicacion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UbicacionPage());
        }
    }
}