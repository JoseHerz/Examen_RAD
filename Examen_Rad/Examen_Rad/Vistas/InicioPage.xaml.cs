using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_Rad.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : ContentPage
    {
        public InicioPage()
        {
            InitializeComponent();
        }

        private void Registrar(object sender, EventArgs e)
        {
            var pageform = new Vistas.PageFormulario();
            Navigation.PushAsync(pageform);
        }

        private void Agenda_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            Agenda.ItemsSource = await App.DBRegistro.GetListAlumn();

        }
    }
}