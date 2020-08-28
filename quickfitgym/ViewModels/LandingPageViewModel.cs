using System;
using quickfitgym.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class LandingPageViewModel :BaseViewModel
    {
        private Timer _timer;

        private TimeSpan _totalSeconds = new TimeSpan(0, 0, 0, 10);
        public TimeSpan TotalSeconds
        {
            get { return _totalSeconds; }
            set
            {
                SetProperty(ref _totalSeconds, value);
                OnPropertyChanged(nameof(TotalSeconds));
            }
        }
        public LandingPageViewModel()
        {
            //_timer = new Timer(TimeSpan.FromSeconds(1), CountDown);
            //TotalSeconds = _totalSeconds;
            //_timer.Start();
        }

        private void CountDown()
        {
            if (_totalSeconds.TotalSeconds == 0)
            {
                //do something after hitting 0, in this example it just stops/resets the timer
                //StopTimerCommand();
                StopTimerCommand();
                var IsAdmin = Preferences.Get("IsAdmin", false);
                if (IsAdmin)
                {
                    Shell.Current.Navigation.PushAsync(new AdminPage());
                }
                    
                else
                    Shell.Current.Navigation.PopAsync();
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
    }
}
