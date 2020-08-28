using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using quickfitgym.Services;
using quickfitgym.Views;
using Xamarin.Essentials;

namespace quickfitgym
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "Brush_Experimental" });
            DependencyService.Register<MockDataStore>();
            /*var token = Preferences.Get("token", string.Empty);
            if (string.IsNullOrWhiteSpace(token))
            {
                MainPage = new NavigationPage(new RegisterPage());
            }
            else
            {
                MainPage = new AppShell();
            }*/
            MainPage = new AppShell();
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
