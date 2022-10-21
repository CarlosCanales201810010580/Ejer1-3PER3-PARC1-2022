using Eje13DatosSqlite.Models;
using Eje13DatosSqlite.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Eje13DatosSqlite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var persona = new Personas
            {
                id = 0,
                nombres = txtNombre.Text,
                apellidos = txtApellido.Text,
                edad = txtEdad.Text,
                correo = txtEmail.Text,
                direccion = txtDireccion.Text,

            };

            var result = await App.DBase.SavePersona(persona);
            if (result > 0)
            {
                await DisplayAlert( "Aviso", "Registro Guardado", "OK");
            }
            else
            {
                await DisplayAlert( "Aviso", "Error al Registrar", "OK");
            }

        }

        private async void toolLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPersona());

        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            var persona = new Personas
            {
                id = Convert.ToInt32(txtId.Text),
                nombres = txtNombre.Text,
                apellidos = txtApellido.Text,
                edad = txtEdad.Text,
                correo = txtEmail.Text,
                direccion = txtDireccion.Text,

            };

            var result = await App.DBase.SavePersona(persona);
            if (result > 0)
            {
                await DisplayAlert("Aviso", "Registro Actualizado", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "Error al Actulizar", "OK");
            }
        }
    }
}
