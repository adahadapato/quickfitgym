using System;
using System.Windows.Input;
using quickfitgym.Models;
using quickfitgym.Services;
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
            GetData();
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

        private string _about;
        public string About
        {
            get { return _about; }
            set
            {
                SetProperty(ref _about, value);
                OnPropertyChanged(nameof(About));
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
                OnPropertyChanged(nameof(Message));
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var about = new AboutUs()
                    {
                        About = About,
                        Message = Message
                    };
                    var result = await ApiService.UpdateAboutUs(about);
                    //if (result)
                    //    await Shell.Current.Navigation.PopAsync();
                });
            }
        }

       
        private async void GetData()
        {
            var result = await ApiService.GetAboutUs();
            if(result!=null)
            {
                About = result.About;
                Message = result.Message;
            }
        }
    }
}