using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using quickfitgym.Models;
using quickfitgym.Services;
using quickfitgym.Views;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        public ObservableCollection<Members> MembersCollection { get; private set; }
        public ObservableCollection<Members> TrainersCollection { get; private set; }
        public CustomerViewModel()
        {
            Title = "Members";
            MembersCollection = new ObservableCollection<Members>();
            TrainersCollection = new ObservableCollection<Members>();
            GetMembers();
        }

        private Members _selectedCustomer;
        public Members SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                SetProperty(ref _selectedCustomer, value);
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        private Members _selectedTrainer;
        public Members SelectedTrainer
        {
            get { return _selectedTrainer; }
            set
            {
                SetProperty(ref _selectedTrainer, value);
                OnPropertyChanged(nameof(SelectedTrainer));
            }
        }

        private async void GetMembers()
        {
            var members = await ApiService.GetMembers();
            if (members != null)
            {
                members.ForEach(x => { x.RegistrationDate = x.JoinDate.ToString("dd/MM/yyyy");
                    x.PhotoUrl = (string.IsNullOrWhiteSpace(x.PhotoUrl)) ? "NormalProfile.png" : x.PhotoUrl;
                });
                
                foreach (var m in members)
                {
                    MembersCollection.Add(m);
                }
            }
        }

        public ICommand SelectedCustomerCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var item = SelectedCustomer;
                    await Shell.Current.Navigation.PushAsync(new CustomerProfilePage(item));
                });
            }
        }

        public ICommand SelectedTrainerCommand
        {
            get
            {
                return new Command( () =>
                {
                    var item = SelectedTrainer;
                    //await Shell.Current.GoToAsync("customerprofile");
                });
            }
        }
    }
}
