using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using S13_LocalDatabase.DataContext;
using S13_LocalDatabase.Interfaces;
using S13_LocalDatabase.Views;


namespace S13_LocalDatabase
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            GetContext().Database.EnsureCreated();
            MainPage = new NavigationPage(new AlbumesPage());
        }

        // Método para obtener el contexto cuando se inicia la aplicación
        public static AppDBContext GetContext()
        {
            string DbPath = DependencyService.Get<IConfigDataBase>().GetFullPath("efCore.db");

            return new AppDBContext(DbPath);
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
