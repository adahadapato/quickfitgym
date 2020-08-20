using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class ContactUsViewModel:BaseViewModel
    {
        public ContactUsViewModel()
        {
        }

        private async void PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException anEx)
            {
                await App.Current.MainPage.DisplayAlert("Error", anEx.Message, "Ok");
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }


        public async Task SendEmail(string body)
        {
            try
            {
                var recipients = new List<string>
                {
                    "healthylevel@gmail.com"
                };
                var message = new EmailMessage
                {
                    Subject = "Comment",
                    Body = body,
                    To = recipients,
                };
                await Email.ComposeAsync(message);
                
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                await App.Current.MainPage.DisplayAlert("Error", fbsEx.Message, "Ok");
                
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
               
            }
        }

      
        private string _number1 = "08035899115";
        public string Number1
        {
            get { return _number1; }
            set
            {
                SetProperty(ref _number1, value);
                OnPropertyChanged(Number1);
            }
        }

        private string _number2 = "09039046272";
        public string Number2
        {
            get { return _number2; }
            set
            {
                SetProperty(ref _number2, value);
                OnPropertyChanged(Number2);
            }
        }

        private string _emailAddress = "healthylevel@gmail.com";
        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
                SetProperty(ref _emailAddress, value);
                OnPropertyChanged(EmailAddress);
            }
        }

        private string _message;// = "healthylevel@gmail.com";
        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
                OnPropertyChanged(Message);
            }
        }

        public ICommand BackCommand { get
            {
                return new Command(async() =>
                {
                    await Shell.Current.Navigation.PopAsync();
                });
            }
        }
        public ICommand SendCommand
        {
            get
            {
                return new Command<string>(async (x) => await SendEmail(x));
            }
        }
        public ICommand CallNumber1Command
        {
            get
            {
                return new Command<string>((x) => PlacePhoneCall(x));
            }
        }
        public ICommand CallNumber2Command
        {
            get
            {
                return new Command<string>((x) => PlacePhoneCall(x));
            }
        }

        public ICommand SendEmailCommand
        {
            get
            {
                return new Command<string>(async (x) => await SendEmail(x));
            }
        }

    }
}
