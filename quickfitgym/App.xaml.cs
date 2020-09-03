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
            Device.SetFlags(new[] { "Brush_Experimental", "SwipeView_Experimental" });
            ListenNetworkChanges();
            DependencyService.Register<MockDataStore>();
            var token = Preferences.Get("token", string.Empty);
            if (string.IsNullOrWhiteSpace(token))
            {
                MainPage = new NavigationPage(new RegisterPage());
            }
            else
            {
                 MainPage = new AppShell();
                //MainPage = new PicturePage();
            }
            //MainPage = new AppShell();
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

        private static void ListenNetworkChanges()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private static void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            CheckInternet();
        }

        private static void CheckInternet()
        {
            var onErrorPage = false;
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                onErrorPage = true;
                Current.MainPage.Navigation.PushAsync(new NoInternetConnectionPage());
            }
            else if (onErrorPage)
            {
                Current.MainPage.Navigation.PopAsync();
                onErrorPage = false;
            }
        }

    }
}
