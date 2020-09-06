using System;
using System.Collections.Generic;
using quickfitgym.Models;
using quickfitgym.ViewModels;
using Xamarin.Forms;

namespace quickfitgym.Views
{
    public partial class CustomerProfilePage : ContentPage
    {
        public CustomerProfilePage(Customer customer)
        {
            InitializeComponent();
            BindingContext = new CustomerProfileViewModel(customer);
        }
    }
}
