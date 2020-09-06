using System;
using System.Windows.Input;
using ImageToArray;
using Plugin.Media;
using Plugin.Media.Abstractions;
using quickfitgym.Models;
using quickfitgym.Services;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class PicturePageViewModel : BaseViewModel
    {
        private MediaFile file;
        private string Picture;
        public PicturePageViewModel(string Picture)
        {
            Title = $"Change {Picture} Picture";
            this.Picture = Picture;
            IsLoading = false;
        }

        public PicturePageViewModel()
        {
        }



        private Image _img;
        public Image IMG
        {
            get { return _img; }
            set
            {
                SetProperty(ref _img, value);
                OnPropertyChanged(nameof(IMG));
            }
        }

        private string _pict;
        public string Pict
        {
            get { return _pict; }
            set
            {
                SetProperty(ref _pict, value);
                OnPropertyChanged(nameof(Pict));
            }
        }

        public ICommand TakePictureCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                    file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        SaveToAlbum = true,
                        Directory = "Quickfit",
                        //Name = "test.jpg",
                        PhotoSize = PhotoSize.Custom,
                        CustomPhotoSize = 30,
                        CompressionQuality = 60
                    });

                    if (file == null)
                        return;

                    await Application.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");

                    IMG.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        return stream;
                    });
                });
            }
        }

        public ICommand PicPictureCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Feature is not supported on this device", "CANCEL");
                        return;
                    }

                    file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    });


                    if (file == null)
                        return;

                    //await Application.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");
                    Pict =    file.Path;
                    IMG = new Image();
                    IMG.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();

                        return stream;
                    });
                });
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                SetProperty(ref _isLoading, value);
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new Command(() =>
                {
                    switch (Picture)
                    {
                        case "Profile":
                            SaveProfilePicture();
                            break;
                        case "Cover":
                            SaveCoverPicture();
                            break;
                    }
                });
            }
        }

        private async void SaveCoverPicture()
        {
            IsLoading = true;
            var imageArray = FromFile.ToArray(file.GetStream());
            file.Dispose();
            var cover = new CoverPict
            {
                CoverPictArray = imageArray
            };

            var result = await ApiService.UpdateCoverPict(cover);
            if (result)
                await Shell.Current.Navigation.PopAsync();
            IsLoading = false;

        }


        private async void SaveProfilePicture()
        {
            IsLoading = true;
            var imageArray = FromFile.ToArray(file.GetStream());
            file.Dispose();
            var picture = new ProfilePict
            {
                ProfilePictArray = imageArray
            };

            var result = await ApiService.UpdateProfilePict(picture);
            if (result)
                await Shell.Current.Navigation.PopAsync();
            IsLoading = false;
        }
    }
}
