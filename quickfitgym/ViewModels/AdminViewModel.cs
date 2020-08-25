using System;
using System.Collections.ObjectModel;
using quickfitgym.Models;

namespace quickfitgym.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        public ObservableCollection<AdminMenu> MenuCollection { get; private set; }
        public AdminViewModel()
        {
            MenuCollection = new ObservableCollection<AdminMenu>() {

            new AdminMenu(){Title ="Program" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Transatcions" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Transatcions" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Transatcions" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Transatcions" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Transatcions" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Transatcions" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Transatcions" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Transatcions" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Transatcions" ,ImageUrl="xxx"},

            };
        }
    }
}
