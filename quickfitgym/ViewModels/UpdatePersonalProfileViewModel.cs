using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using quickfitgym.Models;
using quickfitgym.Services;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class UpdatePersonalProfileViewModel : BaseViewModel
    {
        public ObservableCollection<string> OccupationCollection { get; set; }
        public UpdatePersonalProfileViewModel(Customer customer)
        {
            OccupationCollection = new ObservableCollection<string>()
            {
                "Civil Cervant",
                "Student",
                "Self Employed"
            };
            Init(customer);
        }

        public UpdatePersonalProfileViewModel() { }

        private void Init(Customer customer)
        {
            About = customer.AboutMe;
            Occupation = customer.Occupation;
            CustomerName = customer.Name;
            Address = customer.ContactAddress;
            Country = customer.Country;
            Id = customer.
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

        private string _country;
        public string Country
        {
            get { return _country; }
            set
            {
                SetProperty(ref _country, value);
                OnPropertyChanged(nameof(Country));
            }
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value);
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _occupation;
        public string Occupation
        {
            get { return _occupation; }
            set
            {
                SetProperty(ref _occupation, value);
                OnPropertyChanged(nameof(Occupation));
            }
        }

       
        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                SetProperty(ref _customerName, value);
                OnPropertyChanged(nameof(CustomerName));
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                SetProperty(ref _address, value);
                OnPropertyChanged(nameof(Address));
            }
        }

        private DateTime _dateofBirth;
        public DateTime DateOfBirth
        {
            get { return _dateofBirth; }
            set
            {
                SetProperty(ref _dateofBirth, value);
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var customer = new Customer()
                    {
                        AboutMe = About,
                        ContactAddress = Address,
                        Country = Country,
                        DateOfBirth = DateOfBirth,
                    };
                    var result = await ApiService.UpdateCustomer(customer);
                });
            }
        }
    }
}
