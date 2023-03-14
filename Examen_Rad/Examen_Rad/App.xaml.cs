using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Examen_Rad
{
    public partial class App : Application
    {
        static Controlador.ControladorRegistro dbregistro;

        public static Controlador.ControladorRegistro DBRegistro
        {
            get
            {
                if (dbregistro == null)
                {
                    var dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var dbname = "Regis.db3";
                    dbregistro = new Controlador.ControladorRegistro(Path.Combine(dbpath, dbname));
                }

                return dbregistro;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vistas.InicioPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
