using System;
using System.Collections.ObjectModel;
using quickfitgym.Models;

namespace quickfitgym.ViewModels
{
    public class CustomerProfileViewModel : BaseViewModel
    {
        public ObservableCollection<Pictures> PictureColection { get; set; }
        public CustomerProfileViewModel()
        {
            ProfileImage = "profile02";
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

        private string _profileImage;
        public string ProfileImage
        {
            get { return _profileImage; }
            set
            {
                SetProperty(ref _profileImage, value);
                OnPropertyChanged(nameof(ProfileImage));
            }
        }
    }
}
