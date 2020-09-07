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
            RegisterRoutes();
            //RegName = "Adahada Enobong";
            //RegEmail = "adahadapato@gmail.com";
            BindingContext = this;
            Activate();
        }

        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public ICommand NavigateCommand => new Command(Navigate);
        public ICommand LogoutCommand => new Command(async () => await PushPage(new LoginPage()));

        public ICommand ProgramsCommand
        {
            get
            {
                return new Command(() =>
                {
                   /* if(IsAdmin)
                    {
                        await Shell.Current.Navigation.PushAsync(new ProgramesPage());
                    }
                    else
                    {
                        await Shell.Current.Navigation.PushAsync(new ProgramListPage());
                    }
                    Shell.Current.FlyoutIsPresented = false;*/
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
            routes.Add("editprogram", typeof(EditProgramPage));
            routes.Add("customerdetails", typeof(CustomerDetailsPage));
            routes.Add("home", typeof(HomePage));
            routes.Add("aboutus", typeof(UpdateAboutUsPage));
            routes.Add("about", typeof(AboutPage));
            routes.Add("videos", typeof(VideosPage));
            routes.Add("admin", typeof(AdminPage));
            routes.Add("program", typeof(ProgramesPage));
            routes.Add("roles", typeof(RolesListPage));
            routes.Add("customerprofile", typeof(CustomerProfilePage));
            routes.Add("dietplan", typeof(DietPage));
            foreach (var i in routes)
            {
                Routing.RegisterRoute(i.Key, i.Value);
            }
        }

        public void Activate()
        {
            var IsAdmin = Preferences.Get("IsAdmin", false);
            if (IsAdmin)
            {
                this.CurrentItem = flAdmin;
                flMembers.IsEnabled = false;
                flMembers.IsVisible = false;
            }
            else
            {
                this.CurrentItem = flMembers;
                flAdmin.IsEnabled = false;
                flAdmin.IsVisible = false;
            }
        }
       
        public string RegName
        {
            get
            {
                return Preferences.Get("Name",string.Empty);
            }
        }

        public string RegEmail
        {
            get
            {
                return Preferences.Get("Email", string.Empty);
            }
        }

        public string RegPhone
        {
            get
            {
                return Preferences.Get("mobile", string.Empty);
            }
        }

       
    }
}
