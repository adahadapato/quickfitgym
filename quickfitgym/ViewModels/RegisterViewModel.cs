using System;
using System.Windows.Input;
using quickfitgym.Models;
using quickfitgym.Services;
using quickfitgym.Views;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        public RegisterViewModel()
        {
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

       
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                OnPropertyChanged(nameof(Name));
            }
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

        private string _confirmPassword;
        public string ConfirmPasword
        {
            get { return _confirmPassword; }
            set
            {
                SetProperty(ref _confirmPassword, value);
                OnPropertyChanged(nameof(ConfirmPasword));
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async() =>
                {
                    if (string.IsNullOrWhiteSpace(Email))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Supply value for Email", "CANCEL");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(Phone) )
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Supply value for Phone", "CANCEL");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(Name))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Supply value for Name", "CANCEL");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(Password))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Supply value for Password", "CANCEL");
                        return;
                    }

                    if (Password != ConfirmPasword)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Password and Confirm Password do not match", "CANCEL");
                        return;
                    }
                    var model = new Register()
                    {
                        Email = Email,
                        Name = Name,
                        Mobile = Phone,
                        RoleName = "Member",
                        EmailConfirmed = true,
                        Password = Password
                    };
                    var result = await ApiService.Register(model);
                    if (result)
                    {
                        Application.Current.MainPage =new NavigationPage(new LoginPage());
                    }
                });
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(() =>
                {
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                });
            }
        }
    }
}
