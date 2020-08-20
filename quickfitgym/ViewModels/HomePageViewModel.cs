using System;
using quickfitgym.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class HomePageViewModel:BaseViewModel
    {
        public HomePageViewModel()
        {
            CheckRegistration();
        }

        private async void CheckRegistration()
        {
            var token = Preferences.Get("token", string.Empty);
            if (string.IsNullOrWhiteSpace(token))
            {
               await Shell.Current.Navigation.PushModalAsync(new RegisterPage());
            }
        }
    }
}
