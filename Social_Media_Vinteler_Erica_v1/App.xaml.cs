using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Social_Media_Vinteler_Erica_v1.Data;

namespace Social_Media_Vinteler_Erica_v1
{
    public partial class App : Application
    {
        static UsersDatabase udatabase;

        public static UsersDatabase Udatabase
        {
            get
            {
                if (udatabase == null)
                {
                    udatabase = new UsersDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Users.db3"));
                }
                return udatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SignupOrLoginPage());
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
