using HelpTranslator.Modelos;
using HelpTranslator.Repositorios;
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
    public partial class LenguajesPage : ContentPage
    {
        LenguajeRepositorio datosLenguajes = new LenguajeRepositorio();
        public LenguajesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
            var datos = datosLenguajes.ObtenerLenguajes();
            listaLenguajes.ItemsSource = datos;
        }

        private async void Salir_OnClicked(object sender, EventArgs e)
        {
            bool salir = await DisplayAlert("Salir", "Quieres salir?", "Si", "No");
            if (salir)
            {
                Application.Current.Quit();
                await Navigation.PushAsync(new MainPage());
            }
            
        }

        private void ListaLenguajes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var dato = e.SelectedItem as Lenguajes;

            Device.OpenUri(new Uri(dato.link));
        }
    }
}