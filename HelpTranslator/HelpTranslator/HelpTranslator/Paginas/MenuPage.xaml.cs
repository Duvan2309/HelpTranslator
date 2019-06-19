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
            await DisplayAlert("Salir", "Quieres salir?", "OK");
            Application.Current.Quit();
        }

        private void BtnTraductor_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnVideos_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnLenguajes_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnApps_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnEmail_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnUbicacion_Clicked(object sender, EventArgs e)
        {

        }
    }
}