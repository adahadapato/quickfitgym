using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using quickfitgym.ViewModels;
using quickfitgym.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace quickfitgym
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute("home", typeof(HomePage));
            //Routing.RegisterRoute("Program", typeof(ProgramesPage));
            RegisterRoutes();
            
            BindingContext = this;
        }

        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public ICommand NavigateCommand => new Command(Navigate);
        public ICommand LogoutCommand => new Command(async () => await PushPage(new LoginPage()));

        public ICommand ProgramsCommand
        {
            get
            {
                return new Command(async() =>
                {
                    if(IsAdmin)
                    {
                        await Shell.Current.Navigation.PushAsync(new ProgramesPage());
                    }
                    else
                    {
                        await Shell.Current.Navigation.PushAsync(new ProgramListPage());
                    }
                    Shell.Current.FlyoutIsPresented = false;
                });
            }
        }

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

        void RegisterRoutes()
        {
            //routes.Add("contactus", typeof(ContactUsPage));
            //routes.Add("photos", typeof(PhotosPage));
            //routes.Add("classes", typeof(ClassesPage));
            routes.Add("about", typeof(AboutPage));
            //routes.Add("videos", typeof(VideosPage));
            routes.Add("admin", typeof(AdminPage));
            routes.Add("program", typeof(ProgramesPage));
            //routes.Add("logout", typeof(LoginPage));
            foreach (var i in routes)
            {
                Routing.RegisterRoute(i.Key, i.Value);
            }
        }

        /*private bool _IsFirstTime;
        public bool IsFirstTime
        {
            get
            {
                return _IsFirstTime;
            }
        }*/

        public bool IsMember
        {
            get
            {
                return ! IsAdmin;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return Preferences.Get("IsAdmin", false);
            }
        }
    }
}
