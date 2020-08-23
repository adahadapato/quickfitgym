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

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetProperty(ref _firstName, value);
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName, value);
                OnPropertyChanged(nameof(LastName));
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
                    if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(FirstName)
                || string.IsNullOrWhiteSpace(Password))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "All fields are mandatory", "Ok");
                        return;
                    }

                    if (Password != ConfirmPasword)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Password and Confirm Pasword do not match", "Ok");
                        return;
                    }
                    var model = new Register()
                    {
                        Email = Email,
                        FirstName = FirstName,
                        LasstName = LastName,
                        Mobile = Phone,
                        RoleName = "Member",
                        EmailConfirmed = false,
                        Password = Password
                    };
                    var result = await ApiService.Register(model);
                    if (result)
                    {
                        await Shell.Current.Navigation.PopModalAsync();
                        await Shell.Current.Navigation.PushModalAsync(new LoginPage());
                    }
                       
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Unable to complete the registration", "Ok");
                        return;
                    }
                });
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async() =>
                {
                    await Shell.Current.Navigation.PopModalAsync();
                    await Shell.Current.Navigation.PushModalAsync(new LoginPage());
                });
            }
        }
    }
}
