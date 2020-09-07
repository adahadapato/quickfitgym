using System;
using System.Collections.Generic;
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
        public ObservableCollection<Customer> MembersCollection { get; private set; }
        //public ObservableCollection<Members> TrainersCollection { get; private set; }
        public CustomerViewModel()
        {
            Title = "Customers";
            MembersCollection = new ObservableCollection<Customer>();
            //TrainersCollection = new ObservableCollection<Members>();
            GetAllCustomers();
            CahedDuration = TimeSpan.FromMinutes(2);
        }
        //https://quickfit.zayun.biz/wwwroot/Pc1965299-ea06-42bf-ab53-e30f234f6993.jpg
        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                SetProperty(ref _selectedCustomer, value);
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        private TimeSpan _cahedDuration;
        public TimeSpan CahedDuration
        {
            get { return _cahedDuration; }
            set
            {
                SetProperty(ref _cahedDuration, value);
                OnPropertyChanged(nameof(CahedDuration));
            }
        }

        private List<Customer> cusomers = new List<Customer>();
        private async void GetAllCustomers()
        {
            cusomers = await ApiService.GetAllCustomers();
            if (cusomers != null)
            {
                cusomers.ForEach(x => { x.RegistrationDate = x.JoinDate.ToString("dd/MM/yyyy");
                    //x.FullProfilePictUrl = (string.IsNullOrWhiteSpace(x.ProfilePictUrl)) ? "NormalProfile.png" : x.ProfilePictUrl;
                    
                });
                
                foreach (var m in cusomers)
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
                    //var item = SelectedTrainer;
                    //await Shell.Current.GoToAsync("customerprofile");
                });
            }
        }
    }
}
