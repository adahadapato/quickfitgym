using quickfitgym.Services;
using quickfitgym.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        
        public LoginViewModel()
        {
            if (IsChecked)
            {
                Preferences.Get("Email", string.Empty);
                Preferences.Get("Password", string.Empty);
            }
            //LoginCommand = new Command(OnLoginClicked);
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                SetProperty(ref _phone, value);
                OnPropertyChanged(nameof(Phone));
            }
        }

        private bool _IsChecked;
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                SetProperty(ref _IsChecked, value);
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async() =>
                {
                    if (string.IsNullOrWhiteSpace(Email) && string.IsNullOrWhiteSpace(Phone))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Please provide Email or Phone Number", "Ok");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(Password))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Please provide Password", "Ok");
                        return;
                    }

                    var result = await ApiService.Login(Email, Password);
                    if (result)
                    {
                        Preferences.Set("Email", Email);
                        Preferences.Set("Password", Password);
                        await Shell.Current.Navigation.PopModalAsync();
                        //Application.Current.MainPage = new AppShell();
                    }
                    else
                        return;
                });
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async() =>
                {
                    await Shell.Current.Navigation.PushModalAsync(new RegisterPage());
                });
            }
        }
        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
