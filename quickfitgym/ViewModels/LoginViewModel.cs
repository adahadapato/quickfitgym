using quickfitgym.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

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


        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
