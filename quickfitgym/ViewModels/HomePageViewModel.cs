using System;
using System.Collections.ObjectModel;
using quickfitgym.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class HomePageViewModel:BaseViewModel
    {
        public ObservableCollection<string> GymCollections { get; set; }
        public ObservableCollection<string> ProductsCollection { get; set; }
        public HomePageViewModel()
        {
            GymCollections = new ObservableCollection<string>();
            ProductsCollection = new ObservableCollection<string>();
            //CheckRegistration();
        }
    }
}
