using System;
using System.Collections.Generic;
using quickfitgym.ViewModels;
using Xamarin.Forms;

namespace quickfitgym.Views
{
    public partial class PicturePage : ContentPage
    {
        public PicturePage(string Picture)
        {
            InitializeComponent();
            BindingContext = new PicturePageViewModel(Picture);
        }
    }
}
