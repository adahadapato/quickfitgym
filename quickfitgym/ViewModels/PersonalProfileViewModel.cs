using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using quickfitgym.Models;
using quickfitgym.Services;
using quickfitgym.Views;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class PersonalProfileViewModel : BaseViewModel
    {
        public ObservableCollection<Pictures> PictureColection { get; set; }
        public PersonalProfileViewModel()
        {
            Title = "";
            //ProfilePicture = "profile02";
            //CoverPicture = ProfilePicture;
            PictureColection = new ObservableCollection<Pictures>
            {
                new Pictures { Picture = "profile02"},
                new Pictures { Picture = "profile02"},
                new Pictures { Picture = "profile02"},
                new Pictures { Picture = "profile02"},
                new Pictures { Picture = "profile02"},
                new Pictures { Picture = "profile02"}
            };
            Init();
        }

       

        private async void Init()
        {
            Isloaded = true;
            var customer = await ApiService.GetCustomer();
            if (customer != null)
            {
                CustomerName = customer.Name;
                Occupation = customer.Occupation;
                DateOfBirth = "07/10/2020";// customer.DateOfBirth.ToString();// "ddd, dd MM yyyy");
                About = customer.AboutMe;
                ProfilePicture = customer.FullProfilePictUrl;
                CoverPicture = customer.FullCoverPictUrl;
                About = "With an amacing cinematic career of more than five decades, Dennis Hopper was a multi-talent and unconventional actor/director, regarded by many as one of the...";
            }
            Isloaded = false;
        }

        private bool _isLoaded;
        public bool Isloaded
        {
            get { return _isLoaded; }
            set
            {
                SetProperty(ref _isLoaded, value);
                OnPropertyChanged(nameof(Isloaded));
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

        private string _dateOfBirth;
        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                SetProperty(ref _dateOfBirth, value);
                OnPropertyChanged(nameof(DateOfBirth));
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

        private string _profilePicture;
        public string ProfilePicture
        {
            get { return _profilePicture; }
            set
            {
                SetProperty(ref _profilePicture, value);
                OnPropertyChanged(nameof(ProfilePicture));
            }
        }


        private string _coverPicture;
        public string CoverPicture
        {
            get { return _coverPicture; }
            set
            {
                SetProperty(ref _coverPicture, value);
                OnPropertyChanged(nameof(CoverPicture));
            }
        }

        public ICommand ChangePictureCommand
        {
            get
            {
                return new Command(async (e) =>
                {
                    string Picture = "";
                    var param = e as string;
                    switch (param)
                    {
                        case "profilepict":
                            Picture = "Profile";
                            break;
                        case "coverpict":
                            Picture = "Cover";
                            break;
                        default:
                            break;
                    }
                    if (!string.IsNullOrWhiteSpace(Picture))
                        await Shell.Current.Navigation.PushAsync(new PicturePage(Picture));
                });
            }
        }
    }
}
