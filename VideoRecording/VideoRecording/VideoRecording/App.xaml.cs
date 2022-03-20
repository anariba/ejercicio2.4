using System;
using System.IO;
using VideoRecording.Controller;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VideoRecording.Views;
using SQLite;

namespace VideoRecording
{
    public partial class App : Application
    {
        static Database database;
        public static Database BaseDatos
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM02VideoApp.db3"));
                }

                return database;
            }


        }
        public App()
        {

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
