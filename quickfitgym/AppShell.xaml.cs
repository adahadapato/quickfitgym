using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using quickfitgym.ViewModels;
using quickfitgym.Views;
using Xamarin.Forms;

namespace quickfitgym
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            RegistrRoutes();
            BindingContext = this;
        }

        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public ICommand NavigateCommand => new Command(Navigate);
        //public ICommand SettingsCommand => new Command(async () => await PushPage(new OptionsPage()));

        private async Task PushPage(Page page)
        {
            await Shell.Current.Navigation.PushModalAsync(page);
            Shell.Current.FlyoutIsPresented = false;
        }

        private async void Navigate(object route)
        {
            ShellNavigationState state = Shell.Current.CurrentState;
            await Shell.Current.GoToAsync($"{state.Location}/{route.ToString()}");
            Shell.Current.FlyoutIsPresented = false;
        }

        void RegistrRoutes()
        {
            //routes.Add("articles", typeof(ArticlesPage));
            //routes.Add("photos", typeof(PhotosPage));
            //routes.Add("classes", typeof(ClassesPage));
            routes.Add("about", typeof(AboutPage));
            //routes.Add("videos", typeof(VideosPage));
            routes.Add("admin", typeof(AdminPage));
            routes.Add("programmes", typeof(ProgramesPage));
            routes.Add("logout", typeof(LoginPage));
            foreach (var i in routes)
            {
                Routing.RegisterRoute(i.Key, i.Value);
            }
        }
    }
}
