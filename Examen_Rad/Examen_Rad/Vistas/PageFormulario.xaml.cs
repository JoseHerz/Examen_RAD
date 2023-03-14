using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_Rad.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageFormulario : ContentPage
    {
        public PageFormulario()
        {
            InitializeComponent();
        }

        private void Telefono_invalido(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                if (!int.TryParse(e.NewTextValue, out int result))
                {
                    Telefono.TextColor = Color.Red;
                    DisplayAlert("Error", "Este campo solo admite números.", "OK");
                }
                else
                {
                    Telefono.TextColor = Color.Default;
                }
            }
        }
        private void Limpiar(object sender, EventArgs e)
        {

            Nombre.Text = "";
            Apellido.Text = "";
            Telefono.Text = "";
            Edad.Text = "";
            Nota.Text = "";
            Seleccion.SelectedIndex = -1;
        }

        private async void Guardar(object sender, EventArgs e)
        {
            var alum = new Modelo.ClaseRegistro
            {
                nombres = Nombre.Text,
                apellidos = Apellido.Text,
                notas = Nota.Text,
                edad = int.Parse(Edad.Text),
                pais = Seleccion.SelectedItem.ToString(),
                telefono = int.Parse(Telefono.Text),


            };

            if (await App.DBRegistro.SaveAlum(alum) > 0)
                await DisplayAlert("Aviso", "Alumno Ingresado", "OK");
            else
                await DisplayAlert("Aviso", "Error", "OK");


            var page = new Vistas.ContenidoPage();
            page.BindingContext = alum;
            await Navigation.PushAsync(page);


        }
    }
}