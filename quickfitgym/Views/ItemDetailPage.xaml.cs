using System.ComponentModel;
using Xamarin.Forms;
using quickfitgym.ViewModels;

namespace quickfitgym.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}