using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ImageToArray;
using Plugin.Media;
using Plugin.Media.Abstractions;
using quickfitgym.Models;
using quickfitgym.Views;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class CustomerProfileViewModel : BaseViewModel
    {
        public ObservableCollection<Pictures> PictureColection { get; set; }
        public CustomerProfileViewModel()
        {
            Title = "";
            ProfilePicture = "profile02";
            CoverPicture = ProfilePicture;
            PictureColection = new ObservableCollection<Pictures>
            {
                new Pictures { Picture = "profile02"},
                new Pictures { Picture = "profile02"},
                new Pictures { Picture = "profile02"},
                new Pictures { Picture = "profile02"},
                new Pictures { Picture = "profile02"},
                new Pictures { Picture = "profile02"}
            };
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

        private Image _profilePict;
        public Image ProfilePict
        {
            get { return _profilePict; }
            set
            {
                SetProperty(ref _profilePict, value);
                OnPropertyChanged(nameof(ProfileImage));
            }
        }

        private Image _imgCoverPict;
        public Image IMGCoverPict
        {
            get { return _imgCoverPict; }
            set
            {
                SetProperty(ref _imgCoverPict, value);
                OnPropertyChanged(nameof(IMGCoverPict));
            }
        }

        private string _coverPict;
        public string CoverPict
        {
            get { return _coverPict; }
            set
            {
                SetProperty(ref _coverPict, value);
                OnPropertyChanged(nameof(CoverPict));
            }
        }

        public ICommand ProfileImageCommand
        {
            get
            {
                return new Command(async(e) =>
                {
                    string Picture="";
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
