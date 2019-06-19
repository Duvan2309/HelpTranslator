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
    public partial class IngresoPage : ContentPage
    {
        UsuarioRepositorio datosUsuario;
        public IngresoPage()
        {
            InitializeComponent();
            datosUsuario = new UsuarioRepositorio();
            NavigationPage.SetHasBackButton(this, false);
            txtCorreo.ReturnCommand = new Command(() => txtClave.Focus());
            txtClave1.ReturnCommand = new Command(() => txtClave2.Focus());
            var forgetpassword_tap = new TapGestureRecognizer();
            forgetpassword_tap.Tapped += Forgetpassword_tap_Tapped;
            lblOlvido.GestureRecognizers.Add(forgetpassword_tap);
        }

        private void Forgetpassword_tap_Tapped(object sender, EventArgs e)
        {
            popupLoadingView.IsVisible = true;
        }

        string logesh;

        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            if (txtCorreo.Text != null && txtClave.Text != null)
            {
                var validData = datosUsuario.ValidarIngreso(txtCorreo.Text, txtClave.Text);
                if (validData)
                {
                    popupLoadingView.IsVisible = false;
                    await App.NavigationPageAsync(IngresoPagina);
                }
                else
                {
                    popupLoadingView.IsVisible = false;
                    await DisplayAlert("Ingreso invalido", "Usuario y/o contraseña incorrectos", "OK");
                }
            }
            else
            {
                popupLoadingView.IsVisible = false;
                await DisplayAlert("Ingreso invalido", "Ingrese su correo y contraseña por favor", "OK");
            }
        }

        private async void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(txtValidacionIdUsuario.Text)) || (string.IsNullOrWhiteSpace(txtValidacionIdUsuario.Text)))
            {
                await DisplayAlert("Alerta", "Ingrese correo electronico", "OK");
            }
            else
            {
                logesh = txtValidacionIdUsuario.Text;
                var textresult = datosUsuario.ValidarActualizacionUsuario(txtValidacionIdUsuario.Text);
                if (textresult)
                {
                    popupLoadingView.IsVisible = false;
                    passwordView.IsVisible = true;
                }
                else
                {
                    await DisplayAlert("Usuario no existe", "Ingrese un correo valido", "OK");
                }
            }
        }

        private async void BtnEnviar_Clicked(object sender, EventArgs e)
        {
            if (!string.Equals(txtClave1.Text, txtClave2.Text))
            {
                lblMensaje.Text = "Ingese la misma contraseña";
                lblMensaje.TextColor = Color.IndianRed;
                lblMensaje.IsVisible = true;
            }
            else if ((string.IsNullOrWhiteSpace(txtClave1.Text)) || (string.IsNullOrWhiteSpace(txtClave2.Text)))
            {
                await DisplayAlert("Alerta", " Ingrese contraseñas", "OK");
            }
            else
            {
                try
                {
                    var return1 = datosUsuario.ActualizarUsuario(logesh, txtClave1.Text);
                    passwordView.IsVisible = false;
                    if (return1)
                    {
                        await DisplayAlert("Contraseña actualizada", "Datos de usuario actualizado", "OK");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}