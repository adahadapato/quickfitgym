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
            //IsAdmin = false;
            //IsMember = false;
            BindingContext = this;
            _timer = new Timer(TimeSpan.FromSeconds(1), CountDown);
            TotalSeconds = _totalSeconds;
            _timer.Start();

            //this.CurrentItem.CurrentItem = flAdmin;

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
            //routes.Add("contactus", typeof(ContactUsPage));
            //routes.Add("photos", typeof(PhotosPage));
            routes.Add("aboutus", typeof(UpdateAboutUsPage));
            routes.Add("about", typeof(AboutPage));
            routes.Add("videos", typeof(VideosPage));
            routes.Add("admin", typeof(AdminPage));
            routes.Add("program", typeof(ProgramesPage));
            //routes.Add("logout", typeof(LoginPage));
            foreach (var i in routes)
            {
                Routing.RegisterRoute(i.Key, i.Value);
            }
        }

        private void Activate()
        {
            var IsAdmin =  Preferences.Get("IsAdmin", false);
            if(IsAdmin)
            {
                this.CurrentItem = flAdmin;
            }
            else
            {
                this.CurrentItem = flMembers;
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

       

        #region Landing Page

        private Timer _timer;

        private TimeSpan _totalSeconds = new TimeSpan(0, 0, 0, 10);
        public TimeSpan TotalSeconds
        {
            get { return _totalSeconds; }
            set
            {
                _totalSeconds = value;
                //Set(ref _totalSeconds, value);
                //OnPropertyChanged(nameof(TotalSeconds));
            }
        }

        private void CountDown()
        {
            if (_totalSeconds.TotalSeconds == 0)
            {
                //do something after hitting 0, in this example it just stops/resets the timer
                //StopTimerCommand();
                StopTimerCommand();
                //IsAdmin = Preferences.Get("IsAdmin", false);
                //IsMember = !IsAdmin;
                /*if (IsAdmin)
                {
                    flAdmin.IsVisible = true;
                }
                else
                {
                    flMembers.IsVisible = true;
                }*/
                Shell.Current.Navigation.PopToRootAsync();
                flLoading.IsVisible = false;
            }
            else
            {
                TotalSeconds = _totalSeconds.Subtract(new TimeSpan(0, 0, 0, 1));
            }
        }

        private void StopTimerCommand()
        {
            TotalSeconds = new TimeSpan(0, 0, 0, 10);
            _timer.Stop();
        }
        #endregion
    }
}
