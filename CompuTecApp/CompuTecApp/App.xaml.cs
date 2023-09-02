using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;


namespace CompuTecApp
{
    public partial class App : Application
    {
        private static SQLiteHelper _database;
        public static SQLiteHelper Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CompuTecApp.db3"));
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MiPaginaControl();
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
