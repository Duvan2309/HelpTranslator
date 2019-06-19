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
    public partial class PrincipalPage : ContentPage
    {
        UsuarioRepositorio datosUsuarios = new UsuarioRepositorio();
        public PrincipalPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            var datos = datosUsuarios.ObtenerUsuarios();
            listaUsuarios.ItemsSource = datos;
        }

        private async void Salir_OnClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Salir", "Quieres salir?", "OK");
            Application.Current.Quit();
        }
    }
}