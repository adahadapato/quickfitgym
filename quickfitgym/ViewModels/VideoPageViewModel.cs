using System;
using Plugin.Media;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class VideoPageViewModel
    {
        public VideoPageViewModel()
        {
        }

        private async void TakeVideo()
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
            {
               await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
                Name = "video.mp4",
                Directory = "DefaultVideos",
            });

            if (file == null)
                return;

            await Application.Current.MainPage.DisplayAlert("Video Recorded", "Location: " + file.Path, "OK");

            file.Dispose();
        }

        private async void PickVideo()
        {
            if (!CrossMedia.Current.IsPickVideoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Videos Not Supported", ":( Permission not granted to videos.", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickVideoAsync();

            if (file == null)
                return;

            await Application.Current.MainPage.DisplayAlert("Video Selected", "Location: " + file.Path, "OK");
            file.Dispose();
        }
    }
}
