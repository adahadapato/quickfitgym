using System;
using System.Collections.Generic;
using quickfitgym.Models;
using quickfitgym.ViewModels;
using Xamarin.Forms;

namespace quickfitgym.Views
{
    public partial class UpdatePersonalProfilePage : ContentPage
    {
        public UpdatePersonalProfilePage(Customer customer )
        {
            InitializeComponent();
            this.BindingContext = new UpdatePersonalProfileViewModel(customer);
        }
    }
}
