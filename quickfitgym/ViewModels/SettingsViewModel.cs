using System;
using quickfitgym.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel()
        {
            Change();
        }

        private async void Change()
        {
            var IsAdmin = Preferences.Get("IsAdmin", false);
            if(IsAdmin)
            {
                await Shell.Current.Navigation.PushAsync(new AdminPage());
            }
        }
    }
}
