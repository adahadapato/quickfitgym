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
        }

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
