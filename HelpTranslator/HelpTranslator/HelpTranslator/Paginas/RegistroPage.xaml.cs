using HelpTranslator.Modelos;
using HelpTranslator.Repositorios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelpTranslator.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPage : ContentPage
    {
        Usuario usuario = new Usuario();
        UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

        public RegistroPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            txtCorreo.ReturnCommand = new Command(() => txtNombre.Focus());
            txtNombre.ReturnCommand = new Command(() => txtClave.Focus());
            txtClave.ReturnCommand = new Command(() => txtConfirmaClave.Focus());
            txtConfirmaClave.ReturnCommand = new Command(() => txtCelular.Focus());
        }

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(txtNombre.Text)) || (string.IsNullOrWhiteSpace(txtCorreo.Text)) ||
                (string.IsNullOrWhiteSpace(txtClave.Text)) || (string.IsNullOrWhiteSpace(txtCelular.Text)) ||
                (string.IsNullOrEmpty(txtNombre.Text)) || (string.IsNullOrEmpty(txtCorreo.Text)) ||
                (string.IsNullOrEmpty(txtClave.Text)) || (string.IsNullOrEmpty(txtCelular.Text)))
            {
                await DisplayAlert("Ingrese datos", "Ingrese información valida", "OK");
            }
            else if (!string.Equals(txtClave.Text, txtConfirmaClave.Text))
            {
                lblMensajeClave.Text = "Contraseñas no coinciden";
                txtClave.Text = string.Empty;
                txtConfirmaClave.Text = string.Empty;
                lblMensajeClave.TextColor = Color.IndianRed;
                lblMensajeClave.IsVisible = true;
            }
            else if (txtCelular.Text.Length < 10)
            {
                txtCelular.Text = string.Empty;
                lblMensajeCelular.Text = "Ingrese un celular valido";
                lblMensajeCelular.TextColor = Color.IndianRed;
                lblMensajeCelular.IsVisible = true;
            }
            else
            {
                usuario.nombre = txtNombre.Text;
                usuario.correo = txtCorreo.Text;
                usuario.clave = txtClave.Text;
                usuario.celular = txtCelular.Text.ToString();
                try
                {
                    var retrunvalue = usuarioRepositorio.AgregarUsuario(usuario);
                    if (retrunvalue == "Usuario almacenado exitosamente")
                    {
                        await DisplayAlert("Registrar Usuario", retrunvalue, "OK");
                        await Navigation.PushAsync(new IngresoPage());
                    }
                    else
                    {
                        await DisplayAlert("Registrar Usuario", retrunvalue, "OK");
                        lblMensajeClave.IsVisible = false;
                        txtCorreo.Text = string.Empty;
                        txtNombre.Text = string.Empty;
                        txtClave.Text = string.Empty;
                        txtConfirmaClave.Text = string.Empty;
                        txtCelular.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IngresoPage());
        }
    }
}