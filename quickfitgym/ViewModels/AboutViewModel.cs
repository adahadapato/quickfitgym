using System;
using System.Windows.Input;
using quickfitgym.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        }

        public ICommand OpenWebCommand { get; }

        public ICommand ContactCommand
        {
            get
            {
                return new Command(async() =>
                {
                    await Shell.Current.Navigation.PushAsync(new ContactUsPage());
                });
            }
        }
    }
}