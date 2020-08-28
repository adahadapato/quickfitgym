using System;
using System.Collections.Generic;
using quickfitgym.Models;
using quickfitgym.ViewModels;
using Xamarin.Forms;

namespace quickfitgym.Views
{
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        /*private AdminViewModel ViewModel
        {
            get { return BindingContext as AdminViewModel; }
        }*/

        /*protected override void OnAppearing()
        {
            base.OnAppearing();
            //var currentSelection = CvAdmin.SelectedItem as AdminMenu;
            //if (currentSelection == null) return;
            
            //((CollectionView)sender).SelectedItem = null;
            ViewModel.RefreshScrollDown = () => {
                if (ViewModel.SelectedMenu != null)
                {
                    Device.BeginInvokeOnMainThread(() => {
                        CvAdmin.SelectedItem = null;
                    });
                }
            };
        }*/
    }
}
